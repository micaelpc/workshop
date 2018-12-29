using GymBL.Database;
using System;
using System.Data;

namespace GymBL.Entities
{
    /// <summary>
    /// Represents a meeting between a trainer and a trainee. Paid, ofcurse.
    /// </summary>
    public class PrivateTraining : IDatabaseSerializableWithId
    {
        /// <summary>
        /// The default constructror, for database
        /// </summary>
        public PrivateTraining()
        {
            Id = 0;
        }
        /// <summary>
        /// Defines a private training
        /// </summary>
        /// <param name="trainer">The trainer</param>
        /// <param name="trainee">The trainee</param>
        /// <param name="date">When will they meet</param>
        /// <param name="duration">How long will it take</param>
        public PrivateTraining(Trainer trainer, Trainee trainee, DateTime date, TimeSpan duration)
        {
            this.Trainer = trainer;
            this.Trainee = trainee;
            this.Date = date;
            this.Duration = duration;
            Id = 0;
        }

        /// <summary>
        /// The trainer
        /// </summary>
        public Trainer Trainer { get; private set; }
        
        /// <summary>
        /// The trainee
        /// </summary>
        public Trainee Trainee { get; private set; }
        /// <summary>
        /// When will they meet
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// How long will it take
        /// </summary>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Database id
        /// </summary>
        public int Id { get; private set; }
        /// Overriden methods:


        public string GetId()
        {
            return Id.ToString();
        }

        public void Load(DataRow row, Database.Database database)
        {
            Id = row.Field<int>("id");
            Trainer = database.Get<Trainer>(row.Field<string>("Trainer"));
            Trainee = database.Get<Trainee>(row.Field<string>("Trainee"));
            Date = row.Field<DateTime>("Date");
            Duration = TimeSpan.FromSeconds(row.Field<int>("Duration"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            if (Id != 0)
                stream.Add("id", Id);
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
