using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    public class Trainee : Person
    {
        public Trainee() {
            TrainDays = new List<DayOfWeek>();
            Subscriptions = new List<Subscription> { new Subscription {Start = DateTime.Now,End = DateTime.Now.AddMonths(12) } };
        }
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


        private IList<DayOfWeek> _trainDays;
        private IList<Subscription> _subscriptions;

        public IList<DayOfWeek> TrainDays
        {
            get
            {
                return _trainDays;
            }
            set
            {
                _trainDays = value;
                OnPropertyChanged("TrainDays");
            }
        }

        public IList<Subscription> Subscriptions
        {
            get
            {
                return _subscriptions;
            }
            set
            {
                _subscriptions = value;
                OnPropertyChanged("Subscriptions");
            }
        }

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
