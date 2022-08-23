<%@ Page Title="" Language="C#" MasterPageFile="~/Inside/Inside.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="eWallet.Inside.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome to Profile Page
    <div>
        <img  width="200" height="200" alt="Passport here" runat="server" id="passportContainer"/>
    </div>
    <table>
        <tr>
            <td style="width: 80%">
                <input type="hidden" id="profileId" runat="server"/>
                <table>
                    <tr>
                        <td>Firstname:</td>
                        <td>
                            <input type="text" id="txtFirstname" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Lastname:</td>
                        <td>
                            <input type="text" id="txtLastname" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Phone:</td>
                        <td>
                            <input type="text" id="txtPhone" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Gender:</td>
                        <td>
                            <asp:RadioButtonList ID="GenderRadioButtonList" runat="server">
                                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>States:</td>
                        <td>
                            <asp:DropDownList ID="StateDropDownList" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Address:</td>
                        <td>
                            <textarea id="txtAddress" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>Passport:</td>
                        <td>
                            <input type="file" required="required" accept="image/*" id="passportFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSubmitProfile" OnClick="btnSubmitProfile_Click" runat="server" Text="Submit Profile" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align:top">
                <label id="lblStatus" runat="server"></label>
                <br />
                <label id="lblBalance" runat="server"></label>
            </td>
        </tr>
    </table>


</asp:Content>
