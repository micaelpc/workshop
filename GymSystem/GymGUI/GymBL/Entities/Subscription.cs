using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    /// <summary>
    /// Represents a subscription to the gym. 
    /// </summary>
    public class Subscription : ObservableObject, IDatabaseSerializableWithId
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Subscription() {
            Id = 0;
            IsActive = true;
        }

        /// <summary>
        /// Defines a substription
        /// </summary>
        /// <param name="start">When does it start</param>
        /// <param name="end">When will it end</param>
        /// <param name="monthlyPayment">The monthly payment</param>
        /// <param name="isActive">Whether it's active</param>
        /// <param name="trainee">The trainee in question</param>
        public Subscription(DateTime start, DateTime end, uint monthlyPayment, bool isActive, Trainee trainee)
            :this(0, start, end, monthlyPayment, isActive, trainee)
        {
        }

        /// <summary>
        /// Defines a substription
        /// </summary>
        /// <param name="id">The database id of the subscription</param>
        /// <param name="start">When does it start</param>
        /// <param name="end">When will it end</param>
        /// <param name="monthlyPayment">The monthly payment</param>
        /// <param name="isActive">Whether it's active</param>
        /// <param name="trainee">The trainee in question</param>
        public Subscription(int id, DateTime start, DateTime end, uint monthlyPayment, bool isActive, Trainee trainee) {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.MonthlyPayment = monthlyPayment;
            this.IsActive = isActive;
            this.Trainee = trainee;
        }
        /// <summary>
        /// The database's id
        /// </summary>
        private int m_id;
        /// <summary>
        /// When the substription starts
        /// </summary>
        private DateTime m_start;
        /// <summary>
        /// When will it end
        /// </summary>
        private DateTime m_end;

        /// <summary>
        /// How much to pay each month
        /// </summary>
        private uint m_monthlyPayment;
        /// <summary>
        /// Whether the substription is active or not
        /// </summary>
        private bool m_isActive;


        // Properties:
        public int Id
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
                OnPropertyChanged("Id");
            }
        }



        public DateTime Start
        {
            get
            {
                return m_start;
            }
            set
            {
                m_start = value;
                OnPropertyChanged("Start");
            }
        }


        public DateTime End
        {
            get
            {
                return m_end;
            }
            set
            {
                m_end = value;
                OnPropertyChanged("End");
            }
        }


        public uint MonthlyPayment
        {
            get
            {
                return m_monthlyPayment;
            }
            set
            {
                m_monthlyPayment = value;
                OnPropertyChanged("MonthlyPayment");
            }
        }


        public bool IsActive
        {
            get
            {
                return m_isActive;
            }
            set
            {
                m_isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        public Trainee Trainee { get; set; }

        // overriden methods:

        public string GetId()
        {
            if (this.Id == 0)
                return "";
            return this.Id.ToString();
        }

        public void Load(DataRow row, Database.Database database)
        {
            Id = row.Field<int>("id");
            Start = row.Field<DateTime>("StartT");
            End = row.Field<DateTime>("EndT");
            MonthlyPayment = (uint)row.Field<int>("MonthlyPayment");
            IsActive = Convert.ToBoolean(row.Field<int>("IsActive"));
            Trainee = database.Get<Trainee>(row.Field<string>("Trainee"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            if(Id != 0)
                stream.Add("id", Id);
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
