using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymBL.Report
{
    class SubscriptionNearEnd
    {
        public SubscriptionNearEnd(DateTime until)
        {
            var subs = Database.Database.GetInstance().GetAll<Subscription>($"EndT <= '{until.ToString("yyyy-MM-dd HH:mm:ss.fff")}' and isActive = 1");
            this.Trainees = subs.Select(x => x.Trainee).ToList();
        }

        public List<Trainee> Trainees { get; }
    }
}
