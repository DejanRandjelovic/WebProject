<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AzuriranjePoreskihStopa.aspx.cs" Inherits="AzuriranjePoreskihStopa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
        }
        .style8
        {
            width: 178px;
        }
        .style9
        {
            width: 197px;
        }
        .style10
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <table class="style7" bgcolor="#FFFF99" border="2px">
            <tr>
                <td class="style8" valign="top">
                    Odaberi poresku stopu:</td>
                <td class="style9">
                    <asp:DropDownList ID="ddlPoreskaStopa" runat="server" Width="155px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlPoreskaStopa_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="ddlPoreskaStopa" ErrorMessage="* Odaberite" Font-Bold="True" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style10">
                    <asp:Button ID="btnResetujPolja" runat="server" Text="Resetuj polja" 
                        Width="100px" onclick="btnResetujPolja_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Button ID="btnUbaciStopu" runat="server" Text="Ubaci stopu" 
                        Width="100px" onclick="btnUbaciStopu_Click" />
                </td>
                <td class="style9">
                    <asp:Button ID="btnPromeniStopu" runat="server" Text="Promeni stopu" 
                        Width="100px" onclick="btnPromeniStopu_Click" />
                </td>
                <td class="style10">
                    <asp:Button ID="btnObrisiStopu" runat="server" Text="Obrisi Stopu" 
                        Width="100px" onclick="btnObrisiStopu_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8" valign="top">
                    ID:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxIDStope" runat="server" Enabled="False" Width="155px"></asp:TextBox>
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
                    Naziv stope:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxNazivStope" runat="server" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tboxNazivStope" ErrorMessage="* Obavezan unos" 
                        Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8" valign="top">
                    Vrednost stope:</td>
                <td class="style9">
                    <asp:TextBox ID="tboxVrednostStope" runat="server" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tboxVrednostStope" ErrorMessage="* Obavezan unos" 
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

