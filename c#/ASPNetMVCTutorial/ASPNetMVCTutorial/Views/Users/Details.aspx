<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DataLayer.User.UserBO>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ApplicationContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <table>
            <tr>
                <td>
                    <div class="display-label">
                        ID</div>
                </td>
                <td>
                    <div class="display-field">
                        <%: Model.ID %></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="display-label">
                        FirstName</div>
                </td>
                <td>
                    <div class="display-field">
                        <%: Model.FirstName %></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="display-label">
                        LastName</div>
                </td>
                <td>
                    <div class="display-field">
                        <%: Model.LastName %></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="display-label">
                        Email</div>
                </td>
                <td>
                    <div class="display-field">
                        <%: Model.Email %></div>
                    <div class="display-field">
                        <%: Model.LastName %></div>
                </td>
            </tr>
        </table>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new {  id=Model.ID  }) %>
        |
        <%: Html.ActionLink("Back to List", "") %>
    </p>
</asp:Content>
