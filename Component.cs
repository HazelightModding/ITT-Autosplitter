using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using static LiveSplit.ItTakesTwo.Statics;
using static LiveSplit.ItTakesTwo.Splits;
using System.Diagnostics;

namespace LiveSplit.ItTakesTwo
{
    public struct CurrentRunInformation()
    {
        public TimerModel Model { get; set; }
        public int split = -1;
        public HashSet<ITTSplit> splitsDone = new();
        public ITTSplit lastSplitDone;

    }
    public class Component : IComponent
    {
        public string ComponentName => "It Takes Two Autosplitter";
        public IDictionary<string, Action> ContextMenuControls => null;
        public Logger Log { get; private set; }
        public Memory Memory { get; private set; }
        public Settings Settings { get; private set; }

        public CurrentRunInformation CurrentRun;

        

        public static Component Instance { get; private set; }

        public static ref CurrentRunInformation GetCurrentRun()
        {
            return ref Instance.CurrentRun;
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Component(LiveSplitState state)
        {
            Instance = this;
            Logger.InitLog(this);
            Log = Logger.GetLogger("Component");
            Memory = GetMemory();
            Settings = GetSplitSettings();

            if (state == null)
            {
                return;
            }

            CheckTimingMethod(state);
            CurrentRun.Model = new TimerModel() { CurrentState = state };
            CurrentRun.Model.InitializeGameTime();
            CurrentRun.Model.CurrentState.IsGameTimePaused = true;
            state.OnReset += OnReset;
            state.OnPause += OnPause;
            state.OnResume += OnResume;
            state.OnStart += OnStart;
            state.OnSplit += OnSplit;
            state.OnUndoSplit += OnUndoSplit;
            state.OnSkipSplit += OnSkipSplit;

            CurrentRun.split = -1;
            CurrentRun.splitsDone = new();

#if DEBUG
            AllocConsole();
#endif

        }

        private static void CheckTimingMethod(LiveSplitState state)
        {
            if (state.CurrentTimingMethod == TimingMethod.GameTime)
            {
                return;
            }

            var timingMessage = MessageBox.Show(
                "It Takes Two uses Time without Loads (Game Time) as the main timing method.\n" +
                "LiveSplit is currently set to show Real Time (RTA).\n" +
                "Would you like to set the timing method to Game Time?",
                "LiveSplit | It Takes Two",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (timingMessage == DialogResult.Yes)
            {
                state.CurrentTimingMethod = TimingMethod.GameTime;
            }
        }

        public void Update(IInvalidator invalidator, LiveSplitState lvstate, float width, float height, LayoutMode mode)
        {
            try
            {
                if (!Memory.Update()) { return; }
                if (CurrentRun.Model == null) { return; }

                CurrentRun.Model.CurrentState.IsGameTimePaused = GetData().IsLoadingOrCutscene();

                if (CurrentRun.split >= 0)
                {
                    if (GetData().ShouldReset(ref CurrentRun))
                        CurrentRun.Model.Reset();

                    if (GetData().ShouldSplit(ref CurrentRun))
                        CurrentRun.Model.Split();
                }
                if (CurrentRun.split < 0 && GetData().ShouldStart(ref CurrentRun))
                {
                    CurrentRun.Model.Start();
                }
            }
            catch (Exception e)
            {
                Log.Error("!!!! UNHANDLED ERROR IN UPDATE !!!!");
                Log.Error(e.ToString());
                Log.Error("Please report this stack trace to the dev.");
            }

        }

        public void OnReset(object sender, TimerPhase e)
        {
            var state = sender as LiveSplitState;
            var lastRun = state.Run.AttemptHistory.LastOrDefault();
            CurrentRun.split = -1;
            CurrentRun.Model.CurrentState.IsGameTimePaused = true;
            CurrentRun.splitsDone.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Log.Header(LogLevel.INFO, "Reset");

            string[] resetLines = {
                "Run Reset! Here's some stats: ",
               $"Started: {lastRun.Started?.Time.ToString()}",
               $"Ended: {lastRun.Ended?.Time.ToString()}",
                "",
               $"This run had {GetData().SkippableCutsceneCount} skippable cutscenes, with an average of {GetData().AvgCutsceneLength.ToString(@"ss\s\ fff\m\s")} per cutscene. ",
                "" ,
            };

            Log.Info("\n" + FormatAsBox(resetLines));

            if (ITTSplit.FailedSplits.Count > 0)
            {
                Log.Header(LogLevel.INFO, "Splits without match");
                foreach (var value in ITTSplit.FailedSplits)
                {
                    Log.Info("\"" + value.ToString() + "\" - does not have a defined SplitName value");
                }
                ITTSplit.FailedSplits.Clear();
            }



            GetData().Reset();

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private string FormatAsBox(string[] lines)
        {
            int maxWidth = lines.Max(line => line.Length);
            string border = new('*', maxWidth + 4);
            string body = string.Empty;

            foreach (var line in lines)
            {
                body += $"* {line.PadRight(maxWidth)} *\n";
            }

            return border + "\n" + body + border;
        }
        public void OnStart(object sender, EventArgs e)
        {
            var state = sender as LiveSplitState;
            CurrentRun.split = 0;
            CurrentRun.Model.CurrentState.IsGameTimePaused = true;
            CurrentRun.Model.CurrentState.SetGameTime(CurrentRun.Model.CurrentState.CurrentTime.RealTime);
            CurrentRun.splitsDone.Clear();
            ITTSplit.FailedSplits.Clear();
            Log.Header(LogLevel.INFO, $"Started run #{state.Run.AttemptCount}. Good luck!");
        }
        public void OnResume(object sender, EventArgs e) => Log.Header(LogLevel.INFO, "Resumed Timer");
        public void OnPause(object sender, EventArgs e) => Log.Header(LogLevel.INFO, "Paused Timer");
        public void OnUndoSplit(object sender, EventArgs e)
        {
            CurrentRun.split--;
            CurrentRun.splitsDone.Remove(CurrentRun.lastSplitDone);
            CurrentRun.lastSplitDone = CurrentRun.splitsDone.Last();
        }
        public void OnSkipSplit(object sender, EventArgs e) => CurrentRun.split++;
        public void OnSplit(object sender, EventArgs e) => CurrentRun.split++;







        public Control GetSettingsControl(LayoutMode mode) => Settings;
        public void SetSettings(XmlNode document) => Settings.SetSettings(document);
        public XmlNode GetSettings(XmlDocument document) => Settings.UpdateSettings(document);
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) { }
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) { }
        public float HorizontalWidth => 0;
        public float MinimumHeight => 0;
        public float MinimumWidth => 0;
        public float PaddingBottom => 0;
        public float PaddingLeft => 0;
        public float PaddingRight => 0;
        public float PaddingTop => 0;
        public float VerticalHeight => 0;
        public void Dispose()
        {
            if (CurrentRun.Model == null) return;

            CurrentRun.Model.CurrentState.OnReset -= OnReset;
            CurrentRun.Model.CurrentState.OnPause -= OnPause;
            CurrentRun.Model.CurrentState.OnResume -= OnResume;
            CurrentRun.Model.CurrentState.OnStart -= OnStart;
            CurrentRun.Model.CurrentState.OnSplit -= OnSplit;
            CurrentRun.Model.CurrentState.OnUndoSplit -= OnUndoSplit;
            CurrentRun.Model.CurrentState.OnSkipSplit -= OnSkipSplit;
            CurrentRun.Model = null;
        }
    }
}
