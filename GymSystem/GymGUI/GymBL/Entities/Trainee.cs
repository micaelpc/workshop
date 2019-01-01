using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    /// <summary>
    /// Represents someone who trains in the gym
    /// </summary>
    public class Trainee : Person
    {
        /// <summary>
        /// Default constructor for the database
        /// </summary>
        public Trainee() {
            TrainDays = new List<DayOfWeek>();
            Subscriptions = new List<Subscription> { new Subscription {Start = DateTime.Now,End = DateTime.Now.AddMonths(12) } };
        }
        /// <summary>
        /// A constructor for a trainee
        /// </summary>
        /// <param name="IDNumber">the trainee unique id</param>
        /// <param name="Firstname">first name for the trainee</param>
        /// <param name="Surname">surname for the person</param>
        /// <param name="Address">the trainee`s address</param>
        /// <param name="HomePhone">the trainee`s homephone</param>
        /// <param name="CellPhone">the trainee`s cellphone</param>
        /// <param name="EMail">the trainee`s email</param>
        /// <param name="Birthdate">the trainee`s birthdate</param>
        /// <param name="Comment">a general textual comment for the trainee</param>
        /// <param name="trainDays">When does he trains</param>
        /// <param name="subscriptions">It's substriptions</param>
        public Trainee(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, IList<DayOfWeek> trainDays, IList<Subscription> subscriptions) : base(IDNumber, Firstname, Surname, Address, HomePhone, CellPhone, EMail, Birthdate, Comment)
        {
            this.TrainDays = trainDays;
            this.Subscriptions = subscriptions;
        }

        
        /// <summary>
        /// Caluated prop - Dont map!
        /// </summary>
        public bool IsActiveMember
        {
            get {
                if (this.Subscriptions!=null &&this.Subscriptions.Count>0 &&
                    this.Subscriptions.Any(x=>x.End<DateTime.Now))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// When does he train
        /// </summary>
        private IList<DayOfWeek> m_trainDays;

        /// <summary>
        /// His subscriptions
        /// </summary>
        private IList<Subscription> m_subscriptions;

        public IList<DayOfWeek> TrainDays
        {
            get
            {
                return m_trainDays;
            }
            set
            {
                m_trainDays = value;
                OnPropertyChanged("TrainDays");
            }
        }

        public IList<Subscription> Subscriptions
        {
            get
            {
                return m_subscriptions;
            }
            set
            {
                m_subscriptions = value;
                OnPropertyChanged("Subscriptions");
            }
        }

        // overriden methods:

        public override void Serialize(IDatabaseStream stream)
        {
            base.Serialize(stream);
            var builder = new StringBuilder();
            stream.Add("TrainDays", string.Join("|", TrainDays.Select(x => ((int)x).ToString()).ToArray()));
            foreach (var sub in Subscriptions)
            {
                sub.Trainee = this;
                stream.Add(sub);
            }
        }

        public override void Load(DataRow row, Database.Database database)
        {
            base.Load(row, database);
            if (row.Field<string>("TrainDays").Length == 0)
                TrainDays = new List<DayOfWeek>();
            else
                TrainDays = row.Field<string>("TrainDays").Split('|').Select(x => (DayOfWeek)int.Parse(x)).ToList();
            Subscriptions = database.GetAll<Subscription>($"Trainee = '{IDNumber}'");
        }
    }
}
