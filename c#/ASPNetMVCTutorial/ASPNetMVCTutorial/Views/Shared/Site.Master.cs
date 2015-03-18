using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Views.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationInformation appInfomation = ApplicationInformation.GetInstance();
            litAppTitle.Text = appInfomation.ApplicationName;
            litApplicationName.Text = appInfomation.ApplicationName;


        }
    }
}