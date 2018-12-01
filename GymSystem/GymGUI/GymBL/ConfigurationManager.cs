using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace GymBL
{
    /// <summary>
    /// this class reads the system configuration file and
    /// stores it`s diffrent values for the use of the other 
    /// classes in the system
    /// </summary>
    public class ConfigurationManager
    {
        /// <summary>
        /// this table stores the config values
        /// </summary>
        static private Hashtable m_ConfigMap;

        /// <summary>
        /// this loads the diffrent keys and values to the 
        /// config table
        /// </summary>
        static public void LoadConfigurationFile()
        {
            m_ConfigMap = new Hashtable();
            StreamReader configStream = File.OpenText(Directory.GetCurrentDirectory() + @"\VMSConfig.txt");
            string currentLine = configStream.ReadLine();
            while (currentLine != null)
            {
                string[] configFields = currentLine.Split(';');
                string name = configFields[0];
                string value = configFields[1];
                m_ConfigMap.Add(name,value);
                currentLine = configStream.ReadLine();
            }
        }

        /// <summary>
        /// this method gets a value from the config table
        /// according to a given key
        /// </summary>
        /// <param name="configValueKeyName">the config key</param>
        /// <returns>the config value</returns>
        static public string GetConfigValue(string configValueKeyName)
        {
            if (m_ConfigMap.Contains(configValueKeyName))
                return m_ConfigMap[configValueKeyName].ToString();
            else return "";
        }
    }
}
