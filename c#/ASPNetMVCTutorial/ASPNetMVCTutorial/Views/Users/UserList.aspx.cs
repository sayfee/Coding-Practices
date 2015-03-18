using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EmployeeDirectory.Utilities;
using System.Data;
using System.Text;

namespace EmployeeDirectory.Views.Users
{
    public class UserList : System.Web.Mvc.ViewPage
    {
        protected Literal litUserDetail;
        protected HyperLink linkAddUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            linkAddUser.NavigateUrl =
                ApplicationUtility.FormatURL("/Users/AddUser");

            

            DataTable UsersTable = (DataTable)ViewData["Users"];
            DataView UsersView = UsersTable.DefaultView;
            UsersView.Sort = "ID Desc";

            StringBuilder SB = new StringBuilder();

            SB.Append("<table style=\"width: 99%;\" ");
            SB.Append("rules=\"all\" border=\"1px\" ");
            SB.Append("cellspacing=\"0px\" cellpadding=\"4px\">");

            SB.Append("<tr style=\"background-color: Silver; color: white; ");
            SB.Append("font-weight: bold\">");
            foreach (DataColumn aColumn in UsersTable.Columns)
            {
                SB.Append("<td>");
                SB.Append(aColumn.ColumnName);
                SB.Append("</td>");
            }
            SB.Append("<td>&nbsp;</td>");
            SB.Append("</tr>");

            foreach (DataRowView aRowView in UsersView)
            {
                SB.Append("<tr>");
                foreach (DataColumn aColumn in UsersTable.Columns)
                {
                    SB.Append("<td>");
                    SB.Append(aRowView[aColumn.ColumnName].ToString());
                    SB.Append("</td>");
                }

                string ID = aRowView["ID"].ToString();
                SB.Append("<td>");
                SB.Append("<a href=\"");
                SB.Append(ApplicationUtility.FormatURL("/Users/DeleteUser"));
                SB.Append("?ID=");
                SB.Append(ID);
                SB.Append("\">Delete this User</a>");
                SB.Append("</td>");
                SB.Append("</tr>");
            }

            SB.Append("</table>");

            litUserDetail.Text = SB.ToString();
        }
    }
}