using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    class Subscription
    {
        public Subscription(DateTime start, DateTime end, uint monthlyPayment, bool isActive) {
            this.Start = start;
            this.End = end;
            this.MonthlyPayment = monthlyPayment;
            this.IsActive = isActive;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public uint MonthlyPayment { get; private set; }
        public bool IsActive { get; private set; }
    }
}
