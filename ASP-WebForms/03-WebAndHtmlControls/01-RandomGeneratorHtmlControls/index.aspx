<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01_RandomGeneratorHtmlControls.index" %>

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
        <input type="text" runat="server" id="TextBoxFrom" />
        <br />
        <label>To: </label>
        <input type="text" runat="server" id="TextBoxTo" />
        <br />
        <hr />
        <button id="ButtonGenerate" runat="server" onserverclick="ButtonGenerate_ServerClick">Generate Random Number</button>
        <label id="LabelRandomNumberResult" runat="server"></label>
    </div>
    </form>
</body>
</html>
