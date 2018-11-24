using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace VolunteerManagementDAL
{
    /// <summary>
    /// this class provides the system`s classes various db actions 
    /// and handles the actual execution of the operation in the db
    /// </summary>
    public class DBActions
    {
        /// <summary>
        /// this method executes a query that doesn`t alter the db data
        /// and retunrs one or many data rows
        /// </summary>
        /// <param name="sqlString">the select query</param>
        /// <param name="connection">the db connection for the operation</param>
        /// <returns>this datatable is the result of the query</returns>
        public static DataTable ExecuteQuery(string sqlString, DBConnection connection)
        {
            OleDbCommand command = new OleDbCommand(sqlString,connection.Connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable result = new DataTable();
            try
            {
                adapter.Fill(result);
            }
            catch (Exception e)
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// this method executes a query that alters the db data such
        /// as update or delete
        /// </summary>
        /// <param name="sqlString">the execution command</param>
        /// <param name="connection">the db connection for the operation</param>
        /// <returns>the number of rows affected</returns>
        public static int ExecuteNonQuery(string sqlString, DBConnection connection)
        {
            OleDbCommand command = new OleDbCommand(sqlString, connection.Connection);
            int result = -1;
            try
            {
                result = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return -1;
            }
            return result;
        }

        /// <summary>
        /// this method executes a query that doesn`t alter the db data
        /// and returns only one data object
        /// </summary>
        /// <param name="sqlString">the select query</param>
        /// <param name="connection">the db connection for the operation</param>
        /// <returns>this object is the result of the query</returns>
        public static object ExecuteScalar(string sqlString, DBConnection connection)
        {
            OleDbCommand command = new OleDbCommand(sqlString, connection.Connection);
            object result = null;
            try
            {
                result = command.ExecuteScalar();
            }
            catch (Exception e)
            {
                return null;
            }
            return result;
        }
    }
}
