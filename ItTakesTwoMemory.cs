using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using LiveSplit.ComponentUtil;
using static LiveSplit.ItTakesTwo.ItTakesTwoStatics;

namespace LiveSplit.ItTakesTwo {
    public partial class ItTakesTwoMemory {
        private ItTakesTwoComponent ITT;
        public Process Game { get; set; }
        public bool IsHooked { get; set; }

        public Thread ScanThread;
        public MemoryWatcherList Data;
        public MemoryWatcherList[] Players = new MemoryWatcherList[2];
        DeepPointer CutsceneDP, CodyCutsceneDP;
        public string CurrentCutscene, OldCutscene, CodyCurrentCutscene, CodyOldCutscene;
        public IntPtr FNamePool;

        private Stopwatch stopwatch;
        private const int maxTime = 5000;
        public List<TimeSpan> removedTime = new List<TimeSpan>();

        private Dictionary<int, string> FNameCache = new();


        public ItTakesTwoMemory(ItTakesTwoComponent mainComp) {
            this.ITT = mainComp;
            stopwatch = new Stopwatch();
        }

        private void WriteLog(string log) {
            ITT.WriteLog("[MEMORY] " +  log);
        }

        public string FNameToString(int comparisonIndex) {
            if (FNamePool == IntPtr.Zero) {
                return null;
            }

            if (FNameCache.TryGetValue(comparisonIndex, out string cachedStr)) {
                return cachedStr;
            }

            var blockIndex = comparisonIndex >> 16;
            var blockOffset = 2 * (comparisonIndex & 0xFFFF);
            var headerPtr = new DeepPointer(FNamePool + blockIndex * 8, blockOffset);

            byte[] headerBytes = null;
            if (headerPtr.DerefBytes(Game, 2, out headerBytes)) {
                bool isWide = (headerBytes[0] & 0x01) != 0;
                int length = (headerBytes[1] << 2) | ((headerBytes[0] & 0xC0) >> 6);

                IntPtr headerRawPtr;
                if (headerPtr.DerefOffsets(Game, out headerRawPtr)) {
                    var stringPtr = new DeepPointer(headerRawPtr + 2);
                    ReadStringType stringType = isWide ? ReadStringType.UTF16 : ReadStringType.ASCII;
                    int numBytes = length * (isWide ? 2 : 1);

                    string str;
                    if (stringPtr.DerefString(Game, stringType, numBytes, out str)) {
                        FNameCache[comparisonIndex] = str;
                        return str;
                    }
                }
            }

            return null;
        }

        public bool Update() {
            IsHooked = Game != null && !Game.HasExited;

            if (!IsHooked)
                IsHooked = Hook();
            if (!IsHooked)
                return false;

            if (ScanThread.IsAlive)
                return false;

            Data.UpdateAll(Game);
            Players[0].UpdateAll(Game);
            Players[1].UpdateAll(Game);

            CutsceneDP.DerefString(Game, 200, out string mayStr);
            OldCutscene = CurrentCutscene;
            CurrentCutscene = mayStr;
            CodyCutsceneDP.DerefString(Game, 200, out string codyStr);
            CodyOldCutscene = CodyCurrentCutscene;
            CodyCurrentCutscene = codyStr;

            /*int size;
            if (May["Capabilities Size"].Changed && (size = (int)May["Capabilities Size"].Current) > 1) {
                WriteLog("Printing May capabilities...");

                for (int i = 0x0; i < size - 1; i++) {
                    var capabilityNameDP = new DeepPointer((IntPtr)May["Capabilities"].Current + i * 0x8, 0x18);
                    capabilityNameDP.DerefOffsets(Game, out var ptr);
                    //int capabilityNameFName = capabilityNameDP.Deref<int>(Game);
                    int capabilityNameFName = Game.ReadValue<int>(ptr);
                    WriteLog("[" + i + "] " + capabilityNameFName + ": " + GetObjectNameFromFName(capabilityNameFName) + "(" + ptr.ToString("X") + ")");
                }
            }*/

            return true;
        }

        public bool IsLoadingOrCutscene() {
            return IsLoading() | IsSkippableCutscene();
        }

        public bool IsLoading() {

            return (bool)Data["bIsInLoadingScreen"].Current || Data["Level"].Current.ToString() == "/Game/Maps/Main/Menu_BP";
        }

