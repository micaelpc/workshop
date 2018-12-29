using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymBL.Report
{
    public class SubscriptionNearEnd
    {
        public SubscriptionNearEnd(DateTime from, DateTime to)
        {
            var subs = Database.Database.GetInstance().GetAll<Subscription>($"EndT <= '{to.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and EndT >= '{from.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and isActive = 1 ");
            this.Trainees = subs.Select(x => x.Trainee).ToList();
        }

        public List<Trainee> Trainees { get; }
    }
}
