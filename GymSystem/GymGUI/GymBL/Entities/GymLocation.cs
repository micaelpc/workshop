using GymBL.Database;
using System.Collections.Generic;
using System.Data;

namespace GymBL.Entities
{
    /// <summary>
    /// Represents a gym location
    /// </summary>
    public class GymLocation : IDatabaseSerializableWithId
    {
        /// <summary>
        /// Default constructor for the database
        /// </summary>
        public GymLocation() { }
        /// <summary>
        /// Constructor defining the gym location
        /// </summary>
        /// <param name="name">The name of the gym</param>
        /// <param name="address">It's address</param>
        /// <param name="openingTime">When will it be open</param>
        public GymLocation(string name, string address, IList<TimeSpanOfWeek> openingTime)
        {
            this.Name = name;
            this.Address = address;
            this.OpeningTimes = openingTime;
        }

        /// <summary>
        /// The name of the gym
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The address
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// When will it be open.
        /// </summary>
        public IList<TimeSpanOfWeek> OpeningTimes { get; private set; }
        
        /// Overriden methods


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

        public void SetId(string id)
        {
            Name = id;
        }
    }
}
