using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class DatabaseManager
    {
        private SqlConnection objConnection;
        private SqlTransaction objTransaction;

        private string strConnectionString;
        private string strCommandName;
        private string strCurrentTransaction;

        private CommandType objCommandType;
        private SqlCommand sqlCommandObj;
        private SqlParameter[] objCommandParameters = null;

        private int returnCode;
        private int rowsAffected;
        private SqlParameter objReturnValue;

        private bool blnIsTransaction;
        private SqlDataReader sqlReader;

        /// <summary>
        /// Constructor for DatabaseManager
        /// <param name="strCommandName">Command Name</param> 
        /// </summary>
        public DatabaseManager(string strConnectionString)
        {
            try
            {
                this.strConnectionString = strConnectionString;
                if (objConnection == null)
                {
                    objConnection = new SqlConnection(this.strConnectionString);
                }
                if (sqlCommandObj == null)
                {
                    sqlCommandObj = new SqlCommand(strCommandName, objConnection);
                    sqlCommandObj.CommandType = objCommandType;
                }
                else
                {
                    sqlCommandObj.CommandText = strCommandName;
                }

            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        /// <value>CommandName accesses the value of the strCommandName data member</value>
        public string CommandName
        {
            set
            {
                strCommandName = value;
                sqlCommandObj.CommandText = value;
            }
        }

        public DataSet GetDataSet(int intCommandTimeOut)
        {
            DataSet ds = null;
            try
            {
                CheckConnection();

                if (sqlCommandObj.Parameters.Count > 0)
                {
                    objCommandParameters = new SqlParameter[sqlCommandObj.Parameters.Count];
                    sqlCommandObj.Parameters.CopyTo(objCommandParameters, 0);
                    sqlCommandObj.Parameters.Clear();
                }
                if (intCommandTimeOut > 0)
                {
                    SqlHelper.SetCommandTimeOut(intCommandTimeOut);
                }

                    ds = SqlHelper.ExecuteDataset(objConnection, objCommandType, strCommandName, objCommandParameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ds;
        }

        public int ExecuteCommand(int intCommandTimeOut)
        {
            try
            {
                CheckConnection();

                if (sqlCommandObj.Parameters.Count > 0)
                {
                    objCommandParameters = new SqlParameter[sqlCommandObj.Parameters.Count];
                    sqlCommandObj.Parameters.CopyTo(objCommandParameters, 0);
                    sqlCommandObj.Parameters.Clear();
                }
                if (intCommandTimeOut > 0)
                {
                    SqlHelper.SetCommandTimeOut(intCommandTimeOut);
                }

                rowsAffected = SqlHelper.ExecuteNonQuery(objConnection, objCommandType, strCommandName, objCommandParameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        private void CheckConnection()
        { 
            if (sqlReader != null)
                sqlReader = null;

            if (objConnection.State == ConnectionState.Closed)
                objConnection.Open(); 
        }
    }
}