        private List<string> exceptionCutscenes = new List<string>() {
            "CS_Tree_WaspQueenBoss_Arena_Defeated",
            "CS_Tree_Escape_Chase_Outro",
            "CS_Tree_Escape_Plane_Combat", // Only skippable by Cody, capability blocked for May
		    "CS_Tree_Escape_NoseDive_Intro", // Extremely short skippable window
		    "CS_PlayRoom_Bookshelf_Elephant_Outro", // Skippable is "EntireSequence" but cutscene is too short to be skipped
            "CS_Garden_Shrubbery_Shrubbery_Intro"
        };

        public bool CSRemover = false;

        public bool IsSkippableCutscene() {
            if (!CSRemover) return false;
            EHazeSkippableSetting maySkippable = (EHazeSkippableSetting)Players[0]["SkippableSetting"].Current;
            EHazeSkippableSetting codySkippable = (EHazeSkippableSetting)Players[1]["SkippableSetting"].Current;
            EHazeSkippableSetting Skippable = maySkippable == codySkippable ? maySkippable : EHazeSkippableSetting.None;
            if (Skippable == EHazeSkippableSetting.None || CurrentCutscene != OldCutscene) {
                if (stopwatch.ElapsedMilliseconds > 0) {
                    removedTime.Add(stopwatch.Elapsed);
                    ITT.WriteLogWithTime("Removed time: " + stopwatch.Elapsed.ToString("G").Substring(3, 11));
                }
                stopwatch.Reset();
                return false;
            }

            if (exceptionCutscenes.Contains(CurrentCutscene)) {
                return false;
            }

            if (stopwatch.ElapsedMilliseconds < maxTime) {
                if (!stopwatch.IsRunning) {
                    stopwatch.Start();
                }
                return true;
            }

            stopwatch.Stop();
            return false;
        }

        public bool Hook() {

            // Think this should work just fine for the trial version too? For reference it's "ItTakesTwo_Trial"
            Process[] processes = Process.GetProcessesByName("ItTakesTwo");
            Game = processes != null && processes.Length > 0 ? processes[0] : null;
            if (Game == null || Game.HasExited) {
                return false;
            }
            WriteLog("Hooked to process: " +  Game.ProcessName);

            try {
                SetPointersBySigscan();
                return true;
            } catch (Win32Exception ex) {
                WriteLog(ex.ErrorCode.ToString());
                return false;
            }

        }

