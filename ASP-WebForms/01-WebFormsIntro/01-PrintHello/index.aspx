<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01_PrintHello.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBoxName" runat="server" ></asp:TextBox>
        <asp:Button ID="ButtonHello" runat="server" Text="Submit" OnClick="ButtonHello_Click" />
        <p>
            <asp:Label Text="Enter your name and press submit" runat="server" ID="LabelGreeting"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
