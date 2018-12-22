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
        public Subscription(string id, DateTime start, DateTime end, uint monthlyPayment, bool isActive, Trainee trainee) {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.MonthlyPayment = monthlyPayment;
            this.IsActive = isActive;
            this.Trainee = trainee;
        }

        private string _id;
        private DateTime _start;
        private DateTime _end;
        private uint _monthlyPayment;
        private bool _isActive;



        public string Id
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

        public Trainee Trainee { get; private set; }  //TAL Trainne contains List of subscriptions - i think you shoud remove it to prevent circule

        public string GetId()
        {
            return this.Id;
        }

        public void Load(DataRow row, Database.Database database)
        {
            Id = row.Field<string>("Id");
            Start = row.Field<DateTime>("Start");
            End = row.Field<DateTime>("End");
            MonthlyPayment = (uint)row.Field<int>("MonthlyPayment");
            IsActive = Convert.ToBoolean(row.Field<int>("IsActive"));
            Trainee = database.Get<Trainee>(row.Field<string>("Trainee"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            if(Id.Length != 0)
                stream.Add("Id", Id);
            stream.Add("Start", Start);
            stream.Add("End", End);
            stream.Add("MonthlyPayment", (int)MonthlyPayment);
            stream.Add("IsActive", Convert.ToInt32(IsActive));
            stream.Add("Trainee", Trainee.GetId());
        }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}
