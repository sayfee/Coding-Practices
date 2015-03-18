<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<DataLayer.Employee.EmployeeBo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ApplicationContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ID) %>
                <%: Html.ValidationMessageFor(model => model.ID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.JobId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.JobId) %>
                <%: Html.ValidationMessageFor(model => model.JobId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LocationId) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.LocationId, new SelectList(Model.LocationsList, "Value", "Text"), "Select...")%>
                <%: Html.ValidationMessageFor(model => model.LocationId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ContactId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ContactId) %>
                <%: Html.ValidationMessageFor(model => model.ContactId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Location) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Location) %>
                <%: Html.ValidationMessageFor(model => model.Location) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Phone) %>
                <%: Html.ValidationMessageFor(model => model.Phone) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Job) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Job) %>
                <%: Html.ValidationMessageFor(model => model.Job) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

