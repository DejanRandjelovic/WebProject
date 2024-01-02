<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kontakt.aspx.cs" Inherits="Saradnja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style4
    {
        width: 100%;
    }
        .style5
        {
            width: 152px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style4">
    <tr>
        <td class="style5">
            <asp:Label ID="lblKontakt" runat="server" Font-Bold="True" Font-Size="X-Large" 
                Text="Kontakt"></asp:Label>
            <br />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Slike/LogoIF.png" />
            <br />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblNaziv" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Naziv:"></asp:Label>
            <br />
            <br />
            <br />
        </td>
        <td>
            <asp:Label ID="lblPreduzece4" runat="server" Font-Size="Medium" 
                Text="INTERFORTAS d.o.o. "></asp:Label>
            <br />
            <asp:Label ID="lblPreduzece5" runat="server" Font-Size="Medium" 
                Text="PREDUZEĆE ZA UNUTRAŠNJU I SPOLJNU TRGOVINU"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblAdresa" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Adresa sedišta:"></asp:Label>
            <br />
            <br />
        </td>
        <td>
            <asp:Label ID="lblAdresa1" runat="server" Font-Size="Medium" 
                Text="Devaldovih 1, 11000 Beograd, Srbija"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblOgranak" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Ogranak:"></asp:Label>
            <br />
            <br />
        </td>
        <td>
            <asp:Label ID="lblOgranak1" runat="server" Font-Size="Medium" 
                Text="INTERFORTAS DOO BEOGRAD - OGRANAK HELLO KITTY 1"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblAdresaOgranka" runat="server" Font-Bold="True" 
                Font-Size="Medium" Text="Adresa ogranka:"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
        </td>
        <td>
            <asp:Label ID="lblAdresaOgranka0" runat="server" Font-Size="Medium" 
                Text="TC DELTA CITY"></asp:Label>
        <br />
            <asp:Label ID="lblAdresaOgranka1" runat="server" Font-Size="Medium" 
              Text="Jurija Gagarina 16, lokal br. 240"></asp:Label>
            <br />
            <asp:Label ID="lblAdresaOgranka2" runat="server" Font-Size="Medium" 
                Text="Beograd - Novi Beograd, Srbija"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblTelefon" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Telefon veleprodaje:"></asp:Label>
            <br />
            <br />
         </td>
        <td>
            <asp:Label ID="lblTelefon1" runat="server" Text="+381 11 2191 559" 
                Font-Size="Medium"></asp:Label>
            <br />
            <asp:Label ID="lblTelefon7" runat="server" Text="+381 64 116 3200" 
                Font-Size="Medium"></asp:Label>
         </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblTelefon9" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Telefon maloprodaje:"></asp:Label>
            <br />
         </td>
        <td>
            <asp:Label ID="lblTelefon8" runat="server" Text="+381 11 2203 802" 
                Font-Size="Medium"></asp:Label>
         </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblRVremeM" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="E-mail:"></asp:Label>
            <br />
            <br />
         </td>
        <td>
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Medium" 
                NavigateUrl="sucura.milos@gmail.com">sucura.milos@gmail.com</asp:HyperLink>
         </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="lblRVremeM0" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Radno vreme maloprodaje:"></asp:Label>
            <br />
         </td>
        <td>
            <asp:Label ID="lblTelefon6" runat="server" Text="svaki dan 10 - 22h" 
                Font-Size="Medium"></asp:Label>
            <br />
         </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Radno vreme veleprodaje:"></asp:Label>
            <br />
            <br />
         </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="radnim danima 10 - 16h" 
                Font-Size="Medium"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="subotom i nedeljom ne radi" 
                Font-Size="Medium"></asp:Label>
         </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Podaci za identifikaciju:"></asp:Label>
            <br />
            <br />
         </td>
        <td>
        &nbsp;<asp:Image ID="Image6" runat="server" ImageUrl="~/Slike/Adobe.png" 
                Width="20px" />
&nbsp;<asp:HyperLink ID="HyperLink3" runat="server" Font-Size="Medium" 
                NavigateUrl="~/Brosure/ITF_IDENTIFIKACIJA.pdf">ITF_IDENTIFIKACIJA.pdf</asp:HyperLink>
            <br />
            &nbsp;<asp:Image ID="Image5" runat="server" ImageUrl="~/Slike/Adobe.png" 
                Width="20px" />
&nbsp;<asp:HyperLink ID="HyperLink4" runat="server" Font-Size="Medium" 
                NavigateUrl="~/Brosure/ITF_PEPDV_OBRAZAC.pdf">ITF_PEPDV_OBRAZAC.pdf</asp:HyperLink>
            <br />
            &nbsp;<asp:Image ID="Image7" runat="server" ImageUrl="~/Slike/Adobe.png" 
                Width="20px" />
&nbsp;<asp:HyperLink ID="HyperLink5" runat="server" Font-Size="Medium" 
                NavigateUrl="~/Brosure/ITF_POTVRDA O REGISTRACIJI.pdf">ITF_POTVRDA O REGISRACIJI.pdf</asp:HyperLink>
            <br />
         </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" bgcolor="#CCCCCC">
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Gde se nalazimo:"></asp:Label>
         </td>
        <td>
            <br />
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Slike/PozicijaLokala.png" />
         </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

