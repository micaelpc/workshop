using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    public class Subscription : ObservableObject, IDatabaseSerializableWithId
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
        
        private int _id;
        private DateTime _start;
        private DateTime _end;
        private uint _monthlyPayment;
        private bool _isActive;



        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }



        public DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }


        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
                OnPropertyChanged("End");
            }
        }


        public uint MonthlyPayment
        {
            get
            {
                return _monthlyPayment;
            }
            set
            {
                _monthlyPayment = value;
                OnPropertyChanged("MonthlyPayment");
            }
        }


        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

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
