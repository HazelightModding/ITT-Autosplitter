using LiveSplit.ComponentUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using static LiveSplit.ItTakesTwo.Statics;
using static LiveSplit.ItTakesTwo.Types;

namespace LiveSplit.ItTakesTwo
{
    public partial class Memory()
    {
        public Logger Log = Logger.GetLogger("Memory");

        public bool IsHooked { get; set; }
        private Thread ScanThread;
        private static Data Data;

        private static Memory a;
        public static Memory GetOrCreate()
        {
            return a ??= new Memory();
        }
        public Data GetData()
        {
            //if (!IsHooked || Data == null) throw new Exception("Can't retrieve data while the game isn't hooked.");
            return Data;
        }

        public bool Update()
        {
            IsHooked = Game != null && !Game.HasExited;

            if (!IsHooked)
                IsHooked = Hook();
            if (!IsHooked)
                return false;

            if (ScanThread.IsAlive)
                return false;

            Data.UpdateAll(Game);

            return true;
        }

        public bool Hook()
        {

            // Think this should work just fine for the trial version too? For reference it's "ItTakesTwo_Trial"
            Process[] processes = Process.GetProcessesByName("ItTakesTwo");
            Game = processes != null && processes.Length > 0 ? processes[0] : null;
            if (Game == null || Game.HasExited)
            {
                return false;
            }
            Log.Info("Hooked to process: " + Game.ProcessName);

            try
            {
                SetPointersBySigscan();
                return true;
            }
            catch (Win32Exception ex)
            {
                Log.Error(ex.ErrorCode.ToString());
                return false;
            }

        }

        private void SetPointersBySigscan()
        {
            CancellationTokenSource CancelSource = new();
            ScanThread = new Thread(() =>
            {
                Log.Info("Starting scan thread");

                var scanner = new SignatureScanner(Game, Game.MainModule.BaseAddress, (int)Game.MainModule.ModuleMemorySize);
                var token = CancelSource.Token;

                Log.Info("Scanning process: " + scanner.Process);

                var gWorld = IntPtr.Zero;
                var gWorldSig = new SigScanTarget(10, "80 7C 24 ?? 00 ?? ?? 48 8B 3D ???????? 48") { OnFound = (p, s, ptr) => ptr + 0x4 + p.ReadValue<int>(ptr) };

                while (!token.IsCancellationRequested)
                {
                    if (gWorld == IntPtr.Zero && (gWorld = scanner.Scan(gWorldSig)) != IntPtr.Zero)
                    {
                        Log.Info("Found GWorld at 0x" + gWorld.ToString("X") + ".");
                        Data = new(gWorld);
                        break;
                    }

                    Log.Info("GWorld not found, sleeping...");
                    Thread.Sleep(2000);
                }
                FName.Pool = IntPtr.Zero;
                var FNamePoolSig = new SigScanTarget(13, "89 5C 24 ?? 89 44 24 ?? 74 ?? 48 8D 15") { OnFound = (p, s, ptr) => ptr + 0x4 + p.ReadValue<int>(ptr) };

                while (!token.IsCancellationRequested)
                {
                    if (FName.Pool == IntPtr.Zero && (FName.Pool = scanner.Scan(FNamePoolSig)) != IntPtr.Zero)
                    {
                        Log.Info("Found FNamePool at 0x{0}.", FName.Pool.ToString("X"));
                        break;
                    }

                    Log.Info("FNamePool not found, sleeping...");
                    Thread.Sleep(2000);
                }

                Log.Info("Exiting scan thread.");
            });

            ScanThread.Start();
        }

        public void Dispose()
        {
            Game?.Dispose();
        }
    }
}