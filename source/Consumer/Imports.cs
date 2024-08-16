using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Milliseconds;

        public static implicit operator DateTime(SystemTime systemTime)
        {
            return new DateTime(
                systemTime.Year, 
                systemTime.Month, 
                systemTime.Day,                                
                systemTime.Hour, 
                systemTime.Minute, 
                systemTime.Second,                                
                systemTime.Milliseconds
            );
        }

        public static explicit operator SystemTime(DateTime dateTime)
        {
            return new SystemTime() {
                Year = (ushort)dateTime.Year,
                Month = (ushort)dateTime.Month,
                Day = (ushort)dateTime.Day,
                Hour = (ushort)dateTime.Hour,
                Minute = (ushort)dateTime.Minute,
                Second = (ushort)dateTime.Second,
                Milliseconds = (ushort)dateTime.Millisecond
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ImportantInfo
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Name;
        public int NameLength;
        public SystemTime Date;
        public int Age;
    };

    public static partial class Program
    {
        private const string DLLPath = "Exporter.dll";

        [DllImport(DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern int Add(int a, int b);

        [DllImport(DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetTextOKLength();

        [DllImport(DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetTextOK([MarshalAs(UnmanagedType.LPWStr)] string text, int count);

        [DllImport(DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetRandomsLength(int seed);

        [DllImport(DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetRandoms([MarshalAs(UnmanagedType.LPArray)] int[] data, int count, int seed);

        [DllImport(DLLPath, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetImportantInfo(ref ImportantInfo info);
    }
}
