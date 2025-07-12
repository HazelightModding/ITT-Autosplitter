using LiveSplit.ComponentUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static LiveSplit.ItTakesTwo.Splits;
using static LiveSplit.ItTakesTwo.Statics;
using static LiveSplit.ItTakesTwo.Types;


namespace LiveSplit.ItTakesTwo
{
    public static class Statics
    {
        public static string ToObjectName(this string objectPath, char index = '.')
        {
            return GetObjectNameFromObjectPath(objectPath, index);
        }
        public static string GetObjectNameFromObjectPath(this string objectPath, char index = '.')
        {
            if (objectPath == null) { return null; }

            int lastDotIndex = objectPath.LastIndexOf(index);
            if (lastDotIndex == -1)
            {
                return objectPath;
            }

            return objectPath.Substring(lastDotIndex + 1);
        }

        public static Memory GetMemory() => Memory.GetOrCreate();
        public static Settings GetSplitSettings() => Settings.GetOrCreate();
        public static Data GetData() => GetMemory().GetData();

        public static Process Game { get; set; }
    }

    public static class Types
    {
        private static Logger Log = Logger.GetLogger("Types");


        public struct TArray<T> where T : struct 
        {
            public IntPtr ArrayPtr;
            public int Length;
            public int Capacity;

            private List<T> _array;

            public T this[int index] => _array[index];


            public TArray()
            {
                _array = ReadArray(this);
            }

            public static List<T> ReadArray(TArray<T> InArray)
            {
                int numElements = InArray.Length;
                int elementSize = Marshal.SizeOf(typeof(T));
                int numBytes = elementSize * numElements;

                var ptr = new DeepPointer(InArray.ArrayPtr);

                if (!ptr.DerefBytes(Game, numBytes, out byte[] arrayInBytes))
                    return null;

                T[] result = new T[numElements];

                GCHandle handle = GCHandle.Alloc(arrayInBytes, GCHandleType.Pinned);
                try
                {
                    IntPtr basePtr = handle.AddrOfPinnedObject();
                    for (int i = 0; i < numElements; i++)
                    {
                        IntPtr elementPtr = IntPtr.Add(basePtr, i * elementSize);
                        result[i] = Marshal.PtrToStructure<T>(elementPtr);
                    }
                }
                finally
                {
                    handle.Free();
                }

                return result.ToList();
            }


        }

        public struct FString
        {
            public IntPtr StrPtr;
            public int Length;
            public int Capacity;

            public FString(string str)
            {
                //Str = str;
                //Length = str.Length;
            }

            public static implicit operator FString(string str) => new FString(str);
            public static implicit operator string(FString Fstr) => Fstr.ToString();
            public override readonly string ToString() => FStringToString(this);

            public static string FStringToString(FString Fstr)
            {
                if (Fstr.StrPtr == IntPtr.Zero)
                    return String.Empty;

                if (new DeepPointer(Fstr.StrPtr).DerefString(Game, Fstr.Length * 2, out var str)) 
                {
                    return str;
                }
                return String.Empty;
            }
        }

        public struct FName
        {
            public int Index; 

            public FName(int index)
            {
                Index = index;
            }

            public static Dictionary<int, string> Cache = new();
            private static IntPtr _pool = IntPtr.Zero;
            public static IntPtr Pool
            {
                get
                {
                    if (_pool == IntPtr.Zero)
                    {
                        Log.Warning("FNamePool is not set.");
                    }
                    return _pool;
                }
                set
                {
                    //Log.Info("FNamePool is set to: 0x" + value.ToString("X"));
                    _pool = value;
                }
            }
            public static FName None = new FName(0);
            public override bool Equals(object obj)
            {
                if (obj is FName other)
                    return Index == other.Index;
                return false;
            }

            public override int GetHashCode() => Index.GetHashCode();

            public static bool operator ==(FName a, FName b) => a.Index == b.Index;
            public static bool operator !=(FName a, FName b) => a.Index != b.Index;
            public string ToObjectName() => this.ToString().GetObjectNameFromObjectPath(); 
            public static implicit operator FName(int index) => new FName(index);
            public static implicit operator int(FName name) => name.Index;
            public static implicit operator string(FName name) => name.ToString();
            public override readonly string ToString() => FName.ToString(Index);
            public string ToDebugString() => string.Format("[{0}] {1}", Index.ToString(), ToString());
            public static string ToString(int index)
            {
                if (Pool == IntPtr.Zero)
                    return index.ToString();

                if (Cache.TryGetValue(index, out string cachedStr))
                    return cachedStr;

                var blockIndex = index >> 16;
                var blockOffset = 2 * (index & 0xFFFF);
                var headerPtr = new DeepPointer(Pool + (blockIndex * 0x8) + 0x10, blockOffset);

                if (!headerPtr.DerefBytes(Game, 2, out byte[] headerBytes))
                    return null;

                if (!headerPtr.DerefOffsets(Game, out IntPtr headerRawPtr))
                    return null;

                bool isWide = (headerBytes[0] & 0x01) != 0;
                int length = (headerBytes[1] << 2) | ((headerBytes[0] & 0xC0) >> 6);
                var stringPtr = new DeepPointer(headerRawPtr + 2);
                ReadStringType stringType = isWide ? ReadStringType.UTF16 : ReadStringType.ASCII;
                int numBytes = length * (isWide ? 2 : 1);

                if (!stringPtr.DerefString(Game, stringType, numBytes, out string str))
                    return null; 

                Cache[index] = str;
                return str;
            }
            
        }

        public enum EHazeSkippableSetting
        {
            None = 0,
            ToPosition = 1,
            EntireSequence = 2,
            CloseToEnd = 3,
            CloseToEndDeactivateCameras = 4,
            EHazeSkippableSetting_MAX = 5
        } 

    }
}
