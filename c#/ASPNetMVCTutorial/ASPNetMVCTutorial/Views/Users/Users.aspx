<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<DataLayer.User.UserBO>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ApplicationContent" runat="server">

    <h2>Users</h2>

    <table align="center">
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                Email
            </th>
            <th>
                Password
            </th>
        </tr>

    <% foreach (var item in Model)  
       { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new {   id=item.ID }) %> |
                <%: Html.ActionLink("Details", "Details", new {   id=item.ID })%> |
                <%: Html.ActionLink("Delete", "DeleteUser", new {  id=item.ID })%>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.FirstName %>
            </td>
            <td>
                <%: item.LastName %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.Password %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "AddUser") %>
    </p>

</asp:Content>

