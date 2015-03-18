<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Views/Shared/Site.Master"
    CodeBehind="~/Views/Users/UserList.aspx.cs"
    Inherits="EmployeeDirectory.Views.Users.UserList" %>

<asp:Content id="IndexContent" ContentPlaceHolderID="ApplicationContent" runat="server">
    <form id="form1" runat="server">
    <div style="float: right; margin-right: 10px">
        <asp:HyperLink id="linkAddUser" runat="server" 
        Text="Click to add a user to the list" />
    </div>

    <asp:GridView ID="gwUsers" runat="server">
    </asp:GridView>
    
    <br />
    <div style="margin-top: 5px">
        <asp:Literal id="litUserDetail" runat="server" />
    </div>
    </form>
</asp:Content>