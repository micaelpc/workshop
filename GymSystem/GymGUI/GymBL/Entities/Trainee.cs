using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    public class Trainee : Person
    {
        public Trainee(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, IList<DayOfWeek> trainDays) : base(IDNumber, Firstname, Surname, Address, HomePhone, CellPhone, EMail, Birthdate, Comment)
        {
            this.TrainDays = trainDays;
        }

        public IList<DayOfWeek> TrainDays { get; private set; }

    }
}
