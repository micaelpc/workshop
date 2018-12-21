using GymBL.Database;
using System.Collections.Generic;
using System.Data;

namespace GymBL.Entities
{
    class GymLocation : IDatabaseSerializableWithId
    {
        GymLocation() { }
        GymLocation(string name, string address, IList<TimeSpanOfWeek> openingTime)
        {
            this.Name = name;
            this.Address = address;
            this.OpeningTimes = openingTime;
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public IList<TimeSpanOfWeek> OpeningTimes { get; private set; }

        public string GetId()
        {
            return this.Name;
        }

        public void Load(DataRow row, Database.Database database)
        {
            Name = row.Field<string>("Id");
            Address = row.Field<string>("Address");
            OpeningTimes = Utils.FromString(row.Field<string>("OpeningTimes"));
        }

        public void Serialize(IDatabaseStream stream)
        {
            stream.Add("Id", this.Name);
            stream.Add("Address", this.Address);
            stream.Add("OpeningTimes", Utils.ToString(OpeningTimes));
        }
    }
}
