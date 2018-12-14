using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    class Gym
    {
        class Equipment
        {
            Equipment(string description) {
                this.Description = description;
            }

            public string Description { get; private set; }
        }
    }
}
