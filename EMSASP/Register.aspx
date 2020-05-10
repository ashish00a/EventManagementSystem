<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EMSASP.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <asp:TextBox ID="Textname" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Textname"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="Textgender" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Textgender"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="Textmobile" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Textmobile"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="Textemail" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Textemail"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="Textutype" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Textutype"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="Textuname" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Textuname"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="Textpass" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Textpass"></asp:RequiredFieldValidator><br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Register" />

        </div>
    </form>
</body>
</html>
