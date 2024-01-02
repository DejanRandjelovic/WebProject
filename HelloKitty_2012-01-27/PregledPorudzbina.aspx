<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PregledPorudzbina.aspx.cs" Inherits="PregledPorudzbina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="LabelPoruka" runat="server" Font-Size="Medium"></asp:Label>
    <br/>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OnLineProdavnicaConnectionString %>" 
        SelectCommand="SELECT [RacunID], [Medjuzbir] FROM [Racuni]"></asp:SqlDataSource>
    

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OnLineProdavnicaConnectionString %>"
        
       
        
        SelectCommand="SELECT * FROM [View_PregledPorudzbine] WHERE ([RacunID] = @RacunID)"> 
        
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlRacunID" Name="RacunID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OnLineProdavnicaConnectionString %>" 
        
        
        SelectCommand="SELECT Kupci.KupacID, Kupci.ImePrimaoca, Kupci.PrezimePrimaoca, Kupci.AdresaPrimaoca, Kupci.GradPrimaoca, Kupci.BPostePrimaoca, Kupci.DrzavaPrimaoca, Kupci.Telefon1, Kupci.Telefon2, Kupci.Poruka, Kupci.Email, Racuni.RacunID, Racuni.DatumNarucivanja, Proizvodi.NazivProizvoda, Proizvodi.BarKod, ZaIsporuku.RacunID AS Expr1, ZaIsporuku.JedinicnaCena AS Expr2, ZaIsporuku.Kolicina, Kupci.KorisnickoIme FROM Kupci INNER JOIN Racuni ON Kupci.KupacID = Racuni.KupacID INNER JOIN ZaIsporuku ON Racuni.RacunID = ZaIsporuku.RacunID INNER JOIN Proizvodi ON ZaIsporuku.ProizvodID = Proizvodi.ProizvodID WHERE (Racuni.RacunID = @RacunID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlRacunID" Name="RacunID" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:Label ID="LabelDDLRacun" runat="server" Text="Odaberite broj racuna:" Font-Size="Medium"></asp:Label>

    <asp:DropDownList ID="ddlRacunID" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="RacunID" 
        DataValueField="RacunID" Width="134px" Height="21px">
    </asp:DropDownList>
    &nbsp;&nbsp;
    <br/>
    <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource2" BorderStyle="Solid" BorderWidth="1px" 
        BorderColor="Black" Font-Size="Medium" CellPadding="4" ForeColor="#333333" 
        DataKeyNames="RacunID">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="NazivProizvoda" HeaderText="NazivProizvoda" 
                SortExpression="NazivProizvoda" />
            <asp:BoundField DataField="BarKod" HeaderText="BarKod" 
                SortExpression="BarKod" />
            <asp:BoundField DataField="Kolicina" HeaderText="Kolicina" 
                SortExpression="Kolicina" />
            <asp:BoundField DataField="JedinicnaCena" HeaderText="JedinicnaCena" 
                SortExpression="JedinicnaCena" />
                <asp:BoundField DataField="Iznos" HeaderText="Iznos" ReadOnly="True" 
                    SortExpression="Iznos" />
                <asp:BoundField DataField="Medjuzbir" HeaderText="Ukupno" />

            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    <br />
    <asp:Label ID="Label15" runat="server" Font-Size="Medium" 
        Text="Ukupna suma racuna:"></asp:Label>
&nbsp;<br />
    <br/>
    <asp:FormView ID="FormView1" runat="server" BackColor="#FFFF99" 
        BorderColor="Black" BorderStyle="Solid" CellPadding="4" 
        DataSourceID="SqlDataSource3" Font-Size="Medium" ForeColor="#333333">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <table class="style4">
                <tr>
                    <td bgcolor="#CCCCCC">
                        Ime kupca:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("ImePrimaoca") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Prezime kupca:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("PrezimePrimaoca") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Adresa:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("AdresaPrimaoca") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Grad:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("GradPrimaoca") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Broj poste:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("BPostePrimaoca") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Drzava:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("DrzavaPrimaoca") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        &nbsp;</td>
                    <td bgcolor="#FFFBD6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Datum narucivanja:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("DatumNarucivanja") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Korisnicko ime:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("KorisnickoIme") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Telefon:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Telefon1") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        E-mail:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#CCCCCC">
                        Poruka:</td>
                    <td bgcolor="#FFFBD6">
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("Poruka") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:FormView>
    <br/>
    <br/>
    

        <br />
    

</asp:Content>


