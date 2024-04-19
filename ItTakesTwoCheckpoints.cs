using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Options;
using static LiveSplit.ItTakesTwo.ItTakesTwoStatics;

namespace LiveSplit.ItTakesTwo {
    public partial class ItTakesTwoCheckpoints {
        private ItTakesTwoComponent ITT;

        public List<SplitName> Collected = new();
        public int Total = 0;

        public ItTakesTwoCheckpoints(ItTakesTwoComponent mainComp) {
            this.ITT = mainComp;
        }

        public void Reset() {
            Collected.Clear();
            UpdateCounter();
        }

        public void Start() {
            Collected.Clear();
            SetTotalCPs();
            HandleCheckpoint(GetSplitName(ITT.Memory.CurrentSubchapterCheckpoint));
        }

        public void SetTotalCPs() {
            string Chapter = (string)ITT.Memory.Data["Chapter"].Current;
            if (Chapter != "Music" && ITT.Settings.Splits.Contains(SplitName.Start_CS_Music_Attic_Stage_ClimacticKiss))
                Chapter = "FullGame";

            Total = Chapter switch {
                "Shed" => 37,
                "Tree" => 56,
                "PlayRoom" => 75,
                "Clockwork" => 32,
                "SnowGlobe" => 24,
                "Garden" => 55,
                "Music" => 45,
                _ => 324,
            };
        }

        public void UpdateCounter() {
            string counter = Collected.Count.ToString() + "/" + Total.ToString();
            ITT.WriteLogWithTime("Updated CP Counter: " + counter);
            ITT.Settings.SetTextComponent("CP: ", counter);
        }

