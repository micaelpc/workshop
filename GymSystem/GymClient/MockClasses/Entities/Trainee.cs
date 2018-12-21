using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GymBL.Entities
{
    public class Trainee : Person , INotifyPropertyChanged

    {
        public Trainee() { }
        public Trainee(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, IList<DayOfWeek> trainDays, IList<Subscription> subscriptions) : base(IDNumber, Firstname, Surname, Address, HomePhone, CellPhone, EMail, Birthdate, Comment)
        {
            this.TrainDays = trainDays;
            this.Subscriptions = subscriptions;
        }

        public IList<DayOfWeek> TrainDays { get; private set; }
        public IList<Subscription> Subscriptions { get; private set; }


        //public override void Serialize(IDatabaseStream stream)
        //{
        //    base.Serialize(stream);
        //    var builder = new StringBuilder();
        //    stream.Add("TrainDays", string.Join("|", TrainDays.Select(x => ((int)x).ToString()).ToArray()));
        //    foreach(var sub in Subscriptions)
        //    {
        //        stream.Add(sub);
        //    }
        //}

        //public override void Load(DataRow row, Database.Database database) 
        //{
        //    base.Load(row, database);
        //    TrainDays = row.Field<string>("TrainDays").Split('|').Select(x => (DayOfWeek)int.Parse(x)).ToList();
        //    Subscriptions = database.GetAll<Subscription>($"Trainee = '{IDNumber}'");
        //}
    }
}
