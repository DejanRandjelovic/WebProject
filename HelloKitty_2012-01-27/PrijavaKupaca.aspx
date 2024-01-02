<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrijavaKupaca.aspx.cs" Inherits="PrijavaKupaca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 55%;
        }
        .style8
        {
            width: 114px;
        }
        .style9
        {
            width: 288px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<h3>Unesite vaše podatke</h3>
&nbsp; Polja označena zvezdicom (*) su obavezna&nbsp;<br />

    <table class="style6" bgcolor="#FFFFCC">
    <tr>
    <td>&nbsp;
    </td>
    <td class="style9">
        <asp:Label ID="lblRezultat" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
               
    </td>
    <td>&nbsp;</td>

    </tr>
    <tr>
    <td>
    </td>

    <td class="style9"></td>
    <td></td>
    </tr>

    <tr>
    <td>
        Korisničko ime:*</td>

    <td class="style9">
        <asp:TextBox ID="tboxKorisnickoIme" runat="server" Width="150px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvKorisnickoIme" runat="server" 
            ControlToValidate="tboxKorisnickoIme" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    <td></td>
    </tr>

    <tr>
    <td>
        Šifra:*</td>

    <td class="style9">
        <asp:TextBox ID="tboxSifra" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSifra" runat="server" 
            ControlToValidate="tboxSifra" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    <td></td>
    </tr>
    <tr>
    <td>
        Potvrdi šifru:*</td>

    <td class="style9">
        <asp:TextBox ID="tboxPotvrdiSifru" runat="server" Width="150px" 
            TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="cvPotvrdiSifru" runat="server" 
            ControlToCompare="tboxSifra" ControlToValidate="tboxPotvrdiSifru" 
            ErrorMessage="*" ForeColor="Red"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="rfvPotvrdiSifru" runat="server" 
            ControlToValidate="tboxPotvrdiSifru" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    <td></td>
    </tr>
        <tr>
            <td class="style8">
                E-mail:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxEmail" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                    ControlToValidate="tboxEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
    <td>
    </td>

    <td class="style9">&nbsp;&nbsp;</td>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td>&nbsp;
    </td>

    <td class="style9">&nbsp;</td>
    <td></td>
    </tr>
        <tr>
            <td class="style8">
                Ime:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxIme" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvIme" runat="server" 
                    ControlToValidate="tboxIme" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                Prezime:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxPrezime" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPrezime" runat="server" 
                    ControlToValidate="tboxPrezime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td class="style8">
                Adresa:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxAdresa" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAdresa" runat="server" 
                    ControlToValidate="tboxAdresa" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        

        <tr>
            <td class="style8">
                Grad:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxGrad" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvGrad" runat="server" 
                    ControlToValidate="tboxGrad" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                Broj pošte:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxBrojPoste" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBrojPoste" runat="server" 
                    ControlToValidate="tboxBrojPoste" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                Država:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxDrzava" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDrzava" runat="server" 
                    ControlToValidate="tboxDrzava" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                Telefon 1:*</td>
            <td class="style9">
                <asp:TextBox ID="tboxTelefon1" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTelefon1" runat="server" 
                    ControlToValidate="tboxTelefon1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                Telefon 2:</td>
            <td class="style9">
                <asp:TextBox ID="tboxTelefon2" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" class="style8">
                Poruka:</td>
            <td class="style9">
               
                <asp:TextBox ID="tboxPoruka" runat="server" TextMode="MultiLine" Width="250px" 
                    Height="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;
                
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                
               <asp:Button ID="btnPrijava" runat="server" Text="Pošaljite podatke" 
                    Width="120px" onclick="btnPrijava_Click" />
                    
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnPonisti" runat="server" onclick="btnPonisti_Click" 
                    Text="Ponisiti" Width="100px" />
&nbsp;<br />
                &nbsp;&nbsp;&nbsp;
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                <asp:HyperLink ID="hlIdiNaLogovanje" runat="server" 
                    NavigateUrl="~/Logovanje.aspx" Font-Size="Medium" Font-Bold="True">Idi na Logovanje</asp:HyperLink>
                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

