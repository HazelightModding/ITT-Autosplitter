using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LiveSplit.ItTakesTwo {
    
    public class ItTakesTwoStatics {

        #region Strings
        private readonly struct Tag {
            public const string Chapter = " (Chapter)";
            public const string Level = " (Level)"; // More specific than chapter
            public const string Checkpoint = " (Checkpoint)";
            public const string CutsceneStart = " (Cutscene Start)";
            public const string CutsceneEnd = " (Cutscene End)";
            public const string Death = " (Death)";
            public const string Minigame = " (Minigame)";
            public const string Dev = " (Dev)";
        }
        private readonly struct Chapter {
            public const string Format = "Splits on transition to {0}.";

            public const string Intro = "Intro";
            public const string WakeUpCall = "Wake-Up Call";
            public const string BitingTheDust = "Biting the Dust";
            public const string TheDepths = "The Depths";
            public const string WiredUp = "Wired Up";
            public const string FreshAir = "Fresh Air";
            public const string Captured = "Captured";
            public const string DeeplyRooted = "Deeply Rooted";
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
            public const string TheQueen = "The Queen";
            public const string GatesOfTime = "Gates of Time";
            public const string Clockworks = "Clockworks";
            public const string ABlastFromThePast = "A Blast from the Past";
            public const string WarmingUp = "Warming Up";
            public const string WinterVillage = "Winter Village";
            public const string BeneathTheIce = "Beneath the Ice";
            public const string SlipperySlopes = "Slippery Slopes";
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
        private readonly struct Level {
            public const string Format = "Splits on transition to {0}.";

            public const string Menu = "Main Menu";

            public const string Awakening = "Wake-up Call";
            public const string Vacuum = "Biting the Dust";
            public const string Main_Hammernails = "The Depths";
            public const string Main_Grindsection = "Wired Up";
            public const string RealWorld_Shed_StarGazing_Meet = "Intermediary 1";//"RealWorld_Shed_StarGazing_Meet_BP";
            public const string Approach = "Fresh Air";
            public const string RealWorld_House_Study_Friends = "House Study Friends Cutscene";
            public const string SquirrelTurf_WarRoom = "War Room Cutscene";
            public const string SquirrelHome_BP_Mech = "Captured";
            public const string WaspsNest = "Deeply Rooted";
            public const string Tree_Boat = "Boat";
            public const string Tree_Darkroom = "Darkroom";
            public const string WaspsNest_Elevator = "Deeply Rooted Elevator";
            public const string WaspsNest_Beetle = "Beetle";
            public const string WaspsNest_BeetleRide = "Beetle Ride";
            public const string WaspQueenBoss = "Extermination";
            public const string SquirrelTurf_Flight = "Flight Cutscene";
            public const string Escape = "Getaway";
            public const string RealWorld_Exterior_Roof_Crash = "Intermediary 2";//"RealWorld_Exterior_Roof_Crash_BP";
            public const string PillowFort = "Pillow Fort";
            public const string Spacestation_Hub = "Spaced Out";
            public const string SpaceStation_MoonBaboon = "Moon Baboon";
            public const string Realworld_SpaceStation_Bossfight_BeamOut = "Beam Out Cutscene";
            public const string Hopscotch = "Hopscotch";
            public const string VoidWorld = "Void World";
            public const string Kaleidoscope = "Kaleidoscope";
            public const string Goldberg_Trainstation = "Trainstation";
            public const string Goldberg_Dinoland = "Dino Land";
            public const string Goldberg_Pirate = "Pirates Ahoy";

            public const string Goldberg_Circus = "The Greatest Show";
            public const string Castle_Courtyard = "Once Upon a Time";
            public const string Castle_Dungeon = "Dungeon Crawler";
            public const string Castle_Dungeon_Crusher = "Dungeon Crusher";
            public const string Castle_Dungeon_Charger = "Dungeon Charger";
            public const string Castle_Chessboard = "Dungeon Chess";
            public const string Shelf = "The Queen";
            public const string RealWorld_RoseRoom_Bed_Tears = "Intermediary 3";//"RealWorld_RoseRoom_Bed_Tears_BP";
            public const string TherapyRoom_Session_Theme_Time = "Therapy Room Time";
            public const string Clockwork_Tutorial = "Gates of Time";
            public const string Clockwork_ClockTown = "Clock Town";
            public const string Clockwork_Forest = "Clock Forest";
            public const string Clockwork_ClockTowerLower_CrushingTrapRoom = "Clockworks";
            public const string Clockwork_ClockTowerLower_BridgeIntro = "Clockworks Bridge";
            public const string Clockwork_ClockTowerLower = "Clockworks Statue Room";
            public const string Clockwork_ClockTowerMiniBossRoom = "Clockworks Bull Boss";
            public const string Clockwork_ClockTowerLower_WallJumpCorridor = "Clockworks Wall Jump Corridor";
            public const string Clockwork_ClockTowerLower_CuckooBirdRoom = "Clockworks Pocket Watch Room";
            public const string Clockwork_ClockTowerLastBoss = "A Blast from the Past";
            public const string Clockwork_ClockTowerCourtyardCutscene = "Clock Ending Cutscene";
            public const string RealWorld_House_LowerLevel_Clock = "Realworld Clock Cutscene";
            public const string TherapyRoom_Session_Theme_Attraction = "Therapy Room Attraction";
            public const string SnowGlobe_Forest = "Warming Up";
            public const string SnowGlobe_Forest_TownGate = "Forest Town Gate";
            public const string SnowGlobe_Town = "Winter Village";
            public const string SnowGlobe_Town_BobSled = "Bobsled";
            public const string Snowglobe_Lake = "Beneath the Ice";
            public const string SnowGlobe_Lake_IceCave = "Ice Cave";
            public const string SnowGlobe_Mountain = "Slippery Slopes";
            public const string SnowGlobe_Mountain_Cave = "Slippery Caves";
            public const string SnowGlobe_Mountain_Collapse = "Slippery Collapse";
            public const string SnowGlobe_Mountain_PlayerAttraction = "Slippery Attraction";
            public const string SnowGlobe_Mountain_WindWalk = "Slippery Wind Walk";
            public const string Tower = "Tower Cutscene";
            public const string RealWorld_House_Kitchen_Sandwiches = "Real World Kitchen Sandwiches";
            public const string TherapyRoom_Session_Theme_Garden = "Therapy Room Garden";
            public const string Garden_VegetablePatch = "Green Fingers";
            public const string Garden_Shrubbery = "Weed Whacking";
            public const string Garden_Shrubbery_SecondCombat = "Weed Whacking Second Combat";
            public const string Garden_MoleTunnels_Stealth = "Trespassing";
            public const string Garden_MoleTunnels_Chase = "Trespassing Chase";
            public const string Garden_FrogPond = "Frog Pond";
            public const string Garden_FrogPond_FountainPuzzle = "Frog Pond Fountain Puzzle";
            public const string Garden_Greenhouse = "Affliction";
            public const string Garden_Greenhouse_JoysRoom = "Affliction Joys Room";
            public const string RealWorld_RoseRoom_FlowerPot = "Real World Flower Pot";
            public const string TherapyRoom_Session_Theme_Music = "Therapy Room Music";
            public const string Music_ConcertHall = "Setting the Stage";
            public const string Music_Backstage_Tutorial = "Rehearsal";
            public const string Music_Backstage_PortableSpeakerRoom = "Rehearsal Portable Speaker Room";
            public const string Music_Backstage_SubBassRoom = "Rehearsal Sub Bass Room";
            public const string Music_Backstage_TrussRoom = "Rehearsal Truss Room";
            public const string Music_Backstage_MusicTechWall = "Rehearsal Music Tech Wall";
            public const string Music_Backstage_MurderMicrophoneRoom = "Rehearsal Murder Microphone Room";
            public const string Music_Backstage_MicrophoneChase = "Rehearsal Microphone Chase";
            public const string Music_Backstage_DrumMachineRoom = "Rehearsal Drum Machine Room";
            public const string Music_Backstage_LightRoom = "Rehearsal Light Room";
            public const string Music_Classic_Organ = "Symphony";
            public const string Music_Classic_Ending = "Symphony Ending";
            public const string Music_Nightclub = "Turn Up";
            public const string Music_Ending = "A Grand Finale";
            public const string RealWorld_Ending = "Real World Ending";
            public const string Credits = "Credits";

            public const string TherapyRoom_Session_Theme_Love = "Therapy Room Basement";
            public const string Basement_Seekers = "Basement Seekers";
            public const string Basement_HouseInterior = "Basement House Interior";
            public const string Basement_Boss = "Basement Boss";

        }
        private readonly struct Minigame {
            public const string Format = "Splits when teleporting to the \"{0}\" minigame.";

            public const string WhackACody = "Whack-a-Cody";
            public const string FlipTheSwitch = "Flip the Switch";
            public const string TugOfWar = "Tug of War";
            public const string Plunger = "Plunger Dunger";
            public const string Tank = "Tank Brothers";
            public const string Laser = "Laser Tennis";
            public const string Spacewalk = "Spacewalk";
            public const string Batting = "Batting Team";
            public const string FeedTheReptile = "Feed the Reptile";
            public const string Rodeo = "Rodeo";
            public const string Birdstar = "Birdstar";
            public const string BombRun = "Bomb Run";
            public const string HorseDerby = "Horse Derby";
            public const string SnowWarfare = "Snow Warfare";
            public const string Shuffle = "Shuffle Board";
            public const string Icicle = "Icicle Throwing";
            public const string IceRace = "Ice Race";
            public const string Larva = "Larva Basket";
            public const string Swings = "Garden Swings";
            public const string Snail = "Snail Race";
            public const string Chairs = "Musical Chairs";
            public const string Track = "Track Runner";
            public const string Slotcars = "Slotcars";
            public const string Chess = "Chess";
            public const string Volleyball = "Volleyball";
        }
        private readonly struct Checkpoint {
            public const string Format = "Splits when obtaining the \"{0}\" checkpoint in {1}.";

            public struct Menu {
                public const string MainMenu = "Main Menu";
            }

            public struct Intro {
                public const string HouseKitchenDivorce = "RealWorld House Kitchen Divorce";
            }

            public struct WakeUpCall {
                public const string Start = "Awakening_Start";
                public const string FirstGameplay = "Awakening_FirstGameplay";
                public const string ChaseFuses = "Awakening_ChaseFuses";
                public const string FusesPutIn = "FusesPutIn";
            }

            public struct BitingTheDust {
                public const string Intro = "Vacuum Intro";
                public const string NoIntro = "VacuumNoIntro";
                public const string OilPit = "Oil Pit";
                public const string Generator = "Generator";
                public const string SideScroller = "Side Scroller";
                public const string Stomach = "Stomach";
                public const string PortalLoop = "Portal Loop";
                public const string BossBackpack = "Boss Backpack";
                public const string WeatherVane = "Weather Vane";
                public const string PistonLauncher = "Piston Launcher";
                public const string WeightBowl = "Weight Bowl";
                public const string VacuumBoss = "Vacuum Boss";
                public const string BossNoIntro = "Boss No Intro";
            }

            public struct Depths {
                public const string Intro = "MineIntro";
                public const string IntroNoCS = "MineIntroNoCutscene";
                public const string MineHammerMeeting = "MineHammerMeeting";
                public const string TutorialPuzzle1 = "TutorialPuzzle1";
                public const string MineMainHub = "MineMainHub";
                public const string WhackACody = "WhackACody";
                public const string MachineIntroPuzzle1 = "MachineIntroPuzzle1";
                public const string MineMachineRoom = "MineMachineRoom";
                public const string MineMachineRoomStarted = "MineMachineRoomStarted";
                public const string MineMachineRoomHalfway = "MineMachineRoomHalfway";
                public const string MachineRoomChickenRace = "MachineRoomChickenRace";
                public const string MachineRoomEnding = "MachineRoomEnding";
                public const string PreBossDoubleInteract = "Pre Boss Double Interact";
                public const string MainAndToolBoxCutscene = "MainAndToolBoxCutscene";
                public const string ToolBoxBossIntro = "ToolBoxBossIntro";
                public const string ToolBoxBossHalfWay = "ToolBoxBossHalfWay";
                public const string MainBossFightStarted = "MainBossFightStarted";
                public const string MainBossFightPhase1 = "MainBossFightPhase1";
                public const string MainBossFightPhase2 = "MainBossFightPhase2";
                public const string ToolBoxBossDefeat = "ToolBoxBossDefeat";
            }

            public struct WiredUp {
                public const string Start = "GrindSection_Start";
                public const string StartPostCutscene = "GrindSection_Start_PostCutscene";
                public const string SwapTracks = "GrindSection_SwapTracks";
                public const string ConnectCables = "GrindSection_ConnectCables";
                public const string PostFan = "GrindSection_PostFan";
                public const string GroundPound = "GrindSection_GroundPound";
                public const string Stargazing_Meet = "Stargazing_Meet"; // Realworld instead?
            }

            public struct FreshAir {
                public const string Intro = "Tree_Approach_LevelIntro";
                public const string Start = "Tree_Approach_LevelStart";
                public const string TreeSwing = "Tree_Approach_TreeSwing";
                public const string SquirrelHomeEntry = "Tree_Approach_SquirrelHomeEntry";
                public const string StudyFriends = "RealWorld_StudyFriends"; // Realworld instead?
                public const string Interrogation = "CS_Interrogation";
            }

            public struct Captured {
                public const string Entry = "Entry";
                public const string EntryNoCS = "Entry (No cutscene)";
                public const string Elevator = "Elevator";
                public const string Bridge = "Bridge";
                public const string HangingStuff = "HangingStuff";
                public const string BigWheels = "BigWheels";
                public const string Lift = "Lift";
                public const string FirstContact = "First Contact";
                public const string Ovens = "Ovens";
                public const string Crossing = "Crossing";
                public const string Rails = "Rails";
                public const string Vault = "Vault";
                public const string VaultShieldWasp = "Vault ShieldWasp";
            }

            public struct DeeplyRooted {
                public const string Entry = "Entry";
                public const string EntryNoCS = "Entry (No cutscene)";
                public const string Larva = "Larva";
                public const string Bottles = "Bottles";
                public const string Swarm = "Swarm";
                public const string Slide = "Slide";
                public const string SlidePart1 = "SlidePart1";
                public const string SlidePart2 = "SlidePart2";
                public const string SlidePart3 = "SlidePart3";
                public const string Boat = "Boat (Cutscene)";
                public const string BoatNoCS = "Boat (No cutscene)";
                public const string BoatCalm = "Boat Checkpoint Calm";
                public const string BoatSwarm = "Boat Checkpoint Swarm";
                public const string DarkRoom = "DarkRoom (Cutscene)";
                public const string DarkRoomNoCS = "DarkRoom (No cutscene)";
                public const string FirstLantern = "FirstLantern";
                public const string SecondLantern = "SecondLantern";
                public const string ThirdLantern = "ThirdLantern";
                public const string DarkRoomFlyingAnimal = "DarkRoom FlyingAnimal";
                public const string Elevator = "Elevator (Cutscene)";
                public const string ElevatorNoCS = "Elevator (No cutscene)";
                public const string ElevatorStart = "Elevator Start";
                public const string ElevatorShieldWasp = "Elevator (ShieldWasp)";
                public const string Beetle = "Beetle";
                public const string BeetleRide = "Beetle Ride";
                public const string BeetleRide_Part1 = "BeetleRide_Part1";
                public const string BeetleRide_Part2 = "BeetleRide_Part2";
                public const string BeetleRide_Part3 = "BeetleRide_Part3";
                public const string BeetleRide_Part4 = "BeetleRide_Part4";
                public const string BeetleRide_Part5 = "BeetleRide_Part5";
            }

            public struct Extermination {
                public const string StartWaspBossPhase1 = "StartWaspBossPhase1";
                public const string StartWaspBossPhase1_NoCutscene = "StartWaspBossPhase1_NoCutscene";
                public const string ShotOffFirstArmour = "ShotOffFirstArmour";
                public const string StartWaspBossPhase2 = "StartWaspBossPhase2";
                public const string StartWaspBossPhase2_2Left = "StartWaspBossPhase2_2Left";
                public const string StartWaspBossPhase2_1Left = "StartWaspBossPhase2_1Left";
                public const string StartWaspBossPhase3 = "StartWaspBossPhase3";
                public const string Flight = "CS_Flight";
            }

            public struct Getaway {
                public const string Intro = "Intro";
                public const string AfterSquirrelChaseCS = "AfterSquirrelChaseCS";
                public const string HouseReveal = "House Reveal";
                public const string BeforeCatapultRoom = "Before Catapult Room";
                public const string CanopyLevelSetLoad = "CanopyLevelSetLoad";
                public const string FightOutsideTree = "Fight outside tree";
                public const string CutsceneBeforeGlider = "Cutscene before glider";
                public const string Glider = "Glider Checkpoint";
                public const string GliderInTunnel = "Glider in tunnel";
                public const string GliderHalfway = "Glider halfway through";
                public const string RealWorld_Exterior_Roof_Crash = "RealWorld_Exterior_Roof_Crash";
            }

            public struct PillowFort {
                public const string Intro = "PillowFort";
                public const string IntroNoCS = "Pillowfort Intro No CS";
                public const string PillowfortFinalRoom = "PillowfortFinalRoom";
            }

            public struct SpacedOut {
                public const string Intro = "SpaceStationIntro";
                public const string IntroNoCS = "SpaceStationNoIntro";
                public const string FirstPortalPlatform = "FirstPortalPlatform";
                public const string FirstPortalPlatformCompleted = "FirstPortalPlatformCompleted";
                public const string SecondPortalPlatform = "SecondPortalPlatform";
                public const string SecondPortalPlatformCompleted = "SecondPortalPlatformCompleted";
                public const string MoonBaboonIntro = "MoonBaboonIntro";
                public const string MoonBaboonLaserPointer = "MoonBaboonLaserPointer";
                public const string MoonBaboonRocketPhase = "MoonBaboonRocketPhase";
                public const string MoonBaboonInsideUFO = "MoonBaboonInsideUFO";
                public const string MoonBaboonInsideUFO_Pedal = "MoonBaboonInsideUFO_Pedal";
                public const string MoonBaboonInsideUFO_Crusher = "MoonBaboonInsideUFO_Crusher";
                public const string MoonBaboonInsideUFO_ElectricWall = "MoonBaboonInsideUFO_ElectricWall";
                public const string MoonBaboonMoon = "MoonBaboonMoon";
                public const string SpaceStation_BossFight_BeamOut = "SpaceStation_BossFight_BeamOut";
            }

            public struct Hopscotch {
                public const string Intro = "Intro";
                public const string IntroNoCS = "Intro - No Cutscene";
                public const string GrindSection = "Grind Section";
                public const string Closet = "Closet";
                public const string CoathangerRopeway = "Coathanger Ropeway";
                public const string HomeWorkSection = "HomeWorkSection";
                public const string MarbleMazeRoom = "Marble Maze Room";
                public const string HopscotchDungeon = "Hopscotch Dungeon";
                public const string WhoopeeCushions = "Hopscotch Dungeon - Whoopee Cushions";
                public const string FirstBallFall = "First Ball Fall";
                public const string FidgetSpinners = "Fidget Spinners";
                public const string FidgetSpinnerTunnel = "Fidget Spinner Tunnel";
                public const string Elevator = "Elevator";
                public const string VoidWorld = "Void World";
                public const string SpawningFloor = "Spawning Floor";
                public const string KaleidoscopeIntro = "Kaleidoscope Intro";
                public const string EndOfKaleidoscope = "End of Kaleidoscope";
                public const string BeforeMirrorPuzzle = "Before Mirror Puzzle";
                public const string HomeWorkPen = "HomeWork Pen";
                public const string SIDECONTENT_PullbackCar = "SIDECONTENT_PullbackCar";
            }

            public struct Trainstation {
                public const string Intro = "Trainstation_Start";
                public const string IntroNoCS = "Trainstation_Start_NoCutscene";
                public const string LoadDinoLand = "LoadDinoLand";
            }

            public struct DinoLand {
                public const string Start = "Dinoland_Start";
                public const string LoadDinoLandToPirate = "LoadDInoLandToPirate";
                public const string SlamDinoPt1 = "Dinoland_SlamDinoPt1";
                public const string SlamDinoPt2 = "Dinoland_SlamDinoPt2";
                public const string SlamDinoPt3 = "Dinoland_SlamDinoPt3";
                public const string Platforming = "Dinoland_Platforming";
            }

            public struct PiratesAhoy {
                public const string Start = "Pirate_Part01_Start";
                public const string StartNoCS = "Pirate_Part01_StartWithoutCutscene";
                public const string Corridor = "Pirate_Part02_Corridor";
                public const string PirateShips = "Pirate_Part03_PirateShips";
                public const string PirateShips_End = "Pirate_Part04_PirateShips_End";
                public const string Stream = "Pirate_Part05_Stream";
                public const string BossCutScene = "Pirate_Part06_BossCutScene";
                public const string BossStart = "Pirate_Part06_BossStart";
                public const string BossHalfway = "Pirate_Part07_BossHalfway";
                public const string BossFinalPart = "Pirate_Part08_BossFinalPart";
                public const string BossEnd = "Pirate_Part09_BossEnd";
                public const string BossEndNoCS = "Pirate_Part09_BossEndWithoutCutscene";
            }

            public struct TheGreatestShow {
                public const string Start = "Circus_Start";
                public const string HamsterWheel = "Circus_HamsterWheel";
                public const string Carousel = "Circus_Carousel";
                public const string Cannon = "Circus_Cannon";
                public const string Monowheel = "Circus_Monowheel";
                public const string Trapeeze = "Circus_Trapeeze";
            }

            public struct OnceUponATime {
                public const string Start = "Castle_Courtyard_Start";
                public const string StartNoCS = "Courtyard_Start_NoIntro";
                public const string CranePuzzle = "Castle_Courtyard_CranePuzzle";
                public const string Painting = "MINIGAME_Painting";
            }

            public struct DungeonCrawler {
                public const string Intro = "Castle_Dungeon";
                public const string IntroNoCS = "Castle_Dungeon_NoCutscene";
                public const string DrawBridge = "Castle_Dungeon_DrawBridge";
                public const string PostDrawBridge = "Castle_Dungeon_PostDrawBridge";
                public const string Teleporter = "Castle_Dungeon_Teleporter";
                public const string PostTeleporter = "Castle_Dungeon_PostTeleporter";
                public const string FirePlatforms = "Castle_Dungeon_FirePlatforms";
                public const string CrusherConnector = "Castle_Dungeon_CrusherConnector";
                public const string Crusher = "Castle_Dungeon_Crusher";
                public const string ChargerConnector = "Castle_Dungeon_ChargerConnector";
                public const string Charger = "Castle_Dungeon_Charger";
                public const string ChessIntro = "Castle_Chessboard_Intro";
                public const string ChessBoss = "Castle_Chessboard_BossFIght";
                public const string DungeonNoTeleport = "Castle_Dungeon_NoTeleport";
                public const string ChessNoTeleport = "Castle_Chess_NoTeleport";
            }

            public struct TheQueen {
                public const string Intro = "Shelf_Cutie_Intro";
                public const string IntroNoCS = "Shelf_Cutie";
                public const string CutieStuckInHatch = "Shelf_CutieStuckInHatch";
                public const string RoseTears = "RealWorld_RoseTears";
                public const string TherapyRoom_Time_Session = "TherapyRoom_Time_Session";
            }

            public struct GatesOfTime {
                public const string Intro = "ClockworkIntro";
                public const string IntroNoCS = "Clockwork Intro - No Cutscene";
                public const string ClockTown = "ClockTown";
                public const string ClockTown_NoIntro = "ClockTown_NoIntro";
                public const string ClockTown_Valves = "ClockTown_Valves";
                public const string Forest = "Start Forest";
                public const string ForestNoCS = "Forest - No Cutscene";
                public const string LeftTowerPuzzle = "Left Tower Puizzle";
                public const string LeftTowerDestroyed = "Left_Tower_Destroyed"; // CHECK WITH GLINT
                public const string RightTowerPuzzle = "Right Tower Puzzle";
                public const string RightTowerDestroyed = "Right_Tower_Destroyed"; // CHECK WITH GLINT
                public const string Courtyard = "Tower_Courtyard";
            }

            public struct Clockworks {
                public const string Intro = "Crusher_Trap_Room";
                public const string IntroNoCS = "Crusher Room - No Intro";
                public const string Bridge = "Bridge";
                public const string StatueRoom = "Statue_Room";
                public const string CageRoom = "Cage Room";
                public const string MechanicalWallRoom = "Mechanical Wall Room";
                public const string StatueRoom1 = "Statue Room - Mech Wall Room Done"; // CHECK WITH GLINT
                public const string StatueRoom2 = "Statue Room - OTHER ROOM"; // CHECK WITH GLINT
                public const string StatueRoomComplete = "Statue Room - Both Side Rooms Completed";
                public const string BossFight = "Mini Boss Fight";
                public const string WallJumpCorridor = "Wall Jump Corridor";
                public const string Elevator_Room = "Elevator_Room";
                public const string PocketWatch = "Pocket_Watch_Room";
                public const string PathToEvilBird = "Path to Evil Bird";
                public const string EvilBirdRoom = "Evil Bird Room";
                public const string EvilBirdRoomStarted = "Evil Bird Room Started";
            }

            public struct ABlastFromThePast {
                public const string Intro = "Boss_Intro";
                public const string IntroNoCS = "Boss Intro - No cutscene";
                public const string Pendulum = "Boss Swinging Pendulums";
                public const string FreeFall = "Boss Clock Launch to Free Fall";
                public const string Rewind = "Boss Rewind Smasher";
                public const string DestroyCrusherRoom = "Destroy Crusher Room";
                public const string Explosion = "Explosion";
                public const string FinalExplosion = "Final Explosion";
                public const string Sprint = "Sprint To Couple";
                public const string EndingDev = "Ending Cutscene";
                public const string Ending = "Clockwork Ending";
                public const string RealWorld_House_LowerLevel_Clock = "RealWorld_House_LowerLevel_Clock";
                public const string TherapyRoom_Attraction_Session = "TherapyRoom_Attraction_Session";
            }

            public struct WarmingUp {
                public const string Entry = "Forest_Entry";
                public const string Gate = "Gate";
                public const string Timber = "Timber";
                public const string Mill = "Mill";
                public const string Flipper = "Flipper";
                public const string Cabin = "Cabin";
                public const string CaveTownGate = "CaveTownGate";
            }

            public struct WinterVillage {
                public const string Intro = "Town Entry";
                public const string IntroNoCS = "Town Entry No Cutscene";
                public const string Door = "Town Door";
                public const string Bobsled = "Town Bobsled";
            }

            public struct BeneathTheIce {
                public const string Intro = "Entry";
                public const string IntroNoCS = "Entry no cutscene";
                public const string CoreBase = "CoreBase";
                public const string LakeIceCave = "Lake Ice Cave";
                public const string IceCaveComplete = "Ice Cave Complete";
            }

            public struct SlipperySlopes {
                public const string Intro = "0. Entry";
                public const string IntroNoCS = "Entry no cutscene";
                public const string IceCave = "1. IceCave";
                public const string CaveSkating = "2. CaveSkating";
                public const string Collapse = "3. Collapse";
                public const string PlayerAttraction = "4. PlayerAttraction";
                public const string WindWalk = "5. WindWalk";
                public const string TerraceProposalCutscene = "TerraceProposalCutscene";
                public const string RealWorld_House_Kitchen_Sandwiches = "RealWorld_House_Kitchen_Sandwiches";
                public const string TherapyRoom_Garden_Session = "TherapyRoom_Garden_Session";
            }

            public struct GreenFingers {
                public const string Intro = "Garden_VegetablePatch_Intro";
                public const string IntroNoCS = "Garden_VegetablePatch_Intro_NoCutscene";
                public const string CactusCombatArea = "Cactus_Combat_Area";
                public const string Beanstalk = "Beanstalk_Section";
                public const string Burrown = "Burrown_Enemy";
                public const string BurrownCombat = "Burrown_Enemy_Combat";
                public const string Greenhouse = "Greenhouse_Window";
            }

            public struct WeedWhacking {
                public const string Intro = "Shrubbery_Enter";
                public const string IntroNoCS = "Shrubbery_Enter_NoIntro";
                public const string Sprinkler = "Shrubbery_Sprinkler";
                public const string StartCombat = "Shrubbery_StartCombat";
                public const string FirstCombatFinished = "Shrubbery_FirstCombatFinished";
                public const string DandelionLaunchers = "Shrubbery_DandelionLaunchers";
                public const string SecondSpider = "Shrubbery_SecondSpider";
                public const string SpinningLog = "Shrubbery_SpinningLog";
                public const string EnteringBigLog = "Shrubbery_EnteringBigLog";
                public const string BigLogCollapse = "Shrubbery_BigLogCollapse";
                public const string SinkingLog = "Shrubbery_SinkingLog";
                public const string PurpleSapWall = "Shrubbery_PurpleSapWall";
                public const string EnteringBigSpiderCave = "Shrubbery_EnteringBigSpiderCave";
                public const string AfterLeavingSpiders = "Shrubbery_AfterLeavingSpiders";
                public const string StartingFinalCombat = "Shrubbery_StartingFinalCombat";
                public const string StartingFinalCombatSecondWave = "StartingFinalCombatSecondWave";
                public const string SecondCombatFirstWaveFinished = "SecondCombatFirstWaveFinished";
                public const string FinalCombatFinished = "Shrubbery_FinalCombatFinished";
                public const string Outro = "Shrubbery_Outro";
            }

            public struct Trespassing {
                public const string Intro = "MoleTunnels_Level_Intro";
                public const string IntroNoCS = "MoleTunnels_Level_Start";
                public const string StealthStart = "MoleTunnels_Stealth_Start";
                public const string SneakyBushStart = "MoleTunnels_Stealth_SneakyBushStart";
                public const string SneakyBushMiddle = "MoleTunnels_Stealth_SneakyBushMiddle";
                public const string SneakyBushEnding = "MoleTunnels_Stealth_SneakyBushEnding";
                public const string StealthFinished = "MoleTunnels_Stealth_Finished";
                public const string MoleChaseStart = "MoleTunnels_MoleChase_Start";
                public const string TopDown = "MoleTunnels_MoleChase_TopDown";
                public const string TopDownSafeRoom = "MoleTunnels_MoleChase_TopDown_SafeRoom";
                public const string MoleChase2D = "MoleTunnels_MoleChase_2D";
                public const string MoleChase2DTreasureRoom = "MoleTunnels_MoleChase_2D_TreasureRoom";
            }

            public struct FrogPond {
                public const string Intro = "FrogPond_Intro";
                public const string IntroNoCS = "FrogPondIntroNoCS";
                public const string LilyPads = "LilyPads";
                public const string ScalePuzzle = "Scale_Puzzle";
                public const string SinkingPuzzle = "Sinking_Puzzle";
                public const string Frogger = "Frogger";
                public const string FishFountain = "Fish_Fountain_Puzzle";
                public const string MainFountain = "Main_Fountain_Puzzle";
                public const string TopMainFountain = "Top_of_Main_Fountain";
                public const string GrindSection = "GrindSection";
                public const string WindowPuzzle = "Greenhouse_Window_Puzzle";
            }

            public struct Affliction {
                public const string Intro = "Greenhouse_Intro";
                public const string IntroNoCS = "Greenhouse_StartGameplay";
                public const string FirstBulbExploded = "Greenhouse_FirstBulbExploded";
                public const string JoyIntro = "Joy_Bossfight_Intro";
                public const string Joy1Combat = "Joy_Bossfight_Phase_1_Combat";
                public const string Joy2 = "Joy_Bossfight_Phase_2";
                public const string Joy25 = "Joy_Bossfight_Phase_2_5";
                public const string Joy2Combat = "Joy_Bossfight_Phase_2_Combat";
                public const string Joy3 = "Joy_Bossfight_Phase_3";
                public const string Joy35 = "Joy_Bossfight_Phase_3_5";
                public const string Joy3Combat = "Joy_Bossfight_Phase_3_Combat";
                public const string RealWorld_FlowerPot = "RealWorld_FlowerPot";
                public const string TherapyRoom_Music = "TherapyRoom_Music";
            }

            public struct SettingTheStage {
                public const string Backstage = "ConcertHall_Backstage";
                public const string BackstageNoCS = "ConcertHall_Backstage_NoCS";
                public const string Classic = "ConcertHall_Classic";
                public const string ClassicNoCS = "ConcertHall_Classic_NoCS";
                public const string NightClub = "ConcertHall_NightClub";
                public const string NightClubNoCS = "ConcertHall_NightClub_NoCS";
            }

            public struct Rehearsal {
                public const string Intro = "Tutorial_Intro";
                public const string IntroNoCS = "Tutorial_Start";
                public const string DiskPuzzle = "Tutorial_Disk_Puzzle";
                public const string JukeboxStart = "JukeboxStart";
                public const string JukeboxCoinSlot = "Jukebox_CoinSlot";
                public const string JukeboxVinyl = "JukeboxVinyl";
                public const string PrePortableSpeaker = "PrePortableSpeaker";
                public const string PortableSpeaker = "PortableSpeaker";
                public const string SubBassRoom = "Sub_Bass_Room";
                public const string TrussRoom = "Truss_Room";
                public const string TrussRoomNoSubBassRoom = "Truss_Room_no_SubBassRoom";
                public const string MusicTechWallStart = "Music_Tech_Wall_Start";
                public const string MusicTechWallEQSweeper = "Music Tech Wall - EQ Sweeper";
                public const string SilentRoomIntro = "Silent_Room_Intro";
                public const string MicrophoneChaseDevDebugFallToGrind = "MicrophoneChaseDevDebugFallToGrind";
                public const string SilentRoomElevatorPillar = "Silent_Room_Elevator_Pillar";
                public const string SilentRoomEnd = "Silent_Room_End";
                public const string MicrophoneChase = "MicrophoneChase";
                public const string MicrophoneChaseAfterFirstGrind = "MicrophoneChase_After_First_Grind";
                public const string MicrophoneChaseEnding = "MicrophoneChase_Ending";
                public const string DrumMachineRoom = "DrumMachineRoom";
                public const string LightRoomPowerSwitch = "LightRoom PowerSwitch";
                public const string LightRoom = "LightRoom";
                public const string MicrophoneChaseDevDebugBreamCrush = "MicrophoneChaseDevDebugBreamCrush";
                public const string ChaseLanding = "Chase Landing";
                public const string MicrophoneChaseDoor = "MicrophoneChase Door";
            }

            public struct Symphony {
                public const string Intro = "Classic_01_Attic_Intro";
                public const string IntroNoCS = "Classic_01_Attic";
                public const string FlutePuzzle = "Classic_02_FlutePuzzle";
                public const string AccordionBox = "Classic_03_AccordionBox";
                public const string BridgePuzzle = "Classic_04_BridgePuzzle";
                public const string ShutterPuzzle = "Classic_05_ShutterPuzzle";
                public const string Heaven = "Classic_06_Heaven";
                public const string HeavenCageArea = "Classic_07_Heaven_CageArea";
                public const string HeavenCloudArea = "Classic_08_Heaven_CloudArea";
            }

            public struct TurnUp {
                public const string Intro = "RainbowSlide";
                public const string IntroNoCS = "RainBowSlideNoCutscene";
                public const string SlideEnding = "Slide_ending";
                public const string BeatPlatforming = "Beat_platforming";
                public const string PreDiscoballRide = "Pre_DiscoballRide";
                public const string DiscoBallRide = "DiscoBallRide";
                public const string BasementPreElevator = "Basement_pre_elevator";
                public const string DJDanceFloor = "DJ-Dancefloor";
                public const string AudioSurf = "AudioSurf";
            }

            public struct GrandFinale {
                public const string EndingIntro = "EndingIntro";
                public const string MayInDressingRoom = "MayInDressingRoom";
                public const string CodyBeforeFlipSwitch = "CodyBeforeFlipSwitch";
                public const string MayBeforeCurtains = "MayBeforeCurtains";
                public const string RealWorld_WakeUp = "RealWorld_WakeUp";
                public const string CreditIntro = "CreditIntro";
            }

            public struct Basement {
                public const string SeekersIntro = "SeekersIntro";
                public const string HouseInteriorStart = "HouseInteriorStart";
                public const string BasementBoss = "BasementBoss";
            }
        }
        private readonly struct Cutscene {
            public const string StartFormat = "Splits at the start of the {0} cutscene in {1}.";
            public const string EndFormat = "Splits at the end of the {0} cutscene in {1}.";
            
            public struct WakeUpCall {
                public const string Divorce_Intro = "Divorce_Intro";
                public const string FuseSocket_JumpOut = "FuseSocket_JumpOut";
                public const string FuseSocket_Activate = "FuseSocket_Activate";
                public const string Saw_Success = "Saw_Success";
            }

            public struct BitingTheDust {
                public const string Meet_Sucked = "Meet_Sucked";
                public const string Vacuum_Battle = "Vacuum_Battle";
                public const string LeftEyeSuckProgress = "LeftEyeSuckProgress";
                public const string RightEyeSuckProgress = "RightEyeSuckProgress";
                public const string BossFight_Outro = "BossFight_Outro";
            }

            public struct TheDepths {
                public const string Abyss_Intro = "Abyss_Intro";
                public const string Abyss_Rust = "Abyss_Rust";
                public const string MiniGame_Intro = "MiniGame_Intro";
                public const string MachineRoom_StartMachine = "MachineRoom_StartMachine";
                public const string ToolBoss_Battle = "ToolBoss_Battle";
                public const string ToolBoxBoss_BossIntro = "ToolBoxBoss_BossIntro";
                public const string ToolBoss_FirstPadLock = "ToolBoss_FirstPadLock";
                public const string ToolBoxBoss_KillLeftArm = "ToolBoxBoss_KillLeftArm";
                public const string ToolBoss_Defeat = "ToolBoss_Defeat";
                public const string ToolBoss_Outro = "ToolBoss_Outro";
            }

            public struct WiredUp {
                public const string ToolBoss_Door = "ToolBoss_Door";
                public const string Stargazing_Meet = "Intermediary 1";
            }

            public struct FreshAir {
                public const string Roof_Swing = "Roof_Swing";
                public const string Gate_Intro = "Gate_Intro";
                public const string Study_Friends = "Study_Friends";
                public const string Interrogation = "Interrogation";
            }

            public struct Captured {
                public const string WallDivide_Intro = "WallDivide_Intro";
            }

            public struct DeeplyRooted {
                public const string RobotQueen_Intro = "RobotQueen_Intro";
                public const string Boat_River = "Boat_River";
                public const string BoatSwarmCreation = "BoatSwarmCreation";
                public const string DarkRoom_Intro = "DarkRoom_Intro";
                public const string FallingFromDarkroom = "FallingFromDarkroom";
                public const string Arena_Intro = "Arena_Intro";
                public const string TreeBug_Ride = "TreeBug_Ride";
                public const string Bug_Crash = "Bug_Crash";
            }

            public struct Extermination {
                public const string Boss_Meet = "Boss_Meet";
                public const string PlaneIntro = "PlaneIntro";
                public const string SmashInWood = "SmashInWood";
                public const string Defeated = "Defeated";
                public const string Boss_Victory = "Boss_Victory";
                public const string Return_Flight = "Return_Flight";
            }

            public struct Getaway {
                public const string Flight_Chase = "Flight_Chase";
                public const string Chase_Outro = "Chase_Outro";
                public const string Plane_Combat = "Plane_Combat";
                public const string NoseDive_Intro = "NoseDive_Intro";
                public const string NoseDive_Crash = "NoseDive_Crash";
                public const string LivingRoom_Headache = "Intermediary 2";
                public const string Roof_Crash = "Roof_Crash";
            }

            public struct PillowFort {
                public const string Landing_Intro = "Landing_Intro";
                public const string Dolls_Dialogue = "A Way Out Dolls";
                public const string SpaceStation_Transport = "SpaceStation_Transport";
            }

            public struct SpacedOut {
                public const string BeamUp_Intro = "Intro";
                public const string FirstGeneratorActivated = "FirstGeneratorActivated";
                public const string BalanceScales_ReturnToPortal = "Green Portal Ending";
                public const string Planets_ReturnToPortal = "Red Portal Ending";
                public const string PlasmaBall_ReturnToPortal = "Purple Portal Ending";
                public const string SpaceBowl_ReturnToPortal = "Umbrella Portal Ending";
                public const string LaunchBoard_ReturnToPortal = "Pillow Portal Ending";
                public const string Electricity_ReturnToPortal = "Cube Portal Ending";
                public const string SecondGenerator = "SecondGenerator";
                public const string BossFight_Intro = "BossFight_Intro";
                public const string BossFight_PowerCoresDestroyed = "BossFight_PowerCoresDestroyed";
                public const string BossFight_RipOffLaserGun = "BossFight_RipOffLaserGun";
                public const string BossFight_RocketsPhaseFinished = "BossFight_RocketsPhaseFinished";
                public const string BossFight_Eject = "BossFight_Eject";
                public const string BossFight_Outro = "BossFight_Outro";
                public const string BossFight_BeamOut = "BossFight_BeamOut";
            }

            public struct Hopscotch {
                public const string UnderBed_Landing = "UnderBed_Landing";
                public const string Homework_FallThroughPlanks = "Homework_FallThroughPlanks";
                public const string Homework_FallThroughPlanksLanding = "Homework_FallThroughPlanksLanding";
                public const string CompletedFirstMaze = "CompletedFirstMaze";
                public const string CompletedSecondMaze = "CompletedSecondMaze";
                public const string WhoopeeSwivelDoorTransition = "WhoopeeSwivelDoorTransition";
                public const string Dungeon_TreasureChest = "Dungeon_TreasureChest";
                public const string Kaleidoscope_Elevator = "Kaleidoscope_Elevator";
                public const string MirrorPuzzle_EnterPuzzle = "MirrorPuzzle_EnterPuzzle";
                public const string Kaleidoscope_Outro = "Kaleidoscope_Outro";
            }

            public struct Dinoland {
                public const string DinoCrash_Intro = "DinoCrash_Intro";
                public const string PteranodonCrash = "PteranodonCrash";
                public const string DinoLand_DinoCrash_Outro = "DinoLand_DinoCrash_Outro";
            }

            public struct PiratesAhoy {
                public const string EnteringBoat = "EnteringBoat";
                public const string ShipsIntro = "ShipsIntro";
                public const string BossIntro_MainScene = "BossIntro_MainScene";
                public const string BossSlam_Left = "BossSlam_Left";
                public const string OctopusEnterPhase2 = "OctopusEnterPhase2";
                public const string OctopusEnterPhase3 = "OctopusEnterPhase3";
                public const string BossBoatJab = "BossBoatJab";
                public const string SquidDefeated = "SquidDefeated";
            }

            public struct TheGreatestShow {
                public const string Balloon_Intro = "Balloon_Intro";
                public const string SealsBounceBall = "SealsBounceBall";
                public const string Balloon_Outro = "Balloon_Outro";
                public const string CartRide_Flying = "CartRide_Flying";
            }

            public struct OnceUponATime {
                public const string CartLand = "CartLand";
                public const string PaperSquish_May = "PaperSquish_May";
                public const string PaperSquish_Cody = "PaperSquish_Cody";
                public const string Gate_Intro = "Gate_Intro";
            }

            public struct DungeonCrawler {
                public const string Dungeon_Cell = "Dungeon_Cell";
                public const string CrusherIntro = "CrusherIntro";
                public const string BridgeCollapse = "BridgeCollapse";
                public const string Dungeon_Outro = "Dungeon_Outro";
                public const string Chessboard_Intro = "Chessboard_Intro";
                public const string Chessboard_BossDeath = "Chessboard_BossDeath";
                public const string Chessboard_Outro = "Chessboard_Outro";
            }

            public struct TheQueen {
                public const string Elephant_Intro = "Elephant Intro";
                public const string CaughtByClaw = "Caught By Claw";
                public const string Towerhang_Finish = "Towerhang Finish";
                public const string LegPull_GetStuck = "Leg Pull Get Stuck";
                public const string LegPull_EarRip = "Leg Pull Ear Rip";
                public const string ToEdgeHang = "To Edge Hang";
                public const string Elephant_Outro = "Elephant Outro";
                public const string Bed_Crack = "Intermediary 3";
                public const string Bed_Tears = "Bed Tears";
                public const string TherapyRoom_Session_Theme_Time = "Therapy Room Time";
            }

            public struct GatesOfTime {
                public const string Time_Intro = "Time_Intro";
                public const string OpenFirstGate = "OpenFirstGate";
                public const string ClockTown_Intro = "ClockTown_Intro";
                public const string RevealHellTower = "RevealHellTower";
                public const string Gate_Vegetation = "Gate_Vegetation";
                public const string Bird_Intro = "Bird_Intro";
                public const string LeftTower_ElevatorDown = "LeftTower_ElevatorDown";
                public const string RightTower_OpenRightTower = "RightTower_OpenRightTower";
                public const string RightTower_ElevatorDown = "RightTower_ElevatorDown";
                public const string LeftTower_OpenLeftTower = "LeftTower_OpenLeftTower";
                public const string Tower_Intro = "Tower_Intro";
            }

            public struct Clockworks {
                public const string CrusherRoom_Intro = "CrusherRoom_Intro";
                public const string Bridge_Intro = "Bridge_Intro";
                public const string BullBoss_Intro = "BullBoss_Intro";
                public const string BullBoss_HitPillarFirstTime = "BullBoss_HitPillarFirstTime";
                public const string BullBoss_HitPillarSecondTime = "BullBoss_HitPillarSecondTime";
                public const string BullBoss_BullBossCrushed = "BullBoss_BullBossCrushed";
                public const string ChargerRoom_RoomDebris = "ChargerRoom_RoomDebris";
                public const string EvilBird_Intro = "EvilBird_Intro";
            }

            public struct ABlastFromThePast {
                public const string GlassWalkway_Intro = "Glass Walkway Intro";
                public const string LaunchingPlatform = "Launching Platform";
                public const string BuildingSmasherPlatform = "Building Smasher Platform";
                public const string AfterRewindSmash = "After Rewind Smash";
                public const string LastBoss_Explosion = "Last Boss Explosion";
                public const string Final_Explosion = "Final Explosion";
                public const string LandAfterExplosion = "Land After Explosion";
                public const string CodyEndingPlatform = "Cody Ending Platform";
                public const string MayEndingPlatform = "May Ending Platform";
                public const string EndingRewind = "Intermediary 4";
                public const string Time_Outro = "Time Outro";
                public const string RealWorld_House_LowerLevel_Clock = "RealWorld_House_LowerLevel_Clock";
                public const string TherapyRoom_Session_Theme_Attraction = "Therapy Room Attraction";
            }

            public struct WarmingUp {
                public const string Entrance_Intro = "Entrance Intro";
                public const string Find_Skates = "Find Skates";
            }

            public struct WinterVillage {
                public const string SnowCaveOpenGate = "SnowCaveOpenGate";
                public const string Bells_Intro = "Bells_Intro";
                public const string FirstBellRung = "FirstBellRung";
                public const string SecondGatesOpening = "SecondGatesOpening";
                public const string CraneBellRung = "CraneBellRung";
                public const string BigWheelBellRung = "BigWheelBellRung";
                public const string IceWallBellRung = "IceWallBellRung";
                public const string CableCartOpen = "CableCartOpen";
                public const string BobsledCompleted = "BobsledCompleted";
            }

            public struct BeneathTheIce {
                public const string Swimming_Intro = "Swimming_Intro";
                public const string Factory_Intro = "Factory_Intro";
                public const string IceCaveFinish = "IceCaveFinish";
                public const string FishDone = "FishDone";
                public const string BubbleDone = "BubbleDone";
                public const string CoreElevatorDoorOpen = "CoreElevatorDoorOpen";
                public const string SkiLift_Ride = "SkiLift Outro";
            }

            public struct SlipperySlopes {
                public const string SkiLift_Ride = "SkiLift Intro";
                public const string SmallCabin_Collapse = "SmallCabin_Collapse";
                public const string CollapseFall = "CollapseFall";
                public const string IceCave_Intro = "IceCave_Intro";
                public const string Ground_Elevator = "Ground_Elevator";
                public const string Terrace_Proposal = "Terrace_Proposal";
                public const string RealWorld_House_Kitchen_Sandwiches = "RealWorld_House_Kitchen_Sandwiches";
                public const string TherapyRoom_Session_Theme_Garden = "TherapyRoom_Session_Theme_Garden";
            }

            public struct GreenFingers {
                public const string Entrance_Intro = "Entrance_Intro";
                public const string Entrance_Outro = "Entrance_Outro";
                public const string BeanstalkFlowerGate = "BeanstalkFlowerGate";
                public const string Burrower_Intro = "Burrower_Intro";
                public const string SpaEntrance_May_Enter = "SpaEntrance_May_Enter";
                public const string SpaEntrance_May_Exit = "SpaEntrance_May_Exit";
                public const string SpaEntrance_Cody_Enter = "SpaEntrance_Cody_Enter";
                public const string SpaEntrance_Cody_Exit = "SpaEntrance_Cody_Exit";
                public const string OutsideGreenhouse_Unwither = "OutsideGreenhouse_Unwither";
                public const string Greenhouse_Intro = "Greenhouse_Intro";
            }

            public struct WeedWhacking {
                public const string Shrubbery_Intro = "Shrubbery_Intro";
                public const string IntroducingSpider = "IntroducingSpider";
                public const string SpiderIntro = "SpiderIntro";
                public const string SpiderMount = "SpiderMount";
                public const string LogCollapse = "LogCollapse";
                public const string EscapeFromSinkingLog = "EscapeFromSinkingLog";
                public const string SpiderNest_Outro = "SpiderNest_Outro";
                public const string CactusWaves_Intro = "CactusWaves_Intro";
                public const string SecondCombat_LeavesExtended = "SecondCombat_LeavesExtended";
                public const string PoisonCore_AreaOutro = "PoisonCore_AreaOutro";
            }

            public struct Trespassing {
                public const string LevelStart = "LevelStart";
                public const string PushPineCone = "PushPineCone";
                public const string Discovered_Part1 = "Discovered_Part1";
                public const string Discovered_Part1_Short = "Discovered_Part1_Short";
                public const string PlantDestroyed = "PlantDestroyed";
                public const string FallDownInto2D = "FallDownInto2D";
                public const string LevelEnding = "LevelEnding";
            }

            public struct FrogPond {
                public const string FrogRide = "FrogRide";
                public const string SmallerFountainPlatformsEnabled = "SmallerFountainPlatformsEnabled";
                public const string MainFountain_PoisonBulbDestroyed = "MainFountain_PoisonBulbDestroyed";
                public const string Greenhouse_OpenDoor = "Greenhouse_OpenDoor";
            }

            public struct Affliction {
                public const string Door_Intro = "Door_Intro";
                public const string Floor_KilledSmallBulb = "Floor_KilledSmallBulb";
                public const string RightbulbDestroyed = "RightbulbDestroyed";
                public const string LeftTable_KilledSmallBulb = "LeftTable_KilledSmallBulb";

                public const string MainArea_Greenified = "MainArea_Greenified";
                public const string BossRoom_Intro = "BossRoom_Intro";
                public const string BossRoom_CodyTakesControl = "BossRoom_CodyTakesControl";
                public const string BossRoom_DestroyFirstBlob = "BossRoom_DestroyFirstBlob";
                public const string BossRoom_ThrowSecondPot = "BossRoom_ThrowSecondPot";
                public const string BossRoom_CodyTakesControlPhaseTwo = "BossRoom_CodyTakesControlPhaseTwo";
                public const string BossRoom_ThrowThirdPot = "BossRoom_ThrowThirdPot";
                public const string BossRoom_CodyTakesControlPhaseThree = "BossRoom_CodyTakesControlPhaseThree";
                public const string BossRoom_Outro = "BossRoom_Outro";
                public const string RealWorld_House_RoseRoom_FlowerPot = "RealWorld_House_RoseRoom_FlowerPot";
                public const string TherapyRoom_Session_Theme_Music = "Therapy Room Music";
            }

            public struct SettingTheStage {
                public const string Backstage_Intro = "Backstage Intro";
                public const string EnteringBackstage = "Entering Backstage";
                public const string Backstage_Orchestra = "Backstage Orchestra";
                public const string EnteringClassic = "Entering Classic";
                public const string Backstage_Audience = "Backstage Audience";
                public const string NightClub_Entrance = "Entering Night Club";
            }

            public struct Rehearsal {
                public const string PortableSpeakerRoom_Intro = "Portable Speaker Room Intro";
                public const string Jukebox_CoinSuck = "Jukebox Coin Suck";
                public const string PortableSpeakerRoom_WindowBlast = "Portable Speaker Room Window Blast";
                public const string BassRoom_Landing = "Bass Room Landing";
                public const string MusicTechWall_GoingThroughTruss = "Music Tech Wall Going Through Truss";
                public const string MusicTechWall_Reveal = "Music Tech Wall Reveal";
                public const string MusicTechWall_PowerCableTravel = "Music Tech Wall Power Cable Travel";
                public const string MicrophoneRoom_MotherReveal = "Microphone Room Mother Reveal";
                public const string MicrophoneChase_FallToGrind = "Microphone Chase Fall To Grind";
                public const string MicrophoneChase_BrokenTruss = "Microphone Chase Broken Truss";
                public const string MicrophoneChase_Landing = "Microphone Chase Landing";
                public const string MicrophoneChase_Ending = "Microphone Chase Ending";
                public const string LightRoom_Entrance = "Light Room Entrance";
                public const string LightRoom_EndOfLightRoom = "End Of Light Room";
            }

            public struct Symphony {
                public const string EnterClassic = "Enter Symphony";
                public const string Flying = "Flying";
                public const string Reveal = "Reveal";
                public const string OpenBirdCage = "Open Bird Cage";
                public const string ReleaseFollowersCage = "Release Followers Cage";
                public const string OpenCloudRoom = "Open Cloud Room";
                public const string ReleaseFollowersCloud = "Release Followers Cloud";
                public const string LevelEnding = "Symphony Ending";
            }

            public struct TurnUp {
                public const string RainbowSlide_Intro = "Rainbow Slide Intro";
                public const string RainbowSlide_RespawnMay1 = "Rainbow Slide Respawn May";
                public const string RainbowSlide_RespawnCody1 = "Rainbow Slide Respawn Cody";
                public const string Discoball_GroundpoundStart = "Discoball Groundpound Start";
                public const string DiscoRide_BallCrash = "Disco Ride Ball Crash";
                public const string Basement_DjElevator = "Basement Dj Elevator";
                public const string Basement_Elevator = "Basement Elevator";
                public const string DJ_Outro = "DJ Outro";
            }

            public struct AGrandFinale {
                public const string DropDown_Preparation = "Drop Down Preparation";
                public const string DressingRoom_Mirror = "Dressing Room Mirror";
                public const string FirstCameraRide = "First Camera Ride";
                public const string SecondCameraRide = "Second Camera Ride";
                public const string GrandFinaleEnding = "Grand Finale Ending";
                public const string Smooch = "Smooch";
                public const string ClimacticKiss = "Climactic Kiss (End of run)";
                public const string RealWorld_House_Study_Wakeup = "Real World House Study Wakeup";
                public const string RealWorld_RoseRoom_Bed_Letter = "Real World RoseRoom Bed Letter";
                public const string RealWorld_Exterior_Busstop_Reunion = "Real World Exterior Busstop Reunion";
                public const string RealWorld_House_Credits_PlaceBook = "Real World House Credits Place Book";
            }

            public struct Basement {
                public const string TherapyRoom_Session_Theme_Love = "Therapy Room Basement";
                public const string Seekers_Door_Intro = "Seekers Door Intro";
                public const string BossRoom_Argue_Collapse = "Boss Room Argue Collapse";
                public const string BossRoom_Argue_Light = "Boss Room Argue Light";
                public const string Boss_GrayPlace_Letter = "Boss Gray Place Letter";
            }
        }

        private const string RCPOnly = "\nOnly available when restarting from checkpoint.";
        private const string Alternatives = "\n\nAlternative(s): ";
        #endregion

        public enum SplitName {

            #region Level Splits

            [Description(Level.Menu + Tag.Level),
                ToolTip(Level.Format, Level.Menu)]
            Menu_BP,


            [Description(Level.Awakening + Tag.Level),
                ToolTip(Level.Format, Level.Awakening)]
            Awakening_BP,

            [Description(Level.Vacuum + Tag.Level),
                ToolTip(Level.Format, Level.Vacuum)]
            Vacuum_BP,

            [Description(Level.Main_Hammernails + Tag.Level),
                ToolTip(Level.Format, Level.Main_Hammernails)]
            Main_Hammernails_BP,

            [Description(Level.Main_Grindsection + Tag.Level),
                ToolTip(Level.Format, Level.Main_Grindsection)]
            Main_Grindsection_BP,

            [Description(Level.RealWorld_Shed_StarGazing_Meet + Tag.Level),
                ToolTip(Level.Format, Level.RealWorld_Shed_StarGazing_Meet)]
            RealWorld_Shed_StarGazing_Meet_BP,


            [Description(Level.Approach + Tag.Level),
                ToolTip(Level.Format, Level.Approach)]
            Approach_BP,

            [Description(Level.RealWorld_House_Study_Friends + Tag.Level),
                ToolTip(Level.Format, Level.RealWorld_House_Study_Friends)]
            RealWorld_House_Study_Friends_BP,

            [Description(Level.SquirrelTurf_WarRoom + Tag.Level),
                ToolTip(Level.Format, Level.SquirrelTurf_WarRoom)]
            SquirrelTurf_WarRoom_BP,

            [Description(Level.SquirrelHome_BP_Mech + Tag.Level),
                ToolTip(Level.Format, Level.SquirrelHome_BP_Mech)]
            SquirrelHome_BP_Mech,

            [Description(Level.WaspsNest + Tag.Level),
                ToolTip(Level.Format, Level.WaspsNest)]
            WaspsNest_BP,

            [Description(Level.Tree_Boat + Tag.Level),
                ToolTip(Level.Format, Level.Tree_Boat)]
            Tree_Boat_BP,

            [Description(Level.Tree_Darkroom + Tag.Level),
                ToolTip(Level.Format, Level.Tree_Darkroom)]
            Tree_Darkroom_BP,

            [Description(Level.WaspsNest_Elevator + Tag.Level),
                ToolTip(Level.Format, Level.WaspsNest_Elevator)]
            WaspsNest_Elevator_BP,

            [Description(Level.WaspsNest_Beetle + Tag.Level),
                ToolTip(Level.Format, Level.WaspsNest_Beetle)]
            WaspsNest_Beetle_BP,

            [Description(Level.WaspsNest_BeetleRide + Tag.Level),
                ToolTip(Level.Format, Level.WaspsNest_BeetleRide)]
            WaspsNest_BeetleRide_BP,

            [Description(Level.WaspQueenBoss + Tag.Level),
                ToolTip(Level.Format, Level.WaspQueenBoss)]
            WaspQueenBoss_BP,

            [Description(Level.SquirrelTurf_Flight + Tag.Level),
                ToolTip(Level.Format, Level.SquirrelTurf_Flight)]
            SquirrelTurf_Flight_BP,

            [Description(Level.Escape + Tag.Level),
                ToolTip(Level.Format, Level.Escape)]
            Escape_BP,

            [Description(Level.RealWorld_Exterior_Roof_Crash + Tag.Level),
                ToolTip(Level.Format, Level.RealWorld_Exterior_Roof_Crash)]
            RealWorld_Exterior_Roof_Crash_BP,


            [Description(Level.PillowFort + Tag.Level),
                ToolTip(Level.Format, Level.PillowFort)]
            PillowFort_BP,

            [Description(Level.Spacestation_Hub + Tag.Level),
                ToolTip(Level.Format, Level.Spacestation_Hub)]
            Spacestation_Hub_BP,

            [Description(Level.SpaceStation_MoonBaboon + Tag.Level),
                ToolTip(Level.Format, Level.SpaceStation_MoonBaboon)]
            SpaceStation_MoonBaboon_BP,

            [Description(Level.Realworld_SpaceStation_Bossfight_BeamOut + Tag.Level),
                ToolTip(Level.Format, Level.Realworld_SpaceStation_Bossfight_BeamOut)]
            Realworld_SpaceStation_Bossfight_BeamOut_BP,

            [Description(Level.Hopscotch + Tag.Level),
                ToolTip(Level.Format, Level.Hopscotch)]
            Hopscotch_BP,

            [Description(Level.VoidWorld + Tag.Level),
                ToolTip(Level.Format, Level.VoidWorld)]
            VoidWorld_BP,

            [Description(Level.Kaleidoscope + Tag.Level),
                ToolTip(Level.Format, Level.Kaleidoscope)]
            Kaleidoscope_BP,

            [Description(Level.Goldberg_Trainstation + Tag.Level),
                ToolTip(Level.Format, Level.Goldberg_Trainstation)]
            Goldberg_Trainstation_BP,

            [Description(Level.Goldberg_Dinoland + Tag.Level),
                ToolTip(Level.Format, Level.Goldberg_Dinoland)]
            Goldberg_Dinoland_BP,

            [Description(Level.Goldberg_Pirate + Tag.Level),
                ToolTip(Level.Format, Level.Goldberg_Pirate)]
            Goldberg_Pirate_BP,

            [Description(Level.Goldberg_Circus + Tag.Level),
                ToolTip(Level.Format, Level.Goldberg_Circus)]
            Goldberg_Circus_BP,

            [Description(Level.Castle_Courtyard + Tag.Level),
                ToolTip(Level.Format, Level.Castle_Courtyard)]
            Castle_Courtyard_BP,

            [Description(Level.Castle_Dungeon + Tag.Level),
                ToolTip(Level.Format, Level.Castle_Dungeon)]
            Castle_Dungeon_BP,

            [Description(Level.Castle_Dungeon_Crusher + Tag.Level),
                ToolTip(Level.Format, Level.Castle_Dungeon_Crusher)]
            Castle_Dungeon_Crusher_BP,

            [Description(Level.Castle_Dungeon_Charger + Tag.Level),
                ToolTip(Level.Format, Level.Castle_Dungeon_Charger)]
            Castle_Dungeon_Charger_BP,

            [Description(Level.Castle_Chessboard + Tag.Level),
                ToolTip(Level.Format, Level.Castle_Chessboard)]
            Castle_Chessboard_BP,

            [Description(Level.Shelf + Tag.Level),
                ToolTip(Level.Format, Level.Shelf)]
            Shelf_BP,

            [Description(Level.RealWorld_RoseRoom_Bed_Tears + Tag.Level),
                ToolTip(Level.Format, Level.RealWorld_RoseRoom_Bed_Tears)]
            RealWorld_RoseRoom_Bed_Tears_BP,


            [Description(Level.TherapyRoom_Session_Theme_Time + Tag.Level),
                ToolTip(Level.Format, Level.TherapyRoom_Session_Theme_Time)]
            TherapyRoom_Session_Theme_Time_BP,

            [Description(Level.Clockwork_Tutorial + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_Tutorial)]
            Clockwork_Tutorial_BP,

            [Description(Level.Clockwork_ClockTown + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTown)]
            Clockwork_ClockTown_BP,

            [Description(Level.Clockwork_Forest + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_Forest)]
            Clockwork_Forest_BP,

            [Description(Level.Clockwork_ClockTowerLower_CrushingTrapRoom + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTowerLower_CrushingTrapRoom)]
            Clockwork_ClockTowerLower_CrushingTrapRoom_BP,

            [Description(Level.Clockwork_ClockTowerLower_BridgeIntro + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTowerLower_BridgeIntro)]
            Clockwork_ClockTowerLower_BridgeIntro_BP,

            [Description(Level.Clockwork_ClockTowerLower + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTowerLower)]
            Clockwork_ClockTowerLower_BP,

            [Description(Level.Clockwork_ClockTowerLower_WallJumpCorridor + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTowerLower_WallJumpCorridor)]
            Clockwork_ClockTowerLower_WallJumpCorridor_BP,

            [Description(Level.Clockwork_ClockTowerLower_CuckooBirdRoom + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTowerLower_CuckooBirdRoom)]
            Clockwork_ClockTowerLower_CuckooBirdRoom_BP,

            [Description(Level.Clockwork_ClockTowerLastBoss + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTowerLastBoss)]
            Clockwork_ClockTowerLastBoss_BP,

            [Description(Level.Clockwork_ClockTowerCourtyardCutscene + Tag.Level),
                ToolTip(Level.Format, Level.Clockwork_ClockTowerCourtyardCutscene)]
            Clockwork_ClockTowerCourtyardCutscene_BP,

            [Description(Level.RealWorld_House_LowerLevel_Clock + Tag.Level),
                ToolTip(Level.Format, Level.RealWorld_House_LowerLevel_Clock)]
            RealWorld_House_LowerLevel_Clock_BP,


            [Description(Level.TherapyRoom_Session_Theme_Attraction + Tag.Level),
                ToolTip(Level.Format, Level.TherapyRoom_Session_Theme_Attraction)]
            TherapyRoom_Session_Theme_Attraction_BP,

            [Description(Level.SnowGlobe_Forest + Tag.Level),
                ToolTip(Level.Format, Level.SnowGlobe_Forest)]
            SnowGlobe_Forest_BP,

            [Description(Level.SnowGlobe_Forest_TownGate + Tag.Level),
                ToolTip(Level.Format, Level.SnowGlobe_Forest_TownGate)]
            SnowGlobe_Forest_TownGate_BP,

            [Description(Level.SnowGlobe_Town + Tag.Level),
                ToolTip(Level.Format, Level.SnowGlobe_Town)]
            SnowGlobe_Town_BP,

            [Description(Level.SnowGlobe_Town_BobSled + Tag.Level),
                ToolTip(Level.Format, Level.SnowGlobe_Town_BobSled)]
            SnowGlobe_Town_BobSled,

            [Description(Level.Snowglobe_Lake + Tag.Level),
                ToolTip(Level.Format, Level.Snowglobe_Lake)]
            Snowglobe_Lake_BP,

            [Description(Level.SnowGlobe_Mountain + Tag.Level),
                ToolTip(Level.Format, Level.SnowGlobe_Mountain)]
            SnowGlobe_Mountain_BP,

            [Description(Level.SnowGlobe_Mountain_Collapse + Tag.Level),
                ToolTip(Level.Format, Level.SnowGlobe_Mountain_Collapse)]
            SnowGlobe_Mountain_Collapse_BP,

            [Description(Level.SnowGlobe_Mountain_PlayerAttraction + Tag.Level),
                ToolTip(Level.Format, Level.SnowGlobe_Mountain_PlayerAttraction)]
            SnowGlobe_Mountain_PlayerAttraction_BP,

            [Description(Level.Tower + Tag.Level),
                ToolTip(Level.Format, Level.Tower)]
            Tower_BP,

            [Description(Level.RealWorld_House_Kitchen_Sandwiches + Tag.Level),
                ToolTip(Level.Format, Level.RealWorld_House_Kitchen_Sandwiches)]
            RealWorld_House_Kitchen_Sandwiches_BP,


            [Description(Level.TherapyRoom_Session_Theme_Garden + Tag.Level),
                ToolTip(Level.Format, Level.TherapyRoom_Session_Theme_Garden)]
            TherapyRoom_Session_Theme_Garden_BP,

            [Description(Level.Garden_VegetablePatch + Tag.Level),
                ToolTip(Level.Format, Level.Garden_VegetablePatch)]
            Garden_VegetablePatch_BP,

            [Description(Level.Garden_Shrubbery + Tag.Level),
                ToolTip(Level.Format, Level.Garden_Shrubbery)]
            Garden_Shrubbery_BP,

            [Description(Level.Garden_Shrubbery_SecondCombat + Tag.Level),
                ToolTip(Level.Format, Level.Garden_Shrubbery_SecondCombat)]
            Garden_Shrubbery_SecondCombat_BP,

            [Description(Level.Garden_MoleTunnels_Stealth + Tag.Level),
                ToolTip(Level.Format, Level.Garden_MoleTunnels_Stealth)]
            Garden_MoleTunnels_Stealth_BP,

            [Description(Level.Garden_MoleTunnels_Chase + Tag.Level),
                ToolTip(Level.Format, Level.Garden_MoleTunnels_Chase)]
            Garden_MoleTunnels_Chase_BP,

            [Description(Level.Garden_FrogPond + Tag.Level),
                ToolTip(Level.Format, Level.Garden_FrogPond)]
            Garden_FrogPond_BP,

            [Description(Level.Garden_FrogPond_FountainPuzzle + Tag.Level),
                ToolTip(Level.Format, Level.Garden_FrogPond_FountainPuzzle)]
            Garden_FrogPond_FountainPuzzle_BP,

            [Description(Level.Garden_Greenhouse + Tag.Level),
                ToolTip(Level.Format, Level.Garden_Greenhouse)]
            Garden_Greenhouse_BP,

            [Description(Level.Garden_Greenhouse_JoysRoom + Tag.Level),
                ToolTip(Level.Format, Level.Garden_Greenhouse_JoysRoom)]
            Garden_Greenhouse_JoysRoom_BP,

            [Description(Level.RealWorld_RoseRoom_FlowerPot + Tag.Level),
                ToolTip(Level.Format, Level.RealWorld_RoseRoom_FlowerPot)]
            RealWorld_RoseRoom_FlowerPot_BP,

            [Description(Level.TherapyRoom_Session_Theme_Music + Tag.Level),
                ToolTip(Level.Format, Level.TherapyRoom_Session_Theme_Music)]
            TherapyRoom_Session_Theme_Music_BP,

            [Description(Level.Music_ConcertHall + Tag.Level),
                ToolTip(Level.Format, Level.Music_ConcertHall)]
            Music_ConcertHall_BP,

            [Description(Level.Music_Backstage_Tutorial + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_Tutorial)]
            Music_Backstage_Tutorial_BP,

            [Description(Level.Music_Backstage_PortableSpeakerRoom + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_PortableSpeakerRoom)]
            Music_Backstage_PortableSpeakerRoom_BP,

            [Description(Level.Music_Backstage_SubBassRoom + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_SubBassRoom)]
            Music_Backstage_SubBassRoom_BP,

            [Description(Level.Music_Backstage_TrussRoom + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_TrussRoom)]
            Music_Backstage_TrussRoom_BP,

            [Description(Level.Music_Backstage_MusicTechWall + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_MusicTechWall)]
            Music_Backstage_MusicTechWall_BP,

            [Description(Level.Music_Backstage_MurderMicrophoneRoom + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_MurderMicrophoneRoom)]
            Music_Backstage_MurderMicrophoneRoom_BP,

            [Description(Level.Music_Backstage_MicrophoneChase + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_MicrophoneChase)]
            Music_Backstage_MicrophoneChase_BP,

            [Description(Level.Music_Backstage_DrumMachineRoom + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_DrumMachineRoom)]
            Music_Backstage_DrumMachineRoom_BP,

            [Description(Level.Music_Backstage_LightRoom + Tag.Level),
                ToolTip(Level.Format, Level.Music_Backstage_LightRoom)]
            Music_Backstage_LightRoom_BP,

            [Description(Level.Music_Classic_Organ + Tag.Level),
                ToolTip(Level.Format, Level.Music_Classic_Organ)]
            Music_Classic_Organ_BP,

            [Description(Level.Music_Classic_Ending + Tag.Level),
                ToolTip(Level.Format, Level.Music_Classic_Ending)]
            Music_Classic_Ending_BP,

            [Description(Level.Music_Nightclub + Tag.Level),
                ToolTip(Level.Format, Level.Music_Nightclub)]
            Music_Nightclub_BP,

            [Description(Level.Music_Ending + Tag.Level),
                ToolTip(Level.Format, Level.Music_Ending)]
            Music_Ending_BP,


            [Description(Level.TherapyRoom_Session_Theme_Love + Tag.Level),
                ToolTip(Level.Format, Level.TherapyRoom_Session_Theme_Love)]
            TherapyRoom_Session_Theme_Love_BP,

            [Description(Level.Basement_Seekers + Tag.Level),
                ToolTip(Level.Format, Level.Basement_Seekers)]
            Basement_Seekers_BP,

            [Description(Level.Basement_HouseInterior + Tag.Level),
                ToolTip(Level.Format, Level.Basement_HouseInterior)]
            Basement_HouseInterior_BP,

            [Description(Level.Basement_Boss + Tag.Level),
                ToolTip(Level.Format, Level.Basement_Boss)]
            Basement_Boss_BP,

            #endregion

            #region Checkpoint Splits
            #region Intro
            [Description(Checkpoint.Intro.HouseKitchenDivorce + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Intro.HouseKitchenDivorce, Chapter.Intro)]
            RealWorld_RealWorld_House_Kitchen_Divorce,
            #endregion
            #region Wake-up Call
            [Description(Checkpoint.WakeUpCall.Start + Tag.Checkpoint), 
				ToolTip(Checkpoint.Format + 
                Alternatives + Cutscene.WakeUpCall.Divorce_Intro + Tag.CutsceneStart, 
                Checkpoint.WakeUpCall.Start, Chapter.WakeUpCall)]
            Shed_Awakening_Awakening_Start, 

            [Description(Checkpoint.WakeUpCall.FirstGameplay + Tag.Checkpoint), 
				ToolTip(Checkpoint.Format, Checkpoint.WakeUpCall.FirstGameplay, Chapter.WakeUpCall)]
            Shed_Awakening_Awakening_FirstGameplay, 

            [Description(Checkpoint.WakeUpCall.ChaseFuses + Tag.Checkpoint), 
				ToolTip(Checkpoint.Format, Checkpoint.WakeUpCall.ChaseFuses, Chapter.WakeUpCall)]
            Shed_Awakening_Awakening_ChaseFuses, // Awakening_ChaseFuses // Not actually "obtained" as in you can't RCP from it but can still split on it

            [Description(Checkpoint.WakeUpCall.FusesPutIn + Tag.Checkpoint), 
				ToolTip("Splits when putting in the last fuse in " + Chapter.WakeUpCall)]
            Shed_Awakening_FusesPutIn, // FusesPutIn
            #endregion
            #region Biting the Dust
            [Description(Checkpoint.BitingTheDust.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.Intro, Chapter.BitingTheDust)]
            Shed_Vacuum_VacuumIntro, 

            [Description(Checkpoint.BitingTheDust.NoIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.NoIntro, Chapter.BitingTheDust)]
            Shed_Vacuum_VacuumNoIntro, 

            [Description(Checkpoint.BitingTheDust.OilPit + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.OilPit, Chapter.BitingTheDust)]
            Shed_Vacuum_Oil_Pit, 

            [Description(Checkpoint.BitingTheDust.Generator + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.Generator, Chapter.BitingTheDust)]
            Shed_Vacuum_Generator, 

            [Description(Checkpoint.BitingTheDust.SideScroller + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.SideScroller, Chapter.BitingTheDust)]
            Shed_Vacuum_Side_Scroller, 

            [Description(Checkpoint.BitingTheDust.Stomach + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.Stomach, Chapter.BitingTheDust)]
            Shed_Vacuum_Stomach, 

            [Description(Checkpoint.BitingTheDust.PortalLoop + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.PortalLoop, Chapter.BitingTheDust)]
            Shed_Vacuum_Portal_Loop,

            [Description(Checkpoint.BitingTheDust.BossBackpack + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.BossBackpack, Chapter.BitingTheDust)]
            Shed_Vacuum_Boss_Backpack,

            [Description(Checkpoint.BitingTheDust.WeatherVane + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.WeatherVane, Chapter.BitingTheDust)]
            Shed_Vacuum_Weather_Vane,

            [Description(Checkpoint.BitingTheDust.PistonLauncher + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.PistonLauncher, Chapter.BitingTheDust)]
            Shed_Vacuum_Piston_Launcher,

            [Description(Checkpoint.BitingTheDust.WeightBowl + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.WeightBowl, Chapter.BitingTheDust)]
            Shed_Vacuum_Weight_Bowl, 

            [Description(Checkpoint.BitingTheDust.VacuumBoss + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.VacuumBoss, Chapter.BitingTheDust)]
            Shed_Vacuum_VacuumBoss, 

            [Description(Checkpoint.BitingTheDust.BossNoIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BitingTheDust.BossNoIntro, Chapter.BitingTheDust)]
            Shed_Vacuum_BossNoIntro, 
            #endregion
            #region The Depths
            [Description(Checkpoint.Depths.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Depths.Intro, Chapter.TheDepths)]
            Shed_Main_MineIntro, 

            [Description(Checkpoint.Depths.IntroNoCS + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.IntroNoCS, Chapter.TheDepths)]
            Shed_Main_MineIntroNoCutscene,

            [Description(Checkpoint.Depths.MineHammerMeeting + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MineHammerMeeting, Chapter.TheDepths)]
            Shed_Main_MineHammerMeeting,

            [Description(Checkpoint.Depths.TutorialPuzzle1 + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.TutorialPuzzle1, Chapter.TheDepths)]
            Shed_Main_TutorialPuzzle1, 

            [Description(Checkpoint.Depths.MineMainHub + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MineMainHub, Chapter.TheDepths)]
            Shed_Main_MineMainHub, 

            [Description(Checkpoint.Depths.MachineIntroPuzzle1 + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MachineIntroPuzzle1, Chapter.TheDepths)]
            Shed_Main_MachineIntroPuzzle1,

            [Description(Checkpoint.Depths.MineMachineRoom + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MineMachineRoom, Chapter.TheDepths)]
            Shed_Main_MineMachineRoom,

            [Description(Checkpoint.Depths.MineMachineRoomStarted + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MineMachineRoomStarted, Chapter.TheDepths)]
            Shed_Main_MineMachineRoomStarted,

            [Description(Checkpoint.Depths.MineMachineRoomHalfway + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MineMachineRoomHalfway, Chapter.TheDepths)]
            Shed_Main_MineMachineRoomHalfway, 

            [Description(Checkpoint.Depths.MachineRoomChickenRace + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MachineRoomChickenRace, Chapter.TheDepths)]
            Shed_Main_MachineRoomChickenRace, 

            [Description(Checkpoint.Depths.MachineRoomEnding + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MachineRoomEnding, Chapter.TheDepths)]
            Shed_Main_MachineRoomEnding, 

            [Description(Checkpoint.Depths.PreBossDoubleInteract + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.PreBossDoubleInteract, Chapter.TheDepths)]
            Shed_Main_Pre_Boss_Double_Interact, 

            [Description(Checkpoint.Depths.MainAndToolBoxCutscene + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MainAndToolBoxCutscene, Chapter.TheDepths)]
            Shed_Main_MainAndToolBoxCutscene, 

            [Description(Checkpoint.Depths.ToolBoxBossIntro + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.ToolBoxBossIntro, Chapter.TheDepths)]
            Shed_Main_ToolBoxBossIntro, 

            [Description(Checkpoint.Depths.ToolBoxBossHalfWay + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.ToolBoxBossHalfWay, Chapter.TheDepths)]
            Shed_Main_ToolBoxBossHalfWay, 

            [Description(Checkpoint.Depths.MainBossFightStarted + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MainBossFightStarted, Chapter.TheDepths)]
            Shed_Main_MainBossFightStarted, 

            [Description(Checkpoint.Depths.MainBossFightPhase1 + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MainBossFightPhase1, Chapter.TheDepths)]
            Shed_Main_MainBossFightPhase1, 

            [Description(Checkpoint.Depths.MainBossFightPhase2 + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.MainBossFightPhase2, Chapter.TheDepths)]
            Shed_Main_MainBossFightPhase2, 

            [Description(Checkpoint.Depths.ToolBoxBossDefeat + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Depths.ToolBoxBossDefeat, Chapter.TheDepths)]
            Shed_Main_ToolBoxBossDefeat, 

            #endregion
            #region Wired up
            [Description(Checkpoint.WiredUp.Start + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WiredUp.Start, Chapter.WiredUp)]
            Shed_Main_GrindSection_Start,

            [Description(Checkpoint.WiredUp.StartPostCutscene + Tag.Checkpoint),
                ToolTip(Checkpoint.Format + RCPOnly, Checkpoint.WiredUp.StartPostCutscene, Chapter.WiredUp)]
            Shed_Main_GrindSection_Start_PostCutscene,

            [Description(Checkpoint.WiredUp.SwapTracks + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WiredUp.SwapTracks, Chapter.WiredUp)]
            Shed_Main_GrindSection_SwapTracks,

            [Description(Checkpoint.WiredUp.ConnectCables + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WiredUp.ConnectCables, Chapter.WiredUp)]
            Shed_Main_GrindSection_ConnectCables,

            [Description(Checkpoint.WiredUp.PostFan + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WiredUp.PostFan, Chapter.WiredUp)]
            Shed_Main_GrindSection_PostFan,

            [Description(Checkpoint.WiredUp.GroundPound + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WiredUp.GroundPound, Chapter.WiredUp)]
            Shed_Main_GrindSection_GroundPound,

            [Description(Checkpoint.WiredUp.Stargazing_Meet + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WiredUp.Stargazing_Meet, Chapter.WiredUp)]
            RealWorld_Stargazing_Meet, 

            #endregion
            #region Fresh Air
            [Description(Checkpoint.FreshAir.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FreshAir.Intro, Chapter.FreshAir)]
            Tree_Approach_Tree_Approach_LevelIntro,

            [Description(Checkpoint.FreshAir.Start + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.FreshAir.Start, Chapter.FreshAir)]
            Tree_Approach_Tree_Approach_LevelStart,

            [Description(Checkpoint.FreshAir.TreeSwing + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.FreshAir.TreeSwing, Chapter.FreshAir)]
            Tree_Approach_Tree_Approach_TreeSwing,

            [Description(Checkpoint.FreshAir.SquirrelHomeEntry + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.FreshAir.SquirrelHomeEntry, Chapter.FreshAir)]
            Tree_Approach_Tree_Approach_SquirrelHomeEntry,

            [Description(Checkpoint.FreshAir.StudyFriends + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.FreshAir.StudyFriends, Chapter.FreshAir)]
            RealWorld_RealWorld_StudyFriends,

            [Description(Checkpoint.FreshAir.Interrogation + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.FreshAir.Interrogation, Chapter.FreshAir)]
            Tree_SquirreTurf_CS_Interrogation, 

            #endregion
            #region Captured
            [Description(Checkpoint.Captured.Entry + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Entry, Chapter.Captured)]
            Tree_SquirrelHome_Entry, 

            [Description(Checkpoint.Captured.EntryNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.EntryNoCS, Chapter.Captured)]
            Tree_SquirrelHome_Entry_No_cutscene, 

            [Description(Checkpoint.Captured.Elevator + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Elevator, Chapter.Captured)]
            Tree_SquirrelHome_Elevator, 

            [Description(Checkpoint.Captured.Bridge + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Bridge, Chapter.Captured)]
            Tree_SquirrelHome_Bridge, 

            [Description(Checkpoint.Captured.HangingStuff + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.HangingStuff, Chapter.Captured)]
            Tree_SquirrelHome_HangingStuff, 

            [Description(Checkpoint.Captured.BigWheels + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.BigWheels, Chapter.Captured)]
            Tree_SquirrelHome_BigWheels, 

            [Description(Checkpoint.Captured.Lift + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Lift, Chapter.Captured)]
            Tree_SquirrelHome_Lift, 

            [Description(Checkpoint.Captured.FirstContact + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.FirstContact, Chapter.Captured)]
            Tree_SquirrelHome_First_Contact, 

            [Description(Checkpoint.Captured.Ovens + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Ovens, Chapter.Captured)]
            Tree_SquirrelHome_Ovens, 

            [Description(Checkpoint.Captured.Crossing + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Crossing, Chapter.Captured)]
            Tree_SquirrelHome_Crossing, 

            [Description(Checkpoint.Captured.Rails + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Rails, Chapter.Captured)]
            Tree_SquirrelHome_Rails, 

            [Description(Checkpoint.Captured.Vault + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.Vault, Chapter.Captured)]
            Tree_SquirrelHome_Vault, 

            [Description(Checkpoint.Captured.VaultShieldWasp + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Captured.VaultShieldWasp, Chapter.Captured)]
            Tree_SquirrelHome_Vault_ShieldWasp, 

            #endregion
            #region Deeply Rooted
            [Description(Checkpoint.DeeplyRooted.Entry + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Entry, Chapter.DeeplyRooted)]
            Tree_WaspNest_Entry, 

            [Description(Checkpoint.DeeplyRooted.EntryNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.EntryNoCS, Chapter.DeeplyRooted)]
            Tree_WaspNest_Entry_No_cutscene, 

            [Description(Checkpoint.DeeplyRooted.Larva + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Larva, Chapter.DeeplyRooted)]
            Tree_WaspNest_Larva, 

            [Description(Checkpoint.DeeplyRooted.Bottles + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Bottles, Chapter.DeeplyRooted)]
            Tree_WaspNest_Bottles, 

            [Description(Checkpoint.DeeplyRooted.Swarm + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Swarm, Chapter.DeeplyRooted)]
            Tree_WaspNest_Swarm, 

            [Description(Checkpoint.DeeplyRooted.Slide + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Slide, Chapter.DeeplyRooted)]
            Tree_WaspNest_Slide, 

            [Description(Checkpoint.DeeplyRooted.SlidePart1 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.SlidePart1, Chapter.DeeplyRooted)]
            Tree_WaspNest_SlidePart1, 

            [Description(Checkpoint.DeeplyRooted.SlidePart2 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.SlidePart2, Chapter.DeeplyRooted)]
            Tree_WaspNest_SlidePart2, 

            [Description(Checkpoint.DeeplyRooted.SlidePart3 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.SlidePart3, Chapter.DeeplyRooted)]
            Tree_WaspNest_SlidePart3, 

            [Description(Checkpoint.DeeplyRooted.Boat + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Boat, Chapter.DeeplyRooted)]
            Tree_Boat_Boat_Cutscene, 

            [Description(Checkpoint.DeeplyRooted.BoatNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BoatNoCS, Chapter.DeeplyRooted)]
            Tree_Boat_Boat_No_cutscene, 

            [Description(Checkpoint.DeeplyRooted.BoatCalm + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BoatCalm, Chapter.DeeplyRooted)]
            Tree_Boat_Boat_Checkpoint_Calm, 

            [Description(Checkpoint.DeeplyRooted.BoatSwarm + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BoatSwarm, Chapter.DeeplyRooted)]
            Tree_Boat_Boat_Checkpoint_Swarm, 

            [Description(Checkpoint.DeeplyRooted.DarkRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.DarkRoom, Chapter.DeeplyRooted)]
            Tree_Darkroom_DarkRoom_Cutscene, 

            [Description(Checkpoint.DeeplyRooted.DarkRoomNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.DarkRoomNoCS, Chapter.DeeplyRooted)]
            Tree_Darkroom_DarkRoom_No_cutscene, 

            [Description(Checkpoint.DeeplyRooted.FirstLantern + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.FirstLantern, Chapter.DeeplyRooted)]
            Tree_Darkroom_FirstLantern, 

            [Description(Checkpoint.DeeplyRooted.SecondLantern + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.SecondLantern, Chapter.DeeplyRooted)]
            Tree_Darkroom_SecondLantern, 

            [Description(Checkpoint.DeeplyRooted.ThirdLantern + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.ThirdLantern, Chapter.DeeplyRooted)]
            Tree_Darkroom_ThirdLantern, 

            [Description(Checkpoint.DeeplyRooted.DarkRoomFlyingAnimal + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.DarkRoomFlyingAnimal, Chapter.DeeplyRooted)]
            Tree_Darkroom_DarkRoom_FlyingAnimal, 

            [Description(Checkpoint.DeeplyRooted.Elevator + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Elevator, Chapter.DeeplyRooted)]
            Tree_WaspNest_Elevator_Cutscene, 

            [Description(Checkpoint.DeeplyRooted.ElevatorNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.ElevatorNoCS, Chapter.DeeplyRooted)]
            Tree_WaspNest_Elevator_No_cutscene, 

            [Description(Checkpoint.DeeplyRooted.ElevatorStart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.ElevatorStart, Chapter.DeeplyRooted)]
            Tree_WaspNest_Elevator_Start, 

            [Description(Checkpoint.DeeplyRooted.ElevatorShieldWasp + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.ElevatorShieldWasp, Chapter.DeeplyRooted)]
            Tree_WaspNest_Elevator_ShieldWasp, 

            [Description(Checkpoint.DeeplyRooted.Beetle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.Beetle, Chapter.DeeplyRooted)]
            Tree_WaspNest_Beetle, 

            [Description(Checkpoint.DeeplyRooted.BeetleRide + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BeetleRide, Chapter.DeeplyRooted)]
            Tree_WaspNest_Beetle_Ride, 

            [Description(Checkpoint.DeeplyRooted.BeetleRide_Part1 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BeetleRide_Part1, Chapter.DeeplyRooted)]
            Tree_WaspNest_BeetleRide_Part1, 

            [Description(Checkpoint.DeeplyRooted.BeetleRide_Part2 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BeetleRide_Part2, Chapter.DeeplyRooted)]
            Tree_WaspNest_BeetleRide_Part2, 

            [Description(Checkpoint.DeeplyRooted.BeetleRide_Part3 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BeetleRide_Part3, Chapter.DeeplyRooted)]
            Tree_WaspNest_BeetleRide_Part3, 

            [Description(Checkpoint.DeeplyRooted.BeetleRide_Part4 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BeetleRide_Part4, Chapter.DeeplyRooted)]
            Tree_WaspNest_BeetleRide_Part4, 

            [Description(Checkpoint.DeeplyRooted.BeetleRide_Part5 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DeeplyRooted.BeetleRide_Part5, Chapter.DeeplyRooted)]
            Tree_WaspNest_BeetleRide_Part5, 

            #endregion
            #region Extermination
            [Description(Checkpoint.Extermination.StartWaspBossPhase1 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format + "\nObtained at the end of " + Chapter.DeeplyRooted, Checkpoint.Extermination.StartWaspBossPhase1, Chapter.Extermination)]
            Tree_Boss_StartWaspBossPhase1, // StartWaspBossPhase1

            [Description(Checkpoint.Extermination.StartWaspBossPhase1_NoCutscene + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Extermination.StartWaspBossPhase1_NoCutscene, Chapter.Extermination)]
            Tree_Boss_StartWaspBossPhase1_NoCutscene, // StartWaspBossPhase1_NoCutscene

            [Description(Checkpoint.Extermination.ShotOffFirstArmour + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Extermination.ShotOffFirstArmour, Chapter.Extermination)]
            Tree_Boss_ShotOffFirstArmour,

            [Description(Checkpoint.Extermination.StartWaspBossPhase2 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Extermination.StartWaspBossPhase2, Chapter.Extermination)]
            Tree_Boss_StartWaspBossPhase2,

            [Description(Checkpoint.Extermination.StartWaspBossPhase2_2Left + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Extermination.StartWaspBossPhase2_2Left, Chapter.Extermination)]
            Tree_Boss_StartWaspBossPhase2_2Left,

            [Description(Checkpoint.Extermination.StartWaspBossPhase2_1Left + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Extermination.StartWaspBossPhase2_1Left, Chapter.Extermination)]
            Tree_Boss_StartWaspBossPhase2_1Left,

            [Description(Checkpoint.Extermination.StartWaspBossPhase3 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Extermination.StartWaspBossPhase3, Chapter.Extermination)]
            Tree_Boss_StartWaspBossPhase3,

            [Description(Checkpoint.Extermination.Flight + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Extermination.Flight, Chapter.Extermination)]
            Tree_SquirreTurf_CS_Flight, // CS_Flight

            #endregion
            #region Getaway
            [Description(Checkpoint.Getaway.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.Intro, Chapter.Getaway)]
            Tree_Escape_Intro, // Intro

            [Description(Checkpoint.Getaway.BeforeCatapultRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.BeforeCatapultRoom, Chapter.Getaway)]
            Tree_Escape_Before_Catapult_Room,

            [Description(Checkpoint.Getaway.AfterSquirrelChaseCS + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.AfterSquirrelChaseCS, Chapter.Getaway)]
            Tree_Escape_AfterSquirrelChaseCS,

            [Description(Checkpoint.Getaway.HouseReveal + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.HouseReveal, Chapter.Getaway)]
            Tree_Escape_House_Reveal,

            [Description(Checkpoint.Getaway.CanopyLevelSetLoad + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.CanopyLevelSetLoad, Chapter.Getaway)]
            Tree_Escape_CanopyLevelSetLoad,

            [Description(Checkpoint.Getaway.FightOutsideTree + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.FightOutsideTree, Chapter.Getaway)]
            Tree_Escape_Fight_outside_tree,

            [Description(Checkpoint.Getaway.CutsceneBeforeGlider + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.CutsceneBeforeGlider, Chapter.Getaway)]
            Tree_Escape_Cutscene_before_glider,

            [Description(Checkpoint.Getaway.Glider + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.Glider, Chapter.Getaway)]
            Tree_Escape_Glider_Checkpoint,

            [Description(Checkpoint.Getaway.GliderInTunnel + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.GliderInTunnel, Chapter.Getaway)]
            Tree_Escape_Glider_in_tunnel,

            [Description(Checkpoint.Getaway.GliderHalfway + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.GliderHalfway, Chapter.Getaway)]
            Tree_Escape_Glider_halfway_through,

            [Description(Checkpoint.Getaway.RealWorld_Exterior_Roof_Crash + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Getaway.RealWorld_Exterior_Roof_Crash, Chapter.Getaway)]
            RealWorld_RealWorld_Exterior_Roof_Crash,

            #endregion
            #region Pillow Fort
            [Description(Checkpoint.PillowFort.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PillowFort.Intro, Chapter.PillowFort)]
            PlayRoom_PillowFort_PillowFort, // PillowFort

            [Description(Checkpoint.PillowFort.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PillowFort.IntroNoCS, Chapter.PillowFort)]
            PlayRoom_PillowFort_Pillowfort_Intro_No_CS, // Pillowfort Intro No CS

            [Description(Checkpoint.PillowFort.PillowfortFinalRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PillowFort.PillowfortFinalRoom, Chapter.PillowFort)]
            PlayRoom_PillowFort_PillowfortFinalRoom, // PillowfortFinalRoom

            #endregion
            #region Spaced Out
            [Description(Checkpoint.SpacedOut.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.Intro, Chapter.SpacedOut)]
            PlayRoom_Spacestation_SpaceStationIntro, // SpaceStationIntro

            [Description(Checkpoint.SpacedOut.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.IntroNoCS, Chapter.SpacedOut)]
            PlayRoom_Spacestation_SpaceStationNoIntro, // SpaceStationNoIntro

            [Description(Checkpoint.SpacedOut.FirstPortalPlatform + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.FirstPortalPlatform, Chapter.SpacedOut)]
            PlayRoom_Spacestation_FirstPortalPlatform, // FirstPortalPlatform

            [Description(Checkpoint.SpacedOut.FirstPortalPlatformCompleted + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.FirstPortalPlatformCompleted, Chapter.SpacedOut)]
            PlayRoom_Spacestation_FirstPortalPlatformCompleted, // FirstPortalPlatformCompleted

            [Description(Checkpoint.SpacedOut.SecondPortalPlatform + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.SecondPortalPlatform, Chapter.SpacedOut)]
            PlayRoom_Spacestation_SecondPortalPlatform, // SecondPortalPlatform

            [Description(Checkpoint.SpacedOut.SecondPortalPlatformCompleted + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.SecondPortalPlatformCompleted, Chapter.SpacedOut)]
            PlayRoom_Spacestation_SecondPortalPlatformCompleted, // SecondPortalPlatformCompleted

            [Description(Checkpoint.SpacedOut.MoonBaboonIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonIntro, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonIntro,

            [Description(Checkpoint.SpacedOut.MoonBaboonLaserPointer + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonLaserPointer, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonLaserPointer,

            [Description(Checkpoint.SpacedOut.MoonBaboonRocketPhase + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonRocketPhase, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonRocketPhase,

            [Description(Checkpoint.SpacedOut.MoonBaboonInsideUFO + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonInsideUFO, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonInsideUFO,

            [Description(Checkpoint.SpacedOut.MoonBaboonInsideUFO_Pedal + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonInsideUFO_Pedal, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonInsideUFO_Pedal,

            [Description(Checkpoint.SpacedOut.MoonBaboonInsideUFO_Crusher + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonInsideUFO_Crusher, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonInsideUFO_Crusher,

            [Description(Checkpoint.SpacedOut.MoonBaboonInsideUFO_ElectricWall + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonInsideUFO_ElectricWall, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonInsideUFO_ElectricWall,

            [Description(Checkpoint.SpacedOut.MoonBaboonMoon + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.MoonBaboonMoon, Chapter.SpacedOut)]
            PlayRoom_Spacestation_MoonBaboonMoon,

            [Description(Checkpoint.SpacedOut.SpaceStation_BossFight_BeamOut + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SpacedOut.SpaceStation_BossFight_BeamOut, Chapter.SpacedOut)]
            RealWorld_SpaceStation_BossFight_BeamOut,

            #endregion
            #region Hopscotch
            [Description(Checkpoint.Hopscotch.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.Intro, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Intro,

            [Description(Checkpoint.Hopscotch.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.IntroNoCS, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Intro_No_Cutscene,

            [Description(Checkpoint.Hopscotch.GrindSection + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.GrindSection, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Grind_Section,

            [Description(Checkpoint.Hopscotch.Closet + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.Closet, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Closet,

            [Description(Checkpoint.Hopscotch.CoathangerRopeway + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.CoathangerRopeway, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_CoathangerRopeway,

            [Description(Checkpoint.Hopscotch.HomeWorkSection + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.HomeWorkSection, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_HomeWorkSection,

            [Description(Checkpoint.Hopscotch.MarbleMazeRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.MarbleMazeRoom, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_MarbleMazeRoom,

            [Description(Checkpoint.Hopscotch.HopscotchDungeon + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.HopscotchDungeon, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_HopscotchDungeon,

            [Description(Checkpoint.Hopscotch.WhoopeeCushions + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.WhoopeeCushions, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_HopscotchDungeonWhoopeeCushions,

            [Description(Checkpoint.Hopscotch.FirstBallFall + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.FirstBallFall, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_FirstBallFall,

            [Description(Checkpoint.Hopscotch.FidgetSpinners + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.FidgetSpinners, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_FidgetSpinners,

            [Description(Checkpoint.Hopscotch.FidgetSpinnerTunnel + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.FidgetSpinnerTunnel, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_FidgetSpinnerTunnel,

            [Description(Checkpoint.Hopscotch.Elevator + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.Elevator, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Elevator,

            [Description(Checkpoint.Hopscotch.VoidWorld + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.VoidWorld, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Void_World,

            [Description(Checkpoint.Hopscotch.SpawningFloor + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.SpawningFloor, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Spawning_Floor,

            [Description(Checkpoint.Hopscotch.KaleidoscopeIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.KaleidoscopeIntro, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Kaleidoscope_Intro,

            [Description(Checkpoint.Hopscotch.EndOfKaleidoscope + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.EndOfKaleidoscope, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_End_of_Kaleidoscope,

            [Description(Checkpoint.Hopscotch.BeforeMirrorPuzzle + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.BeforeMirrorPuzzle, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_Before_Mirror_Puzzle,

            [Description(Checkpoint.Hopscotch.HomeWorkPen + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.HomeWorkPen, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_HomeWork_Pen,

            [Description(Checkpoint.Hopscotch.SIDECONTENT_PullbackCar + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Hopscotch.SIDECONTENT_PullbackCar, Chapter.Hopscotch)]
            PlayRoom_Hopscotch_SIDECONTENT_PullbackCar,

            #endregion
            #region Trainstation
            [Description(Checkpoint.Trainstation.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trainstation.Intro, Chapter.TrainStation)]
            PlayRoom_Goldberg_Trainstation_Start,

            [Description(Checkpoint.Trainstation.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trainstation.IntroNoCS, Chapter.TrainStation)]
            PlayRoom_Goldberg_Trainstation_Start_NoCutscene,

            [Description(Checkpoint.Trainstation.LoadDinoLand + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trainstation.LoadDinoLand, Chapter.TrainStation)]
            PlayRoom_Goldberg_LoadDinoLand,

            #endregion
            #region Dino land
            [Description(Checkpoint.DinoLand.Start + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DinoLand.Start, Chapter.DinoLand)]
            PlayRoom_Goldberg_Dinoland_Start,

            [Description(Checkpoint.DinoLand.LoadDinoLandToPirate + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.DinoLand.LoadDinoLandToPirate, Chapter.DinoLand)]
            PlayRoom_Goldberg_LoadDInoLandToPirate,

            [Description(Checkpoint.DinoLand.SlamDinoPt1 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DinoLand.SlamDinoPt1, Chapter.DinoLand)]
            PlayRoom_Goldberg_Dinoland_SlamDinoPt1,

            [Description(Checkpoint.DinoLand.SlamDinoPt2 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DinoLand.SlamDinoPt2, Chapter.DinoLand)]
            PlayRoom_Goldberg_Dinoland_SlamDinoPt2,

            [Description(Checkpoint.DinoLand.SlamDinoPt3 + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.DinoLand.SlamDinoPt3, Chapter.DinoLand)]
            PlayRoom_Goldberg_Dinoland_SlamDinoPt3,

            [Description(Checkpoint.DinoLand.Platforming + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DinoLand.Platforming, Chapter.DinoLand)]
            PlayRoom_Goldberg_Dinoland_Platforming,

            

            #endregion
            #region Pirate's Ahoy
            [Description(Checkpoint.PiratesAhoy.Start + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.Start, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part01_Start,

            [Description(Checkpoint.PiratesAhoy.StartNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.StartNoCS, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part01_StartWithoutCutscene,

            [Description(Checkpoint.PiratesAhoy.Corridor + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.Corridor, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part02_Corridor,

            [Description(Checkpoint.PiratesAhoy.PirateShips + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.PirateShips, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part03_PirateShips,

            [Description(Checkpoint.PiratesAhoy.PirateShips_End + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.PirateShips_End, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part04_PirateShips_End,

            [Description(Checkpoint.PiratesAhoy.Stream + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.Stream, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part05_Stream,

            [Description(Checkpoint.PiratesAhoy.BossCutScene + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.BossCutScene, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part06_BossCutScene,

            [Description(Checkpoint.PiratesAhoy.BossStart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.BossStart, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part06_BossStart,

            [Description(Checkpoint.PiratesAhoy.BossHalfway + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.BossHalfway, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part07_BossHalfway,

            [Description(Checkpoint.PiratesAhoy.BossFinalPart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.BossFinalPart, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part08_BossFinalPart,

            [Description(Checkpoint.PiratesAhoy.BossEnd + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.BossEnd, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part09_BossEnd,

            [Description(Checkpoint.PiratesAhoy.BossEndNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.PiratesAhoy.BossEndNoCS, Chapter.PiratesAhoy)]
            PlayRoom_Goldberg_Pirate_Part09_BossEndWithoutCutscene,

            #endregion
            #region The Greatest Show
            [Description(Checkpoint.TheGreatestShow.Start + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheGreatestShow.Start, Chapter.TheGreatestShow)]
            PlayRoom_Goldberg_Circus_Start,

            [Description(Checkpoint.TheGreatestShow.HamsterWheel + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheGreatestShow.HamsterWheel, Chapter.TheGreatestShow)]
            PlayRoom_Goldberg_Circus_HamsterWheel,

            [Description(Checkpoint.TheGreatestShow.Carousel + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheGreatestShow.Carousel, Chapter.TheGreatestShow)]
            PlayRoom_Goldberg_Circus_Carousel,

            [Description(Checkpoint.TheGreatestShow.Cannon + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheGreatestShow.Cannon, Chapter.TheGreatestShow)]
            PlayRoom_Goldberg_Circus_Cannon,

            [Description(Checkpoint.TheGreatestShow.Monowheel + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheGreatestShow.Monowheel, Chapter.TheGreatestShow)]
            PlayRoom_Goldberg_Circus_Monowheel,

            [Description(Checkpoint.TheGreatestShow.Trapeeze + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheGreatestShow.Trapeeze, Chapter.TheGreatestShow)]
            PlayRoom_Goldberg_Circus_Trapeeze,

            #endregion
            #region Once Upon A Time
            [Description(Checkpoint.OnceUponATime.Start + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.OnceUponATime.Start, Chapter.OnceUponATime)]
            PlayRoom_Courtyard_Castle_Courtyard_Start,

            [Description(Checkpoint.OnceUponATime.StartNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.OnceUponATime.StartNoCS, Chapter.OnceUponATime)]
            PlayRoom_Courtyard_Castle_Courtyard_Start_NoIntro,

            [Description(Checkpoint.OnceUponATime.CranePuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.OnceUponATime.CranePuzzle, Chapter.OnceUponATime)]
            PlayRoom_Courtyard_Castle_Courtyard_CranePuzzle,

            [Description(Checkpoint.OnceUponATime.Painting + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.OnceUponATime.Painting, Chapter.OnceUponATime)]
            PlayRoom_Courtyard_MINIGAME_Painting,

            #endregion
            #region Dungeon Crawler
            [Description(Checkpoint.DungeonCrawler.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.Intro, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon,

            [Description(Checkpoint.DungeonCrawler.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.IntroNoCS, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_NoCutscene,

            [Description(Checkpoint.DungeonCrawler.DrawBridge + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.DrawBridge, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_DrawBridge,

            [Description(Checkpoint.DungeonCrawler.PostDrawBridge + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.PostDrawBridge, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_PostDrawBridge,

            [Description(Checkpoint.DungeonCrawler.Teleporter + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.Teleporter, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_Teleporter,

            [Description(Checkpoint.DungeonCrawler.PostTeleporter + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.PostTeleporter, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_PostTeleporter,

            [Description(Checkpoint.DungeonCrawler.FirePlatforms + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.FirePlatforms, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_FirePlatforms,

            [Description(Checkpoint.DungeonCrawler.CrusherConnector + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.CrusherConnector, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_CrusherConnector,

            [Description(Checkpoint.DungeonCrawler.Crusher + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.Crusher, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_Crusher,

            [Description(Checkpoint.DungeonCrawler.ChargerConnector + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.ChargerConnector, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_ChargerConnector,

            [Description(Checkpoint.DungeonCrawler.Charger + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.Charger, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_Charger,

            [Description(Checkpoint.DungeonCrawler.ChessIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.ChessIntro, Chapter.DungeonCrawler)]
            PlayRoom_Chessboard_Castle_Chessboard_Intro,

            [Description(Checkpoint.DungeonCrawler.ChessBoss + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.ChessBoss, Chapter.DungeonCrawler)]
            PlayRoom_Chessboard_Castle_Chessboard_BossFIght,

            [Description(Checkpoint.DungeonCrawler.DungeonNoTeleport + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.DungeonNoTeleport, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon_Castle_Dungeon_NoTeleport,

            [Description(Checkpoint.DungeonCrawler.ChessNoTeleport + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.DungeonCrawler.ChessNoTeleport, Chapter.DungeonCrawler)]
            PlayRoom_Chessboard_Castle_Chess_NoTeleport,

            #endregion
            #region The Queen
            [Description(Checkpoint.TheQueen.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheQueen.Intro, Chapter.TheQueen)]
            PlayRoom_Shelf_Shelf_Cutie_Intro,

            [Description(Checkpoint.TheQueen.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheQueen.IntroNoCS, Chapter.TheQueen)]
            PlayRoom_Shelf_Shelf_Cutie,

            [Description(Checkpoint.TheQueen.CutieStuckInHatch + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheQueen.CutieStuckInHatch, Chapter.TheQueen)]
            PlayRoom_Shelf_Shelf_CutieStuckInHatch,

            [Description(Checkpoint.TheQueen.RoseTears + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheQueen.RoseTears, Chapter.TheQueen)]
            RealWorld_RealWorld_RoseTears,

            [Description(Checkpoint.TheQueen.TherapyRoom_Time_Session + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TheQueen.TherapyRoom_Time_Session, Chapter.TheQueen)]
            TherapyRoom_TherapyRoom_Time_Session,

            #endregion
            #region Gates of Time
            [Description(Checkpoint.GatesOfTime.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.Intro, Chapter.GatesOfTime)]
            Clockwork_Outside_ClockworkIntro,

            [Description(Checkpoint.GatesOfTime.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.IntroNoCS, Chapter.GatesOfTime)]
            Clockwork_Outside_Clockwork_Intro_No_Cutscene,

            [Description(Checkpoint.GatesOfTime.ClockTown + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.ClockTown, Chapter.GatesOfTime)]
            Clockwork_Outside_ClockTown,

            [Description(Checkpoint.GatesOfTime.ClockTown_NoIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.ClockTown_NoIntro, Chapter.GatesOfTime)]
            Clockwork_Outside_ClockTown_NoIntro,

            [Description(Checkpoint.GatesOfTime.ClockTown_Valves + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.ClockTown_Valves, Chapter.GatesOfTime)]
            Clockwork_Outside_ClockTown_Valves,

            [Description(Checkpoint.GatesOfTime.Forest + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.Forest, Chapter.GatesOfTime)]
            Clockwork_Outside_Start_Forest,

            [Description(Checkpoint.GatesOfTime.ForestNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.ForestNoCS, Chapter.GatesOfTime)]
            Clockwork_Outside_Forest_No_Cutscene,

            [Description(Checkpoint.GatesOfTime.LeftTowerPuzzle + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.LeftTowerPuzzle, Chapter.GatesOfTime)]
            Clockwork_Outside_Left_Tower_Puizzle,

            [Description(Checkpoint.GatesOfTime.LeftTowerDestroyed + Tag.Checkpoint), 
				ToolTip(Checkpoint.Format + "\n NOTE: CHECK WITH GLINT - Regarding Right, Left and Courtyard", 
                Checkpoint.GatesOfTime.LeftTowerDestroyed, Chapter.GatesOfTime)]
            Clockwork_Outside_Left_Tower_Destroyed,

            [Description(Checkpoint.GatesOfTime.RightTowerPuzzle + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.RightTowerPuzzle, Chapter.GatesOfTime)]
            Clockwork_Outside_Right_Tower_Puzzle,

            [Description(Checkpoint.GatesOfTime.RightTowerDestroyed + Tag.Checkpoint), 
				ToolTip(Checkpoint.Format + "\n NOTE: CHECK WITH GLINT - Regarding Right, Left and Courtyard", 
                Checkpoint.GatesOfTime.RightTowerDestroyed, Chapter.GatesOfTime)]
            Clockwork_Outside_Right_Tower_Destroyed,

            [Description(Checkpoint.GatesOfTime.Courtyard + Tag.Checkpoint), 
				ToolTip(Checkpoint.Format, Checkpoint.GatesOfTime.Courtyard, Chapter.GatesOfTime)]
            Clockwork_Outside_Tower_Courtyard,

            #endregion
            #region Clockworks
            [Description(Checkpoint.Clockworks.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.Intro, Chapter.Clockworks)]
            Clockwork_LowerTower_Crusher_Trap_Room,

            [Description(Checkpoint.Clockworks.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.IntroNoCS, Chapter.Clockworks)]
            Clockwork_LowerTower_Crusher_Room_No_Intro,

            [Description(Checkpoint.Clockworks.Bridge + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.Bridge, Chapter.Clockworks)]
            Clockwork_LowerTower_Bridge,

            [Description(Checkpoint.Clockworks.StatueRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.StatueRoom, Chapter.Clockworks)]
            Clockwork_LowerTower_Statue_Room,

            [Description(Checkpoint.Clockworks.CageRoom + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.CageRoom, Chapter.Clockworks)]
            Clockwork_LowerTower_Cage_Room,

            [Description(Checkpoint.Clockworks.MechanicalWallRoom + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.MechanicalWallRoom, Chapter.Clockworks)]
            Clockwork_LowerTower_Mechanical_Wall_Room,

            [Description(Checkpoint.Clockworks.StatueRoom1 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format + "\n NOTE: CHECK WITH GLINT - Regarding side rooms", 
                Checkpoint.Clockworks.StatueRoom1, Chapter.Clockworks)]
            Clockwork_LowerTower_Statue_Room_Mech_Wall_Room_Done,

            [Description(Checkpoint.Clockworks.StatueRoom2 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format + "\n NOTE: CHECK WITH GLINT - Regarding side rooms", 
                Checkpoint.Clockworks.StatueRoom2, Chapter.Clockworks)]
            Clockwork_LowerTower_Statue_Room_OTHER_ROOM,

            [Description(Checkpoint.Clockworks.StatueRoomComplete + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.StatueRoomComplete, Chapter.Clockworks)]
            Clockwork_LowerTower_Statue_Room_Both_Side_Rooms_Completed,

            [Description(Checkpoint.Clockworks.BossFight + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.BossFight, Chapter.Clockworks)]
            Clockwork_LowerTower_Mini_Boss_Fight,

            [Description(Checkpoint.Clockworks.WallJumpCorridor + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.WallJumpCorridor, Chapter.Clockworks)]
            Clockwork_LowerTower_Wall_Jump_Corridor,

            [Description(Checkpoint.Clockworks.Elevator_Room + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.Elevator_Room, Chapter.Clockworks)]
            Clockwork_LowerTower_Elevator_Room,

            [Description(Checkpoint.Clockworks.PocketWatch + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.PocketWatch, Chapter.Clockworks)]
            Clockwork_LowerTower_Pocket_Watch_Room,

            [Description(Checkpoint.Clockworks.PathToEvilBird + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.PathToEvilBird, Chapter.Clockworks)]
            Clockwork_LowerTower_Path_to_Evil_Bird,

            [Description(Checkpoint.Clockworks.EvilBirdRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.EvilBirdRoom, Chapter.Clockworks)]
            Clockwork_LowerTower_Evil_Bird_Room,

            [Description(Checkpoint.Clockworks.EvilBirdRoomStarted + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Clockworks.EvilBirdRoomStarted, Chapter.Clockworks)]
            Clockwork_LowerTower_Evil_Bird_Room_Started,

            #endregion
            #region A Blast from the Past
            [Description(Checkpoint.ABlastFromThePast.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.Intro, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Boss_Intro,

            [Description(Checkpoint.ABlastFromThePast.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.IntroNoCS, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Boss_Intro_No_cutscene,

            [Description(Checkpoint.ABlastFromThePast.Pendulum + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.Pendulum, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Boss_Swinging_Pendulums,

            [Description(Checkpoint.ABlastFromThePast.FreeFall + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.FreeFall, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Boss_Clock_Launch_to_Free_Fall,

            [Description(Checkpoint.ABlastFromThePast.Rewind + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.Rewind, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Boss_Rewind_Smasher,

            [Description(Checkpoint.ABlastFromThePast.DestroyCrusherRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.DestroyCrusherRoom, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Destroy_Crusher_Room,

            [Description(Checkpoint.ABlastFromThePast.Explosion + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.Explosion, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Explosion,

            [Description(Checkpoint.ABlastFromThePast.FinalExplosion + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.FinalExplosion, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Final_Explosion,

            [Description(Checkpoint.ABlastFromThePast.Sprint + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.Sprint, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Sprint_To_Couple,

            [Description(Checkpoint.ABlastFromThePast.EndingDev + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.EndingDev, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower_Ending_Cutscene,

            [Description(Checkpoint.ABlastFromThePast.Ending + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.Ending, Chapter.ABlastFromThePast)]
            Clockwork_Outside_Clockwork_Ending,

            [Description(Checkpoint.ABlastFromThePast.RealWorld_House_LowerLevel_Clock + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.RealWorld_House_LowerLevel_Clock, Chapter.ABlastFromThePast)]
            RealWorld_RealWorld_House_LowerLevel_Clock,

            [Description(Checkpoint.ABlastFromThePast.TherapyRoom_Attraction_Session + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.ABlastFromThePast.TherapyRoom_Attraction_Session, Chapter.ABlastFromThePast)]
            TherapyRoom_TherapyRoom_Attraction_Session,

            #endregion
            #region Warming Up
            [Description(Checkpoint.WarmingUp.Entry + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WarmingUp.Entry, Chapter.WarmingUp)]
            SnowGlobe_Forest_Forest_Entry,

            [Description(Checkpoint.WarmingUp.Gate + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WarmingUp.Gate, Chapter.WarmingUp)]
            SnowGlobe_Forest_Gate,

            [Description(Checkpoint.WarmingUp.Timber + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WarmingUp.Timber, Chapter.WarmingUp)]
            SnowGlobe_Forest_Timber,

            [Description(Checkpoint.WarmingUp.Mill + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WarmingUp.Mill, Chapter.WarmingUp)]
            SnowGlobe_Forest_Mill,

            [Description(Checkpoint.WarmingUp.Flipper + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WarmingUp.Flipper, Chapter.WarmingUp)]
            SnowGlobe_Forest_Flipper,

            [Description(Checkpoint.WarmingUp.Cabin + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WarmingUp.Cabin, Chapter.WarmingUp)]
            SnowGlobe_Forest_Cabin,

            [Description(Checkpoint.WarmingUp.CaveTownGate + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WarmingUp.CaveTownGate, Chapter.WarmingUp)]
            SnowGlobe_Forest_CaveTownGate,

            #endregion
            #region Winter Village
            [Description(Checkpoint.WinterVillage.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WinterVillage.Intro, Chapter.WinterVillage)]
            SnowGlobe_Town_Town_Entry,

            [Description(Checkpoint.WinterVillage.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WinterVillage.IntroNoCS, Chapter.WinterVillage)]
            SnowGlobe_Town_Town_Entry_No_cutscene,

            [Description(Checkpoint.WinterVillage.Door + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WinterVillage.Door, Chapter.WinterVillage)]
            SnowGlobe_Town_Town_Door,

            [Description(Checkpoint.WinterVillage.Bobsled + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WinterVillage.Bobsled, Chapter.WinterVillage)]
            SnowGlobe_Town_Town_Bobsled,

            #endregion
            #region Beneath the ice
            [Description(Checkpoint.BeneathTheIce.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BeneathTheIce.Intro, Chapter.BeneathTheIce)]
            SnowGlobe_Lake_Entry,

            [Description(Checkpoint.BeneathTheIce.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BeneathTheIce.IntroNoCS, Chapter.BeneathTheIce)]
            SnowGlobe_Lake_Entry_No_cutscene,

            [Description(Checkpoint.BeneathTheIce.CoreBase + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BeneathTheIce.CoreBase, Chapter.BeneathTheIce)]
            SnowGlobe_Lake_CoreBase,

            [Description(Checkpoint.BeneathTheIce.LakeIceCave + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BeneathTheIce.LakeIceCave, Chapter.BeneathTheIce)]
            SnowGlobe_Lake_LakeIceCave,

            [Description(Checkpoint.BeneathTheIce.IceCaveComplete + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.BeneathTheIce.IceCaveComplete, Chapter.BeneathTheIce)]
            SnowGlobe_Lake_IceCave_Complete,

            #endregion
            #region Slippery Slopes
            [Description(Checkpoint.SlipperySlopes.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.Intro, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain_0_Entry,

            [Description(Checkpoint.SlipperySlopes.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.IntroNoCS, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain_Entry_No_cutscene,

            [Description(Checkpoint.SlipperySlopes.IceCave + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.IceCave, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain_1_IceCave,

            [Description(Checkpoint.SlipperySlopes.CaveSkating + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.CaveSkating, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain_2_CaveSkating,

            [Description(Checkpoint.SlipperySlopes.Collapse + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.Collapse, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain_3_Collapse,

            [Description(Checkpoint.SlipperySlopes.PlayerAttraction + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.PlayerAttraction, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain_4_PlayerAttraction,

            [Description(Checkpoint.SlipperySlopes.WindWalk + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.WindWalk, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain_5_WindWalk,

            [Description(Checkpoint.SlipperySlopes.TerraceProposalCutscene + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.TerraceProposalCutscene, Chapter.SlipperySlopes)]
            SnowGlobe_Tower_TerraceProposalCutscene,

            [Description(Checkpoint.SlipperySlopes.RealWorld_House_Kitchen_Sandwiches + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.RealWorld_House_Kitchen_Sandwiches, Chapter.SlipperySlopes)]
            RealWorld_RealWorld_House_Kitchen_Sandwiches,

            [Description(Checkpoint.SlipperySlopes.TherapyRoom_Garden_Session + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SlipperySlopes.TherapyRoom_Garden_Session, Chapter.SlipperySlopes)]
            TherapyRoom_TherapyRoom_Garden_Session,

            #endregion
            #region Green Fingers
            [Description(Checkpoint.GreenFingers.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GreenFingers.Intro, Chapter.GreenFingers)]
            Garden_VegetablePatch_Intro,

            [Description(Checkpoint.GreenFingers.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GreenFingers.IntroNoCS, Chapter.GreenFingers)]
            Garden_VegetablePatch_Intro_NoCutscene,

            [Description(Checkpoint.GreenFingers.CactusCombatArea + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GreenFingers.CactusCombatArea, Chapter.GreenFingers)]
            Garden_VegetablePatch_Cactus_Combat_Area,

            [Description(Checkpoint.GreenFingers.Beanstalk + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GreenFingers.Beanstalk, Chapter.GreenFingers)]
            Garden_VegetablePatch_Beanstalk_Section,

            [Description(Checkpoint.GreenFingers.Burrown + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GreenFingers.Burrown, Chapter.GreenFingers)]
            Garden_VegetablePatch_Burrown_Enemy,

            [Description(Checkpoint.GreenFingers.BurrownCombat + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GreenFingers.BurrownCombat, Chapter.GreenFingers)]
            Garden_VegetablePatch_Burrown_Enemy_Combat,

            [Description(Checkpoint.GreenFingers.Greenhouse + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GreenFingers.Greenhouse, Chapter.GreenFingers)]
            Garden_VegetablePatch_Greenhouse_Window,

            #endregion
            #region Weed Whacking
            [Description(Checkpoint.WeedWhacking.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.Intro, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_Enter,

            [Description(Checkpoint.WeedWhacking.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.IntroNoCS, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_Enter_NoIntro,

            [Description(Checkpoint.WeedWhacking.Sprinkler + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.Sprinkler, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_Sprinkler,

            [Description(Checkpoint.WeedWhacking.StartCombat + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.StartCombat, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_StartCombat,

            [Description(Checkpoint.WeedWhacking.FirstCombatFinished + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.FirstCombatFinished, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_FirstCombatFinished,

            [Description(Checkpoint.WeedWhacking.DandelionLaunchers + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.DandelionLaunchers, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_DandelionLaunchers,

            [Description(Checkpoint.WeedWhacking.SecondSpider + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.SecondSpider, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_SecondSpider,

            [Description(Checkpoint.WeedWhacking.SpinningLog + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.SpinningLog, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_SpinningLog,

            [Description(Checkpoint.WeedWhacking.EnteringBigLog + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.EnteringBigLog, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_EnteringBigLog,

            [Description(Checkpoint.WeedWhacking.BigLogCollapse + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.BigLogCollapse, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_BigLogCollapse,

            [Description(Checkpoint.WeedWhacking.SinkingLog + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.SinkingLog, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_SinkingLog,

            [Description(Checkpoint.WeedWhacking.PurpleSapWall + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.PurpleSapWall, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_PurpleSapWall,

            [Description(Checkpoint.WeedWhacking.EnteringBigSpiderCave + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.EnteringBigSpiderCave, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_EnteringBigSpiderCave,

            [Description(Checkpoint.WeedWhacking.AfterLeavingSpiders + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.AfterLeavingSpiders, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_AfterLeavingSpiders,

            [Description(Checkpoint.WeedWhacking.StartingFinalCombat + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.StartingFinalCombat, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_StartingFinalCombat,

            [Description(Checkpoint.WeedWhacking.StartingFinalCombatSecondWave + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.StartingFinalCombatSecondWave, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_StartingFinalCombatSecondWave,

            [Description(Checkpoint.WeedWhacking.SecondCombatFirstWaveFinished + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.SecondCombatFirstWaveFinished, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_SecondCombatFirstWaveFinished,

            [Description(Checkpoint.WeedWhacking.FinalCombatFinished + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.FinalCombatFinished, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_FinalCombatFinished,

            [Description(Checkpoint.WeedWhacking.Outro + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.WeedWhacking.Outro, Chapter.WeedWhacking)]
            Garden_Shrubbery_Shrubbery_Outro,

            #endregion
            #region Trespassing
            [Description(Checkpoint.Trespassing.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.Intro, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_Level_Intro,

            [Description(Checkpoint.Trespassing.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.IntroNoCS, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_Level_Start,

            [Description(Checkpoint.Trespassing.StealthStart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.StealthStart, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_Stealth_Start,

            [Description(Checkpoint.Trespassing.SneakyBushStart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.SneakyBushStart, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_Stealth_SneakyBushStart,

            [Description(Checkpoint.Trespassing.SneakyBushMiddle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.SneakyBushMiddle, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_Stealth_SneakyBushMiddle,

            [Description(Checkpoint.Trespassing.SneakyBushEnding + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.SneakyBushEnding, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_Stealth_SneakyBushEnding,

            [Description(Checkpoint.Trespassing.StealthFinished + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.StealthFinished, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_Stealth_Finished,

            [Description(Checkpoint.Trespassing.MoleChaseStart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.MoleChaseStart, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_MoleChase_Start,

            [Description(Checkpoint.Trespassing.TopDown + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.TopDown, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_MoleChase_TopDown,

            [Description(Checkpoint.Trespassing.TopDownSafeRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.TopDownSafeRoom, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_MoleChase_TopDown_SafeRoom,

            [Description(Checkpoint.Trespassing.MoleChase2D + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.MoleChase2D, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_MoleChase_2D,

            [Description(Checkpoint.Trespassing.MoleChase2DTreasureRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Trespassing.MoleChase2DTreasureRoom, Chapter.Trespassing)]
            Garden_MoleTunnels_MoleTunnels_MoleChase_2D_TreasureRoom,

            #endregion
            #region Frog Pond
            [Description(Checkpoint.FrogPond.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.Intro, Chapter.FrogPond)]
            Garden_FrogPond_Intro,

            [Description(Checkpoint.FrogPond.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.IntroNoCS, Chapter.FrogPond)]
            Garden_FrogPond_FrogPondIntroNoCS,

            [Description(Checkpoint.FrogPond.LilyPads + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.LilyPads, Chapter.FrogPond)]
            Garden_FrogPond_LilyPads,

            [Description(Checkpoint.FrogPond.ScalePuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.ScalePuzzle, Chapter.FrogPond)]
            Garden_FrogPond_Scale_Puzzle,

            [Description(Checkpoint.FrogPond.SinkingPuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.SinkingPuzzle, Chapter.FrogPond)]
            Garden_FrogPond_Sinking_Puzzle,

            [Description(Checkpoint.FrogPond.Frogger + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.Frogger, Chapter.FrogPond)]
            Garden_FrogPond_Frogger,

            [Description(Checkpoint.FrogPond.FishFountain + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.FishFountain, Chapter.FrogPond)]
            Garden_FrogPond_Fish_Fountain_Puzzle,

            [Description(Checkpoint.FrogPond.MainFountain + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.MainFountain, Chapter.FrogPond)]
            Garden_FrogPond_Main_Fountain_Puzzle,

            [Description(Checkpoint.FrogPond.TopMainFountain + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.TopMainFountain, Chapter.FrogPond)]
            Garden_FrogPond_Top_of_Main_Fountain,

            [Description(Checkpoint.FrogPond.GrindSection + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.GrindSection, Chapter.FrogPond)]
            Garden_FrogPond_GrindSection,

            [Description(Checkpoint.FrogPond.WindowPuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.FrogPond.WindowPuzzle, Chapter.FrogPond)]
            Garden_FrogPond_Greenhouse_Window_Puzzle,

            #endregion
            #region Affliction
            [Description(Checkpoint.Affliction.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Intro, Chapter.Affliction)]
            Garden_Greenhouse_Greenhouse_Intro,

            [Description(Checkpoint.Affliction.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.IntroNoCS, Chapter.Affliction)]
            Garden_Greenhouse_Greenhouse_StartGameplay,

            [Description(Checkpoint.Affliction.FirstBulbExploded + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.FirstBulbExploded, Chapter.Affliction)]
            Garden_Greenhouse_Greenhouse_FirstBulbExploded,

            [Description(Checkpoint.Affliction.JoyIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.JoyIntro, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Intro,

            [Description(Checkpoint.Affliction.Joy1Combat + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Joy1Combat, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Phase_1_Combat,

            [Description(Checkpoint.Affliction.Joy2 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Joy2, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Phase_2,

            [Description(Checkpoint.Affliction.Joy25 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Joy25, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Phase_2_5,

            [Description(Checkpoint.Affliction.Joy2Combat + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Joy2Combat, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Phase_2_Combat,

            [Description(Checkpoint.Affliction.Joy3 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Joy3, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Phase_3,

            [Description(Checkpoint.Affliction.Joy35 + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Joy35, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Phase_3_5,

            [Description(Checkpoint.Affliction.Joy3Combat + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.Joy3Combat, Chapter.Affliction)]
            Garden_Greenhouse_Joy_Bossfight_Phase_3_Combat,

            [Description(Checkpoint.Affliction.RealWorld_FlowerPot + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.RealWorld_FlowerPot, Chapter.Affliction)]
            RealWorld_RealWorld_FlowerPot,

            [Description(Checkpoint.Affliction.TherapyRoom_Music + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Affliction.TherapyRoom_Music, Chapter.Affliction)]
            TherapyRoom_TherapyRoom_Music,

            #endregion
            #region Setting the stage
            [Description(Checkpoint.SettingTheStage.Backstage + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SettingTheStage.Backstage, Chapter.SettingTheStage)]
            Music_ConcertHall_ConcertHall_Backstage,

            [Description(Checkpoint.SettingTheStage.BackstageNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SettingTheStage.BackstageNoCS, Chapter.SettingTheStage)]
            Music_ConcertHall_ConcertHall_Backstage_NoCS,

            #endregion
            #region Rehearsal
            [Description(Checkpoint.Rehearsal.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.Intro, Chapter.Rehearsal)]
            Music_Backstage_Tutorial_Intro,

            [Description(Checkpoint.Rehearsal.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.IntroNoCS, Chapter.Rehearsal)]
            Music_Backstage_Tutorial_Start,

            [Description(Checkpoint.Rehearsal.DiskPuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.DiskPuzzle, Chapter.Rehearsal)]
            Music_Backstage_Tutorial_Disk_Puzzle,

            [Description(Checkpoint.Rehearsal.JukeboxStart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.JukeboxStart, Chapter.Rehearsal)]
            Music_Backstage_JukeboxStart,

            [Description(Checkpoint.Rehearsal.JukeboxCoinSlot + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.JukeboxCoinSlot, Chapter.Rehearsal)]
            Music_Backstage_Jukebox_CoinSlot,

            [Description(Checkpoint.Rehearsal.JukeboxVinyl + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.JukeboxVinyl, Chapter.Rehearsal)]
            Music_Backstage_JukeboxVinyl,

            [Description(Checkpoint.Rehearsal.PrePortableSpeaker + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.PrePortableSpeaker, Chapter.Rehearsal)]
            Music_Backstage_PrePortableSpeaker,

            [Description(Checkpoint.Rehearsal.PortableSpeaker + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.PortableSpeaker, Chapter.Rehearsal)]
            Music_Backstage_PortableSpeaker,

            [Description(Checkpoint.Rehearsal.SubBassRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.SubBassRoom, Chapter.Rehearsal)]
            Music_Backstage_Sub_Bass_Room,

            [Description(Checkpoint.Rehearsal.TrussRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.TrussRoom, Chapter.Rehearsal)]
            Music_Backstage_Truss_Room,

            [Description(Checkpoint.Rehearsal.TrussRoomNoSubBassRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.TrussRoomNoSubBassRoom, Chapter.Rehearsal)]
            Music_Backstage_Truss_Room_no_SubBassRoom,

            [Description(Checkpoint.Rehearsal.MusicTechWallStart + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MusicTechWallStart, Chapter.Rehearsal)]
            Music_Backstage_Music_Tech_Wall_Start,

            [Description(Checkpoint.Rehearsal.MusicTechWallEQSweeper + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MusicTechWallEQSweeper, Chapter.Rehearsal)]
            Music_Backstage_Music_Tech_Wall_EQ_Sweeper,

            [Description(Checkpoint.Rehearsal.SilentRoomIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.SilentRoomIntro, Chapter.Rehearsal)]
            Music_Backstage_Silent_Room_Intro,

            [Description(Checkpoint.Rehearsal.MicrophoneChaseDevDebugFallToGrind + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MicrophoneChaseDevDebugFallToGrind, Chapter.Rehearsal)]
            Music_Backstage_MicrophoneChaseDevDebugFallToGrind,

            [Description(Checkpoint.Rehearsal.SilentRoomElevatorPillar + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.SilentRoomElevatorPillar, Chapter.Rehearsal)]
            Music_Backstage_Silent_Room_Elevator_Pillar,

            [Description(Checkpoint.Rehearsal.SilentRoomEnd + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.SilentRoomEnd, Chapter.Rehearsal)]
            Music_Backstage_Silent_Room_End,

            [Description(Checkpoint.Rehearsal.MicrophoneChase + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MicrophoneChase, Chapter.Rehearsal)]
            Music_Backstage_MicrophoneChase,

            [Description(Checkpoint.Rehearsal.MicrophoneChaseAfterFirstGrind + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MicrophoneChaseAfterFirstGrind, Chapter.Rehearsal)]
            Music_Backstage_MicrophoneChase_After_First_Grind,

            [Description(Checkpoint.Rehearsal.MicrophoneChaseEnding + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MicrophoneChaseEnding, Chapter.Rehearsal)]
            Music_Backstage_MicrophoneChase_Ending,

            [Description(Checkpoint.Rehearsal.DrumMachineRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.DrumMachineRoom, Chapter.Rehearsal)]
            Music_Backstage_DrumMachineRoom,

            [Description(Checkpoint.Rehearsal.LightRoomPowerSwitch + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.LightRoomPowerSwitch, Chapter.Rehearsal)]
            Music_Backstage_LightRoom_PowerSwitch,

            [Description(Checkpoint.Rehearsal.LightRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.LightRoom, Chapter.Rehearsal)]
            Music_Backstage_LightRoom,

            [Description(Checkpoint.Rehearsal.MicrophoneChaseDevDebugBreamCrush + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MicrophoneChaseDevDebugBreamCrush, Chapter.Rehearsal)]
            Music_Backstage_MicrophoneChaseDevDebugBreamCrush,

            [Description(Checkpoint.Rehearsal.ChaseLanding + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.ChaseLanding, Chapter.Rehearsal)]
            Music_Backstage_Chase_Landing,

            [Description(Checkpoint.Rehearsal.MicrophoneChaseDoor + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Rehearsal.MicrophoneChaseDoor, Chapter.Rehearsal)]
            Music_Backstage_MicrophoneChase_Door,

            #endregion
            #region Symphony
            [Description(Checkpoint.SettingTheStage.Classic + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SettingTheStage.Classic, Chapter.Symphony)]
            Music_ConcertHall_ConcertHall_Classic,

            [Description(Checkpoint.SettingTheStage.ClassicNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SettingTheStage.ClassicNoCS, Chapter.Symphony)]
            Music_ConcertHall_ConcertHall_Classic_NoCS,

            [Description(Checkpoint.Symphony.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.Intro, Chapter.Symphony)]
            Music_Classic_Classic_01_Attic_Intro,

            [Description(Checkpoint.Symphony.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.IntroNoCS, Chapter.Symphony)]
            Music_Classic_Classic_01_Attic,

            [Description(Checkpoint.Symphony.FlutePuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.FlutePuzzle, Chapter.Symphony)]
            Music_Classic_Classic_02_FlutePuzzle,

            [Description(Checkpoint.Symphony.AccordionBox + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.AccordionBox, Chapter.Symphony)]
            Music_Classic_Classic_03_AccordionBox,

            [Description(Checkpoint.Symphony.BridgePuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.BridgePuzzle, Chapter.Symphony)]
            Music_Classic_Classic_04_BridgePuzzle,

            [Description(Checkpoint.Symphony.ShutterPuzzle + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.ShutterPuzzle, Chapter.Symphony)]
            Music_Classic_Classic_05_ShutterPuzzle,

            [Description(Checkpoint.Symphony.Heaven + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.Heaven, Chapter.Symphony)]
            Music_Classic_Classic_06_Heaven, // Is this checkpoint hit multiple times??

            [Description(Checkpoint.Symphony.HeavenCageArea + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.HeavenCageArea, Chapter.Symphony)]
            Music_Classic_Classic_07_Heaven_CageArea,

            [Description(Checkpoint.Symphony.HeavenCloudArea + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Symphony.HeavenCloudArea, Chapter.Symphony)]
            Music_Classic_Classic_08_Heaven_CloudArea,

            #endregion
            #region Turn up
            [Description(Checkpoint.SettingTheStage.NightClub + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SettingTheStage.NightClub, Chapter.TurnUp)]
            Music_ConcertHall_ConcertHall_NightClub,

            [Description(Checkpoint.SettingTheStage.NightClubNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.SettingTheStage.NightClubNoCS, Chapter.TurnUp)]
            Music_ConcertHall_ConcertHall_NightClub_NoCS,

            [Description(Checkpoint.TurnUp.Intro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.Intro, Chapter.TurnUp)]
            Music_Nightclub_RainbowSlide,

            [Description(Checkpoint.TurnUp.IntroNoCS + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.IntroNoCS, Chapter.TurnUp)]
            Music_Nightclub_RainBowSlideNoCutscene,

            [Description(Checkpoint.TurnUp.SlideEnding + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.SlideEnding, Chapter.TurnUp)]
            Music_Nightclub_Slide_ending,

            [Description(Checkpoint.TurnUp.BeatPlatforming + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.BeatPlatforming, Chapter.TurnUp)]
            Music_Nightclub_Beat_platforming,

            [Description(Checkpoint.TurnUp.PreDiscoballRide + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.PreDiscoballRide, Chapter.TurnUp)]
            Music_Nightclub_Pre_DiscoballRide,

            [Description(Checkpoint.TurnUp.DiscoBallRide + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.DiscoBallRide, Chapter.TurnUp)]
            Music_Nightclub_DiscoBallRide,

            [Description(Checkpoint.TurnUp.BasementPreElevator + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.BasementPreElevator, Chapter.TurnUp)]
            Music_Nightclub_Basement_pre_elevator,

            [Description(Checkpoint.TurnUp.DJDanceFloor + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.DJDanceFloor, Chapter.TurnUp)]
            Music_Nightclub_DJ_Dancefloor,

            [Description(Checkpoint.TurnUp.AudioSurf + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.TurnUp.AudioSurf, Chapter.TurnUp)]
            Music_Nightclub_AudioSurf,

            #endregion
            #region A Grand Finale
            [Description(Checkpoint.GrandFinale.EndingIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GrandFinale.EndingIntro, Chapter.AGrandFinale)]
            Music_Ending_EndingIntro,

            [Description(Checkpoint.GrandFinale.MayInDressingRoom + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GrandFinale.MayInDressingRoom, Chapter.AGrandFinale)]
            Music_Ending_MayInDressingRoom,

            [Description(Checkpoint.GrandFinale.CodyBeforeFlipSwitch + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.GrandFinale.CodyBeforeFlipSwitch, Chapter.AGrandFinale)]
            Music_Ending_CodyBeforeFlipSwitch,

            [Description(Checkpoint.GrandFinale.MayBeforeCurtains + Tag.Dev + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.GrandFinale.MayBeforeCurtains, Chapter.AGrandFinale)]
            Music_Ending_MayBeforeCurtains,

            [Description(Checkpoint.GrandFinale.RealWorld_WakeUp + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GrandFinale.RealWorld_WakeUp, Chapter.AGrandFinale)]
            RealWorld_RealWorld_WakeUp,

            [Description(Checkpoint.GrandFinale.CreditIntro + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.GrandFinale.CreditIntro, Chapter.AGrandFinale)]
            Credits_CreditIntro,

            #endregion
            #region Basement

            [Description(Checkpoint.Basement.SeekersIntro + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Basement.SeekersIntro, Chapter.Basement)]
            Basement_Seekers_SeekersIntro,

            [Description(Checkpoint.Basement.HouseInteriorStart + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Basement.HouseInteriorStart, Chapter.Basement)]
            Basement_Seekers_HouseInteriorStart,

            [Description(Checkpoint.Basement.BasementBoss + Tag.Checkpoint),
                ToolTip(Checkpoint.Format, Checkpoint.Basement.BasementBoss, Chapter.Basement)]
            Basement_Boss_BasementBoss,

            #endregion
            #region Other checkpoints
            [Description(Checkpoint.Menu.MainMenu + Tag.Checkpoint), 
                ToolTip(Checkpoint.Format, Checkpoint.Menu.MainMenu, "MainMenu")]
            Main_Main_Menu,

            #endregion
            #endregion Checkpoint Splits

            #region Subchapter Splits

            [Description(Chapter.WakeUpCall + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.WakeUpCall)]
            Shed_Awakening,

            [Description(Chapter.BitingTheDust + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.BitingTheDust)]
            Shed_Vacuum,

            [Description(Chapter.TheDepths + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.TheDepths)]
            Shed_Main,

            [Description(Chapter.FreshAir + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.FreshAir)]
            Tree_Approach,

            [Description(Chapter.Captured + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Captured)]
            Tree_SquirrelHome,

            [Description(Chapter.DeeplyRooted + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.DeeplyRooted)]
            Tree_WaspNest,

            [Description(Chapter.Extermination + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Extermination)]
            Tree_Boss,

            [Description(Chapter.Getaway + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Getaway)]
            Tree_Escape,

            [Description(Chapter.PillowFort + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.PillowFort)]
            PlayRoom_PillowFort,

            [Description(Chapter.SpacedOut + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.SpacedOut)]
            PlayRoom_Spacestation,

            [Description(Chapter.Hopscotch + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Hopscotch)]
            PlayRoom_Hopscotch,

            [Description(Chapter.Goldberg + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Goldberg)]
            PlayRoom_Goldberg,

            [Description(Chapter.OnceUponATime + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.OnceUponATime)]
            PlayRoom_Courtyard,

            [Description(Chapter.DungeonCrawler + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.DungeonCrawler)]
            PlayRoom_Dungeon,

            [Description(Chapter.TheQueen + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.TheQueen)]
            PlayRoom_Shelf,

            [Description(Chapter.GatesOfTime + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.GatesOfTime)]
            Clockwork_Outside,

            [Description(Chapter.Clockworks + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Clockworks)]
            Clockwork_LowerTower,

            [Description(Chapter.ABlastFromThePast + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.ABlastFromThePast)]
            Clockwork_UpperTower,

            [Description(Chapter.WarmingUp + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.WarmingUp)]
            SnowGlobe_Forest,

            [Description(Chapter.WinterVillage + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.WinterVillage)]
            SnowGlobe_Town,

            [Description(Chapter.BeneathTheIce + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.BeneathTheIce)]
            SnowGlobe_Lake,

            [Description(Chapter.SlipperySlopes + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.SlipperySlopes)]
            SnowGlobe_Mountain,

            [Description(Chapter.GreenFingers + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.GreenFingers)]
            Garden_VegetablePatch,

            [Description(Chapter.WeedWhacking + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.WeedWhacking)]
            Garden_Shrubbery,

            [Description(Chapter.Trespassing + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Trespassing)]
            Garden_MoleTunnels,

            [Description(Chapter.FrogPond + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.FrogPond)]
            Garden_FrogPond,

            [Description(Chapter.Affliction + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Affliction)]
            Garden_Greenhouse,

            [Description(Chapter.SettingTheStage + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.SettingTheStage)]
            Music_ConcertHall,

            [Description(Chapter.Rehearsal + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Rehearsal)]
            Music_Backstage,

            [Description(Chapter.Symphony + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Symphony)]
            Music_Classic,

            [Description(Chapter.TurnUp + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.TurnUp)]
            Music_Nightclub,

            [Description(Chapter.AGrandFinale + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.AGrandFinale)]
            Music_Ending,

            [Description(Chapter.Basement + Tag.Chapter),
                ToolTip(Chapter.Format, Chapter.Basement)]
            Basement_Seekers,

            #endregion

            #region Cutscene Splits
            #region Start
            #region Wake-Up Call
            [Description(Cutscene.WakeUpCall.Divorce_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WakeUpCall.Divorce_Intro, Chapter.WakeUpCall)]
            Start_CS_Shed_Awakening_Divorce_Intro,

            [Description(Cutscene.WakeUpCall.FuseSocket_JumpOut + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WakeUpCall.FuseSocket_JumpOut, Chapter.WakeUpCall)]
            Start_CS_Shed_Awakening_FuseSocket_JumpOut,

            [Description(Cutscene.WakeUpCall.FuseSocket_Activate + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WakeUpCall.FuseSocket_Activate, Chapter.WakeUpCall)]
            Start_CS_Shed_Awakening_FuseSocket_Activate,

            [Description(Cutscene.WakeUpCall.Saw_Success + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WakeUpCall.Saw_Success, Chapter.WakeUpCall)]
            Start_EV_Shed_Awakening_Saw_Success,
            #endregion
            #region Biting the dust
            [Description(Cutscene.BitingTheDust.Meet_Sucked + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BitingTheDust.Meet_Sucked, Chapter.BitingTheDust)]
            Start_CS_Shed_Vacuum_Meet_Sucked,  

            [Description(Cutscene.BitingTheDust.Vacuum_Battle + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BitingTheDust.Vacuum_Battle, Chapter.BitingTheDust)]
            Start_CS_Shed_Awakening_Vacuum_Battle_var2,

            [Description(Cutscene.BitingTheDust.RightEyeSuckProgress + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BitingTheDust.RightEyeSuckProgress, Chapter.BitingTheDust)]
            Start_DS_Shed_Vacuum_BossFight_RightEyeSuckProgress,

            [Description(Cutscene.BitingTheDust.LeftEyeSuckProgress + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BitingTheDust.LeftEyeSuckProgress, Chapter.BitingTheDust)]
            Start_DS_Shed_Vacuum_BossFight_LeftEyeSuckProgress,

            [Description(Cutscene.BitingTheDust.BossFight_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BitingTheDust.BossFight_Outro, Chapter.BitingTheDust)]
            Start_CS_Shed_Vacuum_BossFight_Outro,
            #endregion
            #region The Depths
            [Description(Cutscene.TheDepths.Abyss_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.Abyss_Intro, Chapter.TheDepths)]
            Start_CS_Shed_Main_Abyss_Intro, 

            [Description(Cutscene.TheDepths.Abyss_Rust + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.Abyss_Rust, Chapter.TheDepths)]
            Start_CS_Shed_Main_Abyss_Rust,

            [Description(Cutscene.TheDepths.MiniGame_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.MiniGame_Intro, Chapter.TheDepths)]
            Start_CS_Shed_Tambourine_MiniGame_Intro,

            [Description(Cutscene.TheDepths.MachineRoom_StartMachine + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.MachineRoom_StartMachine, Chapter.TheDepths)]
            Start_CS_Shed_Main_MachineRoom_StartMachine,

            [Description(Cutscene.TheDepths.ToolBoss_Battle + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.ToolBoss_Battle, Chapter.TheDepths)]
            Start_CS_Shed_Main_ToolBoss_Battle,

            [Description(Cutscene.TheDepths.ToolBoxBoss_BossIntro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.ToolBoxBoss_BossIntro, Chapter.TheDepths)]
            Start_CS_Shed_Main_ToolBoxBoss_BossIntro, 

            [Description(Cutscene.TheDepths.ToolBoss_FirstPadLock + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.ToolBoss_FirstPadLock, Chapter.TheDepths)]
            Start_CS_Shed_Main_ToolBoss_FirstPadLock,

            [Description(Cutscene.TheDepths.ToolBoxBoss_KillLeftArm + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.ToolBoxBoss_KillLeftArm, Chapter.TheDepths)]
            Start_CS_Shed_Main_ToolBoxBoss_KillLeftArm,

            [Description(Cutscene.TheDepths.ToolBoss_Defeat + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.ToolBoss_Defeat, Chapter.TheDepths)]
            Start_CS_Shed_Main_ToolBoss_Defeat,

            [Description(Cutscene.TheDepths.ToolBoss_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheDepths.ToolBoss_Outro, Chapter.TheDepths)]
            Start_CS_Shed_Main_ToolBoss_Outro, 
            #endregion
            #region Wired Up
            [Description(Cutscene.WiredUp.ToolBoss_Door + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WiredUp.ToolBoss_Door, Chapter.WiredUp)]
            Start_CS_Shed_Main_ToolBoss_Door, 

            [Description(Cutscene.WiredUp.Stargazing_Meet + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WiredUp.Stargazing_Meet, Chapter.WiredUp)]
            Start_CS_RealWorld_Shed_Stargazing_Meet, 
            #endregion
            #region Fresh Air
            [Description(Cutscene.FreshAir.Roof_Swing + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FreshAir.Roof_Swing, Chapter.FreshAir)]
            Start_CS_Tree_Approach_Roof_Swing, 

            [Description(Cutscene.FreshAir.Gate_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FreshAir.Gate_Intro, Chapter.FreshAir)]
            Start_CS_Tree_Approach_Gate_Intro,

            [Description(Cutscene.FreshAir.Study_Friends + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FreshAir.Study_Friends, Chapter.FreshAir)]
            Start_CS_RealWorld_House_Study_Friends, 

            [Description(Cutscene.FreshAir.Interrogation + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FreshAir.Interrogation, Chapter.FreshAir)]
            Start_CS_Tree_SquirrelTurf_Home_Interrogation, 
            #endregion
            #region Captured
            [Description(Cutscene.Captured.WallDivide_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Captured.WallDivide_Intro, Chapter.Captured)]
            Start_CS_Tree_SquirrelHome_WallDivide_Intro, 
            #endregion
            #region Deeply Rooted
            [Description(Cutscene.DeeplyRooted.RobotQueen_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.RobotQueen_Intro, Chapter.DeeplyRooted)]
            Start_CS_Tree_WaspNest_RobotQueen_Intro, 

            [Description(Cutscene.DeeplyRooted.Boat_River + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.Boat_River, Chapter.DeeplyRooted)]
            Start_CS_Tree_WaspNest_Boat_River, 

            [Description(Cutscene.DeeplyRooted.BoatSwarmCreation + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.BoatSwarmCreation, Chapter.DeeplyRooted)]
            Start_EV_Tree_Boat_Ending_BoatSwarmCreation,

            [Description(Cutscene.DeeplyRooted.DarkRoom_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.DarkRoom_Intro, Chapter.DeeplyRooted)]
            Start_CS_Tree_WaspNest_DarkRoom_Intro, 

            [Description(Cutscene.DeeplyRooted.FallingFromDarkroom + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.FallingFromDarkroom, Chapter.DeeplyRooted)]
            Start_CS_Tree_WaspNest_Elevator_FallingFromDarkroom, 

            [Description(Cutscene.DeeplyRooted.Arena_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.Arena_Intro, Chapter.DeeplyRooted)]
            Start_CS_Tree_WaspNest_Arena_Intro, 

            [Description(Cutscene.DeeplyRooted.TreeBug_Ride + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.TreeBug_Ride, Chapter.DeeplyRooted)]
            Start_CS_Tree_WaspNest_TreeBug_Ride, 

            [Description(Cutscene.DeeplyRooted.Bug_Crash + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DeeplyRooted.Bug_Crash, Chapter.DeeplyRooted)]
            Start_CS_Tree_WaspNest_Bug_Crash, 
            #endregion
            #region Extermination
            [Description(Cutscene.Extermination.Boss_Meet + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Extermination.Boss_Meet, Chapter.Extermination)]
            Start_CS_Tree_Hive_Boss_Meet,

            [Description(Cutscene.Extermination.PlaneIntro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Extermination.PlaneIntro, Chapter.Extermination)]
            Start_CS_Tree_WaspQueenBoss_Arena_PlaneIntro,

            [Description(Cutscene.Extermination.SmashInWood + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Extermination.SmashInWood, Chapter.Extermination)]
            Start_CS_Tree_WaspQueenBoss_Arena_SmashInWood,

            [Description(Cutscene.Extermination.Defeated + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Extermination.Defeated, Chapter.Extermination)]
            Start_CS_Tree_WaspQueenBoss_Arena_Defeated,

            [Description(Cutscene.Extermination.Boss_Victory + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Extermination.Boss_Victory, Chapter.Extermination)]
            Start_CS_Tree_Hive_Boss_Victory,

            [Description(Cutscene.Extermination.Return_Flight + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Extermination.Return_Flight, Chapter.Extermination)]
            Start_CS_Tree_SquirrelTurf_Return_Flight, 
            #endregion
            #region Getaway
            [Description(Cutscene.Getaway.Flight_Chase + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Getaway.Flight_Chase, Chapter.Getaway)]
            Start_CS_Tree_Escape_Flight_Chase,

            [Description(Cutscene.Getaway.Chase_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Getaway.Chase_Outro, Chapter.Getaway)]
            Start_CS_Tree_Escape_Chase_Outro,

            [Description(Cutscene.Getaway.Plane_Combat + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Getaway.Plane_Combat, Chapter.Getaway)]
            Start_CS_Tree_Escape_Plane_Combat,

            [Description(Cutscene.Getaway.NoseDive_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Getaway.NoseDive_Intro, Chapter.Getaway)]
            Start_CS_Tree_Escape_NoseDive_Intro_Right,

            [Description(Cutscene.Getaway.NoseDive_Crash + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Getaway.NoseDive_Crash, Chapter.Getaway)]
            Start_CS_Tree_Escape_NoseDive_Crash,

            [Description(Cutscene.Getaway.LivingRoom_Headache + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Getaway.LivingRoom_Headache, Chapter.Getaway)]
            Start_CS_RealWorld_House_LivingRoom_Headache,

            [Description(Cutscene.Getaway.Roof_Crash + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Getaway.Roof_Crash, Chapter.Getaway)]
            Start_CS_RealWorld_Exterior_Roof_Crash,
            #endregion
            #region Pillow Fort
            [Description(Cutscene.PillowFort.Landing_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PillowFort.Landing_Intro, Chapter.PillowFort)]
            Start_CS_PlayRoom_PillowFort_Landing_Intro, 

            [Description(Cutscene.PillowFort.Dolls_Dialogue + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PillowFort.Dolls_Dialogue, Chapter.PillowFort)]
            Start_CS_PlayRoom_PillowFort_Dolls_Dialogue,

            [Description(Cutscene.PillowFort.SpaceStation_Transport + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PillowFort.SpaceStation_Transport, Chapter.PillowFort)]
            Start_CS_PlayRoom_PillowFort_SpaceStation_Transport,
            #endregion
            #region Spaced Out
            [Description(Cutscene.SpacedOut.BeamUp_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BeamUp_Intro, Chapter.SpacedOut)]
            Start_CS_PlayRoom_PillowFort_BeamUp_Intro, 

            [Description(Cutscene.SpacedOut.FirstGeneratorActivated + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.FirstGeneratorActivated, Chapter.SpacedOut)]
            Start_EV_PlayRoom_SpaceStation_Hub_FirstGeneratorActivated,

            [Description(Cutscene.SpacedOut.BalanceScales_ReturnToPortal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BalanceScales_ReturnToPortal, Chapter.SpacedOut)]
            Start_EV_PlayRoom_SpaceStation_BalanceScales_ReturnToPortal,

            [Description(Cutscene.SpacedOut.Planets_ReturnToPortal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.Planets_ReturnToPortal, Chapter.SpacedOut)]
            Start_EV_PlayRoom_SpaceStation_Planets_ReturnToPortal,

            [Description(Cutscene.SpacedOut.PlasmaBall_ReturnToPortal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.PlasmaBall_ReturnToPortal, Chapter.SpacedOut)]
            Start_EV_PlayRoom_SpaceStation_PlasmaBall_ReturnToPortal,

            [Description(Cutscene.SpacedOut.SpaceBowl_ReturnToPortal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.SpaceBowl_ReturnToPortal, Chapter.SpacedOut)]
            Start_EV_PlayRoom_SpaceStation_SpaceBowl_ReturnToPortal,

            [Description(Cutscene.SpacedOut.LaunchBoard_ReturnToPortal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.LaunchBoard_ReturnToPortal, Chapter.SpacedOut)]
            Start_EV_PlayRoom_SpaceStation_LaunchBoard_ReturnToPortal,

            [Description(Cutscene.SpacedOut.Electricity_ReturnToPortal+ Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.Electricity_ReturnToPortal, Chapter.SpacedOut)]
            Start_EV_PlayRoom_SpaceStation_Electricity_ReturnToPortal,

            [Description(Cutscene.SpacedOut.SecondGenerator + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.SecondGenerator, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_Hub_SecondGenerator, 

            [Description(Cutscene.SpacedOut.BossFight_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BossFight_Intro, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_BossFight_Intro,

            [Description(Cutscene.SpacedOut.BossFight_PowerCoresDestroyed + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BossFight_PowerCoresDestroyed, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_BossFight_PowerCoresDestroyed,

            [Description(Cutscene.SpacedOut.BossFight_RipOffLaserGun + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BossFight_RipOffLaserGun, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_BossFight_RipOffLaserGun,

            [Description(Cutscene.SpacedOut.BossFight_RocketsPhaseFinished + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BossFight_RocketsPhaseFinished, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_BossFight_RocketsPhaseFinished,

            [Description(Cutscene.SpacedOut.BossFight_Eject + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BossFight_Eject, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_BossFight_Eject,

            [Description(Cutscene.SpacedOut.BossFight_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BossFight_Outro, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_BossFight_Outro,

            [Description(Cutscene.SpacedOut.BossFight_BeamOut + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SpacedOut.BossFight_BeamOut, Chapter.SpacedOut)]
            Start_CS_PlayRoom_SpaceStation_BossFight_BeamOut,
            #endregion
            #region Hopscotch
            [Description(Cutscene.Hopscotch.UnderBed_Landing + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.UnderBed_Landing, Chapter.Hopscotch)]
            Start_CS_PlayRoom_Hopscotch_UnderBed_Landing,

            [Description(Cutscene.Hopscotch.Homework_FallThroughPlanks + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.Homework_FallThroughPlanks, Chapter.Hopscotch)]
            Start_CS_PlayRoom_Hopscotch_Homework_FallThroughPlanks,

            [Description(Cutscene.Hopscotch.Homework_FallThroughPlanksLanding + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.Homework_FallThroughPlanksLanding, Chapter.Hopscotch)]
            Start_CS_PlayRoom_Hopscotch_Homework_FallThroughPlanksLanding,

            [Description(Cutscene.Hopscotch.CompletedFirstMaze + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.CompletedFirstMaze, Chapter.Hopscotch)]
            Start_CT_PlayRoom_Hopscotch_MarbleMazeRoom_CompletedFirstMaze,

            [Description(Cutscene.Hopscotch.CompletedSecondMaze + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.CompletedSecondMaze, Chapter.Hopscotch)]
            Start_CT_PlayRoom_Hopscotch_MarbleMazeRoom_CompletedSecondMaze,

            [Description(Cutscene.Hopscotch.WhoopeeSwivelDoorTransition + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.WhoopeeSwivelDoorTransition, Chapter.Hopscotch)]
            Start_CT_PlayRoom_Hopscotch_Dungeon_WhoopeeSwivelDoorTransition,

            [Description(Cutscene.Hopscotch.Dungeon_TreasureChest + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.Dungeon_TreasureChest, Chapter.Hopscotch)]
            Start_CS_PlayRoom_Hopscotch_Dungeon_TreasureChest,

            [Description(Cutscene.Hopscotch.Kaleidoscope_Elevator + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.Kaleidoscope_Elevator, Chapter.Hopscotch)]
            Start_CS_PlayRoom_Hopscotch_Kaleidoscope_Elevator,

            [Description(Cutscene.Hopscotch.MirrorPuzzle_EnterPuzzle + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.MirrorPuzzle_EnterPuzzle, Chapter.Hopscotch)]
            Start_CS_PlayRoom_Hopscotch_MirrorPuzzle_EnterPuzzle,

            [Description(Cutscene.Hopscotch.Kaleidoscope_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Hopscotch.Kaleidoscope_Outro, Chapter.Hopscotch)]
            Start_CS_PlayRoom_Hopscotch_Kaleidoscope_Outro,
            #endregion
            #region Dinoland
            [Description(Cutscene.Dinoland.DinoCrash_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Dinoland.DinoCrash_Intro, Chapter.DinoLand)]
            Start_CS_PlayRoom_DinoLand_DinoCrash_Intro,

            [Description(Cutscene.Dinoland.PteranodonCrash + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Dinoland.PteranodonCrash, Chapter.DinoLand)]
            Start_EV_PlayRoom_DinoLand_PteranodonCrash,

            [Description(Cutscene.Dinoland.DinoLand_DinoCrash_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Dinoland.DinoLand_DinoCrash_Outro, Chapter.DinoLand)]
            Start_CS_PlayRoom_DinoLand_DinoCrash_Outro,
            #endregion
            #region Pirate's Ahoy
            [Description(Cutscene.PiratesAhoy.EnteringBoat + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.EnteringBoat, Chapter.PiratesAhoy)]
            Start_CS_PlayRoom_Goldberg_Pirate_EnteringBoat,

            [Description(Cutscene.PiratesAhoy.ShipsIntro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.ShipsIntro, Chapter.PiratesAhoy)]
            Start_CS_Playroom_Goldberg_Pirate_ShipsIntro,

            [Description(Cutscene.PiratesAhoy.BossIntro_MainScene + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.BossIntro_MainScene, Chapter.PiratesAhoy)]
            Start_CS_PlayRoom_Goldberg_Pirate_BossIntro_MainScene,

            [Description(Cutscene.PiratesAhoy.BossSlam_Left + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.BossSlam_Left, Chapter.PiratesAhoy)]
            Start_CT_Playroom_Goldberg_Pirate_BossSlam_Left,

            [Description(Cutscene.PiratesAhoy.OctopusEnterPhase2 + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.OctopusEnterPhase2, Chapter.PiratesAhoy)]
            Start_CS_PlayRoom_Goldberg_Pirate_OctopusEnterPhase2,

            [Description(Cutscene.PiratesAhoy.OctopusEnterPhase3 + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.OctopusEnterPhase3, Chapter.PiratesAhoy)]
            Start_CS_PlayRoom_Goldberg_Pirate_OctopusEnterPhase3,

            [Description(Cutscene.PiratesAhoy.BossBoatJab + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.BossBoatJab, Chapter.PiratesAhoy)]
            Start_CS_Playroom_Goldberg_Pirate_BossBoatJab,

            [Description(Cutscene.PiratesAhoy.SquidDefeated + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.PiratesAhoy.SquidDefeated, Chapter.PiratesAhoy)]
            Start_CS_PlayRoom_Goldberg_Pirate_SquidDefeated,
            #endregion
            #region The Greatest Show
            [Description(Cutscene.TheGreatestShow.Balloon_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheGreatestShow.Balloon_Intro, Chapter.TheGreatestShow)]
            Start_CS_PlayRoom_Circus_Balloon_Intro,

            [Description(Cutscene.TheGreatestShow.SealsBounceBall + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheGreatestShow.SealsBounceBall, Chapter.TheGreatestShow)]
            Start_LS_PlayRoom_Goldberg_Circus_SealsBounceBall,

            [Description(Cutscene.TheGreatestShow.Balloon_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheGreatestShow.Balloon_Outro, Chapter.TheGreatestShow)]
            Start_CS_PlayRoom_Circus_Balloon_Outro,

            [Description(Cutscene.TheGreatestShow.CartRide_Flying + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheGreatestShow.CartRide_Flying, Chapter.TheGreatestShow)]
            Start_CS_PlayRoom_Circus_CartRide_Flying,
            #endregion
            #region Once Upon a Time
            [Description(Cutscene.OnceUponATime.CartLand + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.OnceUponATime.CartLand, Chapter.OnceUponATime)]
            Start_CS_PlayRoom_Castle_Courtyard_CartLand,

            [Description(Cutscene.OnceUponATime.PaperSquish_May + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.OnceUponATime.PaperSquish_May, Chapter.OnceUponATime)]
            Start_EV_Playroom_Castle_Courtyard_PaperSquish_May,

            [Description(Cutscene.OnceUponATime.PaperSquish_Cody + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.OnceUponATime.PaperSquish_Cody, Chapter.OnceUponATime)]
            Start_EV_Playroom_Castle_Courtyard_PaperSquish_Cody,

            [Description(Cutscene.OnceUponATime.Gate_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.OnceUponATime.Gate_Intro, Chapter.OnceUponATime)]
            Start_CS_PlayRoom_Castle_Gate_Intro,
            #endregion
            #region Dungeon Crawler
            [Description(Cutscene.DungeonCrawler.Dungeon_Cell + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DungeonCrawler.Dungeon_Cell, Chapter.DungeonCrawler)]
            Start_CS_PlayRoom_Castle_Dungeon_Cell,

            [Description(Cutscene.DungeonCrawler.CrusherIntro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DungeonCrawler.CrusherIntro, Chapter.DungeonCrawler)]
            Start_CS_Playroom_Castle_Dungeon_CrusherIntro,

            [Description(Cutscene.DungeonCrawler.BridgeCollapse + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DungeonCrawler.BridgeCollapse, Chapter.DungeonCrawler)]
            Start_LS_Playroom_Castle_Dungeon_BridgeCollapse,

            [Description(Cutscene.DungeonCrawler.Dungeon_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DungeonCrawler.Dungeon_Outro, Chapter.DungeonCrawler)]
            Start_CS_PlayRoom_Castle_Dungeon_Outro,

            [Description(Cutscene.DungeonCrawler.Chessboard_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DungeonCrawler.Chessboard_Intro, Chapter.DungeonCrawler)]
            Start_CS_PlayRoom_Castle_Chessboard_Intro,

            [Description(Cutscene.DungeonCrawler.Chessboard_BossDeath + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DungeonCrawler.Chessboard_BossDeath, Chapter.DungeonCrawler)]
            Start_CS_Playroom_Castle_Chess_Chessboard_BossDeath,

            [Description(Cutscene.DungeonCrawler.Chessboard_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.DungeonCrawler.Chessboard_Outro, Chapter.DungeonCrawler)]
            Start_CS_PlayRoom_Castle_Chessboard_Outro,
            #endregion
            #region The Queen
            [Description(Cutscene.TheQueen.Elephant_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.Elephant_Intro, Chapter.TheQueen)]
            Start_CS_PlayRoom_Bookshelf_Elephant_Intro,

            [Description(Cutscene.TheQueen.CaughtByClaw + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.CaughtByClaw, Chapter.TheQueen)]
            Start_CS_Playroom_Castle_Shelf_CaughtByClaw,

            [Description(Cutscene.TheQueen.Towerhang_Finish + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.Towerhang_Finish, Chapter.TheQueen)]
            Start_CS_PlayRoom_Bookshelf_Towerhang_Finish,

            [Description(Cutscene.TheQueen.LegPull_GetStuck + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.LegPull_GetStuck, Chapter.TheQueen)]
            Start_CS_PlayRoom_Bookshelf_LegPull_GetStuck,

            [Description(Cutscene.TheQueen.LegPull_EarRip + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.LegPull_EarRip, Chapter.TheQueen)]
            Start_CS_PlayRoom_Bookshelf_LegPull_EarRip,

            [Description(Cutscene.TheQueen.ToEdgeHang + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.ToEdgeHang, Chapter.TheQueen)]
            Start_CS_PlayRoom_Bookshelf_ToEdgeHang,

            [Description(Cutscene.TheQueen.Elephant_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.Elephant_Outro, Chapter.TheQueen)]
            Start_CS_PlayRoom_Bookshelf_Elephant_Outro,

            [Description(Cutscene.TheQueen.Bed_Crack + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.Bed_Crack, Chapter.TheQueen)]
            Start_CS_RealWorld_RoseRoom_Bed_Crack,

            [Description(Cutscene.TheQueen.Bed_Tears + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.Bed_Tears, Chapter.TheQueen)]
            Start_CS_RealWorld_RoseRoom_Bed_Tears,

            [Description(Cutscene.TheQueen.TherapyRoom_Session_Theme_Time + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TheQueen.TherapyRoom_Session_Theme_Time, Chapter.TheQueen)]
            Start_CS_TherapyRoom_Session_Theme_Time,
            #endregion
            #region Gates of Time
            [Description(Cutscene.GatesOfTime.Time_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.Time_Intro, Chapter.GatesOfTime)]
            Start_CS_ClockWork_LowerTower_Time_Intro,

            [Description(Cutscene.GatesOfTime.OpenFirstGate + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.OpenFirstGate, Chapter.GatesOfTime)]
            Start_CT_Clockwork_Outside_Tutorial_OpenFirstGate,

            [Description(Cutscene.GatesOfTime.ClockTown_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.ClockTown_Intro, Chapter.GatesOfTime)]
            Start_CS_ClockWork_Outside_ClockTown_Intro,

            [Description(Cutscene.GatesOfTime.RevealHellTower + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.RevealHellTower, Chapter.GatesOfTime)]
            Start_LS_Clockwork_Outside_ClockTown_RevealHellTower,

            [Description(Cutscene.GatesOfTime.Gate_Vegetation + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.Gate_Vegetation, Chapter.GatesOfTime)]
            Start_CS_ClockWork_Outside_Gate_Vegetation,

            [Description(Cutscene.GatesOfTime.Bird_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.Bird_Intro, Chapter.GatesOfTime)]
            Start_CS_ClockWork_Outside_Bird_Intro,

            [Description(Cutscene.GatesOfTime.LeftTower_ElevatorDown + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.LeftTower_ElevatorDown, Chapter.GatesOfTime)]
            Start_CS_Clockwork_Outside_LeftTower_ElevatorDown,

            [Description(Cutscene.GatesOfTime.RightTower_OpenRightTower + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.RightTower_OpenRightTower, Chapter.GatesOfTime)]
            Start_CT_Clockwork_Outside_RightTower_OpenRightTower,

            [Description(Cutscene.GatesOfTime.RightTower_ElevatorDown + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.RightTower_ElevatorDown, Chapter.GatesOfTime)]
            Start_CS_Clockwork_Outside_RightTower_ElevatorDown,

            [Description(Cutscene.GatesOfTime.LeftTower_OpenLeftTower + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.LeftTower_OpenLeftTower, Chapter.GatesOfTime)]
            Start_CT_Clockwork_Outside_LeftTower_OpenLeftTower,

            [Description(Cutscene.GatesOfTime.Tower_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GatesOfTime.Tower_Intro, Chapter.GatesOfTime)]
            Start_CS_ClockWork_Outside_Tower_Intro,
            #endregion
            #region Clockworks
            [Description(Cutscene.Clockworks.CrusherRoom_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.CrusherRoom_Intro, Chapter.Clockworks)]
            Start_CS_ClockWork_LowerTower_CrusherRoom_Intro,

            [Description(Cutscene.Clockworks.Bridge_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.Bridge_Intro, Chapter.Clockworks)]
            Start_CS_Clockwork_LowerTower_Bridge_Intro,

            [Description(Cutscene.Clockworks.BullBoss_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.BullBoss_Intro, Chapter.Clockworks)]
            Start_CS_ClockWork_LowerTower_BullBoss_Intro,

            [Description(Cutscene.Clockworks.BullBoss_HitPillarFirstTime + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.BullBoss_HitPillarFirstTime, Chapter.Clockworks)]
            Start_CS_Clockwork_LowerTower_BullBoss_HitPillarFirstTime,

            [Description(Cutscene.Clockworks.BullBoss_HitPillarSecondTime + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.BullBoss_HitPillarSecondTime, Chapter.Clockworks)]
            Start_CS_Clockwork_LowerTower_BullBoss_HitPillarSecondTime,

            [Description(Cutscene.Clockworks.BullBoss_BullBossCrushed + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.BullBoss_BullBossCrushed, Chapter.Clockworks)]
            Start_CS_Clockwork_LowerTower_BullBoss_BullBossCrushed,

            [Description(Cutscene.Clockworks.ChargerRoom_RoomDebris + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.ChargerRoom_RoomDebris, Chapter.Clockworks)]
            Start_LS_Clockwork_LowerTower_ChargerRoom_RoomDebris,

            [Description(Cutscene.Clockworks.EvilBird_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Clockworks.EvilBird_Intro, Chapter.Clockworks)]
            Start_CS_ClockWork_LowerTower_EvilBird_Intro,
            #endregion
            #region A Blast from the Past
            [Description(Cutscene.ABlastFromThePast.GlassWalkway_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.GlassWalkway_Intro, Chapter.ABlastFromThePast)]
            Start_CS_ClockWork_UpperTower_GlassWalkway_Intro,

            [Description(Cutscene.ABlastFromThePast.LaunchingPlatform + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.LaunchingPlatform, Chapter.ABlastFromThePast)]
            Start_CS_Clockwork_UpperTower_LastBoss_LaunchingPlatform,

            [Description(Cutscene.ABlastFromThePast.BuildingSmasherPlatform + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.BuildingSmasherPlatform, Chapter.ABlastFromThePast)]
            Start_CS_Clockwork_UpperTower_LastBoss_BuildingSmasherPlatform,

            [Description(Cutscene.ABlastFromThePast.AfterRewindSmash + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.AfterRewindSmash, Chapter.ABlastFromThePast)]
            Start_CS_Clockwork_UpperTower_LastBoss_AfterRewindSmash,

            [Description(Cutscene.ABlastFromThePast.LastBoss_Explosion + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.LastBoss_Explosion, Chapter.ABlastFromThePast)]
            Start_DS_Clockwork_UpperTower_LastBoss_Explosion,

            [Description(Cutscene.ABlastFromThePast.Final_Explosion + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.Final_Explosion, Chapter.ABlastFromThePast)]
            Start_CS_ClockWork_UpperTower_Final_Explosion,

            [Description(Cutscene.ABlastFromThePast.LandAfterExplosion + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.LandAfterExplosion, Chapter.ABlastFromThePast)]
            Start_CS_Clockwork_UpperTower_LastBoss_LandAfterExplosion,

            [Description(Cutscene.ABlastFromThePast.CodyEndingPlatform + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.CodyEndingPlatform, Chapter.ABlastFromThePast)]
            Start_EV_Clockwork_UpperTower_LastBoss_CodyEndingPlatform,

            [Description(Cutscene.ABlastFromThePast.MayEndingPlatform + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.MayEndingPlatform, Chapter.ABlastFromThePast)]
            Start_EV_Clockwork_UpperTower_LastBoss_MayEndingPlatform,

            [Description(Cutscene.ABlastFromThePast.EndingRewind + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.EndingRewind, Chapter.ABlastFromThePast)]
            Start_CS_ClockWork_UpperTower_EndingRewind,

            [Description(Cutscene.ABlastFromThePast.Time_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.Time_Outro, Chapter.ABlastFromThePast)]
            Start_CS_ClockWork_CuckoClock_Time_Outro,

            [Description(Cutscene.ABlastFromThePast.RealWorld_House_LowerLevel_Clock + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.RealWorld_House_LowerLevel_Clock, Chapter.ABlastFromThePast)]
            Start_CS_RealWorld_House_LowerLevel_Clock,

            [Description(Cutscene.ABlastFromThePast.TherapyRoom_Session_Theme_Attraction + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.ABlastFromThePast.TherapyRoom_Session_Theme_Attraction, Chapter.ABlastFromThePast)]
            Start_CS_TherapyRoom_Session_Theme_Attraction,
            #endregion
            #region Warming Up
            [Description(Cutscene.WarmingUp.Entrance_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WarmingUp.Entrance_Intro, Chapter.WarmingUp)]
            Start_CS_SnowGlobe_Forest_Entrance_Intro,

            [Description(Cutscene.WarmingUp.Find_Skates + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WarmingUp.Find_Skates, Chapter.WarmingUp)]
            Start_CS_SnowGlobe_Cabin_Find_Skates,
            #endregion
            #region Winter Village
            [Description(Cutscene.WinterVillage.SnowCaveOpenGate + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.SnowCaveOpenGate, Chapter.WinterVillage)]
            Start_CS_SnowGlobe_Town_SnowCaveOpenGate,

            [Description(Cutscene.WinterVillage.Bells_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.Bells_Intro, Chapter.WinterVillage)]
            Start_CS_SnowGlobe_Town_Bells_Intro,

            [Description(Cutscene.WinterVillage.FirstBellRung + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.FirstBellRung, Chapter.WinterVillage)]
            Start_CS_SnowGlobe_Town_TutorialArea_FirstBellRung,

            [Description(Cutscene.WinterVillage.SecondGatesOpening + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.SecondGatesOpening, Chapter.WinterVillage)]
            Start_CT_SnowGlobe_Town_SecondGatesOpening,

            [Description(Cutscene.WinterVillage.CraneBellRung + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.CraneBellRung, Chapter.WinterVillage)]
            Start_CS_SnowGlobe_Town_CraneArea_CraneBellRung,

            [Description(Cutscene.WinterVillage.BigWheelBellRung + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.BigWheelBellRung, Chapter.WinterVillage)]
            Start_CS_SnowGlobe_Town_BigWheelArea_BigWheelBellRung,

            [Description(Cutscene.WinterVillage.IceWallBellRung + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.IceWallBellRung, Chapter.WinterVillage)]
            Start_CS_SnowGlobe_Town_IceWallArea_IceWallBellRung,

            [Description(Cutscene.WinterVillage.CableCartOpen + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.CableCartOpen, Chapter.WinterVillage)]
            Start_CS_SnowGlobe_Town_TownCenter_CableCartOpen,

            [Description(Cutscene.WinterVillage.BobsledCompleted + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WinterVillage.BobsledCompleted, Chapter.WinterVillage)]
            Start_EV_SnowGlobe_Town_BobsledCompleted,
            #endregion
            #region Beneath the Ice
            [Description(Cutscene.BeneathTheIce.Swimming_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BeneathTheIce.Swimming_Intro, Chapter.BeneathTheIce)]
            Start_CS_SnowGlobe_Lake_Swimming_Intro,

            [Description(Cutscene.BeneathTheIce.Factory_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BeneathTheIce.Factory_Intro, Chapter.BeneathTheIce)]
            Start_CS_SnowGlobe_Lake_Factory_Intro,

            [Description(Cutscene.BeneathTheIce.IceCaveFinish + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BeneathTheIce.IceCaveFinish, Chapter.BeneathTheIce)]
            Start_LS_Snowglobe_Lake_IceCaveFinish,

            [Description(Cutscene.BeneathTheIce.FishDone + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BeneathTheIce.FishDone, Chapter.BeneathTheIce)]
            Start_LS_Snowglobe_Lake_FishDone,

            [Description(Cutscene.BeneathTheIce.BubbleDone + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BeneathTheIce.BubbleDone, Chapter.BeneathTheIce)]
            Start_CT_SnowGlobe_Lake_BubbleDone,

            [Description(Cutscene.BeneathTheIce.CoreElevatorDoorOpen + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BeneathTheIce.CoreElevatorDoorOpen, Chapter.BeneathTheIce)]
            Start_LS_SnowGlobe_Lake_CoreElevatorDoorOpen,

            [Description(Cutscene.BeneathTheIce.SkiLift_Ride + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.BeneathTheIce.SkiLift_Ride, Chapter.BeneathTheIce)]
            Start_CS_SnowGlobe_Lake_SkiLift_Ride,
            #endregion
            #region Slippery Slopes
            [Description(Cutscene.SlipperySlopes.SkiLift_Ride + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.SkiLift_Ride, Chapter.SlipperySlopes)]
            Start_CS_SnowGlobe_Mountain_SkiLift_Ride,

            [Description(Cutscene.SlipperySlopes.SmallCabin_Collapse + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.SmallCabin_Collapse, Chapter.SlipperySlopes)]
            Start_CS_SnowGlobe_Mountain_SmallCabin_Collapse,

            [Description(Cutscene.SlipperySlopes.CollapseFall + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.CollapseFall, Chapter.SlipperySlopes)]
            Start_CT_SnowGlobe_Mountain_CollapseFall,

            [Description(Cutscene.SlipperySlopes.IceCave_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.IceCave_Intro, Chapter.SlipperySlopes)]
            Start_CS_SnowGlobe_Mountain_IceCave_Intro,

            [Description(Cutscene.SlipperySlopes.Ground_Elevator + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.Ground_Elevator, Chapter.SlipperySlopes)]
            Start_CS_SnowGlobe_Tower_Ground_Elevator,

            [Description(Cutscene.SlipperySlopes.Terrace_Proposal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.Terrace_Proposal, Chapter.SlipperySlopes)]
            Start_CS_SnowGlobe_Tower_Terrace_Proposal,

            [Description(Cutscene.SlipperySlopes.RealWorld_House_Kitchen_Sandwiches + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.RealWorld_House_Kitchen_Sandwiches, Chapter.SlipperySlopes)]
            Start_CS_RealWorld_House_Kitchen_Sandwiches,

            [Description(Cutscene.SlipperySlopes.TherapyRoom_Session_Theme_Garden + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SlipperySlopes.TherapyRoom_Session_Theme_Garden, Chapter.SlipperySlopes)]
            Start_CS_TherapyRoom_Session_Theme_Garden,
            #endregion
            #region Green Fingers
            [Description(Cutscene.GreenFingers.Entrance_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.Entrance_Intro, Chapter.GreenFingers)]
            Start_CS_Garden_VegetablePatch_Entrance_Intro,

            [Description(Cutscene.GreenFingers.Entrance_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.Entrance_Outro, Chapter.GreenFingers)]
            Start_CS_Garden_VegetablePatch_Entrance_Outro,

            [Description(Cutscene.GreenFingers.BeanstalkFlowerGate + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.BeanstalkFlowerGate, Chapter.GreenFingers)]
            Start_CT_Garden_VegetablePatch_BeanstalkFlowerGate,

            [Description(Cutscene.GreenFingers.Burrower_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.Burrower_Intro, Chapter.GreenFingers)]
            Start_CS_Garden_VegetablePatch_Burrower_Intro,

            [Description(Cutscene.GreenFingers.SpaEntrance_Cody_Enter + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.SpaEntrance_Cody_Enter, Chapter.GreenFingers)]
            Start_CS_Garden_SpaEntrance_Cody_Enter,

            [Description(Cutscene.GreenFingers.SpaEntrance_May_Enter + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.SpaEntrance_May_Enter, Chapter.GreenFingers)]
            Start_CS_Garden_SpaEntrance_May_Enter,

            [Description(Cutscene.GreenFingers.SpaEntrance_Cody_Exit + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.SpaEntrance_Cody_Exit, Chapter.GreenFingers)]
            Start_CS_Garden_SpaEntrance_Cody_Exit,

            [Description(Cutscene.GreenFingers.SpaEntrance_May_Exit + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.SpaEntrance_May_Exit, Chapter.GreenFingers)]
            Start_CS_Garden_SpaEntrance_May_Exit,

            [Description(Cutscene.GreenFingers.OutsideGreenhouse_Unwither + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.OutsideGreenhouse_Unwither, Chapter.GreenFingers)]
            Start_CT_Garden_VegetablePatch_OutsideGreenhouse_Unwither,

            [Description(Cutscene.GreenFingers.Greenhouse_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.GreenFingers.Greenhouse_Intro, Chapter.GreenFingers)]
            Start_CS_Garden_VegetablePatch_Greenhouse_Intro,
            #endregion
            #region Weed Whacking
            [Description(Cutscene.WeedWhacking.Shrubbery_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.Shrubbery_Intro, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_Shrubbery_Intro,

            [Description(Cutscene.WeedWhacking.IntroducingSpider + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.IntroducingSpider, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_CombatArea_IntroducingSpider,

            [Description(Cutscene.WeedWhacking.SpiderIntro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.SpiderIntro, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_CombatArea_SpiderIntro,

            [Description(Cutscene.WeedWhacking.SpiderMount + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.SpiderMount, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_DandelionPit_SpiderMount,

            [Description(Cutscene.WeedWhacking.LogCollapse + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.LogCollapse, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_SpinningLog_LogCollapse,

            [Description(Cutscene.WeedWhacking.EscapeFromSinkingLog + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.EscapeFromSinkingLog, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_SpinningLog_EscapeFromSinkingLog,

            [Description(Cutscene.WeedWhacking.SpiderNest_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.SpiderNest_Outro, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_SpiderNest_Outro,

            [Description(Cutscene.WeedWhacking.CactusWaves_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.CactusWaves_Intro, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_CactusWaves_Intro,

            [Description(Cutscene.WeedWhacking.SecondCombat_LeavesExtended + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.SecondCombat_LeavesExtended, Chapter.WeedWhacking)]
            Start_CT_Garden_Shrubbery_SecondCombat_LeavesExtended,

            [Description(Cutscene.WeedWhacking.PoisonCore_AreaOutro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.WeedWhacking.PoisonCore_AreaOutro, Chapter.WeedWhacking)]
            Start_CS_Garden_Shrubbery_PoisonCore_AreaOutro,
            #endregion
            #region Trespassing
            [Description(Cutscene.Trespassing.LevelStart + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Trespassing.LevelStart, Chapter.Trespassing)]
            Start_CS_Garden_Moletunnels_Stealth_LevelStart,

            [Description(Cutscene.Trespassing.PushPineCone + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Trespassing.PushPineCone, Chapter.Trespassing)]
            Start_CS_Garden_MoleTunnels_Stealth_PushPineCone,

            [Description(Cutscene.Trespassing.Discovered_Part1 + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Trespassing.Discovered_Part1, Chapter.Trespassing)]
            Start_CS_Garden_MoleTunnels_Discovered_Part1,

            [Description(Cutscene.Trespassing.Discovered_Part1_Short + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Trespassing.Discovered_Part1_Short, Chapter.Trespassing)]
            Start_TP_Garden_MoleTunnels_Discovered_Part1_Short,

            [Description(Cutscene.Trespassing.PlantDestroyed + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Trespassing.PlantDestroyed, Chapter.Trespassing)]
            Start_CS_Garden_MoleTunnels_PlantDestroyed,

            [Description(Cutscene.Trespassing.FallDownInto2D + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Trespassing.FallDownInto2D, Chapter.Trespassing)]
            Start_CS_Garden_Moletunnels_Chase_FallDownInto2D,

            [Description(Cutscene.Trespassing.LevelEnding + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Trespassing.LevelEnding, Chapter.Trespassing)]
            Start_CS_Garden_MoleTunnels_Chase_LevelEnding,
            #endregion
            #region Frog Pond
            [Description(Cutscene.FrogPond.FrogRide + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FrogPond.FrogRide, Chapter.FrogPond)]
            Start_CS_Garden_FrogPond_TaxiStand_FrogRide,

            [Description(Cutscene.FrogPond.SmallerFountainPlatformsEnabled + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FrogPond.SmallerFountainPlatformsEnabled, Chapter.FrogPond)]
            Start_CT_Garden_FrogPond_MainFountain_SmallerFountainPlatformsEnabled,

            [Description(Cutscene.FrogPond.MainFountain_PoisonBulbDestroyed + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FrogPond.MainFountain_PoisonBulbDestroyed, Chapter.FrogPond)]
            Start_CS_Garden_FrogPond_MainFountain_PoisonBulbDestroyed,

            [Description(Cutscene.FrogPond.Greenhouse_OpenDoor + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.FrogPond.Greenhouse_OpenDoor, Chapter.FrogPond)]
            Start_CS_Garden_FrogPond_Greenhouse_OpenDoor,
            #endregion
            #region Affliction
            [Description(Cutscene.Affliction.Door_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.Door_Intro, Chapter.Affliction)]
            Start_CS_Garden_GreenHouse_Door_Intro,

            [Description(Cutscene.Affliction.Floor_KilledSmallBulb + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.Floor_KilledSmallBulb, Chapter.Affliction)]
            Start_CT_Garden_Greenhouse_Floor_KilledSmallBulb,

            [Description(Cutscene.Affliction.RightbulbDestroyed + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.RightbulbDestroyed, Chapter.Affliction)]
            Start_CT_Garden_Greenhouse_RightTable_RightbulbDestroyed,

            [Description(Cutscene.Affliction.LeftTable_KilledSmallBulb + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.LeftTable_KilledSmallBulb, Chapter.Affliction)]
            Start_CT_Garden_Greenhouse_LeftTable_KilledSmallBulb,

            [Description(Cutscene.Affliction.MainArea_Greenified + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.MainArea_Greenified, Chapter.Affliction)]
            Start_CT_Garden_Greenhouse_MainArea_Greenified,

            [Description(Cutscene.Affliction.BossRoom_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_Intro, Chapter.Affliction)]
            Start_CS_Garden_GreenHouse_BossRoom_Intro,

            [Description(Cutscene.Affliction.BossRoom_CodyTakesControl + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_CodyTakesControl, Chapter.Affliction)]
            Start_CS_Garden_Greenhouse_BossRoom_CodyTakesControl,

            [Description(Cutscene.Affliction.BossRoom_DestroyFirstBlob + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_DestroyFirstBlob, Chapter.Affliction)]
            Start_CS_Garden_Greenhouse_BossRoom_DestroyFirstBlob,

            [Description(Cutscene.Affliction.BossRoom_ThrowSecondPot + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_ThrowSecondPot, Chapter.Affliction)]
            Start_CS_Garden_Greenhouse_BossRoom_ThrowSecondPot,

            [Description(Cutscene.Affliction.BossRoom_CodyTakesControlPhaseTwo + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_CodyTakesControlPhaseTwo, Chapter.Affliction)]
            Start_CS_Garden_Greenhouse_BossRoom_CodyTakesControlPhaseTwo,

            [Description(Cutscene.Affliction.BossRoom_ThrowThirdPot + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_ThrowThirdPot, Chapter.Affliction)]
            Start_CS_Garden_Greenhouse_BossRoom_ThrowThirdPot,

            [Description(Cutscene.Affliction.BossRoom_CodyTakesControlPhaseThree + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_CodyTakesControlPhaseThree, Chapter.Affliction)]
            Start_CS_Garden_Greenhouse_BossRoom_CodyTakesControlPhaseThree,

            [Description(Cutscene.Affliction.BossRoom_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.BossRoom_Outro, Chapter.Affliction)]
            Start_CS_Garden_GreenHouse_BossRoom_Outro,

            [Description(Cutscene.Affliction.RealWorld_House_RoseRoom_FlowerPot + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.RealWorld_House_RoseRoom_FlowerPot, Chapter.Affliction)]
            Start_CS_RealWorld_House_RoseRoom_FlowerPot,

            [Description(Cutscene.Affliction.TherapyRoom_Session_Theme_Music + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Affliction.TherapyRoom_Session_Theme_Music, Chapter.Affliction)]
            Start_CS_TherapyRoom_Session_Theme_Music,
            #endregion
            #region Setting the Stage
            [Description(Cutscene.SettingTheStage.Backstage_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SettingTheStage.Backstage_Intro, Chapter.SettingTheStage)]
            Start_CS_Music_ConcertHall_Backstage_Intro,

            [Description(Cutscene.SettingTheStage.EnteringBackstage + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SettingTheStage.EnteringBackstage, Chapter.SettingTheStage)]
            Start_CS_Music_ConcertHall_EnteringBackstage,
            #endregion
            #region Rehearsal
            [Description(Cutscene.Rehearsal.PortableSpeakerRoom_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.PortableSpeakerRoom_Intro, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_PortableSpeakerRoom_Intro,

            [Description(Cutscene.Rehearsal.Jukebox_CoinSuck + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.Jukebox_CoinSuck, Chapter.Rehearsal)]
            Start_EV_Music_Backstage_Jukebox_CoinSuck,

            [Description(Cutscene.Rehearsal.PortableSpeakerRoom_WindowBlast + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.PortableSpeakerRoom_WindowBlast, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_PortableSpeakerRoom_WindowBlast,

            [Description(Cutscene.Rehearsal.BassRoom_Landing + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.BassRoom_Landing, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_BassRoom_Landing,

            [Description(Cutscene.Rehearsal.MusicTechWall_GoingThroughTruss + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.MusicTechWall_GoingThroughTruss, Chapter.Rehearsal)]
            Start_CT_Music_Backstage_MusicTechWall_GoingThroughTruss,

            [Description(Cutscene.Rehearsal.MusicTechWall_Reveal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.MusicTechWall_Reveal, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_MusicTechWall_Reveal,

            [Description(Cutscene.Rehearsal.MusicTechWall_PowerCableTravel + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.MusicTechWall_PowerCableTravel, Chapter.Rehearsal)]
            Start_CT_Music_Backstage_MusicTechWall_PowerCableTravel,

            [Description(Cutscene.Rehearsal.MicrophoneRoom_MotherReveal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.MicrophoneRoom_MotherReveal, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_MicrophoneRoom_MotherReveal,

            [Description(Cutscene.Rehearsal.MicrophoneChase_FallToGrind + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.MicrophoneChase_FallToGrind, Chapter.Rehearsal)]
            Start_DS_Music_Backstage_MicrophoneChase_FallToGrind,

            [Description(Cutscene.Rehearsal.MicrophoneChase_BrokenTruss + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.MicrophoneChase_BrokenTruss, Chapter.Rehearsal)]
            Start_DS_Music_Backstage_MicrophoneChase_BrokenTruss,

            [Description(Cutscene.Rehearsal.BassRoom_Landing + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.BassRoom_Landing, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_MicrophoneChase_Landing,

            [Description(Cutscene.Rehearsal.MicrophoneChase_Ending + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.MicrophoneChase_Ending, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_MicrophoneChase_Ending,

            [Description(Cutscene.Rehearsal.LightRoom_Entrance + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.LightRoom_Entrance, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_LightRoom_Entrance,

            [Description(Cutscene.Rehearsal.LightRoom_EndOfLightRoom + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Rehearsal.LightRoom_EndOfLightRoom, Chapter.Rehearsal)]
            Start_CS_Music_Backstage_LightRoom_EndOfLightRoom,
            #endregion
            #region Symphony
            [Description(Cutscene.SettingTheStage.Backstage_Orchestra + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SettingTheStage.Backstage_Orchestra, Chapter.Symphony)]
            Start_CS_Music_ConcertHall_Backstage_Orchestra,

            [Description(Cutscene.SettingTheStage.EnteringClassic + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SettingTheStage.EnteringClassic, Chapter.Symphony)]
            Start_CS_Music_ConcertHall_BackStage_EnteringClassic,

            [Description(Cutscene.Symphony.EnterClassic + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.EnterClassic, Chapter.Symphony)]
            Start_CS_Music_Classic_Attic_EnterClassic,

            [Description(Cutscene.Symphony.Flying + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.Flying, Chapter.Symphony)]
            Start_CS_Music_Classic_Heaven_Flying,

            [Description(Cutscene.Symphony.Reveal + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.Reveal, Chapter.Symphony)]
            Start_CS_Music_Classic_Heaven_Reveal,

            [Description(Cutscene.Symphony.OpenBirdCage + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.OpenBirdCage, Chapter.Symphony)]
            Start_CS_Music_Classic_Heaven_OpenBirdCage,

            [Description(Cutscene.Symphony.ReleaseFollowersCage + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.ReleaseFollowersCage, Chapter.Symphony)]
            Start_CS_Music_Classic_Heaven_ReleaseFollowersCage,

            [Description(Cutscene.Symphony.OpenCloudRoom + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.OpenCloudRoom, Chapter.Symphony)]
            Start_CS_Music_Classic_Heaven_OpenCloudRoom,

            [Description(Cutscene.Symphony.ReleaseFollowersCloud + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.ReleaseFollowersCloud, Chapter.Symphony)]
            Start_CS_Music_Classic_Heaven_ReleaseFollowersCloud,

            [Description(Cutscene.Symphony.LevelEnding + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Symphony.LevelEnding, Chapter.Symphony)]
            Start_CS_Music_Classic_Heaven_LevelEnding,
            #endregion
            #region Turn Up
            [Description(Cutscene.SettingTheStage.Backstage_Audience + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SettingTheStage.Backstage_Audience, Chapter.TurnUp)]
            Start_CS_Music_ConcertHall_Backstage_Audience,

            [Description(Cutscene.SettingTheStage.NightClub_Entrance + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.SettingTheStage.NightClub_Entrance, Chapter.TurnUp)]
            Start_CS_Music_ConcertHall_NightClub_Entrance,

            [Description(Cutscene.TurnUp.RainbowSlide_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.RainbowSlide_Intro, Chapter.TurnUp)]
            Start_CS_Music_Nightclub_RainbowSlide_Intro,

            [Description(Cutscene.TurnUp.RainbowSlide_RespawnMay1 + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.RainbowSlide_RespawnMay1, Chapter.TurnUp)]
            Start_EV_Music_Nightclub_RainbowSlide_RespawnMay1,

            [Description(Cutscene.TurnUp.RainbowSlide_RespawnCody1 + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.RainbowSlide_RespawnCody1, Chapter.TurnUp)]
            Start_EV_Music_Nightclub_RainbowSlide_RespawnCody1,

            [Description(Cutscene.TurnUp.Discoball_GroundpoundStart + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.Discoball_GroundpoundStart, Chapter.TurnUp)]
            Start_CS_Music_NightClub_Discoball_GroundpoundStart,

            [Description(Cutscene.TurnUp.DiscoRide_BallCrash + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.DiscoRide_BallCrash, Chapter.TurnUp)]
            Start_CS_Music_NightClub_DiscoRide_BallCrash,

            [Description(Cutscene.TurnUp.Basement_DjElevator + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.Basement_DjElevator, Chapter.TurnUp)]
            Start_CT_Music_Nightclub_Basement_DjElevator,

            [Description(Cutscene.TurnUp.Basement_Elevator + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.Basement_Elevator, Chapter.TurnUp)]
            Start_CS_Music_NightClub_Basement_Elevator,

            [Description(Cutscene.TurnUp.DJ_Outro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.TurnUp.DJ_Outro, Chapter.TurnUp)]
            Start_CS_Music_NightClub_DJ_Outro,
            #endregion
            #region A Grand Finale
            [Description(Cutscene.AGrandFinale.DropDown_Preparation + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.DropDown_Preparation, Chapter.AGrandFinale)]
            Start_CS_Music_Ending_DropDown_Preparation,

            [Description(Cutscene.AGrandFinale.DressingRoom_Mirror + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.DressingRoom_Mirror, Chapter.AGrandFinale)]
            Start_CS_Music_Ending_DressingRoom_Mirror,

            [Description(Cutscene.AGrandFinale.FirstCameraRide + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.FirstCameraRide, Chapter.AGrandFinale)]
            Start_CS_Music_Ending_BehindStage_FirstCameraRide,

            [Description(Cutscene.AGrandFinale.SecondCameraRide + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.SecondCameraRide, Chapter.AGrandFinale)]
            Start_CS_Music_Ending_BehindStage_SecondCameraRide,

            [Description(Cutscene.AGrandFinale.GrandFinaleEnding + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.GrandFinaleEnding, Chapter.AGrandFinale)]
            Start_CS_Music_Attic_Stage_GrandFinaleEnding,

            [Description(Cutscene.AGrandFinale.Smooch + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.Smooch, Chapter.AGrandFinale)]
            Start_CT_Music_Ending_Smooch,

            [Description(Cutscene.AGrandFinale.ClimacticKiss + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.ClimacticKiss, Chapter.AGrandFinale)]
            Start_CS_Music_Attic_Stage_ClimacticKiss,

            [Description(Cutscene.AGrandFinale.RealWorld_House_Study_Wakeup + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.RealWorld_House_Study_Wakeup, Chapter.AGrandFinale)]
            Start_CS_RealWorld_House_Study_Wakeup,

            [Description(Cutscene.AGrandFinale.RealWorld_RoseRoom_Bed_Letter + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.RealWorld_RoseRoom_Bed_Letter, Chapter.AGrandFinale)]
            Start_CS_RealWorld_RoseRoom_Bed_Letter,

            [Description(Cutscene.AGrandFinale.RealWorld_Exterior_Busstop_Reunion + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.RealWorld_Exterior_Busstop_Reunion, Chapter.AGrandFinale)]
            Start_CS_RealWorld_Exterior_Busstop_Reunion,

            [Description(Cutscene.AGrandFinale.RealWorld_House_Credits_PlaceBook + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.AGrandFinale.RealWorld_House_Credits_PlaceBook, Chapter.AGrandFinale)]
            Start_CS_RealWorld_House_Credits_PlaceBook,
            #endregion
            #region Basement

            [Description(Cutscene.Basement.TherapyRoom_Session_Theme_Love + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Basement.TherapyRoom_Session_Theme_Love, Chapter.Basement)]
            Start_CS_TherapyRoom_Session_Theme_Love,

            [Description(Cutscene.Basement.Seekers_Door_Intro + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Basement.Seekers_Door_Intro, Chapter.Basement)]
            Start_CS_Basement_Seekers_Door_Intro,

            [Description(Cutscene.Basement.BossRoom_Argue_Collapse + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Basement.BossRoom_Argue_Collapse, Chapter.Basement)]
            Start_CS_Basement_BossRoom_Argue_Collapse,

            [Description(Cutscene.Basement.BossRoom_Argue_Light + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Basement.BossRoom_Argue_Light, Chapter.Basement)]
            Start_CS_Basement_BossRoom_Argue_Light,

            [Description(Cutscene.Basement.Boss_GrayPlace_Letter + Tag.CutsceneStart),
                ToolTip(Cutscene.StartFormat, Cutscene.Basement.Boss_GrayPlace_Letter, Chapter.Basement)]
            Start_CS_Basement_Boss_GrayPlace_Letter,

            #endregion
            #endregion
            #region End
            #region Wake-Up Call
            [Description(Cutscene.WakeUpCall.Divorce_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WakeUpCall.Divorce_Intro, Chapter.WakeUpCall)]
            End_CS_Shed_Awakening_Divorce_Intro,

            [Description(Cutscene.WakeUpCall.FuseSocket_JumpOut + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WakeUpCall.FuseSocket_JumpOut, Chapter.WakeUpCall)]
            End_CS_Shed_Awakening_FuseSocket_JumpOut,

            [Description(Cutscene.WakeUpCall.FuseSocket_Activate + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WakeUpCall.FuseSocket_Activate, Chapter.WakeUpCall)]
            End_CS_Shed_Awakening_FuseSocket_Activate,

            [Description(Cutscene.WakeUpCall.Saw_Success + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WakeUpCall.Saw_Success, Chapter.WakeUpCall)]
            End_EV_Shed_Awakening_Saw_Success,
            #endregion
            #region Biting the dust
            [Description(Cutscene.BitingTheDust.Meet_Sucked + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BitingTheDust.Meet_Sucked, Chapter.BitingTheDust)]
            End_CS_Shed_Vacuum_Meet_Sucked,

            [Description(Cutscene.BitingTheDust.Vacuum_Battle + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BitingTheDust.Vacuum_Battle, Chapter.BitingTheDust)]
            End_CS_Shed_Awakening_Vacuum_Battle_var2,

            [Description(Cutscene.BitingTheDust.BossFight_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BitingTheDust.BossFight_Outro, Chapter.BitingTheDust)]
            End_CS_Shed_Vacuum_BossFight_Outro,
            #endregion
            #region The Depths
            [Description(Cutscene.TheDepths.Abyss_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.Abyss_Intro, Chapter.TheDepths)]
            End_CS_Shed_Main_Abyss_Intro,

            [Description(Cutscene.TheDepths.Abyss_Rust + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.Abyss_Rust, Chapter.TheDepths)]
            End_CS_Shed_Main_Abyss_Rust,

            [Description(Cutscene.TheDepths.MiniGame_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.MiniGame_Intro, Chapter.TheDepths)]
            End_CS_Shed_Tambourine_MiniGame_Intro,

            [Description(Cutscene.TheDepths.MachineRoom_StartMachine + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.MachineRoom_StartMachine, Chapter.TheDepths)]
            End_CS_Shed_Main_MachineRoom_StartMachine,

            [Description(Cutscene.TheDepths.ToolBoss_Battle + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.ToolBoss_Battle, Chapter.TheDepths)]
            End_CS_Shed_Main_ToolBoss_Battle,

            [Description(Cutscene.TheDepths.ToolBoxBoss_BossIntro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.ToolBoxBoss_BossIntro, Chapter.TheDepths)]
            End_CS_Shed_Main_ToolBoxBoss_BossIntro,

            [Description(Cutscene.TheDepths.ToolBoss_FirstPadLock + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.ToolBoss_FirstPadLock, Chapter.TheDepths)]
            End_CS_Shed_Main_ToolBoss_FirstPadLock,

            [Description(Cutscene.TheDepths.ToolBoxBoss_KillLeftArm + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.ToolBoxBoss_KillLeftArm, Chapter.TheDepths)]
            End_CS_Shed_Main_ToolBoxBoss_KillLeftArm,

            [Description(Cutscene.TheDepths.ToolBoss_Defeat + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.ToolBoss_Defeat, Chapter.TheDepths)]
            End_CS_Shed_Main_ToolBoss_Defeat,

            [Description(Cutscene.TheDepths.ToolBoss_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheDepths.ToolBoss_Outro, Chapter.TheDepths)]
            End_CS_Shed_Main_ToolBoss_Outro,
            #endregion
            #region Wired Up
            [Description(Cutscene.WiredUp.ToolBoss_Door + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WiredUp.ToolBoss_Door, Chapter.WiredUp)]
            End_CS_Shed_Main_ToolBoss_Door,

            [Description(Cutscene.WiredUp.Stargazing_Meet + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WiredUp.Stargazing_Meet, Chapter.WiredUp)]
            End_CS_RealWorld_Shed_Stargazing_Meet,
            #endregion
            #region Fresh Air
            [Description(Cutscene.FreshAir.Roof_Swing + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FreshAir.Roof_Swing, Chapter.FreshAir)]
            End_CS_Tree_Approach_Roof_Swing,

            [Description(Cutscene.FreshAir.Gate_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FreshAir.Gate_Intro, Chapter.FreshAir)]
            End_CS_Tree_Approach_Gate_Intro,

            [Description(Cutscene.FreshAir.Study_Friends + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FreshAir.Study_Friends, Chapter.FreshAir)]
            End_CS_RealWorld_House_Study_Friends,

            [Description(Cutscene.FreshAir.Interrogation + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FreshAir.Interrogation, Chapter.FreshAir)]
            End_CS_Tree_SquirrelTurf_Home_Interrogation,
            #endregion
            #region Captured
            [Description(Cutscene.Captured.WallDivide_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Captured.WallDivide_Intro, Chapter.Captured)]
            End_CS_Tree_SquirrelHome_WallDivide_Intro,
            #endregion
            #region Deeply Rooted
            [Description(Cutscene.DeeplyRooted.RobotQueen_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.RobotQueen_Intro, Chapter.DeeplyRooted)]
            End_CS_Tree_WaspNest_RobotQueen_Intro,

            [Description(Cutscene.DeeplyRooted.Boat_River + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.Boat_River, Chapter.DeeplyRooted)]
            End_CS_Tree_WaspNest_Boat_River,

            [Description(Cutscene.DeeplyRooted.BoatSwarmCreation + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.BoatSwarmCreation, Chapter.DeeplyRooted)]
            End_EV_Tree_Boat_Ending_BoatSwarmCreation,

            [Description(Cutscene.DeeplyRooted.DarkRoom_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.DarkRoom_Intro, Chapter.DeeplyRooted)]
            End_CS_Tree_WaspNest_DarkRoom_Intro,

            [Description(Cutscene.DeeplyRooted.FallingFromDarkroom + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.FallingFromDarkroom, Chapter.DeeplyRooted)]
            End_CS_Tree_WaspNest_Elevator_FallingFromDarkroom,

            [Description(Cutscene.DeeplyRooted.Arena_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.Arena_Intro, Chapter.DeeplyRooted)]
            End_CS_Tree_WaspNest_Arena_Intro,

            [Description(Cutscene.DeeplyRooted.TreeBug_Ride + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.TreeBug_Ride, Chapter.DeeplyRooted)]
            End_CS_Tree_WaspNest_TreeBug_Ride,

            [Description(Cutscene.DeeplyRooted.Bug_Crash + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DeeplyRooted.Bug_Crash, Chapter.DeeplyRooted)]
            End_CS_Tree_WaspNest_Bug_Crash,
            #endregion
            #region Extermination
            [Description(Cutscene.Extermination.Boss_Meet + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Extermination.Boss_Meet, Chapter.Extermination)]
            End_CS_Tree_Hive_Boss_Meet,

            [Description(Cutscene.Extermination.PlaneIntro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Extermination.PlaneIntro, Chapter.Extermination)]
            End_CS_Tree_WaspQueenBoss_Arena_PlaneIntro,

            [Description(Cutscene.Extermination.SmashInWood + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Extermination.SmashInWood, Chapter.Extermination)]
            End_CS_Tree_WaspQueenBoss_Arena_SmashInWood,

            [Description(Cutscene.Extermination.Defeated + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Extermination.Defeated, Chapter.Extermination)]
            End_CS_Tree_WaspQueenBoss_Arena_Defeated,

            [Description(Cutscene.Extermination.Boss_Victory + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Extermination.Boss_Victory, Chapter.Extermination)]
            End_CS_Tree_Hive_Boss_Victory,

            [Description(Cutscene.Extermination.Return_Flight + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Extermination.Return_Flight, Chapter.Extermination)]
            End_CS_Tree_SquirrelTurf_Return_Flight,
            #endregion
            #region Getaway
            [Description(Cutscene.Getaway.Flight_Chase + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Getaway.Flight_Chase, Chapter.Getaway)]
            End_CS_Tree_Escape_Flight_Chase,

            [Description(Cutscene.Getaway.Chase_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Getaway.Chase_Outro, Chapter.Getaway)]
            End_CS_Tree_Escape_Chase_Outro,

            [Description(Cutscene.Getaway.Plane_Combat + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Getaway.Plane_Combat, Chapter.Getaway)]
            End_CS_Tree_Escape_Plane_Combat,

            [Description(Cutscene.Getaway.NoseDive_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Getaway.NoseDive_Intro, Chapter.Getaway)]
            End_CS_Tree_Escape_NoseDive_Intro_Right,

            [Description(Cutscene.Getaway.NoseDive_Crash + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Getaway.NoseDive_Crash, Chapter.Getaway)]
            End_CS_Tree_Escape_NoseDive_Crash,

            [Description(Cutscene.Getaway.LivingRoom_Headache + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Getaway.LivingRoom_Headache, Chapter.Getaway)]
            End_CS_RealWorld_House_LivingRoom_Headache,

            [Description(Cutscene.Getaway.Roof_Crash + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Getaway.Roof_Crash, Chapter.Getaway)]
            End_CS_RealWorld_Exterior_Roof_Crash,
            #endregion
            #region Pillow Fort
            [Description(Cutscene.PillowFort.Landing_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PillowFort.Landing_Intro, Chapter.PillowFort)]
            End_CS_PlayRoom_PillowFort_Landing_Intro,

            [Description(Cutscene.PillowFort.Dolls_Dialogue + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PillowFort.Dolls_Dialogue, Chapter.PillowFort)]
            End_CS_PlayRoom_PillowFort_Dolls_Dialogue,

            [Description(Cutscene.PillowFort.SpaceStation_Transport + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PillowFort.SpaceStation_Transport, Chapter.PillowFort)]
            End_CS_PlayRoom_PillowFort_SpaceStation_Transport,
            #endregion
            #region Spaced Out
            [Description(Cutscene.SpacedOut.BeamUp_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BeamUp_Intro, Chapter.SpacedOut)]
            End_CS_PlayRoom_PillowFort_BeamUp_Intro,

            [Description(Cutscene.SpacedOut.FirstGeneratorActivated + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.FirstGeneratorActivated, Chapter.SpacedOut)]
            End_EV_PlayRoom_SpaceStation_Hub_FirstGeneratorActivated,

            [Description(Cutscene.SpacedOut.BalanceScales_ReturnToPortal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BalanceScales_ReturnToPortal, Chapter.SpacedOut)]
            End_EV_PlayRoom_SpaceStation_BalanceScales_ReturnToPortal,

            [Description(Cutscene.SpacedOut.Planets_ReturnToPortal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.Planets_ReturnToPortal, Chapter.SpacedOut)]
            End_EV_PlayRoom_SpaceStation_Planets_ReturnToPortal,

            [Description(Cutscene.SpacedOut.PlasmaBall_ReturnToPortal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.PlasmaBall_ReturnToPortal, Chapter.SpacedOut)]
            End_EV_PlayRoom_SpaceStation_PlasmaBall_ReturnToPortal,

            [Description(Cutscene.SpacedOut.SpaceBowl_ReturnToPortal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.SpaceBowl_ReturnToPortal, Chapter.SpacedOut)]
            End_EV_PlayRoom_SpaceStation_SpaceBowl_ReturnToPortal,

            [Description(Cutscene.SpacedOut.LaunchBoard_ReturnToPortal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.LaunchBoard_ReturnToPortal, Chapter.SpacedOut)]
            End_EV_PlayRoom_SpaceStation_LaunchBoard_ReturnToPortal,

            [Description(Cutscene.SpacedOut.Electricity_ReturnToPortal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.Electricity_ReturnToPortal, Chapter.SpacedOut)]
            End_EV_PlayRoom_SpaceStation_Electricity_ReturnToPortal,

            [Description(Cutscene.SpacedOut.SecondGenerator + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.SecondGenerator, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_Hub_SecondGenerator,

            [Description(Cutscene.SpacedOut.BossFight_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BossFight_Intro, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_BossFight_Intro,

            [Description(Cutscene.SpacedOut.BossFight_PowerCoresDestroyed + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BossFight_PowerCoresDestroyed, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_BossFight_PowerCoresDestroyed,

            [Description(Cutscene.SpacedOut.BossFight_RipOffLaserGun + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BossFight_RipOffLaserGun, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_BossFight_RipOffLaserGun,

            [Description(Cutscene.SpacedOut.BossFight_RocketsPhaseFinished + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BossFight_RocketsPhaseFinished, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_BossFight_RocketsPhaseFinished,

            [Description(Cutscene.SpacedOut.BossFight_Eject + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BossFight_Eject, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_BossFight_Eject,

            [Description(Cutscene.SpacedOut.BossFight_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BossFight_Outro, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_BossFight_Outro,

            [Description(Cutscene.SpacedOut.BossFight_BeamOut + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SpacedOut.BossFight_BeamOut, Chapter.SpacedOut)]
            End_CS_PlayRoom_SpaceStation_BossFight_BeamOut,
            #endregion
            #region Hopscotch
            [Description(Cutscene.Hopscotch.UnderBed_Landing + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.UnderBed_Landing, Chapter.Hopscotch)]
            End_CS_PlayRoom_Hopscotch_UnderBed_Landing,

            [Description(Cutscene.Hopscotch.Homework_FallThroughPlanks + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.Homework_FallThroughPlanks, Chapter.Hopscotch)]
            End_CS_PlayRoom_Hopscotch_Homework_FallThroughPlanks,

            [Description(Cutscene.Hopscotch.Homework_FallThroughPlanksLanding + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.Homework_FallThroughPlanksLanding, Chapter.Hopscotch)]
            End_CS_PlayRoom_Hopscotch_Homework_FallThroughPlanksLanding,

            [Description(Cutscene.Hopscotch.CompletedFirstMaze + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.CompletedFirstMaze, Chapter.Hopscotch)]
            End_CT_PlayRoom_Hopscotch_MarbleMazeRoom_CompletedFirstMaze,

            [Description(Cutscene.Hopscotch.CompletedSecondMaze + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.CompletedSecondMaze, Chapter.Hopscotch)]
            End_CT_PlayRoom_Hopscotch_MarbleMazeRoom_CompletedSecondMaze,

            [Description(Cutscene.Hopscotch.WhoopeeSwivelDoorTransition + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.WhoopeeSwivelDoorTransition, Chapter.Hopscotch)]
            End_CT_PlayRoom_Hopscotch_Dungeon_WhoopeeSwivelDoorTransition,

            [Description(Cutscene.Hopscotch.Dungeon_TreasureChest + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.Dungeon_TreasureChest, Chapter.Hopscotch)]
            End_CS_PlayRoom_Hopscotch_Dungeon_TreasureChest,

            [Description(Cutscene.Hopscotch.Kaleidoscope_Elevator + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.Kaleidoscope_Elevator, Chapter.Hopscotch)]
            End_CS_PlayRoom_Hopscotch_Kaleidoscope_Elevator,

            [Description(Cutscene.Hopscotch.MirrorPuzzle_EnterPuzzle + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.MirrorPuzzle_EnterPuzzle, Chapter.Hopscotch)]
            End_CS_PlayRoom_Hopscotch_MirrorPuzzle_EnterPuzzle,

            [Description(Cutscene.Hopscotch.Kaleidoscope_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Hopscotch.Kaleidoscope_Outro, Chapter.Hopscotch)]
            End_CS_PlayRoom_Hopscotch_Kaleidoscope_Outro,
            #endregion
            #region Dinoland
            [Description(Cutscene.Dinoland.DinoCrash_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Dinoland.DinoCrash_Intro, Chapter.DinoLand)]
            End_CS_PlayRoom_DinoLand_DinoCrash_Intro,

            [Description(Cutscene.Dinoland.PteranodonCrash + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Dinoland.PteranodonCrash, Chapter.DinoLand)]
            End_EV_PlayRoom_DinoLand_PteranodonCrash,

            [Description(Cutscene.Dinoland.DinoLand_DinoCrash_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Dinoland.DinoLand_DinoCrash_Outro, Chapter.DinoLand)]
            End_CS_PlayRoom_DinoLand_DinoCrash_Outro,
            #endregion
            #region Pirate's Ahoy
            [Description(Cutscene.PiratesAhoy.EnteringBoat + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.EnteringBoat, Chapter.PiratesAhoy)]
            End_CS_PlayRoom_Goldberg_Pirate_EnteringBoat,

            [Description(Cutscene.PiratesAhoy.ShipsIntro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.ShipsIntro, Chapter.PiratesAhoy)]
            End_CS_Playroom_Goldberg_Pirate_ShipsIntro,

            [Description(Cutscene.PiratesAhoy.BossIntro_MainScene + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.BossIntro_MainScene, Chapter.PiratesAhoy)]
            End_CS_PlayRoom_Goldberg_Pirate_BossIntro_MainScene,

            [Description(Cutscene.PiratesAhoy.BossSlam_Left + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.BossSlam_Left, Chapter.PiratesAhoy)]
            End_CT_Playroom_Goldberg_Pirate_BossSlam_Left,

            [Description(Cutscene.PiratesAhoy.OctopusEnterPhase2 + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.OctopusEnterPhase2, Chapter.PiratesAhoy)]
            End_CS_PlayRoom_Goldberg_Pirate_OctopusEnterPhase2,

            [Description(Cutscene.PiratesAhoy.OctopusEnterPhase3 + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.OctopusEnterPhase3, Chapter.PiratesAhoy)]
            End_CS_PlayRoom_Goldberg_Pirate_OctopusEnterPhase3,

            [Description(Cutscene.PiratesAhoy.BossBoatJab + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.BossBoatJab, Chapter.PiratesAhoy)]
            End_CS_Playroom_Goldberg_Pirate_BossBoatJab,

            [Description(Cutscene.PiratesAhoy.SquidDefeated + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.PiratesAhoy.SquidDefeated, Chapter.PiratesAhoy)]
            End_CS_PlayRoom_Goldberg_Pirate_SquidDefeated,
            #endregion
            #region The Greatest Show
            [Description(Cutscene.TheGreatestShow.Balloon_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheGreatestShow.Balloon_Intro, Chapter.TheGreatestShow)]
            End_CS_PlayRoom_Circus_Balloon_Intro,

            [Description(Cutscene.TheGreatestShow.SealsBounceBall + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheGreatestShow.SealsBounceBall, Chapter.TheGreatestShow)]
            End_LS_PlayRoom_Goldberg_Circus_SealsBounceBall,

            [Description(Cutscene.TheGreatestShow.Balloon_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheGreatestShow.Balloon_Outro, Chapter.TheGreatestShow)]
            End_CS_PlayRoom_Circus_Balloon_Outro,

            [Description(Cutscene.TheGreatestShow.CartRide_Flying + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheGreatestShow.CartRide_Flying, Chapter.TheGreatestShow)]
            End_CS_PlayRoom_Circus_CartRide_Flying,
            #endregion
            #region Once Upon a Time
            [Description(Cutscene.OnceUponATime.CartLand + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.OnceUponATime.CartLand, Chapter.OnceUponATime)]
            End_CS_PlayRoom_Castle_Courtyard_CartLand,

            [Description(Cutscene.OnceUponATime.PaperSquish_May + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.OnceUponATime.PaperSquish_May, Chapter.OnceUponATime)]
            End_EV_Playroom_Castle_Courtyard_PaperSquish_May,

            [Description(Cutscene.OnceUponATime.PaperSquish_Cody + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.OnceUponATime.PaperSquish_Cody, Chapter.OnceUponATime)]
            End_EV_Playroom_Castle_Courtyard_PaperSquish_Cody,

            [Description(Cutscene.OnceUponATime.Gate_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.OnceUponATime.Gate_Intro, Chapter.OnceUponATime)]
            End_CS_PlayRoom_Castle_Gate_Intro,
            #endregion
            #region Dungeon Crawler
            [Description(Cutscene.DungeonCrawler.Dungeon_Cell + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DungeonCrawler.Dungeon_Cell, Chapter.DungeonCrawler)]
            End_CS_PlayRoom_Castle_Dungeon_Cell,

            [Description(Cutscene.DungeonCrawler.CrusherIntro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DungeonCrawler.CrusherIntro, Chapter.DungeonCrawler)]
            End_CS_Playroom_Castle_Dungeon_CrusherIntro,

            [Description(Cutscene.DungeonCrawler.BridgeCollapse + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DungeonCrawler.BridgeCollapse, Chapter.DungeonCrawler)]
            End_LS_Playroom_Castle_Dungeon_BridgeCollapse,

            [Description(Cutscene.DungeonCrawler.Dungeon_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DungeonCrawler.Dungeon_Outro, Chapter.DungeonCrawler)]
            End_CS_PlayRoom_Castle_Dungeon_Outro,

            [Description(Cutscene.DungeonCrawler.Chessboard_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DungeonCrawler.Chessboard_Intro, Chapter.DungeonCrawler)]
            End_CS_PlayRoom_Castle_Chessboard_Intro,

            [Description(Cutscene.DungeonCrawler.Chessboard_BossDeath + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DungeonCrawler.Chessboard_BossDeath, Chapter.DungeonCrawler)]
            End_CS_Playroom_Castle_Chess_Chessboard_BossDeath,

            [Description(Cutscene.DungeonCrawler.Chessboard_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.DungeonCrawler.Chessboard_Outro, Chapter.DungeonCrawler)]
            End_CS_PlayRoom_Castle_Chessboard_Outro,
            #endregion
            #region The Queen
            [Description(Cutscene.TheQueen.Elephant_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.Elephant_Intro, Chapter.TheQueen)]
            End_CS_PlayRoom_Bookshelf_Elephant_Intro,

            [Description(Cutscene.TheQueen.CaughtByClaw + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.CaughtByClaw, Chapter.TheQueen)]
            End_CS_Playroom_Castle_Shelf_CaughtByClaw,

            [Description(Cutscene.TheQueen.Towerhang_Finish + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.Towerhang_Finish, Chapter.TheQueen)]
            End_CS_PlayRoom_Bookshelf_Towerhang_Finish,

            [Description(Cutscene.TheQueen.LegPull_GetStuck + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.LegPull_GetStuck, Chapter.TheQueen)]
            End_CS_PlayRoom_Bookshelf_LegPull_GetStuck,

            [Description(Cutscene.TheQueen.LegPull_EarRip + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.LegPull_EarRip, Chapter.TheQueen)]
            End_CS_PlayRoom_Bookshelf_LegPull_EarRip,

            [Description(Cutscene.TheQueen.ToEdgeHang + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.ToEdgeHang, Chapter.TheQueen)]
            End_CS_PlayRoom_Bookshelf_ToEdgeHang,

            [Description(Cutscene.TheQueen.Elephant_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.Elephant_Outro, Chapter.TheQueen)]
            End_CS_PlayRoom_Bookshelf_Elephant_Outro,

            [Description(Cutscene.TheQueen.Bed_Crack + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.Bed_Crack, Chapter.TheQueen)]
            End_CS_RealWorld_RoseRoom_Bed_Crack,

            [Description(Cutscene.TheQueen.Bed_Tears + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.Bed_Tears, Chapter.TheQueen)]
            End_CS_RealWorld_RoseRoom_Bed_Tears,

            [Description(Cutscene.TheQueen.TherapyRoom_Session_Theme_Time + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TheQueen.TherapyRoom_Session_Theme_Time, Chapter.TheQueen)]
            End_CS_TherapyRoom_Session_Theme_Time,
            #endregion
            #region Gates of Time
            [Description(Cutscene.GatesOfTime.Time_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.Time_Intro, Chapter.GatesOfTime)]
            End_CS_ClockWork_LowerTower_Time_Intro,

            [Description(Cutscene.GatesOfTime.OpenFirstGate + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.OpenFirstGate, Chapter.GatesOfTime)]
            End_CT_Clockwork_Outside_Tutorial_OpenFirstGate,

            [Description(Cutscene.GatesOfTime.ClockTown_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.ClockTown_Intro, Chapter.GatesOfTime)]
            End_CS_ClockWork_Outside_ClockTown_Intro,

            [Description(Cutscene.GatesOfTime.RevealHellTower + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.RevealHellTower, Chapter.GatesOfTime)]
            End_LS_Clockwork_Outside_ClockTown_RevealHellTower,

            [Description(Cutscene.GatesOfTime.Gate_Vegetation + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.Gate_Vegetation, Chapter.GatesOfTime)]
            End_CS_ClockWork_Outside_Gate_Vegetation,

            [Description(Cutscene.GatesOfTime.Bird_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.Bird_Intro, Chapter.GatesOfTime)]
            End_CS_ClockWork_Outside_Bird_Intro,

            [Description(Cutscene.GatesOfTime.LeftTower_ElevatorDown + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.LeftTower_ElevatorDown, Chapter.GatesOfTime)]
            End_CS_Clockwork_Outside_LeftTower_ElevatorDown,

            [Description(Cutscene.GatesOfTime.RightTower_OpenRightTower + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.RightTower_OpenRightTower, Chapter.GatesOfTime)]
            End_CT_Clockwork_Outside_RightTower_OpenRightTower,

            [Description(Cutscene.GatesOfTime.RightTower_ElevatorDown + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.RightTower_ElevatorDown, Chapter.GatesOfTime)]
            End_CS_Clockwork_Outside_RightTower_ElevatorDown,

            [Description(Cutscene.GatesOfTime.LeftTower_OpenLeftTower + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.LeftTower_OpenLeftTower, Chapter.GatesOfTime)]
            End_CT_Clockwork_Outside_LeftTower_OpenLeftTower,

            [Description(Cutscene.GatesOfTime.Tower_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GatesOfTime.Tower_Intro, Chapter.GatesOfTime)]
            End_CS_ClockWork_Outside_Tower_Intro,
            #endregion
            #region Clockworks
            [Description(Cutscene.Clockworks.CrusherRoom_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.CrusherRoom_Intro, Chapter.Clockworks)]
            End_CS_ClockWork_LowerTower_CrusherRoom_Intro,

            [Description(Cutscene.Clockworks.Bridge_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.Bridge_Intro, Chapter.Clockworks)]
            End_CS_Clockwork_LowerTower_Bridge_Intro,

            [Description(Cutscene.Clockworks.BullBoss_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.BullBoss_Intro, Chapter.Clockworks)]
            End_CS_ClockWork_LowerTower_BullBoss_Intro,

            [Description(Cutscene.Clockworks.BullBoss_HitPillarFirstTime + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.BullBoss_HitPillarFirstTime, Chapter.Clockworks)]
            End_CS_Clockwork_LowerTower_BullBoss_HitPillarFirstTime,

            [Description(Cutscene.Clockworks.BullBoss_HitPillarSecondTime + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.BullBoss_HitPillarSecondTime, Chapter.Clockworks)]
            End_CS_Clockwork_LowerTower_BullBoss_HitPillarSecondTime,

            [Description(Cutscene.Clockworks.BullBoss_BullBossCrushed + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.BullBoss_BullBossCrushed, Chapter.Clockworks)]
            End_CS_Clockwork_LowerTower_BullBoss_BullBossCrushed,

            [Description(Cutscene.Clockworks.ChargerRoom_RoomDebris + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.ChargerRoom_RoomDebris, Chapter.Clockworks)]
            End_LS_Clockwork_LowerTower_ChargerRoom_RoomDebris,

            [Description(Cutscene.Clockworks.EvilBird_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Clockworks.EvilBird_Intro, Chapter.Clockworks)]
            End_CS_ClockWork_LowerTower_EvilBird_Intro,
            #endregion
            #region A Blast from the Past
            [Description(Cutscene.ABlastFromThePast.GlassWalkway_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.GlassWalkway_Intro, Chapter.ABlastFromThePast)]
            End_CS_ClockWork_UpperTower_GlassWalkway_Intro,

            [Description(Cutscene.ABlastFromThePast.LaunchingPlatform + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.LaunchingPlatform, Chapter.ABlastFromThePast)]
            End_CS_Clockwork_UpperTower_LastBoss_LaunchingPlatform,

            [Description(Cutscene.ABlastFromThePast.BuildingSmasherPlatform + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.BuildingSmasherPlatform, Chapter.ABlastFromThePast)]
            End_CS_Clockwork_UpperTower_LastBoss_BuildingSmasherPlatform,

            [Description(Cutscene.ABlastFromThePast.AfterRewindSmash + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.AfterRewindSmash, Chapter.ABlastFromThePast)]
            End_CS_Clockwork_UpperTower_LastBoss_AfterRewindSmash,

            [Description(Cutscene.ABlastFromThePast.Final_Explosion + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.Final_Explosion, Chapter.ABlastFromThePast)]
            End_CS_ClockWork_UpperTower_Final_Explosion,

            [Description(Cutscene.ABlastFromThePast.LandAfterExplosion + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.LandAfterExplosion, Chapter.ABlastFromThePast)]
            End_CS_Clockwork_UpperTower_LastBoss_LandAfterExplosion,

            [Description(Cutscene.ABlastFromThePast.MayEndingPlatform + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.MayEndingPlatform, Chapter.ABlastFromThePast)]
            End_EV_Clockwork_UpperTower_LastBoss_MayEndingPlatform,

            [Description(Cutscene.ABlastFromThePast.EndingRewind + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.EndingRewind, Chapter.ABlastFromThePast)]
            End_CS_ClockWork_UpperTower_EndingRewind,

            [Description(Cutscene.ABlastFromThePast.Time_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.Time_Outro, Chapter.ABlastFromThePast)]
            End_CS_ClockWork_CuckoClock_Time_Outro,

            [Description(Cutscene.ABlastFromThePast.RealWorld_House_LowerLevel_Clock + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.RealWorld_House_LowerLevel_Clock, Chapter.ABlastFromThePast)]
            End_CS_RealWorld_House_LowerLevel_Clock,

            [Description(Cutscene.ABlastFromThePast.TherapyRoom_Session_Theme_Attraction + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.ABlastFromThePast.TherapyRoom_Session_Theme_Attraction, Chapter.ABlastFromThePast)]
            End_CS_TherapyRoom_Session_Theme_Attraction,
            #endregion
            #region Warming Up
            [Description(Cutscene.WarmingUp.Entrance_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WarmingUp.Entrance_Intro, Chapter.WarmingUp)]
            End_CS_SnowGlobe_Forest_Entrance_Intro,

            [Description(Cutscene.WarmingUp.Find_Skates + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WarmingUp.Find_Skates, Chapter.WarmingUp)]
            End_CS_SnowGlobe_Cabin_Find_Skates,
            #endregion
            #region Winter Village
            [Description(Cutscene.WinterVillage.SnowCaveOpenGate + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.SnowCaveOpenGate, Chapter.WinterVillage)]
            End_CS_SnowGlobe_Town_SnowCaveOpenGate,

            [Description(Cutscene.WinterVillage.Bells_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.Bells_Intro, Chapter.WinterVillage)]
            End_CS_SnowGlobe_Town_Bells_Intro,

            [Description(Cutscene.WinterVillage.FirstBellRung + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.FirstBellRung, Chapter.WinterVillage)]
            End_CS_SnowGlobe_Town_TutorialArea_FirstBellRung,

            [Description(Cutscene.WinterVillage.SecondGatesOpening + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.SecondGatesOpening, Chapter.WinterVillage)]
            End_CT_SnowGlobe_Town_SecondGatesOpening,

            [Description(Cutscene.WinterVillage.CraneBellRung + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.CraneBellRung, Chapter.WinterVillage)]
            End_CS_SnowGlobe_Town_CraneArea_CraneBellRung,

            [Description(Cutscene.WinterVillage.BigWheelBellRung + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.BigWheelBellRung, Chapter.WinterVillage)]
            End_CS_SnowGlobe_Town_BigWheelArea_BigWheelBellRung,

            [Description(Cutscene.WinterVillage.IceWallBellRung + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.IceWallBellRung, Chapter.WinterVillage)]
            End_CS_SnowGlobe_Town_IceWallArea_IceWallBellRung,

            [Description(Cutscene.WinterVillage.CableCartOpen + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.CableCartOpen, Chapter.WinterVillage)]
            End_CS_SnowGlobe_Town_TownCenter_CableCartOpen,

            [Description(Cutscene.WinterVillage.BobsledCompleted + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WinterVillage.BobsledCompleted, Chapter.WinterVillage)]
            End_EV_SnowGlobe_Town_BobsledCompleted,
            #endregion
            #region Beneath the Ice
            [Description(Cutscene.BeneathTheIce.Swimming_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BeneathTheIce.Swimming_Intro, Chapter.BeneathTheIce)]
            End_CS_SnowGlobe_Lake_Swimming_Intro,

            [Description(Cutscene.BeneathTheIce.Factory_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BeneathTheIce.Factory_Intro, Chapter.BeneathTheIce)]
            End_CS_SnowGlobe_Lake_Factory_Intro,

            [Description(Cutscene.BeneathTheIce.IceCaveFinish + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BeneathTheIce.IceCaveFinish, Chapter.BeneathTheIce)]
            End_LS_Snowglobe_Lake_IceCaveFinish,

            [Description(Cutscene.BeneathTheIce.FishDone + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BeneathTheIce.FishDone, Chapter.BeneathTheIce)]
            End_LS_Snowglobe_Lake_FishDone,

            [Description(Cutscene.BeneathTheIce.BubbleDone + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BeneathTheIce.BubbleDone, Chapter.BeneathTheIce)]
            End_CT_SnowGlobe_Lake_BubbleDone,

            [Description(Cutscene.BeneathTheIce.CoreElevatorDoorOpen + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BeneathTheIce.CoreElevatorDoorOpen, Chapter.BeneathTheIce)]
            End_LS_SnowGlobe_Lake_CoreElevatorDoorOpen,

            [Description(Cutscene.BeneathTheIce.SkiLift_Ride + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.BeneathTheIce.SkiLift_Ride, Chapter.BeneathTheIce)]
            End_CS_SnowGlobe_Lake_SkiLift_Ride,
            #endregion
            #region Slippery Slopes
            [Description(Cutscene.SlipperySlopes.SkiLift_Ride + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.SkiLift_Ride, Chapter.SlipperySlopes)]
            End_CS_SnowGlobe_Mountain_SkiLift_Ride,

            [Description(Cutscene.SlipperySlopes.SmallCabin_Collapse + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.SmallCabin_Collapse, Chapter.SlipperySlopes)]
            End_CS_SnowGlobe_Mountain_SmallCabin_Collapse,

            [Description(Cutscene.SlipperySlopes.CollapseFall + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.CollapseFall, Chapter.SlipperySlopes)]
            End_CT_SnowGlobe_Mountain_CollapseFall,

            [Description(Cutscene.SlipperySlopes.IceCave_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.IceCave_Intro, Chapter.SlipperySlopes)]
            End_CS_SnowGlobe_Mountain_IceCave_Intro,

            [Description(Cutscene.SlipperySlopes.Ground_Elevator + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.Ground_Elevator, Chapter.SlipperySlopes)]
            End_CS_SnowGlobe_Tower_Ground_Elevator,

            [Description(Cutscene.SlipperySlopes.Terrace_Proposal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.Terrace_Proposal, Chapter.SlipperySlopes)]
            End_CS_SnowGlobe_Tower_Terrace_Proposal,

            [Description(Cutscene.SlipperySlopes.RealWorld_House_Kitchen_Sandwiches + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.RealWorld_House_Kitchen_Sandwiches, Chapter.SlipperySlopes)]
            End_CS_RealWorld_House_Kitchen_Sandwiches,

            [Description(Cutscene.SlipperySlopes.TherapyRoom_Session_Theme_Garden + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SlipperySlopes.TherapyRoom_Session_Theme_Garden, Chapter.SlipperySlopes)]
            End_CS_TherapyRoom_Session_Theme_Garden,
            #endregion
            #region Green Fingers
            [Description(Cutscene.GreenFingers.Entrance_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.Entrance_Intro, Chapter.GreenFingers)]
            End_CS_Garden_VegetablePatch_Entrance_Intro,

            [Description(Cutscene.GreenFingers.Entrance_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.Entrance_Outro, Chapter.GreenFingers)]
            End_CS_Garden_VegetablePatch_Entrance_Outro,

            [Description(Cutscene.GreenFingers.BeanstalkFlowerGate + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.BeanstalkFlowerGate, Chapter.GreenFingers)]
            End_CT_Garden_VegetablePatch_BeanstalkFlowerGate,

            [Description(Cutscene.GreenFingers.Burrower_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.Burrower_Intro, Chapter.GreenFingers)]
            End_CS_Garden_VegetablePatch_Burrower_Intro,

            [Description(Cutscene.GreenFingers.SpaEntrance_Cody_Enter + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.SpaEntrance_Cody_Enter, Chapter.GreenFingers)]
            End_CS_Garden_SpaEntrance_Cody_Enter,

            [Description(Cutscene.GreenFingers.SpaEntrance_May_Enter + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.SpaEntrance_May_Enter, Chapter.GreenFingers)]
            End_CS_Garden_SpaEntrance_May_Enter,

            [Description(Cutscene.GreenFingers.SpaEntrance_Cody_Exit + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.SpaEntrance_Cody_Exit, Chapter.GreenFingers)]
            End_CS_Garden_SpaEntrance_Cody_Exit,

            [Description(Cutscene.GreenFingers.SpaEntrance_May_Exit + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.SpaEntrance_May_Exit, Chapter.GreenFingers)]
            End_CS_Garden_SpaEntrance_May_Exit,

            [Description(Cutscene.GreenFingers.OutsideGreenhouse_Unwither + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.OutsideGreenhouse_Unwither, Chapter.GreenFingers)]
            End_CT_Garden_VegetablePatch_OutsideGreenhouse_Unwither,

            [Description(Cutscene.GreenFingers.Greenhouse_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.GreenFingers.Greenhouse_Intro, Chapter.GreenFingers)]
            End_CS_Garden_VegetablePatch_Greenhouse_Intro,
            #endregion
            #region Weed Whacking
            [Description(Cutscene.WeedWhacking.Shrubbery_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.Shrubbery_Intro, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_Shrubbery_Intro,

            [Description(Cutscene.WeedWhacking.IntroducingSpider + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.IntroducingSpider, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_CombatArea_IntroducingSpider,

            [Description(Cutscene.WeedWhacking.SpiderIntro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.SpiderIntro, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_CombatArea_SpiderIntro,

            [Description(Cutscene.WeedWhacking.SpiderMount + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.SpiderMount, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_DandelionPit_SpiderMount,

            [Description(Cutscene.WeedWhacking.LogCollapse + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.LogCollapse, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_SpinningLog_LogCollapse,

            [Description(Cutscene.WeedWhacking.EscapeFromSinkingLog + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.EscapeFromSinkingLog, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_SpinningLog_EscapeFromSinkingLog,

            [Description(Cutscene.WeedWhacking.SpiderNest_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.SpiderNest_Outro, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_SpiderNest_Outro,

            [Description(Cutscene.WeedWhacking.CactusWaves_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.CactusWaves_Intro, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_CactusWaves_Intro,

            [Description(Cutscene.WeedWhacking.SecondCombat_LeavesExtended + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.SecondCombat_LeavesExtended, Chapter.WeedWhacking)]
            End_CT_Garden_Shrubbery_SecondCombat_LeavesExtended,

            [Description(Cutscene.WeedWhacking.PoisonCore_AreaOutro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.WeedWhacking.PoisonCore_AreaOutro, Chapter.WeedWhacking)]
            End_CS_Garden_Shrubbery_PoisonCore_AreaOutro,
            #endregion
            #region Trespassing
            [Description(Cutscene.Trespassing.LevelStart + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Trespassing.LevelStart, Chapter.Trespassing)]
            End_CS_Garden_Moletunnels_Stealth_LevelStart,

            [Description(Cutscene.Trespassing.PushPineCone + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Trespassing.PushPineCone, Chapter.Trespassing)]
            End_CS_Garden_MoleTunnels_Stealth_PushPineCone,

            [Description(Cutscene.Trespassing.Discovered_Part1 + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Trespassing.Discovered_Part1, Chapter.Trespassing)]
            End_CS_Garden_MoleTunnels_Discovered_Part1,

            [Description(Cutscene.Trespassing.Discovered_Part1_Short + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Trespassing.Discovered_Part1_Short, Chapter.Trespassing)]
            End_TP_Garden_MoleTunnels_Discovered_Part1_Short,

            [Description(Cutscene.Trespassing.PlantDestroyed + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Trespassing.PlantDestroyed, Chapter.Trespassing)]
            End_CS_Garden_MoleTunnels_PlantDestroyed,

            [Description(Cutscene.Trespassing.FallDownInto2D + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Trespassing.FallDownInto2D, Chapter.Trespassing)]
            End_CS_Garden_Moletunnels_Chase_FallDownInto2D,

            [Description(Cutscene.Trespassing.LevelEnding + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Trespassing.LevelEnding, Chapter.Trespassing)]
            End_CS_Garden_MoleTunnels_Chase_LevelEnding,
            #endregion
            #region Frog Pond
            [Description(Cutscene.FrogPond.FrogRide + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FrogPond.FrogRide, Chapter.FrogPond)]
            End_CS_Garden_FrogPond_TaxiStand_FrogRide,

            [Description(Cutscene.FrogPond.SmallerFountainPlatformsEnabled + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FrogPond.SmallerFountainPlatformsEnabled, Chapter.FrogPond)]
            End_CT_Garden_FrogPond_MainFountain_SmallerFountainPlatformsEnabled,

            [Description(Cutscene.FrogPond.MainFountain_PoisonBulbDestroyed + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FrogPond.MainFountain_PoisonBulbDestroyed, Chapter.FrogPond)]
            End_CS_Garden_FrogPond_MainFountain_PoisonBulbDestroyed,

            [Description(Cutscene.FrogPond.Greenhouse_OpenDoor + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.FrogPond.Greenhouse_OpenDoor, Chapter.FrogPond)]
            End_CS_Garden_FrogPond_Greenhouse_OpenDoor,
            #endregion
            #region Affliction
            [Description(Cutscene.Affliction.Door_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.Door_Intro, Chapter.Affliction)]
            End_CS_Garden_GreenHouse_Door_Intro,

            [Description(Cutscene.Affliction.Floor_KilledSmallBulb + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.Floor_KilledSmallBulb, Chapter.Affliction)]
            End_CT_Garden_Greenhouse_Floor_KilledSmallBulb,

            [Description(Cutscene.Affliction.RightbulbDestroyed + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.RightbulbDestroyed, Chapter.Affliction)]
            End_CT_Garden_Greenhouse_RightTable_RightbulbDestroyed,

            [Description(Cutscene.Affliction.LeftTable_KilledSmallBulb + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.LeftTable_KilledSmallBulb, Chapter.Affliction)]
            End_CT_Garden_Greenhouse_LeftTable_KilledSmallBulb,

            [Description(Cutscene.Affliction.MainArea_Greenified + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.MainArea_Greenified, Chapter.Affliction)]
            End_CT_Garden_Greenhouse_MainArea_Greenified,

            [Description(Cutscene.Affliction.BossRoom_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_Intro, Chapter.Affliction)]
            End_CS_Garden_GreenHouse_BossRoom_Intro,

            [Description(Cutscene.Affliction.BossRoom_CodyTakesControl + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_CodyTakesControl, Chapter.Affliction)]
            End_CS_Garden_Greenhouse_BossRoom_CodyTakesControl,

            [Description(Cutscene.Affliction.BossRoom_DestroyFirstBlob + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_DestroyFirstBlob, Chapter.Affliction)]
            End_CS_Garden_Greenhouse_BossRoom_DestroyFirstBlob,

            [Description(Cutscene.Affliction.BossRoom_ThrowSecondPot + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_ThrowSecondPot, Chapter.Affliction)]
            End_CS_Garden_Greenhouse_BossRoom_ThrowSecondPot,

            [Description(Cutscene.Affliction.BossRoom_CodyTakesControlPhaseTwo + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_CodyTakesControlPhaseTwo, Chapter.Affliction)]
            End_CS_Garden_Greenhouse_BossRoom_CodyTakesControlPhaseTwo,

            [Description(Cutscene.Affliction.BossRoom_ThrowThirdPot + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_ThrowThirdPot, Chapter.Affliction)]
            End_CS_Garden_Greenhouse_BossRoom_ThrowThirdPot,

            [Description(Cutscene.Affliction.BossRoom_CodyTakesControlPhaseThree + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_CodyTakesControlPhaseThree, Chapter.Affliction)]
            End_CS_Garden_Greenhouse_BossRoom_CodyTakesControlPhaseThree,

            [Description(Cutscene.Affliction.BossRoom_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.BossRoom_Outro, Chapter.Affliction)]
            End_CS_Garden_GreenHouse_BossRoom_Outro,

            [Description(Cutscene.Affliction.RealWorld_House_RoseRoom_FlowerPot + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.RealWorld_House_RoseRoom_FlowerPot, Chapter.Affliction)]
            End_CS_RealWorld_House_RoseRoom_FlowerPot,

            [Description(Cutscene.Affliction.TherapyRoom_Session_Theme_Music + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Affliction.TherapyRoom_Session_Theme_Music, Chapter.Affliction)]
            End_CS_TherapyRoom_Session_Theme_Music,
            #endregion
            #region Setting the Stage
            [Description(Cutscene.SettingTheStage.Backstage_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SettingTheStage.Backstage_Intro, Chapter.SettingTheStage)]
            End_CS_Music_ConcertHall_Backstage_Intro,

            [Description(Cutscene.SettingTheStage.EnteringBackstage + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SettingTheStage.EnteringBackstage, Chapter.SettingTheStage)]
            End_CS_Music_ConcertHall_EnteringBackstage,
            #endregion
            #region Rehearsal
            [Description(Cutscene.Rehearsal.PortableSpeakerRoom_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.PortableSpeakerRoom_Intro, Chapter.Rehearsal)]
            End_CS_Music_Backstage_PortableSpeakerRoom_Intro,

            [Description(Cutscene.Rehearsal.Jukebox_CoinSuck + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.Jukebox_CoinSuck, Chapter.Rehearsal)]
            End_EV_Music_Backstage_Jukebox_CoinSuck,

            [Description(Cutscene.Rehearsal.PortableSpeakerRoom_WindowBlast + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.PortableSpeakerRoom_WindowBlast, Chapter.Rehearsal)]
            End_CS_Music_Backstage_PortableSpeakerRoom_WindowBlast,

            [Description(Cutscene.Rehearsal.BassRoom_Landing + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.BassRoom_Landing, Chapter.Rehearsal)]
            End_CS_Music_Backstage_BassRoom_Landing,

            [Description(Cutscene.Rehearsal.MusicTechWall_GoingThroughTruss + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.MusicTechWall_GoingThroughTruss, Chapter.Rehearsal)]
            End_CT_Music_Backstage_MusicTechWall_GoingThroughTruss,

            [Description(Cutscene.Rehearsal.MusicTechWall_Reveal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.MusicTechWall_Reveal, Chapter.Rehearsal)]
            End_CS_Music_Backstage_MusicTechWall_Reveal,

            [Description(Cutscene.Rehearsal.MusicTechWall_PowerCableTravel + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.MusicTechWall_PowerCableTravel, Chapter.Rehearsal)]
            End_CT_Music_Backstage_MusicTechWall_PowerCableTravel,

            [Description(Cutscene.Rehearsal.MicrophoneRoom_MotherReveal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.MicrophoneRoom_MotherReveal, Chapter.Rehearsal)]
            End_CS_Music_Backstage_MicrophoneRoom_MotherReveal,

            [Description(Cutscene.Rehearsal.MicrophoneChase_FallToGrind + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.MicrophoneChase_FallToGrind, Chapter.Rehearsal)]
            End_DS_Music_Backstage_MicrophoneChase_FallToGrind,

            [Description(Cutscene.Rehearsal.MicrophoneChase_BrokenTruss + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.MicrophoneChase_BrokenTruss, Chapter.Rehearsal)]
            End_DS_Music_Backstage_MicrophoneChase_BrokenTruss,

            [Description(Cutscene.Rehearsal.BassRoom_Landing + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.BassRoom_Landing, Chapter.Rehearsal)]
            End_CS_Music_Backstage_MicrophoneChase_Landing,

            [Description(Cutscene.Rehearsal.MicrophoneChase_Ending + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.MicrophoneChase_Ending, Chapter.Rehearsal)]
            End_CS_Music_Backstage_MicrophoneChase_Ending,

            [Description(Cutscene.Rehearsal.LightRoom_Entrance + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.LightRoom_Entrance, Chapter.Rehearsal)]
            End_CS_Music_Backstage_LightRoom_Entrance,

            [Description(Cutscene.Rehearsal.LightRoom_EndOfLightRoom + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Rehearsal.LightRoom_EndOfLightRoom, Chapter.Rehearsal)]
            End_CS_Music_Backstage_LightRoom_EndOfLightRoom,
            #endregion
            #region Symphony
            [Description(Cutscene.SettingTheStage.Backstage_Orchestra + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SettingTheStage.Backstage_Orchestra, Chapter.Symphony)]
            End_CS_Music_ConcertHall_Backstage_Orchestra,

            [Description(Cutscene.SettingTheStage.EnteringClassic + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SettingTheStage.EnteringClassic, Chapter.Symphony)]
            End_CS_Music_ConcertHall_BackStage_EnteringClassic,

            [Description(Cutscene.Symphony.EnterClassic + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.EnterClassic, Chapter.Symphony)]
            End_CS_Music_Classic_Attic_EnterClassic,

            [Description(Cutscene.Symphony.Flying + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.Flying, Chapter.Symphony)]
            End_CS_Music_Classic_Heaven_Flying,

            [Description(Cutscene.Symphony.Reveal + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.Reveal, Chapter.Symphony)]
            End_CS_Music_Classic_Heaven_Reveal,

            [Description(Cutscene.Symphony.OpenBirdCage + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.OpenBirdCage, Chapter.Symphony)]
            End_CS_Music_Classic_Heaven_OpenBirdCage,

            [Description(Cutscene.Symphony.ReleaseFollowersCage + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.ReleaseFollowersCage, Chapter.Symphony)]
            End_CS_Music_Classic_Heaven_ReleaseFollowersCage,

            [Description(Cutscene.Symphony.OpenCloudRoom + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.OpenCloudRoom, Chapter.Symphony)]
            End_CS_Music_Classic_Heaven_OpenCloudRoom,

            [Description(Cutscene.Symphony.ReleaseFollowersCloud + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.ReleaseFollowersCloud, Chapter.Symphony)]
            End_CS_Music_Classic_Heaven_ReleaseFollowersCloud,

            [Description(Cutscene.Symphony.LevelEnding + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Symphony.LevelEnding, Chapter.Symphony)]
            End_CS_Music_Classic_Heaven_LevelEnding,
            #endregion
            #region Turn Up
            [Description(Cutscene.SettingTheStage.Backstage_Audience + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SettingTheStage.Backstage_Audience, Chapter.TurnUp)]
            End_CS_Music_ConcertHall_Backstage_Audience,

            [Description(Cutscene.SettingTheStage.NightClub_Entrance + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.SettingTheStage.NightClub_Entrance, Chapter.TurnUp)]
            End_CS_Music_ConcertHall_NightClub_Entrance,

            [Description(Cutscene.TurnUp.RainbowSlide_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.RainbowSlide_Intro, Chapter.TurnUp)]
            End_CS_Music_Nightclub_RainbowSlide_Intro,

            [Description(Cutscene.TurnUp.RainbowSlide_RespawnMay1 + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.RainbowSlide_RespawnMay1, Chapter.TurnUp)]
            End_EV_Music_Nightclub_RainbowSlide_RespawnMay1,

            [Description(Cutscene.TurnUp.RainbowSlide_RespawnCody1 + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.RainbowSlide_RespawnCody1, Chapter.TurnUp)]
            End_EV_Music_Nightclub_RainbowSlide_RespawnCody1,

            [Description(Cutscene.TurnUp.Discoball_GroundpoundStart + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.Discoball_GroundpoundStart, Chapter.TurnUp)]
            End_CS_Music_NightClub_Discoball_GroundpoundStart,

            [Description(Cutscene.TurnUp.DiscoRide_BallCrash + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.DiscoRide_BallCrash, Chapter.TurnUp)]
            End_CS_Music_NightClub_DiscoRide_BallCrash,

            [Description(Cutscene.TurnUp.Basement_DjElevator + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.Basement_DjElevator, Chapter.TurnUp)]
            End_CT_Music_Nightclub_Basement_DjElevator,

            [Description(Cutscene.TurnUp.Basement_Elevator + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.Basement_Elevator, Chapter.TurnUp)]
            End_CS_Music_NightClub_Basement_Elevator,

            [Description(Cutscene.TurnUp.DJ_Outro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.TurnUp.DJ_Outro, Chapter.TurnUp)]
            End_CS_Music_NightClub_DJ_Outro,
            #endregion
            #region A Grand Finale
            [Description(Cutscene.AGrandFinale.DropDown_Preparation + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.DropDown_Preparation, Chapter.AGrandFinale)]
            End_CS_Music_Ending_DropDown_Preparation,

            [Description(Cutscene.AGrandFinale.DressingRoom_Mirror + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.DressingRoom_Mirror, Chapter.AGrandFinale)]
            End_CS_Music_Ending_DressingRoom_Mirror,

            [Description(Cutscene.AGrandFinale.FirstCameraRide + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.FirstCameraRide, Chapter.AGrandFinale)]
            End_CS_Music_Ending_BehindStage_FirstCameraRide,

            [Description(Cutscene.AGrandFinale.SecondCameraRide + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.SecondCameraRide, Chapter.AGrandFinale)]
            End_CS_Music_Ending_BehindStage_SecondCameraRide,

            [Description(Cutscene.AGrandFinale.GrandFinaleEnding + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.GrandFinaleEnding, Chapter.AGrandFinale)]
            End_CS_Music_Attic_Stage_GrandFinaleEnding,

            [Description(Cutscene.AGrandFinale.Smooch + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.Smooch, Chapter.AGrandFinale)]
            End_CT_Music_Ending_Smooch,

            [Description(Cutscene.AGrandFinale.ClimacticKiss + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.ClimacticKiss, Chapter.AGrandFinale)]
            End_CS_Music_Attic_Stage_ClimacticKiss,

            [Description(Cutscene.AGrandFinale.RealWorld_House_Study_Wakeup + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.RealWorld_House_Study_Wakeup, Chapter.AGrandFinale)]
            End_CS_RealWorld_House_Study_Wakeup,

            [Description(Cutscene.AGrandFinale.RealWorld_RoseRoom_Bed_Letter + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.RealWorld_RoseRoom_Bed_Letter, Chapter.AGrandFinale)]
            End_CS_RealWorld_RoseRoom_Bed_Letter,

            [Description(Cutscene.AGrandFinale.RealWorld_Exterior_Busstop_Reunion + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.RealWorld_Exterior_Busstop_Reunion, Chapter.AGrandFinale)]
            End_CS_RealWorld_Exterior_Busstop_Reunion,

            [Description(Cutscene.AGrandFinale.RealWorld_House_Credits_PlaceBook + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.AGrandFinale.RealWorld_House_Credits_PlaceBook, Chapter.AGrandFinale)]
            End_CS_RealWorld_House_Credits_PlaceBook,
            #endregion
            #region Basement

            [Description(Cutscene.Basement.TherapyRoom_Session_Theme_Love + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Basement.TherapyRoom_Session_Theme_Love, Chapter.Basement)]
            End_CS_TherapyRoom_Session_Theme_Love,

            [Description(Cutscene.Basement.Seekers_Door_Intro + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Basement.Seekers_Door_Intro, Chapter.Basement)]
            End_CS_Basement_Seekers_Door_Intro,

            [Description(Cutscene.Basement.BossRoom_Argue_Collapse + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Basement.BossRoom_Argue_Collapse, Chapter.Basement)]
            End_CS_Basement_BossRoom_Argue_Collapse,

            [Description(Cutscene.Basement.BossRoom_Argue_Light + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Basement.BossRoom_Argue_Light, Chapter.Basement)]
            End_CS_Basement_BossRoom_Argue_Light,

            [Description(Cutscene.Basement.Boss_GrayPlace_Letter + Tag.CutsceneEnd),
                ToolTip(Cutscene.EndFormat, Cutscene.Basement.Boss_GrayPlace_Letter, Chapter.Basement)]
            End_CS_Basement_Boss_GrayPlace_Letter,

            #endregion
            #endregion
            #endregion Cutscene splits

            #region Minigames

            [Description(Minigame.WhackACody + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.WhackACody)]
            Shed_Main_WhackACody,

            [Description(Minigame.FlipTheSwitch + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.FlipTheSwitch)]
            Shed_Main_MINIGAME_NailWheel,

            [Description(Minigame.TugOfWar + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.TugOfWar)]
            Tree_SquirrelHome_MINIGAME_TugOfWar,

            [Description(Minigame.Plunger + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Plunger)]
            Tree_WaspNest_MINIGAME_Plunger,

            [Description(Minigame.Tank + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Tank)]
            PlayRoom_PillowFort_MINIGAME_Hazeboy,

            [Description(Minigame.Laser + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Laser)]
            PlayRoom_Spacestation_MINIGAME_LaserTennis,

            [Description(Minigame.Spacewalk + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Spacewalk)]
            PlayRoom_Spacestation_MINIGAME_LowGravity,

            [Description(Minigame.Batting + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Batting)]
            PlayRoom_Hopscotch_MINIGAME_BaseBall,

            [Description(Minigame.FeedTheReptile + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.FeedTheReptile)]
            PlayRoom_Hopscotch_MINIGAME_ThrowingHoops,

            [Description(Minigame.Rodeo + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Rodeo)]
            PlayRoom_Hopscotch_MINIGAME_Rodeo,

            [Description(Minigame.Birdstar + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Birdstar)]
            PlayRoom_Courtyard_MINIGAME_BirdStar,

            [Description(Minigame.BombRun + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.BombRun)]
            Clockwork_Outside_MINIGAME_BombRun,

            [Description(Minigame.HorseDerby + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.HorseDerby)]
            Clockwork_Outside_MINIGAME_HorseDerby,

            [Description(Minigame.SnowWarfare + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.SnowWarfare)]
            SnowGlobe_Town_MINIGAME_SnowballFight,

            [Description(Minigame.Shuffle + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Shuffle)]
            SnowGlobe_Town_MINIGAME_ShuffleBoard,

            [Description(Minigame.Icicle + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Icicle)]
            SnowGlobe_Town_MINIGAME_IcicleThrowing,

            [Description(Minigame.IceRace + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.IceRace)]
            SnowGlobe_Lake_MINIGAME_IceRace,

            [Description(Minigame.Larva + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Larva)]
            Garden_Shrubbery_MINIGAME_Basket,

            [Description(Minigame.Swings + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Swings)]
            Garden_Shrubbery_MINIGAME_Swings,

            [Description(Minigame.Snail + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Snail)]
            Garden_FrogPond_Minigame_SnailRace,

            [Description(Minigame.Chairs + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Chairs)]
            Music_ConcertHall_MINIGAME_MusicalChairs,

            [Description(Minigame.Track + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Track)]
            Music_ConcertHall_MINIGAME_TrackRunner,

            [Description(Minigame.Slotcars + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Slotcars)]
            Music_ConcertHall_MINIGAME_SlotCars,

            [Description(Minigame.Chess + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Chess)]
            Music_ConcertHall_MINIGAME_Chess,

            [Description(Minigame.Volleyball + Tag.Minigame),
                ToolTip(Minigame.Format, Minigame.Volleyball)]
            Music_Classic_MINIGAME_VolleyBall,

            #endregion

            #region Other Splits

            [Description("May is dead (Death)"), 
                ToolTip("Splits on any May death")]
            MayIsDead,

            [Description("Cody is dead (Death)"), 
                ToolTip("Splits on any Cody death")]
            CodyIsDead,

            [Description("Any player death (Death)"), 
                ToolTip("Splits on any player death")]
            AnyDead,

            [Description("Manual Split (Misc)"),
                ToolTip("Won't split automatically. For use in ordered splits.")]
            ManualSplit,

            #endregion
        }
        public class ToolTipAttribute : Attribute {
            public string ToolTip { get; set; }
            public ToolTipAttribute(string text) {
                ToolTip = text;
            }

            public ToolTipAttribute(string format, params string[] parameters) {
                ToolTip = string.Format(format, parameters);
            }

        }

        public static string GetDescription(string name) {
            MemberInfo info = typeof(SplitName).GetMember(name)[0];
            DescriptionAttribute Description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
            return Description.Description;
        }

        public static string GetTooltip(string name) {
            MemberInfo info = typeof(SplitName).GetMember(name)[0];
            ToolTipAttribute Tooltip = (ToolTipAttribute)info.GetCustomAttributes(typeof(ToolTipAttribute), false)[0];
            return Tooltip.ToolTip;
        }

        public static SplitName GetSplitName(string text) {
            foreach (SplitName split in Enum.GetValues(typeof(SplitName))) {
                string name = split.ToString();
                if (name.Equals(text, StringComparison.OrdinalIgnoreCase) || GetDescription(name).Equals(text, StringComparison.OrdinalIgnoreCase)) {
                    return split;
                }
            }
            return SplitName.Clockwork_UpperTower;
        }

        public enum EHazeSkippableSetting {
            None = 0,
            ToPosition = 1,
            EntireSequence = 2,
            CloseToEnd = 3,
            CloseToEndDeactivateCameras = 4,
            EHazeSkippableSetting_MAX = 5
        }
    }
}
