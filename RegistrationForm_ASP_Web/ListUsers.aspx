﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="RegistrationForm_ASP_Web.ListUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheetRegistrationForm.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="list-users">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="tableRow_0">
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListUsers" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxListUsers_SelectedIndexChanged" runat="server" ></asp:CheckBoxList>
                </asp:TableCell>
                 <asp:TableCell ID="tableRow_0Col_2">
                     <div class="class-buel-list">
                        <asp:BulletedList BulletStyle="NotSet" DisplayMode="LinkButton" ID="BulletedList1" 
                            OnClick="BulletedList1_Click" runat="server"></asp:BulletedList>
                     </div>
                 </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="btnDelUsers" runat="server" Width="150" Text="Удалить" Enabled="false" OnClick="DelUsers_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnToPageManageRole" runat="server" Width="150" PostBackUrl="~/ManageRoles.aspx" Text="Управление Ролями" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnLinkToRegistrFromListUsers" runat="server" Width="150" Text="Перейти к Регистрации" PostBackUrl="~/Default.aspx" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
     </div>
    </form>
</body>
</html>
