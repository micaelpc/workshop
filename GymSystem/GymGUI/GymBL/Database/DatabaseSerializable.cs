using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    interface DatabaseSerializable
    {
        string GetDatabaseName();
        void Serialize(IDatabaseStream stream);
        void Load(DataRow row);
    }
}