        private void SetPointersBySigscan() {
            CancellationTokenSource CancelSource = new CancellationTokenSource();
            ScanThread = new Thread(() => {
                WriteLog("Starting scan thread");
                // Not an elegant solution lmao, but it's not able to find anything if it connects just as the game starts.
                // Find better way, bc this is not reliable. Works for now though.
                Thread.Sleep(3000);

                var gWorld = IntPtr.Zero;
                var gWorldSig = new SigScanTarget(10, "80 7C 24 ?? 00 ?? ?? 48 8B 3D ???????? 48")
                { OnFound = (p, s, ptr) => ptr + 0x4 + p.ReadValue<int>(ptr) };

                var scanner = new SignatureScanner(Game, Game.MainModule.BaseAddress, (int)Game.MainModule.ModuleMemorySize);
                var token = CancelSource.Token;
                WriteLog("Scanning process: " + scanner.Process);

                while (!token.IsCancellationRequested) {
                    if (gWorld == IntPtr.Zero && (gWorld = scanner.Scan(gWorldSig)) != IntPtr.Zero) {
                        WriteLog("Found GWorld at 0x" + gWorld.ToString("X") + ".");

                        Data = new MemoryWatcherList
                        {
                            new MemoryWatcher<bool>(new DeepPointer(gWorld, 0x180, 0x2b0, 0x0, 0x458, 0xf9)) { Name = "bIsInLoadingScreen"},
                            new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1b8, 0x0), 255) { Name = "Level" },
                            new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1d8, 0x0), 255) { Name = "Checkpoint" },
                            new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1e8, 0x0), 255) { Name = "Chapter" },
                            new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1f8, 0x0), 255) { Name = "Subchapter" },
                        };

                        for (int i = 0; i < 2; i++) {
                            int playerOffset = i == 0 ? 0x0 : 0x8;

                            Players[i] = new MemoryWatcherList {
                                new MemoryWatcher<int>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x390, 0x318)) { Name = "SkippableSetting" , FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull},
                                new MemoryWatcher<int>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x478, 0x2A8, 0x18)) { Name = "RespawnPoint", FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull},
                                new MemoryWatcher<bool>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x470, 0x128)) { Name = "bIsDead"},
                                //new StringWatcher(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x390, 0x2a0, 0x788, 0x0), 255) { Name = "Cutscene", FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull },

                                new MemoryWatcher<IntPtr>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x370, 0x2c8)) { Name = "Capabilities"},
                                new MemoryWatcher<int>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x370, 0x2c8 + 0x8)) { Name = "Capabilities Size"},
                            };
                        }

                        // Keep getting null exceptions when using a memory watcher, so handling it manually since I want to know when it's null. (aka no cutscenes playing)
                        CutsceneDP = new DeepPointer(gWorld, 0x180, 0x2b0, 0x0, 0x390, 0x2a0, 0x788, 0x0);
                        CurrentCutscene = "";
                        CodyCutsceneDP = new DeepPointer(gWorld, 0x180, 0x2b0, 0x8, 0x390, 0x2a0, 0x788, 0x0);
                        CodyCurrentCutscene = "";

                        break;
                    }

                    WriteLog("GWorld not found, sleeping...");
                    Thread.Sleep(2000);
                }

                // Should find sigscan instead but game is unlikely to be updated any time soon if at all so it's fine?
                FNamePool = Game.MainModule.BaseAddress + 0x76BE9D0;
                if (FNamePool != IntPtr.Zero)
                    WriteLog("Found FNamePool at 0x" + FNamePool.ToString("X") + ".");


                WriteLog("Exiting scan thread.");
            });

            ScanThread.Start();
        }

        public bool EnteringLoad() {
            return (bool)Data["bIsInLoadingScreen"].Current && !(bool)Data["bIsInLoadingScreen"].Old;
        }

        public List<SplitName> GetCurrentValues() {
            var currentValues = new List<SplitName>();
            SplitName value;

            var currentData = new string[] {
                GetObjectNameFromObjectPath(Data["Level"].Current.ToString(), '/'),
                Data["Subchapter"].Current.ToString() + "_" + MakeEnumFriendlyString(Data["Checkpoint"].Current.ToString()),
                Data["Subchapter"].Current.ToString(),
                "IGNORE_THIS_FOR_NOW_" + CurrentCutscene,
                "IGNORE_THIS_FOR_NOW_" + CodyCurrentCutscene
            };

            foreach (var item in currentData) {
                if (item == null || item == "")
                    continue;
                if (SplitName.TryParse(item, true, out value)) {
                    currentValues.Add(value);
                } else if (!ITT.failedValues.Contains(item)) {
                    ITT.failedValues.Add(item);
                }
            }

            return currentValues;
        }

        public bool HasAnyValueUpdated(out List<SplitName> updatedValues) {
            updatedValues = new List<SplitName>();
            List<string> splitData = new List<string>();

            if (Data["Chapter"].Changed) {
                string currentChapter = Data["Chapter"].Current.ToString();
                string oldChapter = Data["Chapter"].Old.ToString();
                splitData.Add(currentChapter);
                ITT.WriteLogWithTime("Chapter changed: ".PadRight(22, ' ') + "\"" + oldChapter + "\" -> \"" + currentChapter + "\"");
            }
            if (Data["Subchapter"].Changed) {
                string currentSubchapter = Data["Subchapter"].Current.ToString();
                string oldSubchapter = Data["Subchapter"].Old.ToString();
                splitData.Add(currentSubchapter);
                ITT.WriteLogWithTime("Subchapter changed: ".PadRight(22, ' ') + "\"" + oldSubchapter + "\" -> \"" + currentSubchapter + "\"");
            }
            if (Data["Level"].Changed) {
                string newLvl = GetObjectNameFromObjectPath(Data["Level"].Current.ToString(), '/');
                string oldLvl = GetObjectNameFromObjectPath(Data["Level"].Old.ToString(), '/');
                splitData.Add(newLvl);
                ITT.WriteLogWithTime("Level changed: ".PadRight(22, ' ') + "\"" + oldLvl + "\" -> \"" + newLvl + "\"");
            }
            if (Data["Checkpoint"].Changed) {
                string subchapterCheckpoint = Data["Subchapter"].Current.ToString() + "_" + MakeEnumFriendlyString(Data["Checkpoint"].Current.ToString());
                string subchapterCheckpointOld = Data["Subchapter"].Old.ToString() + "_" + MakeEnumFriendlyString(Data["Checkpoint"].Old.ToString());
                splitData.Add(subchapterCheckpoint);
                ITT.WriteLogWithTime("Checkpoint changed: ".PadRight(22, ' ') + "\"" + subchapterCheckpointOld + "\"  ->  \"" + subchapterCheckpoint + "\"");
            }
            if (OldCutscene != CurrentCutscene) {
                if (CurrentCutscene == null) {
                    splitData.Add("End_" + OldCutscene);
                    ITT.WriteLogWithTime("Cutscene Ended: ".PadRight(22, ' ') + "\"" + OldCutscene + "\"");
                } else {
                    splitData.Add("Start_" + CurrentCutscene);
                    ITT.WriteLogWithTime("Cutscene Started: ".PadRight(22, ' ') + "\"" + CurrentCutscene + "\"");
                }
            }
            if (CodyOldCutscene != CodyCurrentCutscene) {
                if (CodyCurrentCutscene == null && CodyOldCutscene != OldCutscene) {
                    splitData.Add("End_" + CodyOldCutscene);
                    ITT.WriteLogWithTime("Cody Cutscene Ended: ".PadRight(22, ' ') + "\"" + CodyOldCutscene + "\"");
                } else if (CodyCurrentCutscene != CurrentCutscene) {
                    splitData.Add("Start_" + CodyCurrentCutscene);
                    ITT.WriteLogWithTime("Cody Cutscene Started: ".PadRight(22, ' ') + "\"" + CodyCurrentCutscene + "\"");
                }
            }

            for (int i = 0; i < 2; i++) {
                string name = i == 0 ? "May" : "Cody";
                MemoryWatcher playerValue;

                playerValue = Players[i]["RespawnPoint"];
                if (playerValue.Changed) {
                    string respawnName = GetObjectNameFromFName((int)playerValue.Current);
                    //splitData.Add(respawnName);
                    ITT.WriteLogWithTime(name + " Respawn Point: \"" + respawnName + "\"");
                }

                playerValue = Players[i]["bIsDead"];
                if (playerValue.Changed && (bool)playerValue.Current) {
                    updatedValues.Add(i == 0 ? SplitName.MayIsDead : SplitName.CodyIsDead);
                    updatedValues.Add(SplitName.AnyDead);
                    ITT.WriteLogWithTime(name + " died.");
                }

                /*playerValue = Players[i]["Cutscene"];
                if (playerValue.Changed) {
                    bool started = playerValue.Current != null;
                    string cutscene = started ? playerValue.Current.ToString() : playerValue.Old.ToString();

                    var enumName = (started ? "Start_" : "End_") + cutscene;
                    if (!splitData.Contains(enumName))
                        splitData.Add(enumName);

                    ITT.WriteLogWithTime(name + " Cutscene " + (started ? "Started: " : "Ended: ").PadRight(22, ' ') + "\"" + cutscene + "\"");


                }*/

                playerValue = Players[i]["SkippableSetting"];
                if (playerValue.Changed) {
                    ITT.WriteLogWithTime(name + " Skippable: [" + (int)playerValue.Current + "] " + ((EHazeSkippableSetting)playerValue.Current).ToString());
                }
            }

            if (splitData.Count <= 0 && updatedValues.Count <= 0) {
                return false;
            }

            // Convert to enum and add to list
            foreach (string item in splitData) {
                SplitName value;
                if (SplitName.TryParse(item, true, out value)) {
                    updatedValues.Add(value);
                } else if (!ITT.failedValues.Contains(item)) {
                    ITT.failedValues.Add(item);
                }
            }

            return true;
        }

        private string GetObjectNameFromObjectPath(string objectPath, char index = '.') {
            if (objectPath == null) { return null; }

            int lastDotIndex = objectPath.LastIndexOf(index);
            if (lastDotIndex == -1) {
                return objectPath;
            }

            return objectPath.Substring(lastDotIndex + 1);
        }

        private string GetObjectNameFromFName(int comparisonIndex) {
            return GetObjectNameFromObjectPath(FNameToString(comparisonIndex));
        }

        private string MakeEnumFriendlyString(string input) {
            if (string.IsNullOrEmpty(input))
                return null;

            string output = input;
            var charsToRemove = new string[] { "(", ")", "/", "." };
            var charsToReplace = new string[] { " ", "-" };

            foreach (var c in charsToRemove) {
                output = output.Replace(c, string.Empty);
            }

            foreach (var c in charsToReplace) {
                output = output.Replace(c, "_");
            }

            output = Regex.Replace(output, "_+", "_");

            return output;
        }

        public void Dispose() {
            if (Game != null) {
                Game.Dispose();
            }
        }
    }
}