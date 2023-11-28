<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication3.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <asp:Button ID="login" OnClick="login_Click" runat="server" Text="Login" />
    <br />
            <asp:Button ID="register" runat="server" OnClick="register_Click" Text="Register" />
        <br />
        <br />
        <asp:Button ID="dontTouch" runat="server" OnClick="dontTouch_Click" Text="Do Not Touch!" />
        
    </form>
</body>
</html>
