using System;
using System.Collections.Generic;

namespace GymBL.Database
{
    /// <summary>
    /// Implementation of the database stream.
    /// </summary>
    class DatabaseStream : IDatabaseStream
    {
        /// <summary>
        /// The values of the columns
        /// </summary>
        public List<string> Values { get; set; } = new List<string>();
        /// <summary>
        /// The columns
        /// </summary>
        public List<string> Columns { get; set; } = new List<string>();
        /// <summary>
        /// More objects to be inserted to the database
        /// </summary>
        public List<IDatabaseSerializableWithId> MoreObjects { get; set; } = new List<IDatabaseSerializableWithId>();

        /// <summary>
        /// Add a key->value pair without special formatting.
        /// </summary>
        /// <param name="name">The key (column)</param>
        /// <param name="value">The value</param>
        public void AddNoFormat(string name, string value)
        {
            Columns.Add(name);
            Values.Add(value);
        }

        /// <summary>
        /// Adds a byte array value
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        public void Add(string name, byte[] value)
        {
            if (value == null)
            {
                AddNoFormat(name, "NULL");
                return;
            }

            AddNoFormat(name, Utils.ByteArrayToString(value));
        }

        /// <summary>
        /// Adds a number column with value
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        public void Add(string name, int value)
        {
            AddNoFormat(name, value.ToString());
        }

        /// <summary>
        /// Adds a string column with value
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        public void Add(string name, string value)
        {
            AddNoFormat(name, $"N'{value}'");
        }

        /// <summary>
        /// Adds a datetime column with value
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        public void Add(string name, DateTime value)
        {
            AddNoFormat(name, "'" + value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");
        }
        
        /// <summary>
        /// Adds a reference to another object.
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        public void Add(string name, IDatabaseSerializableWithId value)
        {
            Add(name, value.GetId());
            MoreObjects.Add(value);
        }
        
        /// <summary>
        /// Adds an object to be serialized later.
        /// </summary>
        public void Add(IDatabaseSerializableWithId value)
        {
            MoreObjects.Add(value);
        }
    }
}
