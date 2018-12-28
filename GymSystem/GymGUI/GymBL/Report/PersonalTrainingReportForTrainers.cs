using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Report
{
    class PersonalTrainingReportForTrainers
    {
        PersonalTrainingReportForTrainers(Trainer trainer) {
            this.Trainer = trainer;
            this.PrivateTrainings = Database.Database.GetInstance().GetAll<PrivateTraining>($"Trainer = '{trainer.IDNumber}'");
        }

        public Trainer Trainer { get; private set; }
        public List<PrivateTraining> PrivateTrainings { get; }
    }
}
