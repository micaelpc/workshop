using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    class Trainer : Person
    {

        public Trainer(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, IList<TimeSpanOfWeek> workDays) : base(IDNumber, Firstname, Surname, Address, HomePhone, CellPhone, EMail, Birthdate, Comment)
        {
            this.WorkDays = workDays;
        }

        public IList<TimeSpanOfWeek> WorkDays { get; private set; }
    }
}
