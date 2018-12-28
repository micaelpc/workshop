using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    public class Trainer : Person
    {
        public Trainer() { }
        public Trainer(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, IList<TimeSpanOfWeek> workDays) : base(IDNumber, Firstname, Surname, Address, HomePhone, CellPhone, EMail, Birthdate, Comment)
        {
            this.WorkDays = workDays;
        }


        private IList<TimeSpanOfWeek> _workDays; 
    
        public IList<TimeSpanOfWeek> WorkDays { get { return _workDays; }
            set { _workDays= value;
                OnPropertyChanged("WorkDays");
            }
        }


        public override void Serialize(IDatabaseStream stream)
        {
            base.Serialize(stream);
            //TODO - TAL - fix exception
            stream.Add("WorkDays", string.Join("|", WorkDays.Select(x => $"{(int)x.Day};{x.StartTime};{x.EndTime}").ToArray()));
        }

        public override void Load(DataRow row, Database.Database database)
        {
            base.Load(row, database);
            WorkDays = Utils.FromString(row.Field<string>("WorkDays"));
        }
    }
}
 