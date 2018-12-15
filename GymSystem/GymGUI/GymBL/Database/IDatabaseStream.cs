using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    public interface IDatabaseStream
    {
        void Add(string name, int value);
        void Add(string name, string value);
        void Add(string name, DateTime value);
        void Add(string name, IDatabaseSerializableWithId value);
        void Add(IDatabaseSerializable value);
    }
}
