<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_04_StudentRegistration.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <section>
            <h3>Register Student:</h3>
            <div class="input-group">
                <asp:Label ID="LabelFirstName" runat="server" Text="First Name:"></asp:Label>
                <asp:TextBox Id="TextBoxFirstName" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <asp:Label ID="LabelLastName" runat="server" Text="Last Name:"></asp:Label>
                <asp:TextBox Id="TextBoxLastName" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <asp:Label ID="LabelFacultyNumber" runat="server" Text="Faculty Number:"></asp:Label>
                <asp:TextBox Id="TextBoxFacultyNumber" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <asp:Label ID="LabelUniversity" runat="server" Text="University:"></asp:Label>
                <asp:DropDownList Id="DropDownListUniversity" runat="server"></asp:DropDownList>
            </div>
            <div class="input-group">
                <asp:Label ID="LabelSpeciality" runat="server" Text="Speciality:"></asp:Label>
                <asp:DropDownList Id="DropDownListSpeciality" runat="server"></asp:DropDownList>
            </div>
            <div class="input-group">
                <asp:Label ID="Label1" runat="server" Text="Courses:"></asp:Label>
                <asp:ListBox Id="ListBoxCourses" SelectionMode="Multiple" runat="server"></asp:ListBox>
            </div>
            <br />
            <asp:Button ID="ButtonSubmit" Text="Register" runat="server" OnClick="ButtonSubmit_Click"  />
        </section>
        <section>
            <asp:Panel ID="PanelFeedBack" runat="server"></asp:Panel>
        </section>
    </div>
    </form>
</body>
</html>
