using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    /// <summary>
    /// Represents a database object with id
    /// </summary>
    public interface IDatabaseSerializableWithId : IDatabaseSerializable
    {
        /// <summary>
        /// Sets the id
        /// </summary>
        /// <param name="id">The new id</param>
        void SetId(string id);

        /// <summary>
        /// Gets the id. Should be empty when id hasn't been determined yet.
        /// </summary>
        /// <returns>The id</returns>
        string GetId();
    }
}
