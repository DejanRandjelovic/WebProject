<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AzuriranjeProizvoda.aspx.cs" Inherits="AzuriranjeProizvoda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
        }
        .style10
        {}
    .style11
    {}
    .style12
    {}
    .style13
    {}
    .style16
    {
        width: 123px;
        height: 22px;
    }
    .style17
    {
        height: 22px;
    }
        .style18
        {}
        .style19
        {
            width: 123px;
        }
        .style20
        {}
        .style26
        {
            width: 205px;
            height: 22px;
        }
        .style27
        {
            width: 205px;
        }
        .style28
        {
            width: 116px;
            height: 22px;
        }
        .style29
        {
            width: 116px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="style7" bgcolor="#FFFF99" border="2px">
        <tr>
            <td class="style28">
                Pronadji proizvod po:<br />
                <asp:RadioButtonList ID="rblistIzbor" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="rblistIzbor_SelectedIndexChanged">
                    <asp:ListItem>Nazivu</asp:ListItem>
                    <asp:ListItem>BarKodu</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="style26">
                <asp:DropDownList ID="ddlProizvodi" runat="server" AutoPostBack="True" 
                    CssClass="style11" Height="22px" Width="200px" AppendDataBoundItems="True" 
                    DataTextField="NazivProizvoda" DataValueField="ProizvodID" 
                    onselectedindexchanged="ddlProizvodi_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;<asp:TextBox ID="tboxNadjiPoBarKodu" runat="server" Width="90px"></asp:TextBox>
&nbsp;&nbsp;

               <%-- <asp:TextBox ID="tboxPoBarKodu" runat="server" 
                     Width="90px" ondatabinding="btnTraziPoBarKodu_Click" AutoPostBack="True" 
                    on /textchanged=" /tboxPoBarKodu_TextChanged"></asp:TextBox>--%>
&nbsp;
                <asp:Button ID="btnTraziPoBarKodu" runat="server" 
                    onclick="btnTraziPoBarKodu_Click" Text="Trazi ..." Width="68px" />
            </td>
            <td class="style16">
                <asp:Button ID="btnResetujProizvode" runat="server" Text="Resetuj" 
                    onclick="btnResetujProizvode_Click" Width="100px" />
            &nbsp;
                </td>
            <td class="style17">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29">
                &nbsp; 
                <asp:Button ID="btnUbaciProizvod" runat="server" 
                    Text="Ubaci" onclick="btnUbaciProizvod_Click" Width="100px" />
            </td>
            <td class="style27">
                &nbsp;<asp:Button ID="btnPromeniProizvod" runat="server" Text="Promeni" 
                    onclick="btnPromeniProizvod_Click" Width="100px" />
            </td>
            <td class="style19">
                <asp:Button ID="btnObrisiProizvod" runat="server" 
                    Text="Obrisi proizvod" CssClass="style18" Width="100px" Height="26px" 
                    onclick="btnObrisiProizvod_Click" />
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="style29">
                ID:<br />
                <br />
                Sifra:</td>
            <td class="style27">
                <asp:TextBox ID="tboxID" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="tboxSifra" runat="server"></asp:TextBox>
                <br />
            </td>
            <td class="style19">
                Dodaj
                Sliku:</td>
            <td>
                <asp:FileUpload ID="FileUploadSlika" runat="server" CssClass="style20" 
                    Width="217px" />
            </td>
        </tr>
        <tr>
            <td class="style29">
                Naziv:</td>
            <td class="style27">
                <asp:TextBox ID="tboxNaziv" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NazivRequiredFieldValidator1" runat="server" 
                    ControlToValidate="tboxNaziv">*</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tboxNaziv" ErrorMessage="* Obavezan unos" Font-Bold="True" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="style19">
                Dodaj Brosuru:</td>
                <td class="style19">
                    <asp:FileUpload ID="FileUploadBrosura" runat="server" CssClass="style20" 
                        Width="217px" />&nbsp;</td>
            
                
        </tr>
        <tr>
            <td class="style29">
                Opis:</td>
            <td class="style27">
                <asp:TextBox ID="tboxOpis" runat="server" Font-Names="Verdana" 
                    Font-Size="Small" Height="100px" TextMode="MultiLine" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="tboxOpis" ErrorMessage="* Obavezan unos" Font-Bold="True" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="style10" colspan="2" rowspan="6">
                <asp:Literal ID="litRezultat" runat="server"></asp:Literal>
                </td>


        </tr>
        <tr>
            <td class="style29">
                Bar kod:</td>
            <td class="style27">
                <asp:TextBox ID="tboxBarKod" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style29">
                Kategorija:</td>
            <td class="style27">
                <asp:DropDownList ID="ddlKategorije" runat="server" CssClass="style12" 
                    Height="22px" Width="200px" AppendDataBoundItems="True" 
                    ondatabound="ddlProizvodi_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlKategorije" ErrorMessage="* Odaberi Kategoriju" 
                    Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style29">
                Poreska stopa:</td>
            <td class="style27">
                <asp:DropDownList ID="ddlPoreskeStope" runat="server" CssClass="style13" 
                    Height="22px" Width="150px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlPoreskeStope" ErrorMessage="* Odaberi stopu" 
                    Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style29">
                Jedinicna cena:</td>
            <td class="style27">
                <asp:TextBox ID="tboxJednicnaCena" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="tboxJednicnaCena" ErrorMessage="* Obavezan unos" 
                    Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style29">
                Kol. na stanju:</td>
            <td class="style27">
                <asp:TextBox ID="tboxKolicina" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="tboxKolicina" ErrorMessage="* Obavezna kolicina" 
                    Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style29">
                Jeste aktivan:</td>
            <td class="style27">
                <asp:CheckBox ID="cboxAktivan" runat="server" />
            </td>
            <td class="style19">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td class="style29">
                Na Akciji:</td>
            <td class="style27">
                <asp:CheckBox ID="cboxNaAkciji" runat="server" />
            </td>
            <td class="style19">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29">
                <asp:Label ID="lblDatumAzuriranja" runat="server" Text="Datum Azuriranja:"></asp:Label>
            </td>
            <td class="style27">
                <asp:TextBox ID="tboxDatumAzuriranja" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style10" colspan="2">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </asp:Content>

