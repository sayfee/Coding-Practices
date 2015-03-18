using System;
using System.Data;
using DataLayer.User;
using DataLayer;
using System.Web.Configuration;
using System.Configuration;
using System.Collections.Generic;

namespace EmployeeDirectory.Models
{
    public class UsersModel
    {
        private DataTable User;
        private DatabaseManager dm;
        private UserDAC userDAC;

        public UsersModel()
        {
            Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/EmployeeDirectory");
            const string CONSTRINGNAME = "EmployeeDirectory";
            ConnectionStringSettings conString = rootWebConfig.ConnectionStrings.ConnectionStrings[CONSTRINGNAME];
            
            string  connectionString="Data Source=MISLPT040\\SQL2014;Initial Catalog=EmployeeDirectory;Integrated Security=True" ;

            dm = new DatabaseManager(connectionString);            
            userDAC = new UserDAC(dm);

        }

        public int AddUser(UserBO user)
        {
            return userDAC.InsertUser(user);
        }

        public int DeleteUser(int ID)
        {
            return userDAC.DeleteUser(ID);
        }

        public DataTable GetUserDataTable()
        {
            return userDAC.GetAllUsers(0);
        }

        public List<UserBO> GetUsers(int userId)
        {
            DataTable dt = userDAC.GetAllUsers(userId);

            List<UserBO> listBO = new List<UserBO>();
            foreach (DataRow dr in dt.Rows)
            {
                UserBO bo = new UserBO();
                if (!Convert.IsDBNull(dr["ID"]))
                    bo.ID = Convert.ToInt32(dr["ID"].ToString());
                if (!Convert.IsDBNull(dr["FirstName"]))
                    bo.FirstName = dr["FirstName"].ToString();
                if (!Convert.IsDBNull(dr["LastName"]))
                    bo.LastName = dr["LastName"].ToString();
                if (!Convert.IsDBNull(dr["Email"]))
                    bo.Email = dr["Email"].ToString();
                if (!Convert.IsDBNull(dr["Password"]))
                    bo.Password = dr["Password"].ToString();

                listBO.Add(bo);
            }

            return listBO;
        }

        public int Update(UserBO user)
        {
            return userDAC.UpdateUser(user);
        }
    }
}