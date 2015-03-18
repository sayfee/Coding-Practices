using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataLayer.User
{
    public class UserDAC
    {
        protected DatabaseManager objDBManager = null;
        public UserDAC(DatabaseManager objDBM)
        {
            objDBManager = objDBM;
        }

        public DataTable GetAllUsers(int userID)
        {
            string SQLStatement = "SELECT * FROM [User]";

            if (userID > 0)
                SQLStatement += " WHERE ID = " + userID;
            
            objDBManager.CommandName = SQLStatement;
            return objDBManager.GetDataSet(10).Tables[0]; 
        }

        public int InsertUser(UserBO user)
        { 
            // Create INSERT statement with named parameters
            string SQLStatement = "INSERT INTO [dbo].[User] ([FirstName],[LastName],[Email],[Password])" +
            " VALUES ( '{0}', '{1}', '{2}', '{3}')";
 
            objDBManager.CommandName = String.Format(SQLStatement, user.FirstName, user.LastName, user.Email, user.Password);
 
            return objDBManager.ExecuteCommand(10);
        }

        public int DeleteUser(int ID)
        {
            // Create DELETE statement with named parameter
            string SQLStatement = "DELETE [dbo].[User] WHERE ID= '{0}'";

            objDBManager.CommandName = String.Format(SQLStatement, ID);

            return objDBManager.ExecuteCommand(10);
        }

        public int UpdateUser(UserBO user)
        {
            string SQLStatement = "UPDATE [dbo].[User] SET "
                + "[FirstName] = '{0}' , "
                + "[LastName]= '{1}' , "
                + "[Email]= '{2}', "
                + "[Password]= '{3}' "
                + " WHERE ID = {4}";

            objDBManager.CommandName = string.Format(SQLStatement, user.FirstName, user.LastName, user.Email, user.Password, user.ID);

            return objDBManager.ExecuteCommand(10);
        }
    }
}
