using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataLayer.Employee
{
    public class EmployeeDAC
    {
        protected DatabaseManager objDBManager = null;
        public EmployeeDAC(DatabaseManager objDBM)
        {
            objDBManager = objDBM;
        }

        public DataTable GetAll(int ID)
        {
            string SQLStatement = "SELECT E.ID, E.Name, E.ContactId, E.Email, E.JobId, "
                + " J.JobName Job, E.LocationId, L.LocationName Location,"
                + " C.Phone, e.Title FROM [Employee] E "
                + " JOIN Jobs J ON J.ID = E.JobId "
                + " JOIN Contacts C ON C.ID = E.ContactId  AND C.IsPreffered = 1 "
                + " JOIN Locations L ON L.ID = E.LocationId";
            

            if (ID > 0)
                SQLStatement += " WHERE E.ID = " + ID;
            
            objDBManager.CommandName = SQLStatement;
            return objDBManager.GetDataSet(10).Tables[0]; 
        }

        public int Insert(EmployeeBo employee)
        { 
            // Create INSERT statement with named parameters
            string SQLStatement = "INSERT INTO [dbo].[Employee] ([Name],[Title],[Email],[JobId], [LocationId], [ContactId])" +
            " VALUES ( '{0}', '{1}', '{2}', {3}, {4}, {5})";
 
            objDBManager.CommandName = String.Format(SQLStatement, 
                employee.Name, employee.Title, employee.Email, employee.JobId, employee.LocationId, employee.ContactId);
 
            return objDBManager.ExecuteCommand(10);
        }

        public int Delete(int ID)
        {
            // Create DELETE statement with named parameter
            string SQLStatement = "DELETE [dbo].[Employee] WHERE ID= '{0}'";

            objDBManager.CommandName = String.Format(SQLStatement, ID);

            return objDBManager.ExecuteCommand(10);
        }

        public int Update(EmployeeBo employee)
        {
            string SQLStatement = "UPDATE [dbo].[User] SET "
                + "[Name] = '{0}' , "
                + "[Title]= '{1}' , "
                + "[Email]= '{2}', "
                + "[JobId]= {3} ,"
                + "[LocationId]= {4} ,"
                + "[ContactId]= {5} "
                + " WHERE ID = {6}";

            objDBManager.CommandName = String.Format(SQLStatement,
                employee.Name, employee.Title, employee.Email, employee.JobId, employee.LocationId, 
                employee.ContactId, employee.ID);
           

            return objDBManager.ExecuteCommand(10);
        }

        public DataTable GetLocations(int ID)
        {
            string SQLStatement = "SELECT * FROM [Locations]";

            if (ID > 0)
                SQLStatement += " WHERE ID = " + ID;

            objDBManager.CommandName = SQLStatement;
            return objDBManager.GetDataSet(10).Tables[0];
        }

        public DataTable GetContacts(int EmployeeID)
        {
            string SQLStatement = "SELECT * FROM [Employee]";

            if (EmployeeID > 0)
                SQLStatement += " WHERE ID = " + EmployeeID;

            objDBManager.CommandName = SQLStatement;
            return objDBManager.GetDataSet(10).Tables[0];
        }


        public DataTable GetLocations()
        {
            string SQLStatement = "SELECT * FROM [Locations]";
             
            objDBManager.CommandName = SQLStatement;
            return objDBManager.GetDataSet(10).Tables[0];
        }
    }
}
