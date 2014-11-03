<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_05.Calculator.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <style>
        form {
            width: 300px;
            height: auto;
        }

        #TextBoxInput {
            text-align: right;
        }

        .row {
            margin: 10px;
            text-align: center;
        }

        .region {
            border: 1px solid black;
        }

        input {
            min-width: 20px;
            min-height: 25px;
            font-size: 26px;
            margin: 5px;
            vertical-align: middle;
        }

        #TextBoxInput {
            width: 170px;
        }
    </style>
</head>
<body>
    <h3>Welcome to this ovesimplified calculator. Use Clear in order to reset the calculator. Have a nice day. Use the windows calculator for better results.</h3>
    <form id="form1" runat="server">
        <div class="row region">
            <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
            <asp:HiddenField ID="HiddenFieldFirstOperand" runat="server" />
            <asp:HiddenField ID="HiddenFieldOperator" runat="server" />
        </div>

        <div class="region">
            <div class="row">
                <asp:Button ID="Button1" runat="server" Text="1" OnCommand="Button_Command"
                    CommandArgument="1" />
                <asp:Button ID="Button2" runat="server" Text="2" OnCommand="Button_Command"
                    CommandArgument="2" />
                <asp:Button ID="Button3" runat="server" Text="3" OnCommand="Button_Command"
                    CommandArgument="3" />
                <asp:Button ID="ButtonPlus" runat="server" Text="+" OnCommand="Button_Command"
                    CommandName="add" />
            </div>

            <div class="row">
                <asp:Button ID="Button4" runat="server" Text="4" OnCommand="Button_Command"
                    CommandArgument="4" />
                <asp:Button ID="Button5" runat="server" Text="5" OnCommand="Button_Command"
                    CommandArgument="5" />
                <asp:Button ID="Button6" runat="server" Text="6" OnCommand="Button_Command"
                    CommandArgument="6" />
                <asp:Button ID="ButtonMinus" runat="server" Text="-" OnCommand="Button_Command"
                    CommandName="subtract" />
            </div>

            <div class="row">
                <asp:Button ID="Button7" runat="server" Text="7" OnCommand="Button_Command"
                    CommandArgument="7" />
                <asp:Button ID="Button8" runat="server" Text="8" OnCommand="Button_Command"
                    CommandArgument="8" />
                <asp:Button ID="Button9" runat="server" Text="9" OnCommand="Button_Command"
                    CommandArgument="9" />
                <asp:Button ID="ButtonMultiply" runat="server" Text="X" OnCommand="Button_Command"
                    CommandName="multiply" />
            </div>

            <div class="row">
                <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnCommand="Button_Command"
                    CommandName="clear" />
                <asp:Button ID="Button0" runat="server" Text="0" OnCommand="Button_Command"
                    CommandArgument="0" />
                <asp:Button ID="ButtonDivide" runat="server" Text="/" OnCommand="Button_Command"
                    CommandName="divide" />
                <asp:Button ID="ButtonSquareRoot" runat="server" Text="&radic;" OnCommand="Button_Command"
                    CommandName="squareRoot" />
            </div>
        </div>

        <div class="row region">
            <asp:Button ID="ButtonEquals" runat="server" Text="=" Height="23px" Width="101px"
                 OnCommand="Button_Command" CommandName="equals" />
        </div>

        <div>
            <asp:Label ID="LabelFeedback" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>