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

        public void add(string name, int value)
        {
            add(name, value.ToString());
        }

        public void add(string name, string value)
        {
            Columns.Add(name);
            Values.Add(value);
        }

        public void add(string name, DateTime value)
        {
            add(name, value.ToString());
        }
    }
}
