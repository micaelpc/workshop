using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    class PrivateTraining
    {
        public PrivateTraining(Trainer trainer, Trainee trainee, DateTime date, TimeSpan duration) {
            this.Trainer = trainer;
            this.Trainee = trainee;
            this.Date = date;
            this.Duration = duration;
        }

        public Trainer Trainer { get; private set; }
        public Trainee Trainee { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan Duration { get; private set; }
    }
}
