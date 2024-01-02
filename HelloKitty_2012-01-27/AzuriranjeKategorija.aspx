<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AzuriranjeKategorija.aspx.cs" Inherits="AzuriranjeKategorija" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
        }
        .style9
        {
            width: 190px;
        }
        .style10
        {
            width: 175px;
        }
        .style11
        {
            width: 169px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style7" bgcolor="#FFFF99" border="2px">
            <tr>
                <td class="style11" valign="top">
                    Odaberi kategoriju:</td>
                <td class="style9">
                    <asp:DropDownList ID="ddlKategorija" runat="server" Width="200px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlKategorija_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="ddlKategorija" ErrorMessage="* Odaberite" Font-Bold="True" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style10">
                    <asp:Button ID="btnResetujPolja" runat="server" Text="Resetuj polja" 
                        Width="120px" onclick="btnResetujPolja_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Button ID="btnUbaciKategoriju" runat="server" Text="Ubaci kategoriju" 
                        Width="120px" onclick="btnUbaciKategoriju_Click" />
                </td>
                <td class="style9">
                    <asp:Button ID="btnPromeniKategoriju" runat="server" Text="Promeni kategoriju" 
                        Width="120px" onclick="btnPromeniKategoriju_Click" />
                </td>
                <td class="style10">
                    <asp:Button ID="btnObrisiKategoriju" runat="server" Text="Obrisi Kategoriju" 
                        Width="120px" onclick="btnObrisiKategoriju_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11" valign="top">
                    ID:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxIDKategorije" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                    <br />
                </td>
                <td class="style10" colspan="2" rowspan="3" valign="top">
                    <br />
                    <asp:Literal ID="litRezultat" runat="server"></asp:Literal>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="style11" valign="top">
                    Naziv kategorije:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxNazivKategorije" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tboxNazivKategorije" ErrorMessage="* Obavezan unos" 
                        Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11" valign="top">
                    Opis kategorije:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxOpisKategorije" runat="server" Width="200px" 
                        Height="155px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tboxOpisKategorije" ErrorMessage="* Obavezan unos" 
                        Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

