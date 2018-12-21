using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    public class Subscription : IDatabaseSerializableWithId
    {
        public Subscription() { }
        public Subscription(string id, DateTime start, DateTime end, uint monthlyPayment, bool isActive, Trainee trainee) {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.MonthlyPayment = monthlyPayment;
            this.IsActive = isActive;
            this.Trainee = trainee;
        }
        

        public string Id { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public uint MonthlyPayment { get; private set; }
        public bool IsActive { get; private set; }
        public Trainee Trainee { get; private set; }

        public string GetId()
        {
            return this.Id;
        }

        public void Load(DataRow row, Database.Database database)
        {
            Start = row.Field<DateTime>("Start");
            End = row.Field<DateTime>("End");
            MonthlyPayment = (uint)row.Field<int>("MonthlyPayment");
            IsActive = Convert.ToBoolean(row.Field<int>("IsActive"));
            Trainee = database.Get<Trainee>(row.Field<string>("Trainee"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            stream.Add("Id", Id);
            stream.Add("Start", Start);
            stream.Add("End", End);
            stream.Add("MonthlyPayment", (int)MonthlyPayment);
            stream.Add("IsActive", Convert.ToInt32(IsActive));
            stream.Add("Trainee", Trainee.GetId());
        }
    }
}
