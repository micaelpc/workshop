using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GymBL.Database
{
    public interface IDatabaseSerializableWithId : IDatabaseSerializable
    {
        string GetId();
    }
}
