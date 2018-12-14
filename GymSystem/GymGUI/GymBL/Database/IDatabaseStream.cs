using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    interface IDatabaseStream
    {
        void Add(string name, int value);
        void Add(string name, string value);
        void Add(string name, DateTime value);
    }
}
