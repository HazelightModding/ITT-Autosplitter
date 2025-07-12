using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveSplit.ItTakesTwo.Statics;

namespace LiveSplit.ItTakesTwo;

public class Splits
{
    public enum SplitType
    {
        
        None,
        Chapter,
        Level,
        Checkpoint,
        Cutscene,
        Death,
        Minigame,
        Misc
    }

    public enum CheckpointType
    {
        None,
        Dev,
        Excluded,
        Double
    }

    public class ITTSplit
    {
        /// <summary>
        /// The in-game identifier for this split
        /// </summary>
        public string ID { get; private set; }
        /// <summary>
        /// Readable name for this split
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// What type of split this is
        /// </summary>
        public SplitType Type { get; set; }
        public string Subchapter { get; set; }
        public string Info { get; set; }
        private string tooltip;
        public string Tooltip
        {
            get
            {
                if (tooltip == null)
                {
                    switch (Type)
                    {
                        case SplitType.Chapter:
                        case SplitType.Level:
                        tooltip = string.Format("Splits on transition to {0}.", Name);
                        break;
                        case SplitType.Checkpoint:
                        tooltip = string.Format("Splits when obtaining the \"{0}\" checkpoint in {1}.", Name, Subchapter);
                        break;
                        case SplitType.Cutscene:
                        string startend = SplitAtStart ? "start" : "end";
                        tooltip = string.Format("Splits at the {0} of the \"{1}\" cutscene in {2}.", startend, Name, Subchapter);
                        break;
                        case SplitType.Minigame:
                        tooltip = string.Format("Splits when teleporting to the \"{0}\" minigame.", Name);
                        break;
                        default:
                        tooltip = "Tooltip is not defined.";
                        break;
                    }
                }
                return tooltip + (Info != null ? "\n" + Info : "");
            }
            set { tooltip = value; }
        }
        public bool SplitAtStart { get; set; }
        public CheckpointType CheckpointType { get; set; }

        public ITTSplit(string id)
        {
            ID = id;
            Name = ID;
            Type = SplitType.None;
            Subchapter = "NOT DEFINED";
            SplitAtStart = true;
            CheckpointType = CheckpointType.None;
        }

        public ITTSplit(ITTSplit split)
        {
            ID = split.ID;
            Name = split.Name;
            Type = split.Type;
            Subchapter = split.Subchapter;
            Info = split.Info;
            SplitAtStart = split.SplitAtStart;
            CheckpointType = split.CheckpointType;
            Tooltip = split.Tooltip;
        }

        public static implicit operator ITTSplit(string nameID) => Get(nameID);

        public static ITTSplit Get(string nameID)
        {
            if (nameID == string.Empty) return null;

            try
            {
                return new(SplitInfo[nameID]);
            }
            catch (Exception)
            {
                if (nameID == string.Empty || nameID.ToLower() == "none")
                    return null;

                Logger.GetLogger("Split").Warning("\"{0}\" isn't a recognized split.", nameID);
                FailedSplits.Add(nameID); 
                return null;
            }
        }

        public static bool TryGet(string nameID, out ITTSplit split)
        {
            split = ITTSplit.Get(nameID);
            return split != null;
        }


        public string GetNameWithTag()
        {
            return Name + " (" + (CheckpointType == CheckpointType.Dev ? "Dev " : "") + Type.ToString() + ")";
        }

        

        public static HashSet<string> FailedSplits = new HashSet<string>();
    }
    public class ITTSplitList : List<ITTSplit>
    {

        public ITTSplit this[string id] => this.FirstOrDefault((ITTSplit s) => s.ID == id);

        public ITTSplit GetSplit(string text)
        {
            return this.FirstOrDefault((ITTSplit s) => s.ID.Equals(text, StringComparison.OrdinalIgnoreCase)
                || s.GetNameWithTag().Equals(text, StringComparison.OrdinalIgnoreCase));
        }

        public bool TryGetSplit(string text, out ITTSplit split)
        {
            split = GetSplit(text);
            if (split == null) return false;
            return true;
        }

    }

    private readonly struct Chapter
    {

        public const string Intro = "Intro";
        public const string WakeUpCall = "Wake-Up Call";
        public const string BitingTheDust = "Biting the Dust";
        public const string TheDepths = "The Depths";
        public const string WiredUp = "Wired Up";
        public const string FreshAir = "Fresh Air";
        public const string SquirrelTurf = "Squirrel Turf";
        public const string Captured = "Captured";
        public const string DeeplyRooted = "Deeply Rooted";
        public const string Boat = "Boat";
        public const string Darkroom = "Darkroom";
        public const string Extermination = "Extermination";
        public const string Getaway = "Getaway";
        public const string PillowFort = "Pillow Fort";
        public const string SpacedOut = "Spaced Out";
        public const string Hopscotch = "Hopscotch";
        public const string Goldberg = "Goldberg";
        public const string TrainStation = "Train Station";
        public const string DinoLand = "Dino land";
        public const string PiratesAhoy = "Pirates Ahoy";
        public const string TheGreatestShow = "The Greatest Show";
        public const string OnceUponATime = "Once Upon a Time";
        public const string DungeonCrawler = "Dungeon Crawler";
        public const string Chessboard = "Chessboard";
        public const string TheQueen = "The Queen";
        public const string GatesOfTime = "Gates of Time";
        public const string Clockworks = "Clockworks";
        public const string ABlastFromThePast = "A Blast from the Past";
        public const string WarmingUp = "Warming Up";
        public const string WinterVillage = "Winter Village";
        public const string BeneathTheIce = "Beneath the Ice";
        public const string SlipperySlopes = "Slippery Slopes";
        public const string SnowGlobeTower = "Tower";
        public const string GreenFingers = "Green Fingers";
        public const string WeedWhacking = "Weed Whacking";
        public const string Trespassing = "Trespassing";
        public const string FrogPond = "Frog Pond";
        public const string Affliction = "Affliction";
        public const string SettingTheStage = "Setting the Stage";
        public const string Rehearsal = "Rehearsal";
        public const string Symphony = "Symphony";
        public const string TurnUp = "Turn Up";
        public const string AGrandFinale = "A Grand Finale";

        public const string Basement = "Basement";
        // Don't think the ones below should be used, better to go for the level specific ones
        public const string RealWorld = "Real World";
        public const string TherapyRoom = "Therapy Room";
        public const string MainMenu = "Main Menu";
    }