        public void HandleCheckpoint(SplitName checkpoint) {
            if (IsExcludedCheckpoint(checkpoint))
                return;

            if (Collected.Contains(checkpoint))
                return;

            if (IsDoubleCheckpoint(checkpoint))
                Collected.Add(checkpoint);

            Collected.Add(checkpoint);
            UpdateCounter();
        }
        public bool IsExcludedCheckpoint(SplitName checkpoint) {
            return checkpoint switch {
                SplitName.Main_Main_Menu or
                SplitName.RealWorld_RealWorld_House_Kitchen_Divorce or
                SplitName.Shed_Awakening_Awakening_ChaseFuses or
                SplitName.Shed_Awakening_FusesPutIn or
                SplitName.Shed_Vacuum_Boss_Backpack or
                SplitName.Shed_Vacuum_Piston_Launcher or
                SplitName.Shed_Main_MineHammerMeeting or
                SplitName.Shed_Main_WhackACody or
                SplitName.Shed_Main_MINIGAME_NailWheel or
                SplitName.Shed_Main_MineMachineRoomStarted or
                SplitName.Shed_Main_MainAndToolBoxCutscene or
                SplitName.Shed_Main_GrindSection_Start_PostCutscene or
                SplitName.Shed_Main_GrindSection_GroundPound or
                SplitName.RealWorld_Stargazing_Meet or
                SplitName.Tree_Approach_Tree_Approach_TreeSwing or
                SplitName.Tree_Approach_Tree_Approach_SquirrelHomeEntry or
                SplitName.RealWorld_RealWorld_StudyFriends or
                SplitName.Tree_SquirreTurf_CS_Interrogation or
                SplitName.Tree_SquirrelHome_MINIGAME_TugOfWar or
                SplitName.Tree_WaspNest_MINIGAME_Plunger or
                SplitName.Tree_Escape_House_Reveal or
                SplitName.Tree_Escape_Cutscene_before_glider or
                SplitName.RealWorld_RealWorld_Exterior_Roof_Crash or
                SplitName.PlayRoom_PillowFort_MINIGAME_Hazeboy or
                SplitName.PlayRoom_Spacestation_MINIGAME_LowGravity or
                SplitName.PlayRoom_Spacestation_MINIGAME_LaserTennis or
                SplitName.RealWorld_SpaceStation_BossFight_BeamOut or
                SplitName.PlayRoom_Hopscotch_End_of_Kaleidoscope or
                SplitName.PlayRoom_Hopscotch_Before_Mirror_Puzzle or
                SplitName.PlayRoom_Hopscotch_HomeWork_Pen or
                SplitName.PlayRoom_Hopscotch_MINIGAME_ThrowingHoops or
                SplitName.PlayRoom_Hopscotch_MINIGAME_BaseBall or
                SplitName.PlayRoom_Hopscotch_MINIGAME_Rodeo or
                SplitName.PlayRoom_Hopscotch_SIDECONTENT_PullbackCar or
                SplitName.PlayRoom_Goldberg_LoadDinoLand or
                SplitName.PlayRoom_Goldberg_LoadDInoLandToPirate or
                SplitName.PlayRoom_Goldberg_Dinoland_SlamDinoPt3 or
                SplitName.PlayRoom_Goldberg_Pirate_Part06_BossCutScene or
                SplitName.PlayRoom_Goldberg_Pirate_Part09_BossEndWithoutCutscene or
                SplitName.PlayRoom_Courtyard_MINIGAME_Painting or
                SplitName.PlayRoom_Courtyard_MINIGAME_BirdStar or
                SplitName.PlayRoom_Dungeon_Castle_Dungeon_NoTeleport or
                SplitName.PlayRoom_Chessboard_Castle_Chess_NoTeleport or
                SplitName.RealWorld_RealWorld_RoseTears or
                SplitName.TherapyRoom_TherapyRoom_Time_Session or
                SplitName.Clockwork_Outside_Left_Tower_Puizzle or
                SplitName.Clockwork_Outside_Right_Tower_Puzzle or
                SplitName.Clockwork_Outside_MINIGAME_BombRun or
                SplitName.Clockwork_Outside_MINIGAME_HorseDerby or
                SplitName.Clockwork_LowerTower_Cage_Room or
                SplitName.Clockwork_LowerTower_Mechanical_Wall_Room or
                SplitName.Clockwork_LowerTower_Path_to_Evil_Bird or
                SplitName.Clockwork_UpperTower_Destroy_Crusher_Room or
                SplitName.Clockwork_UpperTower_Ending_Cutscene or
                SplitName.Clockwork_Outside_Clockwork_Ending or
                SplitName.RealWorld_RealWorld_House_LowerLevel_Clock or
                SplitName.TherapyRoom_TherapyRoom_Attraction_Session or
                SplitName.SnowGlobe_Town_MINIGAME_IcicleThrowing or
                SplitName.SnowGlobe_Town_MINIGAME_ShuffleBoard or
                SplitName.SnowGlobe_Town_MINIGAME_SnowballFight or
                SplitName.SnowGlobe_Lake_MINIGAME_IceRace or
                SplitName.RealWorld_RealWorld_House_Kitchen_Sandwiches or
                SplitName.TherapyRoom_TherapyRoom_Garden_Session or
                SplitName.Garden_Shrubbery_Shrubbery_BigLogCollapse or
                SplitName.Garden_Shrubbery_Shrubbery_EnteringBigSpiderCave or
                SplitName.Garden_Shrubbery_Shrubbery_FinalCombatFinished or
                SplitName.Garden_Shrubbery_Shrubbery_SecondCombatFirstWaveFinished or
                SplitName.Garden_Shrubbery_Shrubbery_Outro or
                SplitName.Garden_Shrubbery_MINIGAME_Swings or
                SplitName.Garden_Shrubbery_MINIGAME_Basket or
                SplitName.Garden_FrogPond_Greenhouse_Window_Puzzle or
                SplitName.Garden_FrogPond_Minigame_SnailRace or
                SplitName.RealWorld_RealWorld_FlowerPot or
                SplitName.TherapyRoom_TherapyRoom_Music or
                SplitName.Music_ConcertHall_MINIGAME_Chess or
                SplitName.Music_ConcertHall_MINIGAME_MusicalChairs or
                SplitName.Music_ConcertHall_MINIGAME_SlotCars or
                SplitName.Music_ConcertHall_MINIGAME_TrackRunner or
                SplitName.Music_Backstage_Music_Tech_Wall_EQ_Sweeper or
                SplitName.Music_Backstage_MicrophoneChaseDevDebugFallToGrind or
                SplitName.Music_Backstage_LightRoom_PowerSwitch or
                SplitName.Music_Backstage_MicrophoneChaseDevDebugBreamCrush or
                SplitName.Music_Backstage_Chase_Landing or
                SplitName.Music_Backstage_Truss_Room_no_SubBassRoom or
                SplitName.Music_Classic_MINIGAME_VolleyBall or
                SplitName.Music_Ending_CodyBeforeFlipSwitch or
                SplitName.Music_Ending_MayBeforeCurtains or
                SplitName.RealWorld_RealWorld_WakeUp or
                SplitName.Credits_CreditIntro => true,
                _ => false,
            };
        }

        public bool IsDoubleCheckpoint(SplitName checkpoint) {
            return checkpoint switch {
                SplitName.Shed_Main_GrindSection_Start or
                SplitName.PlayRoom_Hopscotch_Intro or
                SplitName.PlayRoom_Goldberg_Pirate_Part09_BossEnd or
                SplitName.Clockwork_Outside_Tower_Courtyard or
                SplitName.Clockwork_LowerTower_Statue_Room_Both_Side_Rooms_Completed or
                SplitName.Clockwork_UpperTower_Boss_Intro => true,
                _ => false,
            };
        }
    }
}
