using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static LiveSplit.ComponentUtil.MemoryWatcherList;
using static LiveSplit.ItTakesTwo.Data;
using static LiveSplit.ItTakesTwo.Splits;
using static LiveSplit.ItTakesTwo.Statics;
using static LiveSplit.ItTakesTwo.Types;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LiveSplit.ItTakesTwo
{

    [Flags]
    public enum LoadingScreenState
    {
        None,
        Entering,
        Leaving,
        True,
        False
    }
    public partial class Data
    {
        public struct player
        {
            private MemoryWatcherList _player;

            public string Name;

            public MemoryWatcher this[string name] => _player[name];

            public MemoryWatcher<EHazeSkippableSetting> SkippableSetting => (MemoryWatcher<EHazeSkippableSetting>)_player["SkippableSetting"];
            public MemoryWatcher<FName> RespawnPoint => (MemoryWatcher<FName>)_player["RespawnPoint"];
            public MemoryWatcher<bool> bIsDead => (MemoryWatcher<bool>)_player["bIsDead"];

            public MemoryWatcher<FName> Cutscene => (MemoryWatcher<FName>)_player["Cutscene"];

            public player(int playerOffset, MemoryWatcherList playerList, Logger Log)
            {
                Name = playerOffset == 0x0 ? "May" : "Cody";
                _player = playerList;
            }

            public void UpdateAll(Process Game)
            {
                _player.UpdateAll(Game);
            }

            public bool Changed
            {
                get
                {
                    foreach (var w in _player) 
                    { 
                        if (w.Changed) return true;
                    }
                    return false;
                }
            }

        }

        public struct players
        {
            private player[] _players = new player[2];
            private Logger log;

            public player this[int id] => _players[id];

            public bool IsCutsceneIdentical() => _players[0].Cutscene.Current == _players[1].Cutscene.Current;
            public bool IsAnyDead() => _players[0].bIsDead.Current || _players[1].bIsDead.Current;

            public EHazeSkippableSetting SkippableSetting
            {
                get
                {
                    if (_players[0].SkippableSetting.Current == _players[1].SkippableSetting.Current)
                        return _players[0].SkippableSetting.Current;
                    return EHazeSkippableSetting.None;

                }
            }

            public FName Cutscene
            {
                get
                {
                    if (IsCutsceneIdentical())
                        return _players[0].Cutscene.Current;
                    return FName.None;

                }
            }

            public players(player[] players, Logger log)
            {
                _players = players;
                this.log = log;
            }

            public void UpdateAll(Process Game)
            {
                _players[0].UpdateAll(Game);
                _players[1].UpdateAll(Game);
            }

            public bool Changed => _players[0].Changed || _players[1].Changed;
        }

        private MemoryWatcherList _global;

        public MemoryWatcher this[string name] => _global[name];

        public MemoryWatcher<bool> bIsInLoadingScreen => (MemoryWatcher<bool>)_global["bIsInLoadingScreen"];
        public StringWatcher Level          => (StringWatcher)_global["Level"];
        public StringWatcher Checkpoint     => (StringWatcher)_global["Checkpoint"];
        public StringWatcher Chapter        => (StringWatcher)_global["Chapter"];
        public StringWatcher Subchapter     => (StringWatcher)_global["Subchapter"];

        public string SubchapterCheckpoint_Current => Subchapter.Current + "_" + Checkpoint.Current;
        public string SubchapterCheckpoint_Old => Subchapter.Old + "_" + Checkpoint.Old;

        public players Players;
        public player May => Players[0];
        public player Cody => Players[1];

        private Logger Log = Logger.GetLogger("Data");

        public bool Changed = false;

        public bool IsLoadingOrCutscene() => IsLoading() | IsSkippableCutscene();
        public bool IsLoading() => bIsInLoadingScreen.Current || Level.Current == "/Game/Maps/Main/Menu_BP";

        public bool EnteringLoadingScreen => bIsInLoadingScreen.Current && !bIsInLoadingScreen.Old;

        public bool LeavingLoadingScreen => !bIsInLoadingScreen.Current && bIsInLoadingScreen.Old;


        public Data(IntPtr gWorld)
        {
            AddMemoryWatcherLists(gWorld);
        }

        private void AddMemoryWatcherLists(IntPtr gWorld)
        {
            _global = [
                new MemoryWatcher<bool>(new DeepPointer(gWorld, 0x180, 0x2b0, 0x0, 0x458, 0xf9)) { Name = "bIsInLoadingScreen", Current = true },
                new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1b8, 0x0), 255) { Name = "Level" },
                new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1d8, 0x0), 255) { Name = "Checkpoint" },
                new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1e8, 0x0), 255) { Name = "Chapter" },
                new StringWatcher(new DeepPointer(gWorld, 0x180, 0x368, 0x8, 0x1f8, 0x0), 255) { Name = "Subchapter" },
            ];

            player[] players = new player[2];

            for (int i = 0; i < 2; i++)
            {
                int playerOffset = i == 0x0 ? i : 0x8;

                players[i] = new(playerOffset, [
                    new MemoryWatcher<EHazeSkippableSetting>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x390, 0x318)) { Name = "SkippableSetting", FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull },
                    new MemoryWatcher<FName>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x478, 0x2A8, 0x18)) { Name = "RespawnPoint", FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull },
                    new MemoryWatcher<bool>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x470, 0x128)) { Name = "bIsDead" },
                    new MemoryWatcher<FName>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x390, 0x2a0, 0x508, 0x18)) { Name = "Cutscene", FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull },
                    //new MemoryWatcher<IntPtr>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x370, 0x2c8)) { Name = "Capabilities"},
                    //new MemoryWatcher<int>(new DeepPointer(gWorld, 0x180, 0x2b0, playerOffset, 0x370, 0x2c8 + 0x8)) { Name = "Capabilities Size"},
                ], Log);
            }
            Players = new players(players, Log);
        }



        [Flags]
        public enum CutsceneState
        {
            Inactive,
            Active,
            Entering,
            Leaving
        }

        private void OnDataChanged(MemoryWatcher inWatcher, string playerName = null, LogLevel logLevel = LogLevel.INFO)
        {

            Changed = true;
            var watcherName = string.IsNullOrEmpty(playerName) ? inWatcher.Name : $"{playerName} {inWatcher.Name}";

            Log.LogWithFormat(logLevel, "\"{0}\" changed: Old: \"{1}\" -> New: \"{2}\"", watcherName, inWatcher.Old.ToString(), inWatcher.Current.ToString());

            ChangedWatchers.Add(inWatcher);
        }

        private List<MemoryWatcher> ChangedWatchers = new();
        private ITTSplitList ChangedSplits = new();
        private Dictionary<string, ITTSplit> CurrentSplits = new();

        public LoadingScreenState LoadingScreen = LoadingScreenState.None;
        public bool WasEnteringLoadingScreen = false;

        public void UpdateAll(Process Game)
        {
            Changed = false;
            ChangedSplits.Clear();

            _global.UpdateAll(Game);
            Players.UpdateAll(Game);

            HandleChangedValues();
        }

        public bool ShouldStart(ref CurrentRunInformation CurrentRun)
        {
            if (CurrentRun.Model.CurrentState.CurrentPhase == TimerPhase.Running)
            {
                return false;
            }

            List<ITTSplit> possibleSplits = new();
            try
            {
                if (EnteringLoadingScreen)
                {
                    possibleSplits.AddRange(GetCurrentSplits());
                }
                else if (TryGetChangedSplits(out var changedSplits))
                {
                    possibleSplits.AddRange(changedSplits);
                }

                if (possibleSplits.Count <= 0)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Log.Debug("Exception in ShouldStart:");
                Log.Debug(e.ToString());
            }

            bool enteringCutscene = possibleSplits.Contains(SplitInfo["EnteringCutscene"]);
            bool leavingCutscene = possibleSplits.Contains(SplitInfo["LeavingCutscene"]);

            var startTrigger = GetSplitSettings().StartTrigger;
            var matchedSplit = possibleSplits.FirstOrDefault(split => split.ID == startTrigger?.ID);

            bool shouldStart = false;

            if (matchedSplit != null)
            {
                if (startTrigger.Type == SplitType.Cutscene)
                {
                    shouldStart = (startTrigger.SplitAtStart && enteringCutscene) ||
                                  (!startTrigger.SplitAtStart && leavingCutscene);
                }
                else
                {
                    shouldStart = true;
                }
            }

            if (shouldStart)
            {
                Log.Debug($"EnteringCutscene: {enteringCutscene}, LeavingCutscene: {leavingCutscene}");
                Log.Debug($"StartTrigger ID: {startTrigger?.ID}, SplitAtStart: {startTrigger?.SplitAtStart}");
                Log.Debug("PossibleSplits: " + string.Join(", ", possibleSplits.Select(s => s.ID)));
                Log.Info("Start caused by: \"" + GetSplitSettings().StartTrigger.ID + "\"" + (GetSplitSettings().StartTrigger.Type == SplitType.Cutscene ? " Split at start = " + GetSplitSettings().StartTrigger.SplitAtStart : ""));
            }

            return shouldStart;
        }

        public bool ShouldReset(ref CurrentRunInformation CurrentRun)
        {
            if (CurrentRun.Model.CurrentState.CurrentPhase == TimerPhase.NotRunning &&
                GetSplitSettings().Splits.Count <= 0)
            {
                return false;
            }

            List<ITTSplit> possibleSplits = new();

            if (EnteringLoadingScreen)
            {
                possibleSplits.AddRange(GetCurrentSplits());
            }
            else if (TryGetChangedSplits(out var changedSplits))
            {
                possibleSplits.AddRange(changedSplits);
            }

            if (possibleSplits.Count <= 0)
            {
                return false;
            }

            bool enteringCutscene = possibleSplits.Contains(SplitInfo["EnteringCutscene"]);
            bool leavingCutscene = possibleSplits.Contains(SplitInfo["LeavingCutscene"]);

            var resetTrigger = GetSplitSettings().ResetTrigger;
            var matchedSplit = possibleSplits.FirstOrDefault(split => split.ID == resetTrigger?.ID);

            bool shouldReset = false;

            if (matchedSplit != null)
            {
                if (resetTrigger.Type == SplitType.Cutscene)
                {
                    shouldReset = (resetTrigger.SplitAtStart && enteringCutscene) ||
                                  (!resetTrigger.SplitAtStart && leavingCutscene);
                }
                else
                {
                    shouldReset = true;
                }
            }

            if (shouldReset)
            {
                Log.Debug($"EnteringCutscene: {enteringCutscene}, LeavingCutscene: {leavingCutscene}");
                Log.Debug($"ResetTrigger ID: {resetTrigger?.ID}, SplitAtStart: {resetTrigger?.SplitAtStart}");
                Log.Debug("PossibleSplits: " + string.Join(", ", possibleSplits.Select(s => s.ID)));
                Log.Info("Reset caused by: \"" + resetTrigger.ID + "\"" +
                         (resetTrigger.Type == SplitType.Cutscene
                             ? " Split at start = " + resetTrigger.SplitAtStart
                             : ""));
            }

            return shouldReset;
        }

        public bool ShouldSplit(ref CurrentRunInformation CurrentRun)
        {
            LiveSplitState State = CurrentRun.Model.CurrentState;
            if (State.CurrentPhase == TimerPhase.NotRunning && GetSplitSettings().Splits.Count <= 0)
            {
                return false;
            }

            List<ITTSplit> possibleSplits = new();
            if (TryGetChangedSplits(out var changedSplits))
            {
                possibleSplits.AddRange(changedSplits);
            }
            else
            {
                return false;
            }

            Log.Debug("Split Possible Splits: ");
            foreach (var possibleSplit in possibleSplits)
            {
                Log.Debug(possibleSplit.Name + " (" + possibleSplit.ID + "): " + possibleSplit.SplitAtStart);
            }
            bool shouldSplit = false;

            if (!GetSplitSettings().Ordered)
            {
                foreach (ITTSplit Split in GetSplitSettings().Splits)
                {
                    if (CurrentRun.splitsDone.Contains(Split))
                    {
                        continue;
                    }

                    shouldSplit = IsSplitMatch(possibleSplits, Split, ref CurrentRun);
                    
                    if (shouldSplit) { Log.Debug("Should Split " + Split.Name + " (" + Split.ID + ", " + Split.SplitAtStart + "): " + shouldSplit); break; }
                }

            }
            else if (CurrentRun.split < GetSplitSettings().Splits.Count)
            {
                ITTSplit Split = GetSplitSettings().Splits[CurrentRun.split];
                shouldSplit = IsSplitMatch(possibleSplits, Split, ref CurrentRun);
                Log.Debug("Should Split " + Split.Name + ": " + shouldSplit);
            }

            return shouldSplit;
        }

        private bool IsSplitMatch(List<ITTSplit> possibleSplits, ITTSplit split, ref CurrentRunInformation CurrentRun)
        {
            bool isMatch = false;
            if (possibleSplits.Any(s => s.ID == split.ID))
            {
                isMatch = true;

                if (split.Type == SplitType.Cutscene)
                {
                    //Log.Debug("Cutscene: " + split.Name + "(" + split.ID + ")");

                    isMatch = (split.SplitAtStart && possibleSplits.Contains(SplitInfo["EnteringCutscene"]))
                        || (!split.SplitAtStart && possibleSplits.Contains(SplitInfo["LeavingCutscene"]));
                }
                Log.Info("Split Matched: " + split.Name + "(" + split.ID + ")");
                CurrentRun.splitsDone.Add(split);
                CurrentRun.lastSplitDone = split;
            }

            
            return isMatch;
        }

        private void HandleChangedValues()
        {
            if (bIsInLoadingScreen.Changed)
            {
                OnDataChanged(bIsInLoadingScreen, null, LogLevel.DEBUG);

                Log.Debug($"bIsInLoadingScreen Changed. Old: {bIsInLoadingScreen.Old}, Current: {bIsInLoadingScreen.Current}");

            }

            if (Level.Changed)
            {
                OnDataChanged(Level);

                var currentLevel = Level.Current.ToObjectName('/');
                if (ITTSplit.TryGet(currentLevel, out var lvl))
                    ChangedSplits.Add(lvl);
            }

            if (Chapter.Changed)
            {
                OnDataChanged(Chapter);
            }

            if (Checkpoint.Changed || Subchapter.Changed)
            {
                if (Checkpoint.Changed)
                    OnDataChanged(Checkpoint);

                if (Subchapter.Changed)
                {
                    OnDataChanged(Subchapter);

                    if (ITTSplit.TryGet(Subchapter.Current, out var sub))
                        ChangedSplits.Add(sub);


                }

                if (ITTSplit.TryGet(SubchapterCheckpoint_Current, out var split))
                    ChangedSplits.Add(split);

            }

            for (int i = 0; i < 2; i++)
            {
                var player = Players[i];

                if (player.SkippableSetting.Changed)
                {
                    OnDataChanged(player.SkippableSetting, player.Name);
                }

                if (player.RespawnPoint.Changed)
                {
                    OnDataChanged(player.RespawnPoint, player.Name, LogLevel.DEBUG);

                    string respawnName = Level.Current.ToObjectName('/') + "_" + player.RespawnPoint.Current.ToObjectName();
                    Log.Info("{0} Respawn Point: \"{1}\"", player.Name, respawnName);

                    if (ITTSplit.TryGet(respawnName, out var split))
                    {
                        ChangedSplits.Add(split);
                        ChangedSplits.Add(SplitInfo["AnyRespawnPoint"]);
                    }


                }

                if (player.bIsDead.Changed)
                {
                    OnDataChanged(player.bIsDead, player.Name);

                    if (player.bIsDead.Current && ITTSplit.TryGet(player.Name + "_bIsDead", out var split))
                    {
                        ChangedSplits.Add(split);
                        ChangedSplits.Add(SplitInfo["AnyDead"]);
                    }
                }

                if (player.Cutscene.Changed)
                {
                    OnDataChanged(player.Cutscene, player.Name);

                    if (player.Cutscene.Current != FName.None && player.Cutscene.Old != player.Cutscene.Current)
                    {
                        ChangedSplits.Add(SplitInfo["EnteringCutscene"]);
                        if (ITTSplit.TryGet(player.Cutscene.Current.ToString(), out var cs))
                        {
                            ChangedSplits.Add(cs);
                        }
                    }

                    if (player.Cutscene.Old != FName.None && player.Cutscene.Current != player.Cutscene.Old)
                    {
                        ChangedSplits.Add(SplitInfo["LeavingCutscene"]);
                        if (ITTSplit.TryGet(player.Cutscene.Old.ToString(), out var cs))
                        {
                            ChangedSplits.Add(cs);
                        }
                    }
                }
            }
        }

        

        

        public bool TryGetChangedSplits(out ITTSplitList splitList)
        {
            splitList = null;
            if (!Changed) 
                return false;

            return (splitList = ChangedSplits).Count > 0;
        }

        public ITTSplitList GetChangedSplits()
        {
            return ChangedSplits;
        }

        public ITTSplitList GetCurrentSplits() 
        {
            ITTSplitList splitList = new();
            var currentData = new List<string> {
                Level.Current.ToObjectName('/'),
                SubchapterCheckpoint_Current,
                Subchapter.Current,
            };

            for (int i = 0; i < 2; i++)
            {
                currentData.AddRange([
                    Players[i].Cutscene.Current,
                    Level.Current.ToObjectName('/') + "_" + Players[i].RespawnPoint.Current.ToObjectName(),
                ]);

                if (Players[i].bIsDead.Current) 
                    currentData.Add(Players[i].Name + "_bIsDead");
            }

            foreach (var item in currentData)
            {
                if (ITTSplit.TryGet(item, out var split))
                {
                    splitList.Add(split);
                }
            }

            return splitList;
        }



    }

    

}
