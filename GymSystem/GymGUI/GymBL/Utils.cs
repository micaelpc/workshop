using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymBL
{
    public static class Utils
    {
        public static string ToString(IList<TimeSpanOfWeek> list)
        {
            return string.Join("|", list.Select(x => $"{(int)x.Day};{x.StartTime};{x.EndTime}").ToArray());
        }

        public static IList<TimeSpanOfWeek> FromString(string data)
        {
            if (data.Length == 0)
                return new List<TimeSpanOfWeek>();
            return data.Split('|').
                Select(x => x.Split(';')).
                Select(x => new TimeSpanOfWeek((DayOfWeek)int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]))).ToList();
        }

        public static DateTime Trim(this DateTime date, long ticks)
        {
            return new DateTime(date.Ticks - (date.Ticks % ticks), date.Kind);
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Substring(2);
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        public static string ByteArrayToString(byte[] ba)
        {
            return "0x" + BitConverter.ToString(ba).Replace("-", "");
        }
    }
}
