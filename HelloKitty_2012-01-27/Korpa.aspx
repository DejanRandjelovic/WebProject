<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Korpa.aspx.cs" Inherits="Korpa1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
        }
        .style8
        {
        }
        .style9
        {
            width: 297px;
        }
        .style10
        {
            width: 63px;
        }
        .style11
        {
            text-align:right;
        }
           
            
        .style12
        {
            width: 250px;
        }
           
            
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />

    <table class="style7">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Odaberite kategoriju:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Odaberite proizvod:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:DropDownList ID="ddlKategorijaKorpa" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSource3" DataTextField="NazivKategorije" 
                    DataValueField="KategorijaID" Height="23px" Width="180px" 
                    onselectedindexchanged="ddlKategorijaKorpa_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>

    <asp:DropDownList ID="ddlProizKorpa" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="NazivProizvoda" 
        DataValueField="ProizvodID" 
        onselectedindexchanged="ddlProizKorpa_SelectedIndexChanged" Height="23px" 
                    Width="280px">
    </asp:DropDownList>
            </td>
        </tr>
    </table>

    <br />

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OnLineProdavnicaConnectionString %>" 
        
        SelectCommand="SELECT Proizvodi.ProizvodID, Proizvodi.NazivProizvoda, Kategorije.KategorijaID, Kategorije.NazivKategorije FROM Proizvodi INNER JOIN Kategorije ON Proizvodi.KategorijaID = Kategorije.KategorijaID WHERE (Kategorije.KategorijaID = @KategorijaID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlKategorijaKorpa" Name="KategorijaID" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OnLineProdavnicaConnectionString %>" 
        SelectCommand="SELECT * FROM [Proizvodi] WHERE ([ProizvodID] = @ProizvodID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlProizKorpa" Name="ProizvodID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OnLineProdavnicaConnectionString %>" 
        SelectCommand="SELECT [KategorijaID], [NazivKategorije] FROM [Kategorije]">
    </asp:SqlDataSource>
    <br />
    
    
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ProizvodID" 
        DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" 
        BorderColor="#CCCCCC" BorderStyle="Groove" BorderWidth="1px" Width="600px" 
        AllowPaging="True" Font-Size="Large">
        <EditItemTemplate>
            ProizvodID:
            <asp:Label ID="ProizvodIDLabel1" runat="server" 
                Text='<%# Eval("ProizvodID") %>' />
            <br />
            NazivProizvoda:
            <asp:TextBox ID="NazivProizvodaTextBox" runat="server" 
                Text='<%# Bind("NazivProizvoda") %>' />
            <br />
            OpisProizvoda:
            <asp:TextBox ID="OpisProizvodaTextBox" runat="server" 
                Text='<%# Bind("OpisProizvoda") %>' />
            <br />
            BarKod:
            <asp:TextBox ID="BarKodTextBox" runat="server" Text='<%# Bind("BarKod") %>' />
            <br />
            KategorijaID:
            <asp:TextBox ID="KategorijaIDTextBox" runat="server" 
                Text='<%# Bind("KategorijaID") %>' />
            <br />
            Slika:
            <asp:TextBox ID="SlikaTextBox" runat="server" Text='<%# Bind("Slika") %>' />
            <br />
            PoreskaStopaID:
            <asp:TextBox ID="PoreskaStopaIDTextBox" runat="server" 
                Text='<%# Bind("PoreskaStopaID") %>' />
            <br />
            JedinicnaCena:
            <asp:TextBox ID="JedinicnaCenaTextBox" runat="server" 
                Text='<%# Bind("JedinicnaCena") %>' />
            <br />
            NaStanju:
            <asp:TextBox ID="NaStanjuTextBox" runat="server" 
                Text='<%# Bind("NaStanju") %>' />
            <br />
            JeAktivan:
            <asp:CheckBox ID="JeAktivanCheckBox" runat="server" 
                Checked='<%# Bind("JeAktivan") %>' />
            <br />
            DatumAzuriranja:
            <asp:TextBox ID="DatumAzuriranjaTextBox" runat="server" 
                Text='<%# Bind("DatumAzuriranja") %>' />
            <br />
            BrosuraPath:
            <asp:TextBox ID="BrosuraPathTextBox" runat="server" 
                Text='<%# Bind("BrosuraPath") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <InsertItemTemplate>
            NazivProizvoda:
            <asp:TextBox ID="NazivProizvodaTextBox" runat="server" 
                Text='<%# Bind("NazivProizvoda") %>' />
            <br />
            OpisProizvoda:
            <asp:TextBox ID="OpisProizvodaTextBox" runat="server" 
                Text='<%# Bind("OpisProizvoda") %>' />
            <br />
            BarKod:
            <asp:TextBox ID="BarKodTextBox" runat="server" Text='<%# Bind("BarKod") %>' />
            <br />
            KategorijaID:
            <asp:TextBox ID="KategorijaIDTextBox" runat="server" 
                Text='<%# Bind("KategorijaID") %>' />
            <br />
            Slika:
            <asp:TextBox ID="SlikaTextBox" runat="server" Text='<%# Bind("Slika") %>' />
            <br />
            PoreskaStopaID:
            <asp:TextBox ID="PoreskaStopaIDTextBox" runat="server" 
                Text='<%# Bind("PoreskaStopaID") %>' />
            <br />
            JedinicnaCena:
            <asp:TextBox ID="JedinicnaCenaTextBox" runat="server" 
                Text='<%# Bind("JedinicnaCena") %>' />
            <br />
            NaStanju:
            <asp:TextBox ID="NaStanjuTextBox" runat="server" 
                Text='<%# Bind("NaStanju") %>' />
            <br />
            JeAktivan:
            <asp:CheckBox ID="JeAktivanCheckBox" runat="server" 
                Checked='<%# Bind("JeAktivan") %>' />
            <br />
            DatumAzuriranja:
            <asp:TextBox ID="DatumAzuriranjaTextBox" runat="server" 
                Text='<%# Bind("DatumAzuriranja") %>' />
            <br />
            BrosuraPath:
            <asp:TextBox ID="BrosuraPathTextBox" runat="server" 
                Text='<%# Bind("BrosuraPath") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <table class="style7">
                <tr>
                    <td width="80">
                        ID:</td>
                    <td width="150">
                        <asp:Label ID="ProizvodIDLabel" runat="server" 
                            Text='<%# Eval("ProizvodID") %>' />
                    </td>
                    <td height="200" rowspan="5" width="200">
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl='<%# Eval("ProizvodID","Slika.aspx?ProizvodID={0}") %>' />
                    </td>
                </tr>
                <tr>
                    <td width="80">
                        Naziv:</td>
                    <td width="150">
                        <asp:Label ID="NazivProizvodaLabel" runat="server" 
                            Text='<%# Bind("NazivProizvoda") %>' />
                    </td>
                </tr>
                <tr>
                    <td width="80">
                        Opis:</td>
                    <td width="150">
                        <asp:Label ID="OpisProizvodaLabel" runat="server" 
                            Text='<%# Bind("OpisProizvoda") %>' />
                    </td>
                </tr>
                <tr>
                    <td width="80">
                        Barkod:</td>
                    <td width="150">
                        <asp:Label ID="BarKodLabel" runat="server" Text='<%# Bind("BarKod") %>' />
                    </td>
                </tr>
                <tr>
                    <td width="80">
                        Cena:</td>
                    <td width="150">
                        <asp:Label ID="JedinicnaCenaLabel" runat="server" 
                            Text='<%# Bind("JedinicnaCena") %>' />
                    </td>
                </tr>
            </table>
            <br />
            <br />

        </ItemTemplate>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:FormView>
    <br />
    <table class="style7">
        <tr>
            <td class="style10" valign="top">
                *
                Kolicina:</td>
            <td class="style9">
                <asp:TextBox ID="tboxKolicina" runat="server" CssClass="style11" Height="23px" 
                    Width="150px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tboxKolicina" ErrorMessage="Obavezan unos kolicine" 
                    ForeColor="#CC3300"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tboxKolicina" ErrorMessage="Samo celobrojne vrednosti" 
                    ForeColor="#CC3300" ValidationExpression="[0-9]"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="lblKorpaPoruka" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                <asp:Button ID="btnDodajUKorpu" runat="server" Text="Dodaj u korpu" 
                    onclick="btnDodajUKorpu_Click" Width="150px" />
            </td>
            <td>
                <asp:Button ID="btnPregledKorpe" runat="server" Text="Pregled korpe" 
                    onclick="btnPregledKorpe_Click" Width="150px" />
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ForeColor="#CC3300" />
                <br />
            </td>
        </tr>
    </table>
    <br />

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

