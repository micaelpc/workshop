using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    interface IDatabaseStream
    {
        void add(string name, int value);
        void add(string name, string value);
        void add(string name, DateTime value);
    }
}
