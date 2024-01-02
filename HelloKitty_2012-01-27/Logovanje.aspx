<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Logovanje.aspx.cs" Inherits="Logovanje" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 59%;
        }
        .style7
        {}
        .style8
        {}
        .style9
        {
            width: 188px;
        }
        .style10
        {
        }
        .style11
        {
            width: 110px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br/>
    <br/>

    <table bgcolor="#FFFFCC" class="style6">
        <tr>
            <td class="style10" colspan="3">
                Molimo unesite Vaše 
                korisničko ime i šifru da bi ste se ulogovali<br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style11">
                Korisničko ime:</td>
            <td class="style9">
                <asp:TextBox ID="tboxKorisnickoIme" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvKorisnickoIme" runat="server" 
                    ControlToValidate="tboxKorisnickoIme" ErrorMessage="*" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                Šifra:</td>
            <td class="style9">
                <asp:TextBox ID="tboxSifra" runat="server" CssClass="style8" 
                    TextMode="Password" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSifra" runat="server" 
                    ControlToValidate="tboxSifra" ErrorMessage="*" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                <asp:CheckBox ID="cbZapamtiMe" runat="server" Text="Zapamti me" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnLogujSe" runat="server" CssClass="style7" Text="Loguj se" 
                    Width="109px" onclick="btnLogujSe_Click" />
            </td>
        </tr>
        <tr>
            <td class="style10" colspan="3">
                <br />
                <asp:Label ID="lblGreska" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <asp:HyperLink ID="hlKreirajNalog" runat="server" 
        NavigateUrl="~/PrijavaKupaca.aspx" Font-Size="Medium" Font-Bold="True" 
    ForeColor="#3366CC">Kreiraj Novi nalog</asp:HyperLink>
</asp:Content>

