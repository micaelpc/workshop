using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymBL
{
    static class Utils
    {
        public static string ToString(IList<TimeSpanOfWeek> list)
        {
            return string.Join("|", list.Select(x => $"{(int)x.Day};{x.StartTime};{x.EndTime}").ToArray());
        }

        public static IList<TimeSpanOfWeek> FromString(string data)
        {
            return data.Split('|').
                Select(x => x.Split(';')).
                Select(x => new TimeSpanOfWeek((DayOfWeek)int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]))).ToList();
        }

    }
}
