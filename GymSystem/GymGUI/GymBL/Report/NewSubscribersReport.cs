using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Report
{
    public class NewSubscribersReport
    {
        public NewSubscribersReport(DateTime from, DateTime to) {
            var subs = Database.Database.GetInstance().GetAll<Subscription>($"StartT >= '{from.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and StartT <= '{to.ToString("yyyy-MM-dd HH:mm:ss.fff")}'");
            this.Trainees = subs.Select(x => x.Trainee).ToList();
        }

        public List<Trainee> Trainees { get; }
    }
}
