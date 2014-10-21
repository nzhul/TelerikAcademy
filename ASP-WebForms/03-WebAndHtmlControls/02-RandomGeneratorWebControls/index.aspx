<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_02_RandomGeneratorWebControls.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Generate Random Number in the range:</p>
        <label>From: </label>
        <asp:TextBox ID="TextBoxFrom" runat="server"></asp:TextBox>
        <br />
        <label>To: </label>
        <asp:TextBox ID="TextBoxTo" runat="server"></asp:TextBox>
        <br />
        <hr />
        <asp:Button ID="ButtonGenerate" runat="server" Text="Generate Random Number" OnClick="ButtonGenerate_Click" />
        <asp:Label runat="server" ID="LabelRandomNumberResult"></asp:Label>
    </div>
    </form>
</body>
</html>
