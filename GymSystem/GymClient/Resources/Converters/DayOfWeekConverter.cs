using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GymClient.Resources
{
    public class DayOfWeekConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = "ראשון";
            DayOfWeek value1 = (DayOfWeek)value;
            switch (value1)
            {
                case DayOfWeek.Sunday:
                    res = "ראשון";
                    break;
                case DayOfWeek.Monday:
                    res = "שני";
                    break;
                case DayOfWeek.Tuesday:
                    res = "שלישי";
                    break;
                case DayOfWeek.Wednesday:
                    res = "רביעי";
                    break;
                case DayOfWeek.Thursday:
                    res = "חמישי";
                    break;
                case DayOfWeek.Friday:
                    res = "שישי";
                    break;
                case DayOfWeek.Saturday:
                    res = "שבת";
                    break;
                default:
                    break;
            }

            return res;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            DayOfWeek res = DayOfWeek.Sunday;

            switch (value)
            {
                case "ראשון":
                    
                    break;
                case "שני":
                    res = DayOfWeek.Monday;
                    break;
                case "שלישי":
                    res = DayOfWeek.Tuesday;
                    break;
                case "רביעי":
                    res = DayOfWeek.Wednesday;
                    break;
                case "חמישי":
                    res = DayOfWeek.Thursday;
                    break;
                case "שישי":
                    res = DayOfWeek.Friday;
                    break;
                case "שבת":
                    res = DayOfWeek.Saturday;
                    break;


                default:
                    break;
            }

            return res;
        }
    }
}
