<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DataLayer.Employee.EmployeeBo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ApplicationContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                Name
            </th>
            <th>
                Title
            </th>
            <th>
                Email
            </th>
            <th>
                JobId
            </th>
            <th>
                LocationId
            </th>
            <th>
                ContactId
            </th>
            <th>
                Location
            </th>
            <th>
                Phone
            </th>
            <th>
                Job
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.JobId %>
            </td>
            <td>
                <%: item.LocationId %>
            </td>
            <td>
                <%: item.ContactId %>
            </td>
            <td>
                <%: item.Location %>
            </td>
            <td>
                <%: item.Phone %>
            </td>
            <td>
                <%: item.Job %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

