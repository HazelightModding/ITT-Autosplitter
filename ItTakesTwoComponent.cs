using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using LiveSplit.Web.SRL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static LiveSplit.ItTakesTwo.ItTakesTwoStatics;
using System.Diagnostics;
using System.Linq;

namespace LiveSplit.ItTakesTwo {
    public class ItTakesTwoComponent : IComponent {
        public TimerModel Model { get; set; }
        public string ComponentName { get { return "It Takes Two Autosplitter"; } }
        public IDictionary<string, Action> ContextMenuControls { get { return null; } }
        public ItTakesTwoMemory Memory { get; private set; }
        public ItTakesTwoSettings Settings { get; private set; }

        private int currentSplit = -1;
        private HashSet<SplitName> splitsDone = new HashSet<SplitName>();
        private SplitName lastSplitDone;
        public List<string> failedValues = new List<string>();

        private static string LOGFILE = "_ItTakesTwo.log";
        private bool hasLog = false;

        public ItTakesTwoComponent(LiveSplitState state) {
            InitLog();
            Memory = new ItTakesTwoMemory(this);
            Settings = new ItTakesTwoSettings(this);

            if (state == null) {
                return;
            }

            Model = new TimerModel() { CurrentState = state };
            Model.InitializeGameTime();
            Model.CurrentState.IsGameTimePaused = true;
            state.OnReset += OnReset;
            state.OnPause += OnPause;
            state.OnResume += OnResume;
            state.OnStart += OnStart;
            state.OnSplit += OnSplit;
            state.OnUndoSplit += OnUndoSplit;
            state.OnSkipSplit += OnSkipSplit;

            if (state.CurrentTimingMethod == TimingMethod.RealTime) {
                var timingMessage = MessageBox.Show(
                    "It Takes Two uses Time without Loads (Game Time) as the main timing method.\n" +
                    "LiveSplit is currently set to show Real Time (RTA).\n" +
                    "Would you like to set the timing method to Game Time?",
                    "LiveSplit | It Takes Two",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );

                if (timingMessage == DialogResult.Yes) {
                    state.CurrentTimingMethod = TimingMethod.GameTime;
                }
            }
        }

        private void InitLog() {
            hasLog = File.Exists(LOGFILE);
#if DEBUG
            if (!hasLog) {
                File.Create(LOGFILE);
                hasLog = true;
            }
#endif
            if (!hasLog) {
                return;
            }

            // Just making sure it doesn't get SUPER long
            DateTime creationTime = File.GetCreationTime(LOGFILE);
            if ((DateTime.Now - creationTime).TotalDays > 2) {
                File.Delete(LOGFILE);
                File.Create(LOGFILE);
            }
        }

        public void Update(IInvalidator invalidator, LiveSplitState lvstate, float width, float height, LayoutMode mode) {

            if (!Memory.Update()) { return; }
            if (Model == null) { return; }

            Model.CurrentState.IsGameTimePaused = Memory.IsLoadingOrCutscene();

            if (Memory.EnteringLoad()) {
                ShouldReset(Memory.GetCurrentValues());
            }

            if (Memory.HasAnyValueUpdated(out List<SplitName> updatedValues)) {
                ShouldReset(updatedValues);
                ShouldSplit(updatedValues);
                ShouldStart(updatedValues);
            }
        }

        private bool ShouldStart(List<SplitName> updatedValues) {

            if (Model.CurrentState.CurrentPhase == TimerPhase.Running) {
                return false;
            }

            if (currentSplit >= 0) {
                return false;
            }

            bool shouldStart = Settings.StartTrigger != null ? updatedValues.Contains(Settings.StartTrigger.Value) : false;

            if (shouldStart) {
                Model.Start();
            }

            return shouldStart;
        }

        private bool ShouldSplit(List<SplitName> updatedValues) {

            if (Model.CurrentState.CurrentPhase == TimerPhase.NotRunning && Settings.Splits.Count <= 0) {
                return false;
            }

            if (currentSplit < 0) {
                return false;
            }

            bool shouldSplit = false;

            if (!Settings.Ordered) {
                foreach (SplitName Split in Settings.Splits) {
                    if (splitsDone.Contains(Split)) {
                        continue;
                    }

                    if (updatedValues.Contains(Split)) {
                        splitsDone.Add(Split);
                        lastSplitDone = Split;
                        if (hasLog || !Console.IsOutputRedirected) 
                                WriteLogWithTime("Split: " + Split);
                        shouldSplit = true;
                        break;
                    }
                }

            } else if (currentSplit < Settings.Splits.Count) {
                SplitName Split = Settings.Splits[currentSplit];

                if (updatedValues.Contains(Split)) {
                    splitsDone.Add(Split);
                    lastSplitDone = Split;
                    if (hasLog || !Console.IsOutputRedirected) 
                        WriteLogWithTime("Split: " + Split);
                    shouldSplit = true;
                }
            }

            if (shouldSplit) {
                Model.Split();
            }

            return shouldSplit;
        }

