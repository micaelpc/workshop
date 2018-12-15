using GymBL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    class Trainer : Person
    {
        public Trainer() { }
        public Trainer(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, IList<TimeSpanOfWeek> workDays) : base(IDNumber, Firstname, Surname, Address, HomePhone, CellPhone, EMail, Birthdate, Comment)
        {
            this.WorkDays = workDays;
        }

        public IList<TimeSpanOfWeek> WorkDays { get; private set; }


        public override void Serialize(IDatabaseStream stream)
        {
            base.Serialize(stream);
            var builder = new StringBuilder();
            stream.Add("TrainDays", string.Join("|", WorkDays.Select(x => $"{(int)x.Day};{x.StartTime};{x.EndTime}").ToArray()));
        }

        public override void Load(DataRow row, Database.Database database)
        {
            base.Load(row, database);
            WorkDays = row.Field<string>("TrainDays").
                Split('|').
                Select(x => x.Split(';')).
                Select(x => new TimeSpanOfWeek((DayOfWeek)int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]))).ToList();
        }
    }
}
 