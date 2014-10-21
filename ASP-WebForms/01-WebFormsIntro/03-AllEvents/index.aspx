<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_03_AllEvents.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="ButtonDump" 
            runat="server" 
            Text="Dump" 
            OnClick="ButtonDump_Click" 
            OnInit="ButtonDump_Init" 
            OnLoad="ButtonDump_Load" 
            OnPreRender="ButtonDump_PreRender" />
    </div>
    </form>
</body>
</html>