        private bool ShouldReset(List<SplitName> values) {
            if (Model.CurrentState.CurrentPhase == TimerPhase.NotRunning && Settings.Splits.Count <= 0) {
                return false;
            }

            if (currentSplit < 0) {
                return false;
            }

            bool shouldReset = Settings.ResetTrigger != null ? values.Contains(Settings.ResetTrigger.Value) : false;

            if (shouldReset) {
                Model.Reset();
            }

            return shouldReset;
        }

        public void OnReset(object sender, TimerPhase e) {
            currentSplit = -1;
            Model.CurrentState.IsGameTimePaused = true;
            splitsDone.Clear();
            if (failedValues.Count > 0) {
                WriteLog("---------Splits without match-------------------");
                foreach (var value in failedValues) {
                    WriteLogWithTime("\"" + value.ToString() + "\" - does not have a defined SplitName value");
                }
                failedValues.Clear();
            }
            int TotalCutscenes = Memory.removedTime.Count;
            if (TotalCutscenes > 0) {
                WriteLog("---------Removed time from cutscenes------------");
                
                TimeSpan TotalRemovedTime = TimeSpan.Zero;
                foreach (var value in Memory.removedTime) {
                    TotalRemovedTime += value;
                    if (value.TotalMilliseconds < 100 && TotalCutscenes > 2) {
                        TotalCutscenes--;
                    }
                }

                WriteLogWithTime("Skippable Cutscenes: " + TotalCutscenes.ToString());
                WriteLogWithTime("Total removed time: " + TotalRemovedTime.ToString("G").Substring(3, 11));
                WriteLogWithTime("Avg time removed per cutscene: " + TimeSpan.FromTicks(TotalRemovedTime.Ticks / TotalCutscenes).ToString("G").Substring(3, 11));

                Memory.removedTime.Clear();
            }
            WriteLog("---------Reset----------------------------------");
        }
        public void OnResume(object sender, EventArgs e) {
            WriteLog("---------Resumed--------------------------------");
        }
        public void OnPause(object sender, EventArgs e) {
            WriteLog("---------Paused---------------------------------");
        }
        public void OnStart(object sender, EventArgs e) {
            currentSplit = 0;
            Model.CurrentState.IsGameTimePaused = true;
            Model.CurrentState.SetGameTime(Model.CurrentState.CurrentTime.RealTime);
            splitsDone.Clear();
            failedValues.Clear();

            WriteLog("---------New Game-------------------------------");
        }
        public void OnUndoSplit(object sender, EventArgs e) {
            currentSplit--;
            //if (!settings.Ordered) splitsDone.Remove(lastSplitDone); Reminder of THIS BREAKS THINGS
        }
        public void OnSkipSplit(object sender, EventArgs e) {
            currentSplit++;
        }
        public void OnSplit(object sender, EventArgs e) {
            currentSplit++;
        }

        

        

        public void WriteLog(string data) {
            if (hasLog || !Console.IsOutputRedirected) {
                if (!Console.IsOutputRedirected) {
                    //Console.WriteLine(currentValues);
                    Console.WriteLine(data);
                }
                if (hasLog) {
                    using (StreamWriter wr = new StreamWriter(LOGFILE, true)) {
                        wr.WriteLine(data);
                    }
                }
            }
        }
        public void WriteLogWithTime(string data) {

            WriteLog(DateTime.Now.ToString(@"HH\:mm\:ss.fff") + (Model != null && Model.CurrentState.CurrentTime.GameTime.HasValue ? " | " + Model.CurrentState.CurrentTime.GameTime.Value.ToString("G").Substring(3, 11) : "") + ": " + data);

        }

        public Control GetSettingsControl(LayoutMode mode) { return Settings; }
        public void SetSettings(XmlNode document) { Settings.SetSettings(document); }
        public XmlNode GetSettings(XmlDocument document) { return Settings.UpdateSettings(document); }
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) { }
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) { }
        public float HorizontalWidth { get { return 0; } }
        public float MinimumHeight { get { return 0; } }
        public float MinimumWidth { get { return 0; } }
        public float PaddingBottom { get { return 0; } }
        public float PaddingLeft { get { return 0; } }
        public float PaddingRight { get { return 0; } }
        public float PaddingTop { get { return 0; } }
        public float VerticalHeight { get { return 0; } }
        public void Dispose() {

            if (Model != null) {
                Model.CurrentState.OnReset -= OnReset;
                Model.CurrentState.OnPause -= OnPause;
                Model.CurrentState.OnResume -= OnResume;
                Model.CurrentState.OnStart -= OnStart;
                Model.CurrentState.OnSplit -= OnSplit;
                Model.CurrentState.OnUndoSplit -= OnUndoSplit;
                Model.CurrentState.OnSkipSplit -= OnSkipSplit;
                Model = null;
            }
        }
    }
}