    public static readonly ITTSplitList SplitInfo = new() {
        #region LEVELS
            new ITTSplit("Menu_BP") {
                Name = Chapter.MainMenu,
                Type = SplitType.Level
            },
            new ITTSplit("Awakening_BP") {
                Name = Chapter.WakeUpCall,
                Type = SplitType.Level
            },
            new ITTSplit("Vacuum_BP") {
                Name = Chapter.BitingTheDust,
                Type = SplitType.Level
            },
            new ITTSplit("Main_Hammernails_BP") {
                Name = Chapter.TheDepths,
                Type = SplitType.Level
            },
            new ITTSplit("Main_Bossfight_BP") {
                Name = "Depths Bossfight",
                Type = SplitType.Level
            },
            new ITTSplit("Main_Grindsection_BP") {
                Name = Chapter.WiredUp,
                Type = SplitType.Level
            },
            new ITTSplit("RealWorld_Shed_StarGazing_Meet_BP") {
                Name = "Intermediary 1",
                Type = SplitType.Level
            },
            new ITTSplit("Approach_BP") {
                Name = Chapter.FreshAir,
                Type = SplitType.Level
            },
            new ITTSplit("RealWorld_House_Study_Friends_BP") {
                Name = "House Study Friends Cutscene",
                Type = SplitType.Level
            },
            new ITTSplit("SquirrelTurf_WarRoom_BP") {
                Name = "War Room Cutscene",
                Type = SplitType.Level
            },
            new ITTSplit("SquirrelHome_BP_Mech") {
                Name = Chapter.Captured,
                Type = SplitType.Level
            },
            new ITTSplit("WaspsNest_BP") {
                Name = Chapter.DeeplyRooted,
                Type = SplitType.Level
            },
            new ITTSplit("Tree_Boat_BP") {
                Name = Chapter.Boat,
                Type = SplitType.Level
            },
            new ITTSplit("Tree_Darkroom_BP") {
                Name = Chapter.Darkroom,
                Type = SplitType.Level
            },
            new ITTSplit("WaspsNest_Elevator_BP") {
                Name = "Deeply Rooted Elevator",
                Type = SplitType.Level
            },
            new ITTSplit("WaspsNest_Beetle_BP") {
                Name = "Beetle",
                Type = SplitType.Level
            },
            new ITTSplit("WaspsNest_BeetleRide_BP") {
                Name = "Beetle Ride",
                Type = SplitType.Level
            },
            new ITTSplit("WaspQueenBoss_BP") {
                Name = Chapter.Extermination,
                Type = SplitType.Level
            },
            new ITTSplit("SquirrelTurf_Flight_BP") {
                Name = "Flight Cutscene",
                Type = SplitType.Level
            },
            new ITTSplit("Escape_BP") {
                Name = Chapter.Getaway,
                Type = SplitType.Level
            },
            new ITTSplit("RealWorld_Exterior_Roof_Crash_BP") {
                Name = "Intermediary 2",
                Type = SplitType.Level
            },
            new ITTSplit("PillowFort_BP") {
                Name = Chapter.PillowFort,
                Type = SplitType.Level
            },
            new ITTSplit("Spacestation_Hub_BP") {
                Name = Chapter.SpacedOut,
                Type = SplitType.Level
            },
            new ITTSplit("SpaceStation_MoonBaboon_BP") {
                Name = "Moon Baboon",
                Type = SplitType.Level
            },
            new ITTSplit("Realworld_SpaceStation_Bossfight_BeamOut_BP") {
                Name = "Beam Out Cutscene",
                Type = SplitType.Level
            },
            new ITTSplit("Hopscotch_BP") {
                Name = Chapter.Hopscotch,
                Type = SplitType.Level
            },
            new ITTSplit("Hopscotch_Homework_BP") {
                Name = "Homework",
                Type = SplitType.Level
            },
            new ITTSplit("Hopscotch_Dungeon_BP") {
                Name = "Hopscotch Dungeon",
                Type = SplitType.Level
            },
            new ITTSplit("VoidWorld_BP") {
                Name = "Void World",
                Type = SplitType.Level
            },
            new ITTSplit("Kaleidoscope_BP") {
                Name = "Kaleidoscope",
                Type = SplitType.Level
            },
            new ITTSplit("Goldberg_Trainstation_BP") {
                Name = Chapter.TrainStation,
                Type = SplitType.Level
            },
            new ITTSplit("Goldberg_Dinoland_BP") {
                Name = Chapter.DinoLand,
                Type = SplitType.Level
            },
            new ITTSplit("Goldberg_Pirate_BP") {
                Name = Chapter.PiratesAhoy,
                Type = SplitType.Level
            },
            new ITTSplit("Goldberg_Circus_BP") {
                Name = Chapter.TheGreatestShow,
                Type = SplitType.Level
            },
            new ITTSplit("Castle_Courtyard_BP") {
                Name = Chapter.OnceUponATime,
                Type = SplitType.Level
            },
            new ITTSplit("Castle_Dungeon_BP") {
                Name = Chapter.DungeonCrawler,
                Type = SplitType.Level
            },
            new ITTSplit("Castle_Dungeon_Crusher_BP") {
                Name = "Dungeon Crusher",
                Type = SplitType.Level
            },
            new ITTSplit("Castle_Dungeon_Charger_BP") {
                Name = "Dungeon Charger",
                Type = SplitType.Level
            },
            new ITTSplit("Castle_Chessboard_BP") {
                Name = "Dungeon Chess",
                Type = SplitType.Level
            },
            new ITTSplit("Shelf_BP") {
                Name = Chapter.TheQueen,
                Type = SplitType.Level
            },
            new ITTSplit("RealWorld_RoseRoom_Bed_Tears_BP") {
                Name = "Intermediary 3",
                Type = SplitType.Level
            },
            new ITTSplit("TherapyRoom_Session_Theme_Time_BP") {
                Name = "Therapy Room Time",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_Tutorial_BP") {
                Name = Chapter.GatesOfTime,
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTown_BP") {
                Name = "Clock Town",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_Forest_BP") {
                Name = "Clock Forest",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerLower_CrushingTrapRoom_BP") {
                Name = Chapter.Clockworks,
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerLower_BridgeIntro_BP") {
                Name = "Clockworks Bridge",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerLower_BP") {
                Name = "Clockworks Statue Room",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerMiniBossRoom_BP") {
                Name = "Clockworks Bull Boss",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerLower_WallJumpCorridor_BP") {
                Name = "Clockworks Wall Jump Corridor",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerLower_CuckooBirdRoom_BP") {
                Name = "Clockworks Pocket Watch Room",
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerLastBoss_BP") {
                Name = Chapter.ABlastFromThePast,
                Type = SplitType.Level
            },
            new ITTSplit("Clockwork_ClockTowerCourtyardCutscene_BP") {
                Name = "Clock Ending Cutscene",
                Type = SplitType.Level
            },
            new ITTSplit("RealWorld_House_LowerLevel_Clock_BP") {
                Name = "Realworld Clock Cutscene",
                Type = SplitType.Level
            },
            new ITTSplit("TherapyRoom_Session_Theme_Attraction_BP") {
                Name = "Therapy Room Attraction",
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Forest_BP") {
                Name = Chapter.WarmingUp,
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Forest_TownGate_BP") {
                Name = "Forest Town Gate",
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Town_BP") {
                Name = Chapter.WinterVillage,
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Town_BobSled") {
                Name = "Bobsled",
                Type = SplitType.Level
            },
            new ITTSplit("Snowglobe_Lake_BP") {
                Name = Chapter.BeneathTheIce,
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Lake_IceCave_BP") {
                Name = "Ice Cave",
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Mountain_BP") {
                Name = Chapter.SlipperySlopes,
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Mountain_Cave_BP") {
                Name = "Slippery Caves",
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Mountain_Collapse_BP") {
                Name = "Slippery Collapse",
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Mountain_PlayerAttraction_BP") {
                Name = "Slippery Attraction",
                Type = SplitType.Level
            },
            new ITTSplit("SnowGlobe_Mountain_WindWalk_BP") {
                Name = "Slippery Wind Walk",
                Type = SplitType.Level
            },
            new ITTSplit("Tower_BP") {
                Name = "Tower Cutscene",
                Type = SplitType.Level
            },
            new ITTSplit("RealWorld_House_Kitchen_Sandwiches_BP") {
                Name = "Real World Kitchen Sandwiches",
                Type = SplitType.Level
            },
            new ITTSplit("TherapyRoom_Session_Theme_Garden_BP") {
                Name = "Therapy Room Garden",
                Type = SplitType.Level
            },
            new ITTSplit("Garden_VegetablePatch_BP") {
                Name = Chapter.GreenFingers,
                Type = SplitType.Level
            },
            new ITTSplit("Garden_Shrubbery_BP") {
                Name = Chapter.WeedWhacking,
                Type = SplitType.Level
            },
            new ITTSplit("Garden_Shrubbery_SecondCombat_BP") {
                Name = "Weed Whacking Second Combat",
                Type = SplitType.Level
            },
            new ITTSplit("Garden_MoleTunnels_Stealth_BP") {
                Name = Chapter.Trespassing,
                Type = SplitType.Level
            },
            new ITTSplit("Garden_MoleTunnels_Chase_BP") {
                Name = "Trespassing Chase",
                Type = SplitType.Level
            },
            new ITTSplit("Garden_FrogPond_BP") {
                Name = Chapter.FrogPond,
                Type = SplitType.Level
            },
            new ITTSplit("Garden_FrogPond_FountainPuzzle_BP") {
                Name = "Frog Pond Fountain Puzzle",
                Type = SplitType.Level
            },
            new ITTSplit("Garden_Greenhouse_BP") {
                Name = Chapter.Affliction,
                Type = SplitType.Level
            },
            new ITTSplit("Garden_Greenhouse_JoysRoom_BP") {
                Name = "Affliction Joys Room",
                Type = SplitType.Level
            },
            new ITTSplit("RealWorld_RoseRoom_FlowerPot_BP") {
                Name = "Real World Flower Pot",
                Type = SplitType.Level
            },
            new ITTSplit("TherapyRoom_Session_Theme_Music_BP") {
                Name = "Therapy Room Music",
                Type = SplitType.Level
            },
            new ITTSplit("Music_ConcertHall_BP") {
                Name = Chapter.SettingTheStage,
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_Tutorial_BP") {
                Name = Chapter.Rehearsal,
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_PortableSpeakerRoom_BP") {
                Name = "Rehearsal Portable Speaker Room",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_SubBassRoom_BP") {
                Name = "Rehearsal Sub Bass Room",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_TrussRoom_BP") {
                Name = "Rehearsal Truss Room",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_MusicTechWall_BP") {
                Name = "Rehearsal Music Tech Wall",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_MurderMicrophoneRoom_BP") {
                Name = "Rehearsal Murder Microphone Room",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_MicrophoneChase_BP") {
                Name = "Rehearsal Microphone Chase",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_DrumMachineRoom_BP") {
                Name = "Rehearsal Drum Machine Room",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Backstage_LightRoom_BP") {
                Name = "Rehearsal Light Room",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Classic_Organ_BP") {
                Name = Chapter.Symphony,
                Type = SplitType.Level
            },
            new ITTSplit("Music_Classic_Ending_BP") {
                Name = "Symphony Ending",
                Type = SplitType.Level
            },
            new ITTSplit("Music_Nightclub_BP") {
                Name = Chapter.TurnUp,
                Type = SplitType.Level
            },
            new ITTSplit("Music_Ending_BP") {
                Name = Chapter.AGrandFinale,
                Type = SplitType.Level
            },
            new ITTSplit("TherapyRoom_Session_Theme_Love_BP") {
                Name = "Therapy Room Basement",
                Type = SplitType.Level
            },
            new ITTSplit("Basement_Seekers_BP") {
                Name = "Basement Seekers",
                Type = SplitType.Level
            },
            new ITTSplit("Basement_HouseInterior_BP") {
                Name = "Basement House Interior",
                Type = SplitType.Level
            },
            new ITTSplit("Basement_Boss_BP") {
                Name = "Basement Boss",
                Type = SplitType.Level
            },
            #endregion
        #region CHECKPOINTS
        #region Intro
            new ITTSplit("RealWorld_RealWorld_House_Kitchen_Divorce") {
                Name = "RealWorld House Kitchen Divorce",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Intro,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Wake-up Call
            new ITTSplit("Shed_Awakening_Awakening_Start") {
                Name = "Awakening_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WakeUpCall
            },
            new ITTSplit("Shed_Awakening_Awakening_FirstGameplay") {
                Name = "Awakening_FirstGameplay",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WakeUpCall
            },
            new ITTSplit("Shed_Awakening_Awakening_ChaseFuses") { // Awakening_ChaseFuses // Not actually "obtained" as in you can't RCP from it but can still split on it
                Name = "Awakening_ChaseFuses",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WakeUpCall,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Shed_Awakening_FusesPutIn") {
                Name = "FusesPutIn",
                Type = SplitType.Checkpoint,
                Tooltip = "Splits when putting in the last fuse in " + Chapter.WakeUpCall,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Biting the Dust
            new ITTSplit("Shed_Vacuum_VacuumIntro") {
                Name = "Vacuum Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_VacuumNoIntro") {
                Name = "VacuumNoIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Oil Pit") {
                Name = "Oil Pit",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Behind Boss") {
                Name = "Behind Boss",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Generator") {
                Name = "Generator",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Side Scroller") {
                Name = "Side Scroller",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Stomach") {
                Name = "Stomach",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Portal Loop") {
                Name = "Portal Loop",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Boss_Backpack") {
                Name = "Boss Backpack",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Shed_Vacuum_Weather Vane") {
                Name = "Weather Vane",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_Piston_Launcher") {
                Name = "Piston Launcher",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Shed_Vacuum_Weight Bowl") {
                Name = "Weight Bowl",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_VacuumBoss") {
                Name = "Vacuum Boss",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("Shed_Vacuum_BossNoIntro") {
                Name = "Boss No Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BitingTheDust
            },
        #endregion
        #region The Depths
            new ITTSplit("Shed_Main_MineIntro") {
                Name = "MineIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MineIntroNoCutscene") {
                Name = "MineIntroNoCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MineHammerMeeting") {
                Name = "MineHammerMeeting",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Shed_Main_TutorialPuzzle1") {
                Name = "TutorialPuzzle1",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_TutorialPuzzle2") {
                Name = "TutorialPuzzle2",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MineMainHub") {
                Name = "MineMainHub",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_WhackACody Machine Room Intro") {
                Name = "WhackACody Machine Room Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MachineIntroPuzzle1") {
                Name = "MachineIntroPuzzle1",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MineMachineRoom") {
                Name = "MineMachineRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MineMachineRoomStarted") {
                Name = "MineMachineRoomStarted",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Shed_Main_MineMachineRoomHalfway") {
                Name = "MineMachineRoomHalfway",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MachineRoomChickenRace") {
                Name = "MachineRoomChickenRace",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MachineRoomEnding") {
                Name = "MachineRoomEnding",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_Pre Boss Double Interact") {
                Name = "Pre Boss Double Interact",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MainAndToolBoxCutscene") {
                Name = "MainAndToolBoxCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Shed_Main_ToolBoxBossIntro") {
                Name = "ToolBoxBossIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_ToolBoxBossHalfWay") {
                Name = "ToolBoxBossHalfWay",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MainBossFightStarted") {
                Name = "MainBossFightStarted",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MainBossFightPhase1") {
                Name = "MainBossFightPhase1",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_MainBossFightPhase2") {
                Name = "MainBossFightPhase2",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("Shed_Main_ToolBoxBossDefeat") {
                Name = "ToolBoxBossDefeat",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheDepths
            },
        #endregion
        #region Wired Up
            new ITTSplit("Shed_Main_GrindSection_Start") {
                Name = "GrindSection_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WiredUp,
                CheckpointType = CheckpointType.Double
            },
            new ITTSplit("Shed_Main_GrindSection_Start_PostCutscene") {
                Name = "GrindSection_Start_PostCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WiredUp,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Shed_Main_GrindSection_SwapTracks") {
                Name = "GrindSection_SwapTracks",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WiredUp
            },
            new ITTSplit("Shed_Main_GrindSection_ConnectCables") {
                Name = "GrindSection_ConnectCables",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WiredUp
            },
            new ITTSplit("Shed_Main_GrindSection_PostFan") {
                Name = "GrindSection_PostFan",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WiredUp
            },
            new ITTSplit("Shed_Main_GrindSection_GroundPound") {
                Name = "GrindSection_GroundPound",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WiredUp,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("RealWorld_Stargazing_Meet") {
                Name = "Stargazing_Meet",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WiredUp,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Fresh Air
            new ITTSplit("Tree_Approach_Tree_Approach_LevelIntro") {
                Name = "Tree_Approach_LevelIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FreshAir
            },
            new ITTSplit("Tree_Approach_Tree_Approach_LevelStart") {
                Name = "Tree_Approach_LevelStart",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FreshAir
            },
            new ITTSplit("Tree_Approach_Tree_Approach_TreeSwing") {
                Name = "Tree_Approach_TreeSwing",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FreshAir,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Tree_Approach_Tree_Approach_SquirrelHomeEntry") {
                Name = "Tree_Approach_SquirrelHomeEntry",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FreshAir,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("RealWorld_RealWorld_StudyFriends") {
                Name = "RealWorld_StudyFriends",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FreshAir,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Tree_SquirreTurf_CS_Interrogation") {
                Name = "CS_Interrogation",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FreshAir,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Captured
            new ITTSplit("Tree_SquirrelHome_Entry") {
                Name = "Entry",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Entry (No cutscene)") {
                Name = "Entry (No cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Elevator") {
                Name = "Elevator",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Bridge") {
                Name = "Bridge",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_HangingStuff") {
                Name = "HangingStuff",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_BigWheels") {
                Name = "BigWheels",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Lift") {
                Name = "Lift",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_First Contact") {
                Name = "First Contact",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Ovens") {
                Name = "Ovens",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Crossing") {
                Name = "Crossing",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Rails") {
                Name = "Rails",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Vault") {
                Name = "Vault",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
            new ITTSplit("Tree_SquirrelHome_Vault ShieldWasp") {
                Name = "Vault ShieldWasp",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Captured
            },
        #endregion
        #region Deeply Rooted
            new ITTSplit("Tree_WaspNest_Entry") {
                Name = "Entry",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Entry (No cutscene)") {
                Name = "Entry (No cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Larva") {
                Name = "Larva",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Bottles") {
                Name = "Bottles",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Swarm") {
                Name = "Swarm",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Slide") {
                Name = "Slide",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_SlidePart1") {
                Name = "SlidePart1",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_SlidePart2") {
                Name = "SlidePart2",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_SlidePart3") {
                Name = "SlidePart3",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Boat_Boat (Cutscene)") {
                Name = "Boat (Cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Boat_Boat (No cutscene)") {
                Name = "Boat (No cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Boat_Boat Checkpoint Calm") {
                Name = "Boat Checkpoint Calm",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Boat_Boat Checkpoint Swarm") {
                Name = "Boat Checkpoint Swarm",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Darkroom_DarkRoom (Cutscene)") {
                Name = "DarkRoom (Cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Darkroom_DarkRoom (No cutscene)") {
                Name = "DarkRoom (No cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Darkroom_FirstLantern") {
                Name = "FirstLantern",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Darkroom_SecondLantern") {
                Name = "SecondLantern",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Darkroom_ThirdLantern") {
                Name = "ThirdLantern",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Darkroom_DarkRoom FlyingAnimal") {
                Name = "DarkRoom FlyingAnimal",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Elevator (Cutscene)") {
                Name = "Elevator (Cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Elevator (No cutscene)") {
                Name = "Elevator (No cutscene)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Elevator Start") {
                Name = "Elevator Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Elevator (ShieldWasp)") {
                Name = "Elevator (ShieldWasp)",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Beetle") {
                Name = "Beetle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_Beetle Ride") {
                Name = "Beetle Ride",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_BeetleRide_Part1") {
                Name = "BeetleRide_Part1",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_BeetleRide_Part2") {
                Name = "BeetleRide_Part2",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_BeetleRide_Part3") {
                Name = "BeetleRide_Part3",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_BeetleRide_Part4") {
                Name = "BeetleRide_Part4",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_WaspNest_BeetleRide_Part5") {
                Name = "BeetleRide_Part5",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DeeplyRooted
            },
        #endregion
        #region Extermination
            new ITTSplit("Tree_Boss_StartWaspBossPhase1") {
                Name = "StartWaspBossPhase1",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Extermination,
                CheckpointType = CheckpointType.Double,
                Info = "Obtained at the end of " + Chapter.DeeplyRooted
            },
            new ITTSplit("Tree_Boss_StartWaspBossPhase1_NoCutscene") {
                Name = "StartWaspBossPhase1_NoCutscene",
                Type = SplitType.Checkpoint,
                CheckpointType = CheckpointType.Excluded,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("Tree_Boss_ShotOffFirstArmour") {
                Name = "ShotOffFirstArmour",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("Tree_Boss_StartWaspBossPhase2") {
                Name = "StartWaspBossPhase2",
                Type = SplitType.Checkpoint,
                CheckpointType = CheckpointType.Excluded,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("Tree_Boss_StartWaspBossPhase2_2Left") {
                Name = "StartWaspBossPhase2_2Left",
                Type = SplitType.Checkpoint,
                CheckpointType = CheckpointType.Excluded,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("Tree_Boss_StartWaspBossPhase2_1Left") {
                Name = "StartWaspBossPhase2_1Left",
                Type = SplitType.Checkpoint,
                CheckpointType = CheckpointType.Excluded,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("Tree_Boss_StartWaspBossPhase3") {
                Name = "StartWaspBossPhase3",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("Tree_SquirreTurf_CS_Flight") {
                Name = "CS_Flight",
                Type = SplitType.Checkpoint,
                CheckpointType = CheckpointType.Excluded,
                Subchapter = Chapter.Extermination
            },
        #endregion
        #region Getaway
            new ITTSplit("Tree_Escape_Intro") {
                Name = "Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("Tree_Escape_Before Catapult Room") {
                Name = "Before Catapult Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("Tree_Escape_AfterSquirrelChaseCS") {
                Name = "AfterSquirrelChaseCS",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("Tree_Escape_House_Reveal") {
                Name = "House Reveal",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Tree_Escape_CanopyLevelSetLoad") {
                Name = "CanopyLevelSetLoad",
                Type = SplitType.Checkpoint,
                CheckpointType = CheckpointType.Dev,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("Tree_Escape_Fight outside tree") {
                Name = "Fight outside tree",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("Tree_Escape_Cutscene before glider") {
                Name = "Cutscene before glider",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Tree_Escape_Glider Checkpoint") {
                Name = "Glider Checkpoint",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("Tree_Escape_Glider in tunnel") {
                Name = "Glider in tunnel",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("Tree_Escape_Glider halfway through") {
                Name = "Glider halfway through",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("RealWorld_RealWorld_Exterior_Roof_Crash") {
                Name = "RealWorld_Exterior_Roof_Crash",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Getaway,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Pillow Fort
            new ITTSplit("PlayRoom_PillowFort_PillowFort") {
                Name = "PillowFort",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PillowFort
            },
            new ITTSplit("PlayRoom_PillowFort_Pillowfort Intro No CS") {
                Name = "Pillowfort Intro No CS",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PillowFort
            },
            new ITTSplit("PlayRoom_PillowFort_PillowfortFinalRoom") {
                Name = "PillowfortFinalRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PillowFort
            },
        #endregion
        #region Spaced Out
            new ITTSplit("PlayRoom_Spacestation_SpaceStationIntro") {
                Name = "SpaceStationIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_SpaceStationNoIntro") {
                Name = "SpaceStationNoIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_FirstPortalPlatform") {
                Name = "FirstPortalPlatform",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_FirstPortalPlatformCompleted") {
                Name = "FirstPortalPlatformCompleted",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_SecondPortalPlatform") {
                Name = "SecondPortalPlatform",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_SecondPortalPlatformCompleted") {
                Name = "SecondPortalPlatformCompleted",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonIntro") {
                Name = "MoonBaboonIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonLaserPointer") {
                Name = "MoonBaboonLaserPointer",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonRocketPhase") {
                Name = "MoonBaboonRocketPhase",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonInsideUFO") {
                Name = "MoonBaboonInsideUFO",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonInsideUFO_Pedal") {
                Name = "MoonBaboonInsideUFO_Pedal",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonInsideUFO_Crusher") {
                Name = "MoonBaboonInsideUFO_Crusher",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonInsideUFO_ElectricWall") {
                Name = "MoonBaboonInsideUFO_ElectricWall",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("PlayRoom_Spacestation_MoonBaboonMoon") {
                Name = "MoonBaboonMoon",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("RealWorld_SpaceStation_BossFight_BeamOut") {
                Name = "SpaceStation_BossFight_BeamOut",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SpacedOut,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Hopscotch
            new ITTSplit("PlayRoom_Hopscotch_Intro") {
                Name = "Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch,
                CheckpointType = CheckpointType.Double
            },
            new ITTSplit("PlayRoom_Hopscotch_Intro - No Cutscene") {
                Name = "Intro - No Cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Grind Section") {
                Name = "Grind Section",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Closet") {
                Name = "Closet",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Coathanger Ropeway") {
                Name = "Coathanger Ropeway",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_HomeWorkSection") {
                Name = "HomeWorkSection",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Marble Maze Room") {
                Name = "Marble Maze Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Hopscotch Dungeon") {
                Name = "Hopscotch Dungeon",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Hopscotch Dungeon - Whoopee Cushions") {
                Name = "Hopscotch Dungeon - Whoopee Cushions",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_First Ball Fall") {
                Name = "First Ball Fall",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Fidget Spinners") {
                Name = "Fidget Spinners",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Fidget Spinner Tunnel") {
                Name = "Fidget Spinner Tunnel",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Elevator") {
                Name = "Elevator",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Void World") {
                Name = "Void World",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Spawning Floor") {
                Name = "Spawning Floor",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_Kaleidoscope Intro") {
                Name = "Kaleidoscope Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("PlayRoom_Hopscotch_End_of_Kaleidoscope") {
                Name = "End of Kaleidoscope",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("PlayRoom_Hopscotch_Before_Mirror_Puzzle") {
                Name = "Before Mirror Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("PlayRoom_Hopscotch_HomeWork_Pen") {
                Name = "HomeWork Pen",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("PlayRoom_Hopscotch_SIDECONTENT_PullbackCar") {
                Name = "SIDECONTENT_PullbackCar",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Hopscotch,
                CheckpointType = CheckpointType.Dev
            },
        #endregion
        #region Trainstation
            new ITTSplit("PlayRoom_Goldberg_Trainstation_Start") {
                Name = "Trainstation_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TrainStation
            },
            new ITTSplit("PlayRoom_Goldberg_Trainstation_Start_NoCutscene") {
                Name = "Trainstation_Start_NoCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TrainStation
            },
            new ITTSplit("PlayRoom_Goldberg_LoadDinoLand") {
                Name = "LoadDinoLand",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TrainStation,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region DinoLand
            new ITTSplit("PlayRoom_Goldberg_Dinoland_Start") {
                Name = "Dinoland_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DinoLand
            },
            new ITTSplit("PlayRoom_Goldberg_LoadDInoLandToPirate") {
                Name = "LoadDInoLandToPirate",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DinoLand,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("PlayRoom_Goldberg_Dinoland_SlamDinoPt1") {
                Name = "Dinoland_SlamDinoPt1",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DinoLand
            },
            new ITTSplit("PlayRoom_Goldberg_Dinoland_SlamDinoPt2") {
                Name = "Dinoland_SlamDinoPt2",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DinoLand
            },
            new ITTSplit("PlayRoom_Goldberg_Dinoland_SlamDinoPt3") {
                Name = "Dinoland_SlamDinoPt3",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DinoLand,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("PlayRoom_Goldberg_Dinoland_Platforming") {
                Name = "Dinoland_Platforming",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DinoLand
            },
        #endregion
        #region Pirates Ahoy
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part01_Start") {
                Name = "Pirate_Part01_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part01_StartWithoutCutscene") {
                Name = "Pirate_Part01_StartWithoutCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part02_Corridor") {
                Name = "Pirate_Part02_Corridor",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part03_PirateShips") {
                Name = "Pirate_Part03_PirateShips",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part04_PirateShips_End") {
                Name = "Pirate_Part04_PirateShips_End",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part05_Stream") {
                Name = "Pirate_Part05_Stream",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part06_BossCutScene") {
                Name = "Pirate_Part06_BossCutScene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part06_BossStart") {
                Name = "Pirate_Part06_BossStart",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part07_BossHalfway") {
                Name = "Pirate_Part07_BossHalfway",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part08_BossFinalPart") {
                Name = "Pirate_Part08_BossFinalPart",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part09_BossEnd") {
                Name = "Pirate_Part09_BossEnd",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy,
                CheckpointType = CheckpointType.Double
            },
            new ITTSplit("PlayRoom_Goldberg_Pirate_Part09_BossEndWithoutCutscene") {
                Name = "Pirate_Part09_BossEndWithoutCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.PiratesAhoy,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region The Greatest Show
            new ITTSplit("PlayRoom_Goldberg_Circus_Start") {
                Name = "Circus_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("PlayRoom_Goldberg_Circus_HamsterWheel") {
                Name = "Circus_HamsterWheel",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("PlayRoom_Goldberg_Circus_Carousel") {
                Name = "Circus_Carousel",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("PlayRoom_Goldberg_Circus_Cannon") {
                Name = "Circus_Cannon",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("PlayRoom_Goldberg_Circus_Monowheel") {
                Name = "Circus_Monowheel",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("PlayRoom_Goldberg_Circus_Trapeeze") {
                Name = "Circus_Trapeeze",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheGreatestShow
            },
        #endregion
        #region Once Upon a Time
            new ITTSplit("PlayRoom_Courtyard_Castle_Courtyard_Start") {
                Name = "Castle_Courtyard_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.OnceUponATime
            },
            new ITTSplit("PlayRoom_Courtyard_Castle_Courtyard_Start_NoIntro") {
                Name = "Courtyard_Start_NoIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.OnceUponATime
            },
            new ITTSplit("PlayRoom_Courtyard_Castle_Courtyard_CranePuzzle") {
                Name = "Castle_Courtyard_CranePuzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.OnceUponATime
            },
            new ITTSplit("PlayRoom_Courtyard_MINIGAME_Painting") {
                Name = "MINIGAME_Painting",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.OnceUponATime,
                CheckpointType = CheckpointType.Dev
            },
        #endregion
        #region Dungeon Crawler
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon") {
                Name = "Castle_Dungeon",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_NoCutscene") {
                Name = "Castle_Dungeon_NoCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_DrawBridge") {
                Name = "Castle_Dungeon_DrawBridge",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_PostDrawBridge") {
                Name = "Castle_Dungeon_PostDrawBridge",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_Teleporter") {
                Name = "Castle_Dungeon_Teleporter",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_PostTeleporter") {
                Name = "Castle_Dungeon_PostTeleporter",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_FirePlatforms") {
                Name = "Castle_Dungeon_FirePlatforms",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_CrusherConnector") {
                Name = "Castle_Dungeon_CrusherConnector",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_Crusher") {
                Name = "Castle_Dungeon_Crusher",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_ChargerConnector") {
                Name = "Castle_Dungeon_ChargerConnector",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_Charger") {
                Name = "Castle_Dungeon_Charger",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Chessboard_Castle_Chessboard_Intro") {
                Name = "Castle_Chessboard_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Chessboard_Castle_Chessboard_BossFIght") {
                Name = "Castle_Chessboard_BossFIght",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("PlayRoom_Dungeon_Castle_Dungeon_NoTeleport") {
                Name = "Castle_Dungeon_NoTeleport",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("PlayRoom_Chessboard_Castle_Chess_NoTeleport") {
                Name = "Castle_Chess_NoTeleport",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.DungeonCrawler,
                CheckpointType = CheckpointType.Dev
            },
        #endregion
        #region The Queen
            new ITTSplit("PlayRoom_Shelf_Shelf_Cutie_Intro") {
                Name = "Shelf_Cutie_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("PlayRoom_Shelf_Shelf_Cutie") {
                Name = "Shelf_Cutie",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("PlayRoom_Shelf_Shelf_CutieStuckInHatch") {
                Name = "Shelf_CutieStuckInHatch",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("RealWorld_RealWorld_RoseTears") {
                Name = "RealWorld_RoseTears",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheQueen,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("TherapyRoom_TherapyRoom_Time_Session") {
                Name = "TherapyRoom_Time_Session",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TheQueen,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Gates of Time
            new ITTSplit("Clockwork_Outside_ClockworkIntro") {
                Name = "ClockworkIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("Clockwork_Outside_Clockwork Intro - No Cutscene") {
                Name = "Clockwork Intro - No Cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("Clockwork_Outside_ClockTown") {
                Name = "ClockTown",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("Clockwork_Outside_ClockTown_NoIntro") {
                Name = "ClockTown_NoIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("Clockwork_Outside_ClockTown_Valves") {
                Name = "ClockTown_Valves",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("Clockwork_Outside_Start Forest") {
                Name = "Start Forest",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("Clockwork_Outside_Forest - No Cutscene") {
                Name = "Forest - No Cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("Clockwork_Outside_Left Tower Puizzle") {
                Name = "Left Tower Puizzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Clockwork_Outside_Left_Tower_Destroyed") {
                Name = "Left_Tower_Destroyed",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime,
                Info = "TODO: Check Left/Right/Courtyard stuff."
            },
            new ITTSplit("Clockwork_Outside_Right Tower Puzzle") {
                Name = "Right Tower Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Clockwork_Outside_Right_Tower_Destroyed") {
                Name = "Right_Tower_Destroyed",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime,
                Info = "TODO: Check Left/Right/Courtyard stuff."
            },
            new ITTSplit("Clockwork_Outside_Tower Courtyard") {
                Name = "Tower_Courtyard",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GatesOfTime,
                CheckpointType = CheckpointType.Double
            },
        #endregion
        #region Clockworks
            new ITTSplit("Clockwork_LowerTower_Crusher Trap Room") {
                Name = "Crusher_Trap_Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Crusher_Room_No_Intro") {
                Name = "Crusher Room - No Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Bridge") {
                Name = "Bridge",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Statue Room") {
                Name = "Statue_Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Cage Room") {
                Name = "Cage Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Clockwork_LowerTower_Mechanical Wall Room") {
                Name = "Mechanical Wall Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Clockwork_LowerTower_Statue_Room_Mech_Wall_Room_Done") {
                Name = "Statue Room - Mech Wall Room Done",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks,
                Info = "TODO: Check side rooms."
            },
            new ITTSplit("Clockwork_LowerTower_Statue_Room_OTHER_ROOM") {
                Name = "Statue Room - OTHER ROOM",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks,
                Info = "TODO: Check side rooms."
            },
            new ITTSplit("Clockwork_LowerTower_Statue_Room_Both_Side_Rooms_Completed") {
                Name = "Statue Room - Both Side Rooms Completed",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks,
                CheckpointType = CheckpointType.Double
            },
            new ITTSplit("Clockwork_LowerTower_Mini Boss Fight") {
                Name = "Mini Boss Fight",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Wall Jump Corridor") {
                Name = "Wall Jump Corridor",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Elevator Room") {
                Name = "Elevator_Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Pocket Watch Room") {
                Name = "Pocket_Watch_Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Path_to_Evil_Bird") {
                Name = "Path to Evil Bird",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Clockwork_LowerTower_Evil Bird Room") {
                Name = "Evil Bird Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("Clockwork_LowerTower_Evil_Bird_Room_Started") {
                Name = "Evil Bird Room Started",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Clockworks
            },
        #endregion
        #region A Blast from the Past
            new ITTSplit("Clockwork_UpperTower_Boss Intro") {
                Name = "Boss_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast,
                CheckpointType = CheckpointType.Double
            },
            new ITTSplit("Clockwork_UpperTower_Boss_Intro_No_cutscene") {
                Name = "Boss Intro - No cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("Clockwork_UpperTower_Boss_Swinging_Pendulums") {
                Name = "Boss Swinging Pendulums",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("Clockwork_UpperTower_Boss_Clock_Launch_to_Free_Fall") {
                Name = "Boss Clock Launch to Free Fall",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("Clockwork_UpperTower_Boss_Rewind_Smasher") {
                Name = "Boss Rewind Smasher",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("Clockwork_UpperTower_Destroy_Crusher_Room") {
                Name = "Destroy Crusher Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Clockwork_UpperTower_Explosion") {
                Name = "Explosion",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("Clockwork_UpperTower_Final_Explosion") {
                Name = "Final Explosion",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("Clockwork_UpperTower_Sprint_To_Couple") {
                Name = "Sprint To Couple",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("Clockwork_UpperTower_Ending_Cutscene") {
                Name = "Ending Cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Clockwork_Outside_Clockwork Ending") {
                Name = "Clockwork Ending",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("RealWorld_RealWorld_House_LowerLevel_Clock") {
                Name = "RealWorld_House_LowerLevel_Clock",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("TherapyRoom_TherapyRoom_Attraction_Session") {
                Name = "TherapyRoom_Attraction_Session",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.ABlastFromThePast,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Warming Up
            new ITTSplit("SnowGlobe_Forest_Forest Entry") {
                Name = "Forest_Entry",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WarmingUp
            },
            new ITTSplit("SnowGlobe_Forest_Gate") {
                Name = "Gate",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WarmingUp
            },
            new ITTSplit("SnowGlobe_Forest_Timber") {
                Name = "Timber",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WarmingUp
            },
            new ITTSplit("SnowGlobe_Forest_Mill") {
                Name = "Mill",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WarmingUp
            },
            new ITTSplit("SnowGlobe_Forest_Flipper") {
                Name = "Flipper",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WarmingUp
            },
            new ITTSplit("SnowGlobe_Forest_Cabin") {
                Name = "Cabin",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WarmingUp
            },
            new ITTSplit("SnowGlobe_Forest_CaveTownGate") {
                Name = "CaveTownGate",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WarmingUp
            },
        #endregion
        #region Winter Village
            new ITTSplit("SnowGlobe_Town_Town Entry") {
                Name = "Town Entry",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("SnowGlobe_Town_Town Entry (No cutscene)") {
                Name = "Town Entry No Cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("SnowGlobe_Town_Town Door") {
                Name = "Town Door",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("SnowGlobe_Town_Town Bobsled") {
                Name = "Town Bobsled",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WinterVillage
            },
        #endregion
        #region Beneath the Ice
            new ITTSplit("SnowGlobe_Lake_Entry") {
                Name = "Entry",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("SnowGlobe_Lake_Entry (No cutscene)") {
                Name = "Entry no cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("SnowGlobe_Lake_CoreBase") {
                Name = "CoreBase",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("SnowGlobe_Lake_LakeIceCave") {
                Name = "Lake Ice Cave",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("SnowGlobe_Lake_IceCave Complete") {
                Name = "Ice Cave Complete",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.BeneathTheIce
            },
        #endregion
        #region Slippery Slopes
            new ITTSplit("SnowGlobe_Mountain_0. Entry") {
                Name = "0. Entry",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("SnowGlobe_Mountain_Entry (No cutscene)") {
                Name = "Entry no cutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("SnowGlobe_Mountain_1. IceCave") {
                Name = "1. IceCave",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("SnowGlobe_Mountain_2. CaveSkating") {
                Name = "2. CaveSkating",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("SnowGlobe_Mountain_3. Collapse") {
                Name = "3. Collapse",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("SnowGlobe_Mountain_4. PlayerAttraction") {
                Name = "4. PlayerAttraction",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("SnowGlobe_Mountain_5. WindWalk") {
                Name = "5. WindWalk",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("SnowGlobe_Tower_TerraceProposalCutscene") {
                Name = "TerraceProposalCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("RealWorld_RealWorld_House_Kitchen_Sandwiches") {
                Name = "RealWorld_House_Kitchen_Sandwiches",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("TherapyRoom_TherapyRoom_Garden_Session") {
                Name = "TherapyRoom_Garden_Session",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SlipperySlopes,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Green Fingers
            new ITTSplit("Garden_VegetablePatch_Intro") {
                Name = "Garden_VegetablePatch_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("Garden_VegetablePatch_Intro_NoCutscene") {
                Name = "Garden_VegetablePatch_Intro_NoCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("Garden_VegetablePatch_Cactus Combat Area") {
                Name = "Cactus_Combat_Area",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("Garden_VegetablePatch_Beanstalk Section") {
                Name = "Beanstalk_Section",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("Garden_VegetablePatch_Burrown Enemy") {
                Name = "Burrown_Enemy",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("Garden_VegetablePatch_Burrown Enemy Combat") {
                Name = "Burrown_Enemy_Combat",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("Garden_VegetablePatch_Greenhouse Window") {
                Name = "Greenhouse_Window",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.GreenFingers
            },
        #endregion
        #region Weed Whacking
            new ITTSplit("Garden_Shrubbery_Shrubbery_Enter") {
                Name = "Shrubbery_Enter",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_Enter_NoIntro") {
                Name = "Shrubbery_Enter_NoIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_Sprinkler") {
                Name = "Shrubbery_Sprinkler",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_StartCombat") {
                Name = "Shrubbery_StartCombat",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_FirstCombatFinished") {
                Name = "Shrubbery_FirstCombatFinished",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_DandelionLaunchers") {
                Name = "Shrubbery_DandelionLaunchers",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_SecondSpider") {
                Name = "Shrubbery_SecondSpider",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_SpinningLog") {
                Name = "Shrubbery_SpinningLog",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_EnteringBigLog") {
                Name = "Shrubbery_EnteringBigLog",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_BigLogCollapse") {
                Name = "Shrubbery_BigLogCollapse",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_SinkingLog") {
                Name = "Shrubbery_SinkingLog",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_PurpleSapWall") {
                Name = "Shrubbery_PurpleSapWall",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_EnteringBigSpiderCave") {
                Name = "Shrubbery_EnteringBigSpiderCave",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_AfterLeavingSpiders") {
                Name = "Shrubbery_AfterLeavingSpiders",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_StartingFinalCombat") {
                Name = "Shrubbery_StartingFinalCombat",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_StartingFinalCombatSecondWave") {
                Name = "StartingFinalCombatSecondWave",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_SecondCombatFirstWaveFinished") {
                Name = "SecondCombatFirstWaveFinished",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_FinalCombatFinished") {
                Name = "Shrubbery_FinalCombatFinished",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Garden_Shrubbery_Shrubbery_Outro") {
                Name = "Shrubbery_Outro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.WeedWhacking,
                CheckpointType = CheckpointType.Dev
            },
        #endregion
        #region Trespassing
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_Level_Intro") {
                Name = "MoleTunnels_Level_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_Level_Start") {
                Name = "MoleTunnels_Level_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_Stealth_Start") {
                Name = "MoleTunnels_Stealth_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_Stealth_SneakyBushStart") {
                Name = "MoleTunnels_Stealth_SneakyBushStart",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_Stealth_SneakyBushMiddle") {
                Name = "MoleTunnels_Stealth_SneakyBushMiddle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_Stealth_SneakyBushEnding") {
                Name = "MoleTunnels_Stealth_SneakyBushEnding",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_Stealth_Finished") {
                Name = "MoleTunnels_Stealth_Finished",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_MoleChase_Start") {
                Name = "MoleTunnels_MoleChase_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_MoleChase_TopDown") {
                Name = "MoleTunnels_MoleChase_TopDown",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_MoleChase_TopDown_SafeRoom") {
                Name = "MoleTunnels_MoleChase_TopDown_SafeRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_MoleChase_2D") {
                Name = "MoleTunnels_MoleChase_2D",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("Garden_MoleTunnels_MoleTunnels_MoleChase_2D_TreasureRoom") {
                Name = "MoleTunnels_MoleChase_2D_TreasureRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Trespassing
            },
        #endregion
        #region Frog Pond
            new ITTSplit("Garden_FrogPond_Intro") {
                Name = "FrogPond_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_FrogPondIntroNoCS") {
                Name = "FrogPondIntroNoCS",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_LilyPads") {
                Name = "LilyPads",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_Scale Puzzle") {
                Name = "Scale_Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_Sinking Puzzle") {
                Name = "Sinking_Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_Frogger") {
                Name = "Frogger",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_Fish Fountain Puzzle") {
                Name = "Fish_Fountain_Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_Main Fountain Puzzle") {
                Name = "Main_Fountain_Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_Top of Main Fountain") {
                Name = "Top_of_Main_Fountain",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_GrindSection") {
                Name = "GrindSection",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("Garden_FrogPond_Greenhouse Window Puzzle") {
                Name = "Greenhouse_Window_Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.FrogPond,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Affliction
            new ITTSplit("Garden_Greenhouse_Greenhouse_Intro") {
                Name = "Greenhouse_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Greenhouse_StartGameplay") {
                Name = "Greenhouse_StartGameplay",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Greenhouse_FirstBulbExploded") {
                Name = "Greenhouse_FirstBulbExploded",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Intro") {
                Name = "Joy_Bossfight_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Phase_1_Combat") {
                Name = "Joy_Bossfight_Phase_1_Combat",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Phase_2") {
                Name = "Joy_Bossfight_Phase_2",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Phase_2_5") {
                Name = "Joy_Bossfight_Phase_2_5",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Phase_2_Combat") {
                Name = "Joy_Bossfight_Phase_2_Combat",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Phase_3") {
                Name = "Joy_Bossfight_Phase_3",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Phase_3_5") {
                Name = "Joy_Bossfight_Phase_3_5",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("Garden_Greenhouse_Joy_Bossfight_Phase_3_Combat") {
                Name = "Joy_Bossfight_Phase_3_Combat",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("RealWorld_RealWorld_FlowerPot") {
                Name = "RealWorld_FlowerPot",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("TherapyRoom_TherapyRoom_Music") {
                Name = "TherapyRoom_Music",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Affliction,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Setting the stage
            new ITTSplit("Music_ConcertHall_ConcertHall_Backstage") {
                Name = "ConcertHall_Backstage",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SettingTheStage
            },
            new ITTSplit("Music_ConcertHall_ConcertHall_Backstage_NoCS") {
                Name = "ConcertHall_Backstage_NoCS",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.SettingTheStage
            },
        #endregion
        #region Rehearsal
            new ITTSplit("Music_Backstage_Tutorial_Intro") {
                Name = "Tutorial_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Tutorial_Start") {
                Name = "Tutorial_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Tutorial_Disk_Puzzle") {
                Name = "Tutorial_Disk_Puzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_JukeboxStart") {
                Name = "JukeboxStart",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Jukebox_CoinSlot") {
                Name = "Jukebox_CoinSlot",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_JukeboxVinyl") {
                Name = "JukeboxVinyl",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_PrePortableSpeaker") {
                Name = "PrePortableSpeaker",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_PortableSpeaker") {
                Name = "PortableSpeaker",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Sub Bass Room") {
                Name = "Sub_Bass_Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Truss Room") {
                Name = "Truss_Room",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Truss Room no SubBassRoom") {
                Name = "Truss_Room_no_SubBassRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Music_Backstage_Music Tech Wall - Start") {
                Name = "Music_Tech_Wall_Start",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Music_Tech_Wall_EQ_Sweeper") {
                Name = "Music Tech Wall - EQ Sweeper",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Music_Backstage_Silent Room Intro") {
                Name = "Silent_Room_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_MicrophoneChaseDevDebugFallToGrind") {
                Name = "MicrophoneChaseDevDebugFallToGrind",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Music_Backstage_Silent Room Elevator Pillar") {
                Name = "Silent_Room_Elevator_Pillar",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_Silent Room End") {
                Name = "Silent_Room_End",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_MicrophoneChase") {
                Name = "MicrophoneChase",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_MicrophoneChase After First Grind") {
                Name = "MicrophoneChase_After_First_Grind",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_MicrophoneChase Ending") {
                Name = "MicrophoneChase_Ending",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_DrumMachineRoom") {
                Name = "DrumMachineRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_LightRoom PowerSwitch") {
                Name = "LightRoom PowerSwitch",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Music_Backstage_LightRoom") {
                Name = "LightRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("Music_Backstage_MicrophoneChaseDevDebugBreamCrush") {
                Name = "MicrophoneChaseDevDebugBreamCrush",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Music_Backstage_Chase_Landing") {
                Name = "Chase Landing",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Music_Backstage_MicrophoneChase_Door") {
                Name = "MicrophoneChase Door",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Rehearsal,
                CheckpointType = CheckpointType.Dev
            },
        #endregion
        #region Symphony
            new ITTSplit("Music_ConcertHall_ConcertHall_Classic") {
                Name = "ConcertHall_Classic",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_ConcertHall_ConcertHall_Classic_NoCS") {
                Name = "ConcertHall_Classic_NoCS",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_01_Attic_Intro") {
                Name = "Classic_01_Attic_Intro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_01_Attic") {
                Name = "Classic_01_Attic",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_02_FlutePuzzle") {
                Name = "Classic_02_FlutePuzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_03_AccordionBox") {
                Name = "Classic_03_AccordionBox",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_04_BridgePuzzle") {
                Name = "Classic_04_BridgePuzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_05_ShutterPuzzle") {
                Name = "Classic_05_ShutterPuzzle",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_06_Heaven") {
                Name = "Classic_06_Heaven",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony,
                Info = "TODO: Check if this checkpoint is hit multiple times."
            },
            new ITTSplit("Music_Classic_Classic_07_Heaven_CageArea") {
                Name = "Classic_07_Heaven_CageArea",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("Music_Classic_Classic_08_Heaven_CloudArea") {
                Name = "Classic_08_Heaven_CloudArea",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Symphony
            },
        #endregion
        #region Turn up
            new ITTSplit("Music_ConcertHall_ConcertHall_NightClub") {
                Name = "ConcertHall_NightClub",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_ConcertHall_ConcertHall_NightClub_NoCS") {
                Name = "ConcertHall_NightClub_NoCS",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_RainbowSlide") {
                Name = "RainbowSlide",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_RainBowSlideNoCutscene") {
                Name = "RainBowSlideNoCutscene",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_Slide ending") {
                Name = "Slide_ending",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_Beat platforming") {
                Name = "Beat_platforming",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_Pre DiscoballRide") {
                Name = "Pre_DiscoballRide",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_DiscoBallRide") {
                Name = "DiscoBallRide",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_Basement / pre elevator") {
                Name = "Basement_pre_elevator",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_DJ-Dancefloor") {
                Name = "DJ-Dancefloor",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("Music_Nightclub_AudioSurf") {
                Name = "AudioSurf",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.TurnUp
            },
        #endregion
        #region A Grand Finale
            new ITTSplit("Music_Ending_EndingIntro") {
                Name = "EndingIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("Music_Ending_MayInDressingRoom") {
                Name = "MayInDressingRoom",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("Music_Ending_CodyBeforeFlipSwitch") {
                Name = "CodyBeforeFlipSwitch",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.AGrandFinale,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("Music_Ending_MayBeforeCurtains") {
                Name = "MayBeforeCurtains",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.AGrandFinale,
                CheckpointType = CheckpointType.Dev
            },
            new ITTSplit("RealWorld_RealWorld_WakeUp") {
                Name = "RealWorld_WakeUp",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.AGrandFinale,
                CheckpointType = CheckpointType.Excluded
            },
            new ITTSplit("Credits_CreditIntro") {
                Name = "CreditIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.AGrandFinale,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #region Basement
            new ITTSplit("Basement_Seekers_SeekersIntro") {
                Name = "SeekersIntro",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Basement
            },
            new ITTSplit("Basement_Seekers_HouseInteriorStart") {
                Name = "HouseInteriorStart",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Basement
            },
            new ITTSplit("Basement_Boss_BasementBoss") {
                Name = "BasementBoss",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.Basement
            },
        #endregion
        #region Other Checkpoints
            new ITTSplit("Main_Main Menu") {
                Name = "Main Menu",
                Type = SplitType.Checkpoint,
                Subchapter = Chapter.MainMenu,
                CheckpointType = CheckpointType.Excluded
            },
        #endregion
        #endregion
        #region SUBCHAPTERS
            new ITTSplit("Shed_Awakening") {
                Name = Chapter.WakeUpCall,
                Type = SplitType.Chapter
            },
            new ITTSplit("Shed_Vacuum") {
                Name = Chapter.BitingTheDust,
                Type = SplitType.Chapter
            },
            new ITTSplit("Shed_Main") {
                Name = Chapter.TheDepths,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_Approach") {
                Name = Chapter.FreshAir,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_SquirreTurf") {
                Name = Chapter.SquirrelTurf,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_SquirrelHome") {
                Name = Chapter.Captured,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_WaspNest") {
                Name = Chapter.DeeplyRooted,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_Boat") {
                Name = Chapter.Boat,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_Darkroom") {
                Name = Chapter.Darkroom,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_Boss") {
                Name = Chapter.Extermination,
                Type = SplitType.Chapter
            },
            new ITTSplit("Tree_Escape") {
                Name = Chapter.Getaway,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_PillowFort") {
                Name = Chapter.PillowFort,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_Spacestation") {
                Name = Chapter.SpacedOut,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_Hopscotch") {
                Name = Chapter.Hopscotch,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_Goldberg") {
                Name = Chapter.Goldberg,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_Courtyard") {
                Name = Chapter.OnceUponATime,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_Dungeon") {
                Name = Chapter.DungeonCrawler,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_Chessboard") {
                Name = Chapter.Chessboard,
                Type = SplitType.Chapter
            },
            new ITTSplit("PlayRoom_Shelf") {
                Name = Chapter.TheQueen,
                Type = SplitType.Chapter
            },
            new ITTSplit("Clockwork_Outside") {
                Name = Chapter.GatesOfTime,
                Type = SplitType.Chapter
            },
            new ITTSplit("Clockwork_LowerTower") {
                Name = Chapter.Clockworks,
                Type = SplitType.Chapter
            },
            new ITTSplit("Clockwork_UpperTower") {
                Name = Chapter.ABlastFromThePast,
                Type = SplitType.Chapter
            },
            new ITTSplit("SnowGlobe_Forest") {
                Name = Chapter.WarmingUp,
                Type = SplitType.Chapter
            },
            new ITTSplit("SnowGlobe_Town") {
                Name = Chapter.WinterVillage,
                Type = SplitType.Chapter
            },
            new ITTSplit("SnowGlobe_Lake") {
                Name = Chapter.BeneathTheIce,
                Type = SplitType.Chapter
            },
            new ITTSplit("SnowGlobe_Mountain") {
                Name = Chapter.SlipperySlopes,
                Type = SplitType.Chapter
            },
            new ITTSplit("SnowGlobe_Tower") {
                Name = Chapter.SnowGlobeTower,
                Type = SplitType.Chapter
            },
            new ITTSplit("Garden_VegetablePatch") {
                Name = Chapter.GreenFingers,
                Type = SplitType.Chapter
            },
            new ITTSplit("Garden_Shrubbery") {
                Name = Chapter.WeedWhacking,
                Type = SplitType.Chapter
            },
            new ITTSplit("Garden_MoleTunnels") {
                Name = Chapter.Trespassing,
                Type = SplitType.Chapter
            },
            new ITTSplit("Garden_FrogPond") {
                Name = Chapter.FrogPond,
                Type = SplitType.Chapter
            },
            new ITTSplit("Garden_Greenhouse") {
                Name = Chapter.Affliction,
                Type = SplitType.Chapter
            },
            new ITTSplit("Music_ConcertHall") {
                Name = Chapter.SettingTheStage,
                Type = SplitType.Chapter
            },
            new ITTSplit("Music_Backstage") {
                Name = Chapter.Rehearsal,
                Type = SplitType.Chapter
            },
            new ITTSplit("Music_Classic") {
                Name = Chapter.Symphony,
                Type = SplitType.Chapter
            },
            new ITTSplit("Music_Nightclub") {
                Name = Chapter.TurnUp,
                Type = SplitType.Chapter
            },
            new ITTSplit("Music_Ending") {
                Name = Chapter.AGrandFinale,
                Type = SplitType.Chapter
            },
            new ITTSplit("Basement_Seekers") {
                Name = Chapter.Basement,
                Type = SplitType.Chapter
            },
        #endregion
        #region CUTSCENES
            new ITTSplit("EnteringCutscene") {
                Name = "Entering a cutscene",
                Type = SplitType.Cutscene
            },
            new ITTSplit("LeavingCutscene") {
                Name = "Leaving a cutscene",
                Type = SplitType.Cutscene
            },
        #region Wake-Up Call
            new ITTSplit("CS_Shed_Awakening_Divorce_Intro") {
                Name = "Divorce_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WakeUpCall
            },
            new ITTSplit("CS_Shed_Awakening_FuseSocket_JumpOut") {
                Name = "FuseSocket_JumpOut",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WakeUpCall
            },
            new ITTSplit("CS_Shed_Awakening_FuseSocket_Activate") {
                Name = "FuseSocket_Activate",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WakeUpCall
            },
            new ITTSplit("EV_Shed_Awakening_Saw_Success") {
                Name = "Saw_Success",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WakeUpCall
            },
        #endregion
        #region Biting the dust
            new ITTSplit("CS_Shed_Vacuum_Meet_Sucked") {
                Name = "Meet_Sucked",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("CS_Shed_Awakening_Vacuum_Battle") {
                Name = "Vacuum_Battle",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("CS_Shed_Awakening_Vacuum_Battle_var2") {
                Name = "Vacuum_Battle_var2",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("DS_Shed_Vacuum_BossFight_RightEyeSuckProgress") {
                Name = "RightEyeSuckProgress",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("DS_Shed_Vacuum_BossFight_LeftEyeSuckProgress") {
                Name = "LeftEyeSuckProgress",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BitingTheDust
            },
            new ITTSplit("CS_Shed_Vacuum_BossFight_Outro") {
                Name = "BossFight_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BitingTheDust
            },
        #endregion
        #region The Depths
            new ITTSplit("CS_Shed_Main_Abyss_Intro") {
                Name = "Abyss_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_Abyss_Rust") {
                Name = "Abyss_Rust",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Tambourine_MiniGame_Intro") {
                Name = "MiniGame_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_MachineRoom_StartMachine") {
                Name = "MachineRoom_StartMachine",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_ToolBoss_Battle") {
                Name = "ToolBoss_Battle",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_ToolBoxBoss_BossIntro") {
                Name = "ToolBoxBoss_BossIntro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_ToolBoss_FirstPadLock") {
                Name = "ToolBoss_FirstPadLock",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_ToolBoxBoss_KillLeftArm") {
                Name = "ToolBoxBoss_KillLeftArm",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_ToolBoss_Defeat") {
                Name = "ToolBoss_Defeat",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
            new ITTSplit("CS_Shed_Main_ToolBoss_Outro") {
                Name = "ToolBoss_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheDepths
            },
        #endregion
        #region Wired Up
            new ITTSplit("CS_Shed_Main_ToolBoss_Door") {
                Name = "ToolBoss_Door",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WiredUp
            },
            new ITTSplit("CS_RealWorld_Shed_Stargazing_Meet") {
                Name = "Intermediary 1",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WiredUp
            },
        #endregion
        #region Fresh Air
            new ITTSplit("CS_Tree_Approach_Roof_Swing") {
                Name = "Roof_Swing",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FreshAir
            },
            new ITTSplit("CS_Tree_Approach_Gate_Intro") {
                Name = "Gate_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FreshAir
            },
            new ITTSplit("CS_RealWorld_House_Study_Friends") {
                Name = "Study_Friends",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FreshAir
            },
            new ITTSplit("CS_Tree_SquirrelTurf_Home_Interrogation") {
                Name = "Interrogation",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FreshAir
            },
        #endregion
        #region Captured
            new ITTSplit("CS_Tree_SquirrelHome_WallDivide_Intro") {
                Name = "WallDivide_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Captured
            },
        #endregion
        #region Deeply Rooted
            new ITTSplit("CS_Tree_WaspNest_RobotQueen_Intro") {
                Name = "RobotQueen_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("CS_Tree_WaspNest_Boat_River") {
                Name = "Boat_River",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("EV_Tree_Boat_Ending_BoatSwarmCreation") {
                Name = "BoatSwarmCreation",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("CS_Tree_WaspNest_DarkRoom_Intro") {
                Name = "DarkRoom_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("CS_Tree_WaspNest_Elevator_FallingFromDarkroom") {
                Name = "FallingFromDarkroom",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("CS_Tree_WaspNest_Arena_Intro") {
                Name = "Arena_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("CS_Tree_WaspNest_TreeBug_Ride") {
                Name = "TreeBug_Ride",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
            new ITTSplit("CS_Tree_WaspNest_Bug_Crash") {
                Name = "Bug_Crash",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DeeplyRooted
            },
        #endregion
        #region Extermination
            new ITTSplit("CS_Tree_Hive_Boss_Meet") {
                Name = "Boss_Meet",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("CS_Tree_WaspQueenBoss_Arena_PlaneIntro") {
                Name = "PlaneIntro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("CS_Tree_WaspQueenBoss_Arena_SmashInWood") {
                Name = "SmashInWood",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("CS_Tree_WaspQueenBoss_Arena_Defeated") {
                Name = "Defeated",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("CS_Tree_Hive_Boss_Victory") {
                Name = "Boss_Victory",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Extermination
            },
            new ITTSplit("CS_Tree_SquirrelTurf_Return_Flight") {
                Name = "Return_Flight",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Extermination
            },
        #endregion
        #region Getaway
            new ITTSplit("CS_Tree_Escape_Flight_Chase") {
                Name = "Flight_Chase",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("CS_Tree_Escape_Chase_Outro") {
                Name = "Chase_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("CS_Tree_Escape_Plane_Combat") {
                Name = "Plane_Combat",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("CS_Tree_Escape_NoseDive_Intro_Right") {
                Name = "NoseDive_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("CS_Tree_Escape_NoseDive_Crash") {
                Name = "NoseDive_Crash",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("CS_RealWorld_House_LivingRoom_Headache") {
                Name = "Intermediary 2",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Getaway
            },
            new ITTSplit("CS_RealWorld_Exterior_Roof_Crash") {
                Name = "Roof_Crash",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Getaway
            },
        #endregion
        #region Pillow Fort
            new ITTSplit("CS_PlayRoom_PillowFort_Landing_Intro") {
                Name = "Landing_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PillowFort
            },
            new ITTSplit("CS_PlayRoom_PillowFort_Dolls_Dialogue") {
                Name = "A Way Out Dolls",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PillowFort
            },
            new ITTSplit("CS_PlayRoom_PillowFort_SpaceStation_Transport") {
                Name = "SpaceStation_Transport",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PillowFort
            },
        #endregion
        #region Spaced Out
            new ITTSplit("CS_PlayRoom_PillowFort_BeamUp_Intro") {
                Name = "Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("EV_PlayRoom_SpaceStation_Hub_FirstGeneratorActivated") {
                Name = "FirstGeneratorActivated",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("EV_PlayRoom_SpaceStation_BalanceScales_ReturnToPortal") {
                Name = "Green Portal Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("EV_PlayRoom_SpaceStation_Planets_ReturnToPortal") {
                Name = "Red Portal Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("EV_PlayRoom_SpaceStation_PlasmaBall_ReturnToPortal") {
                Name = "Purple Portal Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("EV_PlayRoom_SpaceStation_SpaceBowl_ReturnToPortal") {
                Name = "Umbrella Portal Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("EV_PlayRoom_SpaceStation_LaunchBoard_ReturnToPortal") {
                Name = "Pillow Portal Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("EV_PlayRoom_SpaceStation_Electricity_ReturnToPortal") {
                Name = "Cube Portal Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_Hub_SecondGenerator") {
                Name = "SecondGenerator",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_Intro") {
                Name = "BossFight_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_PowerCoresDestroyed") {
                Name = "BossFight_PowerCoresDestroyed",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_RipOffLaserGun") {
                Name = "BossFight_RipOffLaserGun",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_RocketsPhaseFinished") {
                Name = "BossFight_RocketsPhaseFinished",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_LandInsideUFO") {
                Name = "BossFight_LandInsideUFO",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_Eject") {
                Name = "BossFight_Eject",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_Outro") {
                Name = "BossFight_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
            new ITTSplit("CS_PlayRoom_SpaceStation_BossFight_BeamOut") {
                Name = "BossFight_BeamOut",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SpacedOut
            },
        #endregion
        #region Hopscotch
            new ITTSplit("CS_PlayRoom_Hopscotch_UnderBed_Landing") {
                Name = "UnderBed_Landing",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CS_PlayRoom_Hopscotch_Homework_FallThroughPlanks") {
                Name = "Homework_FallThroughPlanks",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CS_PlayRoom_Hopscotch_Homework_FallThroughPlanksLanding") {
                Name = "Homework_FallThroughPlanksLanding",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CT_PlayRoom_Hopscotch_MarbleMazeRoom_CompletedFirstMaze") {
                Name = "CompletedFirstMaze",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CT_PlayRoom_Hopscotch_MarbleMazeRoom_CompletedSecondMaze") {
                Name = "CompletedSecondMaze",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CT_PlayRoom_Hopscotch_Dungeon_WhoopeeSwivelDoorTransition") {
                Name = "WhoopeeSwivelDoorTransition",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("LS_PlayRoom_Hopscotch_Dungeon_OpenSwivelDoor") {
                Name = "Dungeon_OpenSwivelDoor",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CS_PlayRoom_Hopscotch_Dungeon_TreasureChest") {
                Name = "Dungeon_TreasureChest",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CS_PlayRoom_Hopscotch_Kaleidoscope_Elevator") {
                Name = "Kaleidoscope_Elevator",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CS_PlayRoom_Hopscotch_MirrorPuzzle_EnterPuzzle") {
                Name = "MirrorPuzzle_EnterPuzzle",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
            new ITTSplit("CS_PlayRoom_Hopscotch_Kaleidoscope_Outro") {
                Name = "Kaleidoscope_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Hopscotch
            },
        #endregion
        #region Dinoland
            new ITTSplit("CS_PlayRoom_DinoLand_DinoCrash_Intro") {
                Name = "DinoCrash_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DinoLand
            },
            new ITTSplit("EV_PlayRoom_DinoLand_PteranodonCrash") {
                Name = "PteranodonCrash",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DinoLand
            },
            new ITTSplit("CS_PlayRoom_DinoLand_DinoCrash_Outro") {
                Name = "DinoLand_DinoCrash_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DinoLand
            },
        #endregion
        #region Pirate's Ahoy
            new ITTSplit("CS_PlayRoom_Goldberg_Pirate_EnteringBoat") {
                Name = "EnteringBoat",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("CS_Playroom_Goldberg_Pirate_ShipsIntro") {
                Name = "ShipsIntro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("CS_PlayRoom_Goldberg_Pirate_BossIntro_MainScene") {
                Name = "BossIntro_MainScene",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("CT_Playroom_Goldberg_Pirate_BossSlam_Left") {
                Name = "BossSlam_Left",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("CS_PlayRoom_Goldberg_Pirate_OctopusEnterPhase2") {
                Name = "OctopusEnterPhase2",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("CS_PlayRoom_Goldberg_Pirate_OctopusEnterPhase3") {
                Name = "OctopusEnterPhase3",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("CS_Playroom_Goldberg_Pirate_BossBoatJab") {
                Name = "BossBoatJab",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
            new ITTSplit("CS_PlayRoom_Goldberg_Pirate_SquidDefeated") {
                Name = "SquidDefeated",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.PiratesAhoy
            },
        #endregion
        #region The Greatest Show
            new ITTSplit("CS_PlayRoom_Circus_Balloon_Intro") {
                Name = "Balloon_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("LS_PlayRoom_Goldberg_Circus_SealsBounceBall") {
                Name = "SealsBounceBall",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("CS_PlayRoom_Circus_Balloon_Outro") {
                Name = "Balloon_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheGreatestShow
            },
            new ITTSplit("CS_PlayRoom_Circus_CartRide_Flying") {
                Name = "CartRide_Flying",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheGreatestShow
            },
        #endregion
        #region Once Upon a Time
            new ITTSplit("CS_PlayRoom_Castle_Courtyard_CartLand") {
                Name = "CartLand",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.OnceUponATime
            },
            new ITTSplit("EV_Playroom_Castle_Courtyard_PaperSquish_May") {
                Name = "PaperSquish_May",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.OnceUponATime
            },
            new ITTSplit("EV_Playroom_Castle_Courtyard_PaperSquish_Cody") {
                Name = "PaperSquish_Cody",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.OnceUponATime
            },
            new ITTSplit("CS_PlayRoom_Castle_Gate_Intro") {
                Name = "Gate_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.OnceUponATime
            },
        #endregion
        #region Dungeon Crawler
            new ITTSplit("CS_PlayRoom_Castle_Dungeon_Cell") {
                Name = "Dungeon_Cell",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("CS_Playroom_Castle_Dungeon_CrusherIntro") {
                Name = "CrusherIntro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("LS_Playroom_Castle_Dungeon_BridgeCollapse") {
                Name = "BridgeCollapse",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("CS_PlayRoom_Castle_Dungeon_Outro") {
                Name = "Dungeon_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("CS_PlayRoom_Castle_Chessboard_Intro") {
                Name = "Chessboard_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("CS_Playroom_Castle_Chess_Chessboard_BossDeath") {
                Name = "Chessboard_BossDeath",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DungeonCrawler
            },
            new ITTSplit("CS_PlayRoom_Castle_Chessboard_Outro") {
                Name = "Chessboard_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.DungeonCrawler
            },
        #endregion
        #region The Queen
            new ITTSplit("CS_PlayRoom_Bookshelf_Elephant_Intro") {
                Name = "Elephant Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_Playroom_Castle_Shelf_CaughtByClaw") {
                Name = "Caught By Claw",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_PlayRoom_Bookshelf_Towerhang_Finish") {
                Name = "Towerhang Finish",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_PlayRoom_Bookshelf_LegPull_GetStuck") {
                Name = "Leg Pull Get Stuck",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_PlayRoom_Bookshelf_LegPull_EarRip") {
                Name = "Leg Pull Ear Rip",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_PlayRoom_Bookshelf_ToEdgeHang") {
                Name = "To Edge Hang",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_PlayRoom_Bookshelf_Elephant_Outro") {
                Name = "Elephant Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_RealWorld_RoseRoom_Bed_Crack") {
                Name = "Intermediary 3",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_RealWorld_RoseRoom_Bed_Tears") {
                Name = "Bed Tears",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
            new ITTSplit("CS_TherapyRoom_Session_Theme_Time") {
                Name = "Therapy Room Time",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TheQueen
            },
        #endregion
        #region Gates of Time
            new ITTSplit("CS_ClockWork_LowerTower_Time_Intro") {
                Name = "Time_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CT_Clockwork_Outside_Tutorial_OpenFirstGate") {
                Name = "OpenFirstGate",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CS_ClockWork_Outside_ClockTown_Intro") {
                Name = "ClockTown_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("LS_Clockwork_Outside_ClockTown_RevealHellTower") {
                Name = "RevealHellTower",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CS_ClockWork_Outside_Gate_Vegetation") {
                Name = "Gate_Vegetation",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CS_ClockWork_Outside_Bird_Intro") {
                Name = "Bird_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CS_Clockwork_Outside_LeftTower_ElevatorDown") {
                Name = "LeftTower_ElevatorDown",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CT_Clockwork_Outside_RightTower_OpenRightTower") {
                Name = "RightTower_OpenRightTower",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CS_Clockwork_Outside_RightTower_ElevatorDown") {
                Name = "RightTower_ElevatorDown",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CT_Clockwork_Outside_LeftTower_OpenLeftTower") {
                Name = "LeftTower_OpenLeftTower",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
            new ITTSplit("CS_ClockWork_Outside_Tower_Intro") {
                Name = "Tower_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GatesOfTime
            },
        #endregion
        #region Clockworks
            new ITTSplit("CS_ClockWork_LowerTower_CrusherRoom_Intro") {
                Name = "CrusherRoom_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("CS_Clockwork_LowerTower_Bridge_Intro") {
                Name = "Bridge_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("CS_ClockWork_LowerTower_BullBoss_Intro") {
                Name = "BullBoss_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("CS_Clockwork_LowerTower_BullBoss_HitPillarFirstTime") {
                Name = "BullBoss_HitPillarFirstTime",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("CS_Clockwork_LowerTower_BullBoss_HitPillarSecondTime") {
                Name = "BullBoss_HitPillarSecondTime",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("CS_Clockwork_LowerTower_BullBoss_BullBossCrushed") {
                Name = "BullBoss_BullBossCrushed",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("LS_Clockwork_LowerTower_ChargerRoom_RoomDebris") {
                Name = "ChargerRoom_RoomDebris",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
            new ITTSplit("CS_ClockWork_LowerTower_EvilBird_Intro") {
                Name = "EvilBird_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Clockworks
            },
        #endregion
        #region A Blast from the Past
            new ITTSplit("CS_ClockWork_UpperTower_GlassWalkway_Intro") {
                Name = "Glass Walkway Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_Clockwork_UpperTower_LastBoss_LaunchingPlatform") {
                Name = "Launching Platform",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_Clockwork_UpperTower_LastBoss_BuildingSmasherPlatform") {
                Name = "Building Smasher Platform",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_Clockwork_UpperTower_LastBoss_AfterRewindSmash") {
                Name = "After Rewind Smash",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("DS_Clockwork_UpperTower_LastBoss_Explosion") {
                Name = "Last Boss Explosion",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_ClockWork_UpperTower_Final_Explosion") {
                Name = "Final Explosion",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_Clockwork_UpperTower_LastBoss_LandAfterExplosion") {
                Name = "Land After Explosion",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("EV_Clockwork_UpperTower_LastBoss_CodyEndingPlatform") {
                Name = "Cody Ending Platform",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("EV_Clockwork_UpperTower_LastBoss_MayEndingPlatform") {
                Name = "May Ending Platform",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_ClockWork_UpperTower_EndingRewind") {
                Name = "Intermediary 4",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_ClockWork_CuckoClock_Time_Outro") {
                Name = "Time Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_RealWorld_House_LowerLevel_Clock") {
                Name = "RealWorld_House_LowerLevel_Clock",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
            new ITTSplit("CS_TherapyRoom_Session_Theme_Attraction") {
                Name = "Therapy Room Attraction",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.ABlastFromThePast
            },
        #endregion
        #region Warming Up
            new ITTSplit("CS_SnowGlobe_Forest_Entrance_Intro") {
                Name = "Entrance Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WarmingUp
            },
            new ITTSplit("CS_SnowGlobe_Cabin_Find_Skates") {
                Name = "Find Skates",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WarmingUp
            },
        #endregion
        #region Winter Village
            new ITTSplit("CS_SnowGlobe_Town_SnowCaveOpenGate") {
                Name = "SnowCaveOpenGate",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("CS_SnowGlobe_Town_Bells_Intro") {
                Name = "Bells_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("CS_SnowGlobe_Town_TutorialArea_FirstBellRung") {
                Name = "FirstBellRung",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("CT_SnowGlobe_Town_SecondGatesOpening") {
                Name = "SecondGatesOpening",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("CS_SnowGlobe_Town_CraneArea_CraneBellRung") {
                Name = "CraneBellRung",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("CS_SnowGlobe_Town_BigWheelArea_BigWheelBellRung") {
                Name = "BigWheelBellRung",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("CS_SnowGlobe_Town_IceWallArea_IceWallBellRung") {
                Name = "IceWallBellRung",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("CS_SnowGlobe_Town_TownCenter_CableCartOpen") {
                Name = "CableCartOpen",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
            new ITTSplit("EV_SnowGlobe_Town_BobsledCompleted") {
                Name = "BobsledCompleted",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WinterVillage
            },
        #endregion
        #region Beneath the Ice
            new ITTSplit("CS_SnowGlobe_Lake_Swimming_Intro") {
                Name = "Swimming_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("CS_SnowGlobe_Lake_Factory_Intro") {
                Name = "Factory_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("LS_Snowglobe_Lake_IceCaveFinish") {
                Name = "IceCaveFinish",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("LS_Snowglobe_Lake_FishDone") {
                Name = "FishDone",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("CT_SnowGlobe_Lake_BubbleDone") {
                Name = "BubbleDone",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("LS_SnowGlobe_Lake_CoreElevatorDoorOpen") {
                Name = "CoreElevatorDoorOpen",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BeneathTheIce
            },
            new ITTSplit("CS_SnowGlobe_Lake_SkiLift_Ride") {
                Name = "SkiLift Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.BeneathTheIce
            },
        #endregion
        #region Slippery Slopes
            new ITTSplit("CS_SnowGlobe_Mountain_SkiLift_Ride") {
                Name = "SkiLift Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("CS_SnowGlobe_Mountain_SmallCabin_Collapse") {
                Name = "SmallCabin_Collapse",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("CT_SnowGlobe_Mountain_CollapseFall") {
                Name = "CollapseFall",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("CS_SnowGlobe_Mountain_IceCave_Intro") {
                Name = "IceCave_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("CS_SnowGlobe_Tower_Ground_Elevator") {
                Name = "Ground_Elevator",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("CS_SnowGlobe_Tower_Terrace_Proposal") {
                Name = "Terrace_Proposal",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("CS_RealWorld_House_Kitchen_Sandwiches") {
                Name = "RealWorld_House_Kitchen_Sandwiches",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
            new ITTSplit("CS_TherapyRoom_Session_Theme_Garden") {
                Name = "TherapyRoom_Session_Theme_Garden",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SlipperySlopes
            },
        #endregion
        #region Green Fingers
            new ITTSplit("CS_Garden_VegetablePatch_Entrance_Intro") {
                Name = "Entrance_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CS_Garden_VegetablePatch_Entrance_Outro") {
                Name = "Entrance_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CT_Garden_VegetablePatch_BeanstalkFlowerGate") {
                Name = "BeanstalkFlowerGate",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CS_Garden_VegetablePatch_Burrower_Intro") {
                Name = "Burrower_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CS_Garden_SpaEntrance_Cody_Enter") {
                Name = "SpaEntrance_Cody_Enter",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CS_Garden_SpaEntrance_May_Enter") {
                Name = "SpaEntrance_May_Enter",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CS_Garden_SpaEntrance_Cody_Exit") {
                Name = "SpaEntrance_Cody_Exit",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CS_Garden_SpaEntrance_May_Exit") {
                Name = "SpaEntrance_May_Exit",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CT_Garden_VegetablePatch_OutsideGreenhouse_Unwither") {
                Name = "OutsideGreenhouse_Unwither",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
            new ITTSplit("CS_Garden_VegetablePatch_Greenhouse_Intro") {
                Name = "Greenhouse_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.GreenFingers
            },
        #endregion
        #region Weed Whacking
            new ITTSplit("CS_Garden_Shrubbery_Shrubbery_Intro") {
                Name = "Shrubbery_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_CombatArea_IntroducingSpider") {
                Name = "IntroducingSpider",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_CombatArea_SpiderIntro") {
                Name = "SpiderIntro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_DandelionPit_SpiderMount") {
                Name = "SpiderMount",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_SpinningLog_LogCollapse") {
                Name = "LogCollapse",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_SpinningLog_EscapeFromSinkingLog") {
                Name = "EscapeFromSinkingLog",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_SpiderNest_Outro") {
                Name = "SpiderNest_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_CactusWaves_Intro") {
                Name = "CactusWaves_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CT_Garden_Shrubbery_SecondCombat_LeavesExtended") {
                Name = "SecondCombat_LeavesExtended",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
            new ITTSplit("CS_Garden_Shrubbery_PoisonCore_AreaOutro") {
                Name = "PoisonCore_AreaOutro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.WeedWhacking
            },
        #endregion
        #region Trespassing
            new ITTSplit("CS_Garden_Moletunnels_Stealth_LevelStart") {
                Name = "LevelStart",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("CS_Garden_MoleTunnels_Stealth_PushPineCone") {
                Name = "PushPineCone",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("CS_Garden_MoleTunnels_Discovered_Part1") {
                Name = "Discovered_Part1",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("TP_Garden_MoleTunnels_Discovered_Part1_Short") {
                Name = "Discovered_Part1_Short",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("CS_Garden_MoleTunnels_PlantDestroyed") {
                Name = "PlantDestroyed",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("CS_Garden_Moletunnels_Chase_FallDownInto2D") {
                Name = "FallDownInto2D",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Trespassing
            },
            new ITTSplit("CS_Garden_MoleTunnels_Chase_LevelEnding") {
                Name = "LevelEnding",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Trespassing
            },
        #endregion
        #region Frog Pond
            new ITTSplit("CS_Garden_FrogPond_TaxiStand_FrogRide") {
                Name = "FrogRide",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("CT_Garden_FrogPond_MainFountain_SmallerFountainPlatformsEnabled") {
                Name = "SmallerFountainPlatformsEnabled",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("CS_Garden_FrogPond_MainFountain_PoisonBulbDestroyed") {
                Name = "MainFountain_PoisonBulbDestroyed",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FrogPond
            },
            new ITTSplit("CS_Garden_FrogPond_Greenhouse_OpenDoor") {
                Name = "Greenhouse_OpenDoor",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.FrogPond
            },
        #endregion
        #region Affliction
            new ITTSplit("CS_Garden_GreenHouse_Door_Intro") {
                Name = "Door_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CT_Garden_Greenhouse_Floor_KilledSmallBulb") {
                Name = "Floor_KilledSmallBulb",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CT_Garden_Greenhouse_RightTable_RightbulbDestroyed") {
                Name = "RightbulbDestroyed",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CT_Garden_Greenhouse_LeftTable_KilledSmallBulb") {
                Name = "LeftTable_KilledSmallBulb",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CT_Garden_Greenhouse_MainArea_Greenified") {
                Name = "MainArea_Greenified",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_GreenHouse_BossRoom_Intro") {
                Name = "BossRoom_Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_Greenhouse_BossRoom_CodyTakesControl") {
                Name = "BossRoom_CodyTakesControl",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_Greenhouse_BossRoom_DestroyFirstBlob") {
                Name = "BossRoom_DestroyFirstBlob",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_Greenhouse_BossRoom_ThrowSecondPot") {
                Name = "BossRoom_ThrowSecondPot",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_Greenhouse_BossRoom_CodyTakesControlPhaseTwo") {
                Name = "BossRoom_CodyTakesControlPhaseTwo",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_Greenhouse_BossRoom_ThrowThirdPot") {
                Name = "BossRoom_ThrowThirdPot",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_Greenhouse_BossRoom_CodyTakesControlPhaseThree") {
                Name = "BossRoom_CodyTakesControlPhaseThree",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_Garden_GreenHouse_BossRoom_Outro") {
                Name = "BossRoom_Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_RealWorld_House_RoseRoom_FlowerPot") {
                Name = "RealWorld_House_RoseRoom_FlowerPot",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
            new ITTSplit("CS_TherapyRoom_Session_Theme_Music") {
                Name = "Therapy Room Music",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Affliction
            },
        #endregion
        #region Setting the Stage
            new ITTSplit("CS_Music_ConcertHall_Backstage_Intro") {
                Name = "Backstage Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SettingTheStage
            },
            new ITTSplit("CS_Music_ConcertHall_EnteringBackstage") {
                Name = "Entering Backstage",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.SettingTheStage
            },
        #endregion
        #region Rehearsal
            new ITTSplit("CS_Music_Backstage_PortableSpeakerRoom_Intro") {
                Name = "Portable Speaker Room Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("EV_Music_Backstage_Jukebox_CoinSuck") {
                Name = "Jukebox Coin Suck",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_PortableSpeakerRoom_WindowBlast") {
                Name = "Portable Speaker Room Window Blast",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_BassRoom_Landing") {
                Name = "Bass Room Landing",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CT_Music_Backstage_MusicTechWall_GoingThroughTruss") {
                Name = "Music Tech Wall Going Through Truss",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_MusicTechWall_Reveal") {
                Name = "Music Tech Wall Reveal",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CT_Music_Backstage_MusicTechWall_PowerCableTravel") {
                Name = "Music Tech Wall Power Cable Travel",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_MicrophoneRoom_MotherReveal") {
                Name = "Microphone Room Mother Reveal",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("DS_Music_Backstage_MicrophoneChase_FallToGrind") {
                Name = "Microphone Chase Fall To Grind",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("DS_Music_Backstage_MicrophoneChase_BrokenTruss") {
                Name = "Microphone Chase Broken Truss",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_MicrophoneChase_Landing") {
                Name = "Microphone Chase Landing",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_MicrophoneChase_Ending") {
                Name = "Microphone Chase Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_LightRoom_Entrance") {
                Name = "Light Room Entrance",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
            new ITTSplit("CS_Music_Backstage_LightRoom_EndOfLightRoom") {
                Name = "End Of Light Room",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Rehearsal
            },
        #endregion
        #region Symphony
            new ITTSplit("CS_Music_ConcertHall_Backstage_Orchestra") {
                Name = "Backstage Orchestra",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_ConcertHall_BackStage_EnteringClassic") {
                Name = "Entering Classic",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Attic_EnterClassic") {
                Name = "Enter Symphony",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Heaven_Flying") {
                Name = "Flying",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Heaven_Reveal") {
                Name = "Reveal",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Heaven_OpenBirdCage") {
                Name = "Open Bird Cage",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Heaven_ReleaseFollowersCage") {
                Name = "Release Followers Cage",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Heaven_OpenCloudRoom") {
                Name = "Open Cloud Room",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Heaven_ReleaseFollowersCloud") {
                Name = "Release Followers Cloud",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
            new ITTSplit("CS_Music_Classic_Heaven_LevelEnding") {
                Name = "Symphony Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Symphony
            },
        #endregion
        #region Turn Up
            new ITTSplit("CS_Music_ConcertHall_Backstage_Audience") {
                Name = "Backstage Audience",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("CS_Music_ConcertHall_NightClub_Entrance") {
                Name = "Entering Night Club",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("CS_Music_Nightclub_RainbowSlide_Intro") {
                Name = "Rainbow Slide Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("EV_Music_Nightclub_RainbowSlide_RespawnMay1") {
                Name = "Rainbow Slide Respawn May",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("EV_Music_Nightclub_RainbowSlide_RespawnCody1") {
                Name = "Rainbow Slide Respawn Cody",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("CS_Music_NightClub_Discoball_GroundpoundStart") {
                Name = "Discoball Groundpound Start",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("CS_Music_NightClub_DiscoRide_BallCrash") {
                Name = "Disco Ride Ball Crash",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("CT_Music_Nightclub_Basement_DjElevator") {
                Name = "Basement Dj Elevator",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("CS_Music_NightClub_Basement_Elevator") {
                Name = "Basement Elevator",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
            new ITTSplit("CS_Music_NightClub_DJ_Outro") {
                Name = "DJ Outro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.TurnUp
            },
        #endregion
        #region A Grand Finale
            new ITTSplit("CS_Music_Ending_DropDown_Preparation") {
                Name = "Drop Down Preparation",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_Music_Ending_DressingRoom_Mirror") {
                Name = "Dressing Room Mirror",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_Music_Ending_BehindStage_FirstCameraRide") {
                Name = "First Camera Ride",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_Music_Ending_BehindStage_SecondCameraRide") {
                Name = "Second Camera Ride",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_Music_Attic_Stage_GrandFinaleEnding") {
                Name = "Grand Finale Ending",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CT_Music_Ending_Smooch") {
                Name = "Smooch",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_Music_Attic_Stage_ClimacticKiss") {
                Name = "Climactic Kiss (End of run)",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_RealWorld_House_Study_Wakeup") {
                Name = "Real World House Study Wakeup",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_RealWorld_RoseRoom_Bed_Letter") {
                Name = "Real World RoseRoom Bed Letter",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_RealWorld_Exterior_Busstop_Reunion") {
                Name = "Real World Exterior Busstop Reunion",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
            new ITTSplit("CS_RealWorld_House_Credits_PlaceBook") {
                Name = "Real World House Credits Place Book",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.AGrandFinale
            },
        #endregion
        #region Basement
            new ITTSplit("CS_TherapyRoom_Session_Theme_Love") {
                Name = "Therapy Room Basement",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Basement
            },
            new ITTSplit("CS_Basement_Seekers_Door_Intro") {
                Name = "Seekers Door Intro",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Basement
            },
            new ITTSplit("CS_Basement_BossRoom_Argue_Collapse") {
                Name = "Boss Room Argue Collapse",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Basement
            },
            new ITTSplit("CS_Basement_BossRoom_Argue_Light") {
                Name = "Boss Room Argue Light",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Basement
            },
            new ITTSplit("CS_Basement_Boss_GrayPlace_Letter") {
                Name = "Boss Gray Place Letter",
                Type = SplitType.Cutscene,
                Subchapter = Chapter.Basement
            },
        #endregion
        #endregion
        #region MINIGAMES
            new ITTSplit("Shed_Main_WhackACody") {
                Name = "Whack-a-Cody",
                Type = SplitType.Minigame
            },
            new ITTSplit("Shed_Main_MINIGAME_NailWheel") {
                Name = "Flip the Switch",
                Type = SplitType.Minigame
            },
            new ITTSplit("Tree_SquirrelHome_MINIGAME_TugOfWar") {
                Name = "Tug of War",
                Type = SplitType.Minigame
            },
            new ITTSplit("Tree_WaspNest_MINIGAME_Plunger") {
                Name = "Plunger Dunger",
                Type = SplitType.Minigame
            },
            new ITTSplit("PlayRoom_PillowFort_MINIGAME_Hazeboy") {
                Name = "Tank Brothers",
                Type = SplitType.Minigame
            },
            new ITTSplit("PlayRoom_Spacestation_MINIGAME_LaserTennis") {
                Name = "Laser Tennis",
                Type = SplitType.Minigame
            },
            new ITTSplit("PlayRoom_Spacestation_MINIGAME_LowGravity") {
                Name = "Spacewalk",
                Type = SplitType.Minigame
            },
            new ITTSplit("PlayRoom_Hopscotch_MINIGAME_BaseBall") {
                Name = "Batting Team",
                Type = SplitType.Minigame
            },
            new ITTSplit("PlayRoom_Hopscotch_MINIGAME_ThrowingHoops") {
                Name = "Feed the Reptile",
                Type = SplitType.Minigame
            },
            new ITTSplit("PlayRoom_Hopscotch_MINIGAME_Rodeo") {
                Name = "Rodeo",
                Type = SplitType.Minigame
            },
            new ITTSplit("PlayRoom_Courtyard_MINIGAME_BirdStar") {
                Name = "Birdstar",
                Type = SplitType.Minigame
            },
            new ITTSplit("Clockwork_Outside_MINIGAME_BombRun") {
                Name = "Bomb Run",
                Type = SplitType.Minigame
            },
            new ITTSplit("Clockwork_Outside_MINIGAME_HorseDerby") {
                Name = "Horse Derby",
                Type = SplitType.Minigame
            },
            new ITTSplit("SnowGlobe_Town_MINIGAME_SnowballFight") {
                Name = "Snow Warfare",
                Type = SplitType.Minigame
            },
            new ITTSplit("SnowGlobe_Town_MINIGAME_ShuffleBoard") {
                Name = "Shuffle Board",
                Type = SplitType.Minigame
            },
            new ITTSplit("SnowGlobe_Town_MINIGAME_IcicleThrowing") {
                Name = "Icicle Throwing",
                Type = SplitType.Minigame
            },
            new ITTSplit("SnowGlobe_Lake_MINIGAME_IceRace") {
                Name = "Ice Race",
                Type = SplitType.Minigame
            },
            new ITTSplit("Garden_Shrubbery_MINIGAME_Basket") {
                Name = "Larva Basket",
                Type = SplitType.Minigame
            },
            new ITTSplit("Garden_Shrubbery_MINIGAME_Swings") {
                Name = "Garden Swings",
                Type = SplitType.Minigame
            },
            new ITTSplit("Garden_FrogPond_Minigame_SnailRace") {
                Name = "Snail Race",
                Type = SplitType.Minigame
            },
            new ITTSplit("Music_ConcertHall_MINIGAME_MusicalChairs") {
                Name = "Musical Chairs",
                Type = SplitType.Minigame
            },
            new ITTSplit("Music_ConcertHall_MINIGAME_TrackRunner") {
                Name = "Track Runner",
                Type = SplitType.Minigame
            },
            new ITTSplit("Music_ConcertHall_MINIGAME_SlotCars") {
                Name = "Slotcars",
                Type = SplitType.Minigame
            },
            new ITTSplit("Music_ConcertHall_MINIGAME_Chess") {
                Name = "Chess",
                Type = SplitType.Minigame
            },
            new ITTSplit("Music_Classic_MINIGAME_VolleyBall") {
                Name = "Volleyball",
                Type = SplitType.Minigame
            },
        #endregion
        #region OTHER
            new ITTSplit("May_bIsDead") {
                Name = "May is dead",
                Type = SplitType.Death,
                Tooltip = "Splits on any May death"
            },
            new ITTSplit("Cody_bIsDead") {
                Name = "Cody is dead",
                Type = SplitType.Death,
                Tooltip = "Splits on any Cody death"
            },
            new ITTSplit("AnyDead") {
                Name = "Any player death",
                Type = SplitType.Death,
                Tooltip = "Splits on any player death"
            },
            new ITTSplit("ManualSplit") {
                Name = "Manual Split",
                Type = SplitType.Misc,
                Tooltip = "Autosplitter doesn't split on this. For use in ordered splits."
            },
        #endregion
        };
}
