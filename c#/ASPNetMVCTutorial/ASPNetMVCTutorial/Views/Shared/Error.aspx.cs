using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EmployeeDirectory.Models;
using EmployeeDirectory.Utilities;

namespace EmployeeDirectory.Views.Shared
{
    public class Error : System.Web.Mvc.ViewPage
    {
        protected Literal litErrorMessage;
        protected HyperLink linkBackToMainPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            linkBackToMainPage.NavigateUrl
                = ApplicationUtility.FormatURL("/Users/UserList");
            string ErrorMessage = ViewData["ERROR"].ToString();
            litErrorMessage.Text = ErrorMessage;
        }
    }
}