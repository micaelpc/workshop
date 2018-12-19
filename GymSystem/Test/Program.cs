using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Database;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database(@"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True");
        }
    }
}
