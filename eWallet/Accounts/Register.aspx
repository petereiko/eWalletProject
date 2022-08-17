<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="eWallet.Accounts.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/styles/register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" class="deji" runat="server">
        <center>
            <img id="register-logo" src="../Content/images/logo.jpg"/>
            <div id="login-wrapper">
                <table>
                    <tr>
                        <td class="white-text">Email:</td>
                        <td><input type="email" id="txtEmail" class="textbox" runat="server"/></td>
                    </tr>
                    <tr>
                        <td class="white-text">Password:</td>
                        <td><input type="password" id="txtPassword" class="textbox" runat="server"/></td>
                    </tr>
                    <tr>
                        <td class="white-text">Confirm Password:</td>
                        <td><input type="password" id="txtConfirmPassword" class="textbox" runat="server"/></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnRegister" Text="Register" OnClick="btnRegister_Click" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <label id="lblResult" runat="server"></label>
                        </td>
                    </tr>
                </table>
            </div>
        </center>
    </form>
</body>
</html>
