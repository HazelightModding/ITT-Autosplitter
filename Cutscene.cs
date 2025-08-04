using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveSplit.ItTakesTwo.Splits;
using static LiveSplit.ItTakesTwo.Types;

namespace LiveSplit.ItTakesTwo
{
    public partial class Data
    {
        public TimeSpan RealTime => Component.Instance.CurrentRun.Model.CurrentState.CurrentTime.RealTime ?? TimeSpan.Zero;

        private readonly List<string> InvalidCutscenes = 
        [
            "CS_Tree_WaspQueenBoss_Arena_Defeated",
            "CS_Tree_Escape_Chase_Outro",
            "CS_Tree_Escape_Plane_Combat",          // Only skippable by Cody, capability blocked for May
		    "CS_Tree_Escape_NoseDive_Intro",        // Extremely short skippable window
		    "CS_PlayRoom_Bookshelf_Elephant_Outro", // Skippable is "EntireSequence" but cutscene is too short to be skipped
            "CS_Garden_Shrubbery_Shrubbery_Intro"
        ];

        public TimeSpan CutsceneTimes = TimeSpan.Zero;

        public int SkippableCutsceneCount = 0;
        public TimeSpan AvgCutsceneLength
        {
            get
            {
                if (SkippableCutsceneCount <= 0)
                    return TimeSpan.Zero;

                if (CutsceneTimes == TimeSpan.Zero) 
                    return TimeSpan.Zero;

                return TimeSpan.FromTicks(CutsceneTimes.Ticks / SkippableCutsceneCount);
            }
        }

        private TimeSpan CutsceneStartTimestamp = TimeSpan.Zero;
        private TimeSpan ElapsedCSTime = TimeSpan.Zero;
        private bool FreshCutscene = false;

        // Remove up to 5 seconds of skippable cutscenes to balance out ping differences
        public bool IsSkippableCutscene()
        {
            var enterCutscene = (May.Cutscene.Changed && May.Cutscene.Current != FName.None) ||
                                (Cody.Cutscene.Changed && Cody.Cutscene.Current != FName.None);

            var leaveCutscene = (bIsInLoadingScreen.Changed && bIsInLoadingScreen.Current) ||
                                (May.Cutscene.Changed && May.Cutscene.Old != FName.None) ||
                                (Cody.Cutscene.Changed && Cody.Cutscene.Old != FName.None);

            var isSkippable = Players.SkippableSetting != EHazeSkippableSetting.None && 
                              !InvalidCutscenes.Contains(Players.Cutscene);

            var enterSkippableCutscene = enterCutscene && isSkippable;

            ElapsedCSTime = RealTime - CutsceneStartTimestamp;

            if (FreshCutscene)
            {
                if (leaveCutscene || ElapsedCSTime >= TimeSpan.FromSeconds(5))
                {
                    FreshCutscene = false;
                    CutsceneTimes += ElapsedCSTime;
                    if (ElapsedCSTime >= TimeSpan.FromMilliseconds(100))
                    {
                        SkippableCutsceneCount++;
                    }
                    Log.Info("Removed time: " + ElapsedCSTime.ToString(@"ss\.fff"));
                }
                
            }

            if (enterSkippableCutscene)
            {
                FreshCutscene = true;
                ElapsedCSTime = TimeSpan.Zero;
                CutsceneStartTimestamp = RealTime;
            }

            return FreshCutscene;
        }

        public void Reset()
        {
            FreshCutscene = false;
            ElapsedCSTime = TimeSpan.Zero;
            CutsceneStartTimestamp = TimeSpan.Zero;
            SkippableCutsceneCount = 0;
            CutsceneTimes = TimeSpan.Zero;
        }

    }
}
