<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PregledKorpe.aspx.cs" Inherits="PregledKorpe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
        }
        .style8
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style7">
        <tr>
            <td class="style8" colspan="2">
                <asp:ListBox ID="ListBoxUKorpi" runat="server" Width="600px" Height="180px"></asp:ListBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td>&nbsp; <asp:Label ID="lblPoruka" runat="server" Text=" "></asp:Label></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>

        <tr>
            <td class="style8">
                <asp:Button ID="btnUkupnaSuma" runat="server" 
                    onclick="btnUkupnaSuma_Click" Text="Ukupna suma" Width="150px" />
            </td>
            <td>
        <asp:Button ID="btnUkloniStavku" runat="server" onclick="btnUkloniStavku_Click" 
                    Text="Ukloni Stavku" Width="150px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Button ID="btnNastaviKupovinu" runat="server" 
                    onclick="btnNastaviKupovinu_Click" Text="Nastavi kupovinu" Width="150px" />
            </td>
            <td>
                <asp:Button ID="btnIsprazniKorpu" runat="server" 
                    onclick="btnIsprazniKorpu_Click" Text="Isprazni Korpu" Width="150px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
               
                <asp:Button ID="btnPosaljiPorudzbinu" runat="server" Text="Posalji Porudzbinu" 
                    Width="150px" onclick="btnPosaljiPorudzbinu_Click" />
            </td>
            <td>
                <asp:Literal ID="litRezultat" runat="server"></asp:Literal>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

