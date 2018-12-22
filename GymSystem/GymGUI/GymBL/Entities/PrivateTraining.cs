using GymBL.Database;
using System;
using System.Data;

namespace GymBL.Entities
{
    public class PrivateTraining : IDatabaseSerializableWithId
    {
        public PrivateTraining()
        {
            Id = 0;
        }
        public PrivateTraining(Trainer trainer, Trainee trainee, DateTime date, TimeSpan duration)
        {
            this.Trainer = trainer;
            this.Trainee = trainee;
            this.Date = date;
            this.Duration = duration;
            Id = 0;
        }

        public Trainer Trainer { get; private set; }
        public Trainee Trainee { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int Id { get; private set; }

        public string GetId()
        {
            return Id.ToString();
        }

        public void Load(DataRow row, Database.Database database)
        {
            Id = row.Field<int>("Id");
            Trainer = database.Get<Trainer>(row.Field<string>("Trainer"));
            Trainee = database.Get<Trainee>(row.Field<string>("Trainee"));
            Date = row.Field<DateTime>("Date");
            Duration = TimeSpan.FromSeconds(row.Field<int>("Duration"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            if (Id != 0)
                stream.Add("Id", Id);
            stream.Add("Trainer", Trainer.GetId());
            stream.Add("Trainee", Trainee.GetId());
            stream.Add("Date", Date);
            stream.Add("Duration", (int)Duration.TotalSeconds);
        }

        public void SetId(string id)
        {
            Id = int.Parse(id);
        }
    }
}
