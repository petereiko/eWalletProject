<%@ Page Title="" Language="C#" MasterPageFile="~/Inside/Inside.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="eWallet.Inside.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: right">
                <button type="button" onclick="showBuyContent()">Buy</button>
            </td>
            <td style="text-align: left">
                <button type="button" onclick="showSellContent()">Sell</button>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <label runat="server" id="lblSellResponse"></label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridViewMyTransactions" runat="server"></asp:GridView>
            </td>
        </tr>
    </table>


    <div id="buysection" runat="server" style="display:none">
        Buy Content
    </div>

    <div id="sellsection" runat="server" style="display:none">
        <table>
            <tr>
                <td colspan="2">
                    
                </td> 
            </tr>
            <tr>
                <td>Amount</td>
                <td><input type="text" id="txtAmount" runat="server"/></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSell" OnClick="btnSell_Click" runat="server" Text="Sell Now" />
                </td>
            </tr>
        </table>
    </div>

    <script>
        function showBuyContent() {
            document.getElementById("ContentPlaceHolder1_buysection").style.display = "block";
            document.getElementById("ContentPlaceHolder1_sellsection").style.display = "none";
        }

        function showSellContent() {
            document.getElementById("ContentPlaceHolder1_sellsection").style.display = "block";
            document.getElementById("ContentPlaceHolder1_buysection").style.display = "none";
        }
    </script>

</asp:Content>
