<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication3.Admin" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>admin!</title>
</head>
<body>
    <form id="form1" runat="server">
        <%if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                Response.Redirect("game.aspx"); }
else { %>
      <table border="0" align="center">
       <tr>
           <td>
               username
              
           </td>

           <td><input type="text" name="fUserName" id="fUserName"/></td>
       </tr>

          
   </table>

    <br />

    <div style="text-align:center;">
       <button onclick="passUsername()" class="buttonStyle">change User Permission</button>
 </div>

  <%--  <br />--%>
   

     
      <div style="text-align:center;">
    <asp:Button ID="updatePremission" runat="server" OnClick="updateUserPermission" Text="change User Permission" CssClass="buttonStyle" style="display:none"/>

    </div>
     <br />

   <div style="text-align:center;">
     <asp:Button ID="showDbAsTableButton" runat="server" OnClick="showDbAsTable" Text="Show DB As Table"  CssClass="buttonStyle"/>

 </div>

  <br />

   <div style="text-align:center;">
     <asp:Button ID="showDbAsTextButton" runat="server" OnClick="showDbAsText" Text="Show DB As Text"  CssClass="buttonStyle"/>

 </div>
        <div style="text-align:center;">
            <br />
             <asp:Button ID="logout" runat="server" OnClick="Logout_Click" Text="logout" CssClass="buttonStyle"/>
        </div>

     <div>
     <asp:HiddenField ID="hdnfldUserName" runat="server" />
     </div>
       
        <%}%>
    </form>

    <script src="JavaScript-Admin.js"></script>
</body>
</html>