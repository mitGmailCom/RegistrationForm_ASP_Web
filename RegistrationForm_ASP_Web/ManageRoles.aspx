<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="RegistrationForm_ASP_Web.ManageRoles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton2" PostBackUrl="~/Default.aspx" runat="server">Default</asp:LinkButton>
        <br />
        <asp:HiddenField ID="HiddenFieldData" runat="server" />
        <asp:Table runat="server" class="class-table">
            <asp:TableRow ID="RowManage">
                <asp:TableCell ID="ColListBox">
                    <asp:ListBox ID="ListBoxRoles" Width="100" runat="server"></asp:ListBox>
                </asp:TableCell>
                <asp:TableCell ID="ColManage" CssClass="colManageClass" Width="200">
                    <asp:TextBox ID="TextBoxExAdd" CssClass="colManageClass" Visible="false" runat="server" Width="196" Enabled="false" ></asp:TextBox>
                    <asp:Button ID="btnExecute" CssClass="colManageClass" Visible="false" runat="server" OnClick="btnExecute_Click" Text="Добавить" Width="100" Enabled="false" />
                    <asp:TextBox ID="TextBoxExEdit" Visible="false" runat="server" Enabled="false" Width="196" ></asp:TextBox>
                    <asp:Button ID="btnExecuteEdit" Visible="false" runat="server" OnClick="btnExecuteEdit_Click" Width="100" Text="Изменить" Enabled="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnAdd" runat="server" OnClick="Add_Click" Width="100" Text="Add" EnableViewState="True" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnEdit" runat="server" OnClick="Edit_Click" Width="100" Text="Edit" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="Delete_Click" Width="100" Text="Delete" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
    </div>
    </form>
</body>
</html>
