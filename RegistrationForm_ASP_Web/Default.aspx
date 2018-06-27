<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegistrationForm_ASP_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheetRegistrationForm.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainDiv">
            <div class="link-list-users">
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/ListUsers.aspx" runat="server">Список пользователей</asp:HyperLink>
            </div>
            <br /><br />

            <asp:Label class="labelRegistrForm" ID="lblFirstnameUser" runat="server" Text="Имя"></asp:Label>
            <asp:TextBox class="txb-registr-new-user" ID="txbFirstnameUser" Text="Иван" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="X" ControlToValidate="txbFirstnameUser" Display="Static" ErrorMessage="Введите Имя"></asp:RequiredFieldValidator>

            <br /><br />
            <asp:Label class="labelRegistrForm" ID="lblLastnameUser" runat="server" Text="Фамилия"></asp:Label>
            <asp:TextBox class="txb-registr-new-user" ID="txbLastnameUser" runat="server" Text="Иванов"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Text="X" ControlToValidate="txbLastnameUser" Display="Static" ErrorMessage="Введите Фамилию"></asp:RequiredFieldValidator>
            <br /><br />
            
            <asp:Label class="labelRegistrForm" ID="lblCityUser" runat="server" Text="Город"></asp:Label>
            <asp:TextBox class="txb-registr-new-user" ID="txbCityUser" runat="server" Text="Киев"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Text="X" ControlToValidate="txbCityUser" Display="Static" ErrorMessage="Введите Город"></asp:RequiredFieldValidator>
            <br /><br />

            <asp:Label class="labelRegistrForm" ID="lblEmailUser" runat="server" Text="Email"></asp:Label>
            <asp:TextBox class="txb-registr-new-user" ID="txbEmailUser" runat="server" Text="ivanovivan@gmail.com"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" Text="X" ControlToValidate="txbEmailUser" Display="Static" ErrorMessage="Введите Email"></asp:RequiredFieldValidator>
            <br /><br />

            <asp:Label class="labelRegistrForm" ID="lblbPasswordUser" runat="server" Text="Пароль"></asp:Label>
            <asp:TextBox class="labelRegistrForm" ID="txbPasswordUser" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" Text="X" ControlToValidate="txbPasswordUser" Display="Static" ErrorMessage="Введите Пароль"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\w{6,16}" runat="server" ControlToValidate="txbPasswordUser" ErrorMessage="Пароль должен состоять от 8 до 16 символов"></asp:RegularExpressionValidator>
            <br /><br />

            <asp:Label class="labelRegistrForm" ID="lblConfirmPassword" runat="server" Text="Повторить пароль"></asp:Label>
            <asp:TextBox class="labelRegistrForm" ID="txbConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" Text="X" ControlToValidate="txbConfirmPassword" Display="Static" ErrorMessage="Введите Пароль"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txbConfirmPassword" ControlToCompare="txbPasswordUser" runat="server" ErrorMessage="Пароли не совпадают"></asp:CompareValidator>
            <br /><br /><br /> 

            <asp:Label class="labelRegistrForm" ID="lblRoleUser" runat="server" Text="Роль"></asp:Label>
            <asp:DropDownList ID="drdlRoleUser" runat="server"></asp:DropDownList>

            <br /><br />
            <hr />
            <br /><br />
            <div class="div-btn-registr">
                <asp:Button ID="btnRegister" runat="server" Text="Зарегистрировать пользователя" OnClick="btnRegister_Click" PostBackUrl="~/ListUsers.aspx" />
            </div>
            <asp:HiddenField ID="HiddenField1" Value="null" runat="server" />
            <br />
        </div>
    </form>
</body>
</html>
