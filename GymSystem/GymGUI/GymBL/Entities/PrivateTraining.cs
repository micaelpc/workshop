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
    }
}
