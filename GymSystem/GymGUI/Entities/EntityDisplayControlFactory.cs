using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementGUI.Entities
{
    /// <summary>
    /// this class is a factory for entity display controls. 
    /// the factory creates an entity display control from 
    /// according to the requested entity type and then returns it to
    /// the entity window
    /// </summary>
    public class EntityDisplayControlFactory
    {
        /// <summary>
        /// this enum defines all of the entity types in the system
        /// </summary>
        public enum DisplayControlTypeEnum
        {
            Volunteer,
            Activity,
            ActivityType,
            User,
            Reminder
        }

        /// <summary>
        /// this is the factory method that creates a new entity display control
        /// according to the requested entity type. 
        /// </summary>
        /// <param name="controlType">the requested entity type</param>
        /// <returns>the new entity display control</returns>
        public static IGeneralEntityDisplayControl CreateDisplayControl(DisplayControlTypeEnum controlType)
        {
            switch (controlType)
            {
                case DisplayControlTypeEnum.Volunteer:
                    return new VolunteerDisplayControl();
                case DisplayControlTypeEnum.Activity:
                    return new ActivityDisplayControl();
                case DisplayControlTypeEnum.ActivityType:
                    return new ActivityTypeDisplayControl();
                case DisplayControlTypeEnum.User:
                    return new UserDisplayControl();
                case DisplayControlTypeEnum.Reminder:
                    return new ReminderDisplayControl();
            }
            throw new Exception("The display control type " + controlType + " is not recognized.");
        }
    }
}
