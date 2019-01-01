using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace GymBL.Entities
{
    /// <summary>
    /// An active trainer in the gym
    /// </summary>
    public class Trainer : Person
    {
        /// <summary>
        /// Default constructor for the database.
        /// </summary>
        public Trainer()
        {
            this.WorkDays = new List<TimeSpanOfWeek>();
        }

        /// <summary>
        /// The Trainer's constructor the define all it's properties.
        /// </summary>
        /// <param name="IDNumber">The trainer's ID number</param>
        /// <param name="Firstname">The trainer's first name</param>
        /// <param name="Surname">The trainer's surname</param>
        /// <param name="Address">The trainer's address</param>
        /// <param name="HomePhone">The trainer's home phone</param>
        /// <param name="CellPhone">The trainer's cellphone</param>
        /// <param name="EMail">The trainer's email address</param>
        /// <param name="Birthdate">The trainer's Birthdate</param>
        /// <param name="Comment">A comment on the trainer</param>
        /// <param name="workDays">When the trainer can work. Days and duration</param>
        public Trainer(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, IList<TimeSpanOfWeek> workDays) : base(IDNumber, Firstname, Surname, Address, HomePhone, CellPhone, EMail, Birthdate, Comment)
        {
            this.WorkDays = workDays;
        }

        /// <summary>
        /// The days the trainer works, with time duration.
        /// </summary>
        private IList<TimeSpanOfWeek> m_workDays;

        public IList<TimeSpanOfWeek> WorkDays
        {
            get { return m_workDays; }
            set
            {
                m_workDays = value;
                OnPropertyChanged("WorkDays");
            }
        }

        /// <summary>
        /// Serialize to database.
        /// </summary>
        /// <param name="stream">The serialization output</param>
        public override void Serialize(IDatabaseStream stream)
        {
            base.Serialize(stream);
            stream.Add("WorkDays", Utils.ToString(WorkDays));
        }

        /// <summary>
        /// Loads the trainer from the database
        /// </summary>
        /// <param name="row">The row representing the trainer</param>
        /// <param name="database">The database containing the trainer</param>
        public override void Load(DataRow row, Database.Database database)
        {
            base.Load(row, database);
            WorkDays = Utils.FromString(row.Field<string>("WorkDays"));
        }
    }
}
