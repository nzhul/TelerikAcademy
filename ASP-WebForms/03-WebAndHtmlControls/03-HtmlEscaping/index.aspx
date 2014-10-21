<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_03_HtmlEscaping.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Enter your text:</h3>
        <asp:TextBox TextMode="multiline" Columns="30" Rows="5" ID="TextBoxInput" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonDisplay" runat="server" Text="Display" OnClick="ButtonDisplay_Click" />
        <br />
        <hr />
        <h3>Result:</h3>
        <asp:TextBox TextMode="multiline" ReadOnly="true" Columns="30" Rows="5" ID="TextBoxResult" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
