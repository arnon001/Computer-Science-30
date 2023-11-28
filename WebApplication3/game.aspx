<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="game.aspx.cs" Inherits="WebApplication3.game" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Game</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button runat="server" OnClick="btnLogout_Click" ID="Logout" Text="Logout" />
        <%if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"]) { }
            else
            { %>
        <br />
        <br />
        <asp:Button runat="server" OnClick="btnAdmin_Click" ID="adminPage" Text="To Admin Page" />
        <%} %>
</form>
</body>
</html>