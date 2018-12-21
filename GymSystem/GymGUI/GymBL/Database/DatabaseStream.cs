using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    class DatabaseStream : IDatabaseStream
    {
        public List<string> Values { get ; set; } = new List<string>();
        public List<string> Columns { get; set; } = new List<string>();
        public List<IDatabaseSerializable> MoreObjects { get; set; } = new List<IDatabaseSerializable>();

        public void AddNoFormat(string name, string value)
        {
            Columns.Add(name);
            Values.Add(value);
        }

        public void Add(string name, int value)
        {
            AddNoFormat(name, value.ToString());
        }

        public void Add(string name, string value)
        {
            AddNoFormat(name, $"N'{value}'");
        }

        public void Add(string name, DateTime value)
        {
            AddNoFormat(name, "'" + value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");
        }

        public void Add(string name, IDatabaseSerializableWithId value)
        {
            Add(name, value.GetId());
            MoreObjects.Add(value);
        }

        public void Add(IDatabaseSerializable value)
        {
            MoreObjects.Add(value);
        }
    }
}
