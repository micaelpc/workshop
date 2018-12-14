using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementGUI.Entities
{
    /// <summary>
    /// this interface defines all the common methods for an entity display control
    /// </summary>
    public interface IGeneralEntityDisplayControl
    {
        /// <summary>
        /// this method deletes the entity from the system
        /// </summary>
        /// <returns>true if success else false</returns>
        bool DeleteEntity();

        /// <summary>
        /// this methods adds a new entity to the system
        /// </summary>
        /// <returns>true if success else false</returns>
        bool AddEntity();

        /// <summary>
        /// this method updates the current entity data
        /// </summary>
        /// <returns>true if success else false</returns>
        bool UpdateEntity();

        /// <summary>
        /// this method changes the update mode of the entity.
        /// an entity in update mode can be saved to the db and
        /// it`s data can be changed. otherwise the entity data is
        /// readonly
        /// </summary>
        /// <param name="updateState">the desired update mode - true for update mode</param>
        void SetUpdateState(bool updateState);

        /// <summary>
        /// this method loads an entity data from the db into
        /// the control display controls
        /// </summary>
        /// <param name="entityID">the requested entity id</param>
        /// <returns>true if success else false</returns>
        bool LoadEntity(object entityID);

        /// <summary>
        /// this entity gets the entity name for the form caption
        /// </summary>
        /// <returns>the current entity name</returns>
        string GetEntityName();

        /// <summary>
        /// this method checks if the entity is in update mode
        /// </summary>
        /// <returns>true if in update mode, else false</returns>
        bool IsUpdateable();
    }
}
