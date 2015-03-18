using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.Data;
using DataLayer.Employee;
using System.Web.Mvc;

namespace ASPNetMVCTutorial.Models
{
    public class EmployeeModel
    {
        private DatabaseManager dm;
        private EmployeeDAC DAC;

        public EmployeeModel()
        {
            string connectionString = "Data Source=MISLPT040\\SQL2014;Initial Catalog=EmployeeDirectory;Integrated Security=True";

            dm = new DatabaseManager(connectionString);
            DAC = new EmployeeDAC(dm);
        }

        public List<EmployeeBo> GetUsers(int Id)
        {
            DataTable dt = DAC.GetAll(Id);

            List<EmployeeBo> listBO = new List<EmployeeBo>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeBo bo = new EmployeeBo();
                if (!Convert.IsDBNull(dr["ID"]))
                    bo.ID = Convert.ToInt32(dr["ID"].ToString());
                if (!Convert.IsDBNull(dr["Name"]))
                    bo.Name = dr["Name"].ToString();
                if (!Convert.IsDBNull(dr["ContactId"]))
                    bo.ContactId = Convert.ToInt32(dr["ContactId"]);
                if (!Convert.IsDBNull(dr["Email"]))
                    bo.Email = dr["Email"].ToString();
                if (!Convert.IsDBNull(dr["Job"]))
                    bo.Job = dr["Job"].ToString();
                if (!Convert.IsDBNull(dr["JobId"]))
                    bo.JobId = Convert.ToInt32(dr["JobId"]);
                if (!Convert.IsDBNull(dr["Location"]))
                    bo.Location = dr["Location"].ToString();
                if (!Convert.IsDBNull(dr["LocationId"]))
                    bo.LocationId = Convert.ToInt32(dr["LocationId"]);
                if (!Convert.IsDBNull(dr["Phone"]))
                    bo.Phone = dr["Phone"].ToString();
                if (!Convert.IsDBNull(dr["Title"]))
                    bo.Title = dr["Title"].ToString();

                listBO.Add(bo);
            }

            return listBO;
        }
         
        public List<SelectListItem> GetLocations()
        {
            DataTable dt = DAC.GetLocations();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow dr in dt.Rows)
            { 
                string id = dr["ID"].ToString();
                string name = dr["LocationName"].ToString();
                list.Add(new SelectListItem() { Value = id, Text = name });
            }

            return list;
        }
    }
}