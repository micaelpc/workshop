using GymBL.Database;
using System;
using System.Data;

namespace GymBL.Entities
{
    class PrivateTraining : IDatabaseSerializable
    {
        public PrivateTraining(Trainer trainer, Trainee trainee, DateTime date, TimeSpan duration)
        {
            this.Trainer = trainer;
            this.Trainee = trainee;
            this.Date = date;
            this.Duration = duration;
        }

        public Trainer Trainer { get; private set; }
        public Trainee Trainee { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan Duration { get; private set; }
        
        public void Load(DataRow row, Database.Database database)
        {
            Trainer = database.Get<Trainer>(row.Field<string>("Trainer"));
            Trainee = database.Get<Trainee>(row.Field<string>("Trainee"));
            Date = row.Field<DateTime>("Trainee");
            Duration = TimeSpan.FromSeconds(row.Field<int>("Duration"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            stream.Add("Trainer", Trainer.GetId());
            stream.Add("Trainee", Trainee.GetId());
            stream.Add("Date", Date);
            stream.Add("Duration", (int)Duration.TotalSeconds);
        }
    }
}
