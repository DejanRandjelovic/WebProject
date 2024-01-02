<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AzuriranjeKurirskeSluzbe.aspx.cs" Inherits="AzurianjeKurirskeSluzbe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 64px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style7" bgcolor="#FFFF99" border="2px">
            <tr>
                <td class="style8" valign="top">
                    Odaberi Kurirsku službu:</td>
                <td class="style9">
                    <asp:DropDownList ID="ddlKurirskaSluzba" runat="server" Width="150px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlKurirskaSluzba_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="ddlKurirskaSluzba" ErrorMessage="* Odaberite" Font-Bold="True" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style10">
                    <asp:Button ID="btnResetujPolja" runat="server" Text="Resetuj polja" 
                        Width="120px" onclick="btnResetujPolja_Click" />
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Button ID="btnUbaciKurirsku" runat="server" Text="Ubaci Kurirsku" 
                        Width="150px" onclick="btnUbaciKurirsku_Click" />
                </td>
                <td class="style9">
                    <asp:Button ID="btnPromeniKurirsku" runat="server" Text="Promeni Kurirsku" 
                        Width="150px" onclick="btnPromeniKurirsku_Click" />
                </td>
                <td class="style10">
                    <asp:Button ID="btnObrisiKurirsku" runat="server" Text="Obrisi  Kurirsku" 
                        Width="120px" onclick="btnObrisiKurirsku_Click" />
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8" valign="top">
                    ID:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxIDKurirske" runat="server" Enabled="False" Width="155px"></asp:TextBox>
                    <br />
                </td>
                <td class="style10" colspan="2" rowspan="3" valign="top">
                    <asp:Literal ID="litRezultat" runat="server"></asp:Literal>
                    <br />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="style8" valign="top">
                    Naziv firme:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxNazivFirme" runat="server" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tboxNazivFirme" ErrorMessage="* Obavezan unos" 
                        Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8" valign="top">
                    Telefon:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxTelefon" runat="server" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tboxTelefon" ErrorMessage="* Obavezan unos" 
                        Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

