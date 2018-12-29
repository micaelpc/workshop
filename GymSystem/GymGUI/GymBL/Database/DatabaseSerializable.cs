using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    /// <summary>
    /// Represents an object that can be serialized to the database.
    /// </summary>
    public interface IDatabaseSerializable
    {
        /// <summary>
        /// Serializes the object to the database stream.
        /// </summary>
        /// <param name="stream">The output stream</param>
        void Serialize(IDatabaseStream stream);

        /// <summary>
        /// Loads the object from the database
        /// </summary>
        /// <param name="row">The row representing the object</param>
        /// <param name="database">The database, in order to retrieve additional objects linked to this</param>
        void Load(DataRow row, Database database);
    }
}
