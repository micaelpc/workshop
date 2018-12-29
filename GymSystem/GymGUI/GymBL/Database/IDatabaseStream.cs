using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    /// <summary>
    /// The interface for database stream. Helper class for serializing objects
    /// to the database
    /// </summary>
    public interface IDatabaseStream
    {

        /// <summary>
        /// Adds a integer column with value.
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        void Add(string name, int value);

        /// <summary>
        /// Adds a string column with value.
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        void Add(string name, string value);

        /// <summary>
        /// Adds a datetime column with value.
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        void Add(string name, DateTime value);

        /// <summary>
        /// Adds a byte array column with value.
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        void Add(string name, byte[] value);


        /// <summary>
        /// Adds a reference column with value.
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        void Add(string name, IDatabaseSerializableWithId value);

        /// <summary>
        /// Adds an object to be serialized later.wq
        /// </summary>
        /// <param name="name">The column name</param>
        /// <param name="value">The value</param>
        void Add(IDatabaseSerializableWithId value);
    }
}
