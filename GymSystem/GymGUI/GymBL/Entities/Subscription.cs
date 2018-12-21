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

        public Subscription(DateTime start, DateTime end, uint monthlyPayment, bool isActive, Trainee trainee)
            :this(0, start, end, monthlyPayment, isActive, trainee)
        {
        }

        public Subscription(int id, DateTime start, DateTime end, uint monthlyPayment, bool isActive, Trainee trainee) {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.MonthlyPayment = monthlyPayment;
            this.IsActive = isActive;
            this.Trainee = trainee;
        }

        public int Id { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public uint MonthlyPayment { get; private set; }
        public bool IsActive { get; private set; }
        public Trainee Trainee { get; private set; }

        public string GetId()
        {
            return this.Id.ToString();
        }

        public void Load(DataRow row, Database.Database database)
        {
            Id = row.Field<int>("Id");
            Start = row.Field<DateTime>("StartT");
            End = row.Field<DateTime>("EndT");
            MonthlyPayment = (uint)row.Field<int>("MonthlyPayment");
            IsActive = Convert.ToBoolean(row.Field<int>("IsActive"));
            Trainee = database.Get<Trainee>(row.Field<string>("Trainee"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            if(Id != 0)
                stream.Add("Id", Id);
            stream.Add("StartT", Start);
            stream.Add("EndT", End);
            stream.Add("MonthlyPayment", (int)MonthlyPayment);
            stream.Add("IsActive", Convert.ToInt32(IsActive));
            stream.Add("Trainee", Trainee.GetId());
        }

        public void SetId(string id)
        {
            Id = int.Parse(id);
        }
    }
}
