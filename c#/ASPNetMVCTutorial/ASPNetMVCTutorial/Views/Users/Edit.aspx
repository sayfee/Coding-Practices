<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DataLayer.User.UserBO>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ApplicationContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <table>
            <tr>
                <td>
                        <%: Html.HiddenFor(model => model.ID) %>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.FirstName) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.FirstName) %>
                        <%: Html.ValidationMessageFor(model => model.FirstName) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.LastName) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.LastName) %>
                        <%: Html.ValidationMessageFor(model => model.LastName) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Email) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Email) %>
                        <%: Html.ValidationMessageFor(model => model.Email) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Password) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Password) %>
                        <%: Html.ValidationMessageFor(model => model.Password) %>
                    </div>
                </td>
            </tr>
        </table>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "") %>
    </div>
</asp:Content>
