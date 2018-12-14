using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    interface DatabaseSerializable
    {
        string getDatabaseName();
        void serialize(IDatabaseStream stream);
        void load(DataRow row);
    }
}
