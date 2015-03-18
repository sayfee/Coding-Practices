using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DataLayer.Employee
{
    public class EmployeeBo
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public string Title {get; set;}
        public string Email {get; set;}
        public int JobId {get; set;}
        public int LocationId {get; set;}
        public int ContactId {get; set;}
        public string Location { get; set;}
        public string Phone { get; set; }
        public string Job { get; set; }

        public List<SelectListItem> LocationsList { get; set; }
    }
     
}
