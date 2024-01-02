<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pocetna.aspx.cs" Inherits="Pocetna" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/Ads.xml" 
        Width="975px" Height="112px"/>
        <br />

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetKategorije" 
    TypeName="KategorijeBLL"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetProizvodiByKategorijaID" 
        TypeName="OnLineShopTableAdapters.ProizvodiTableAdapter" 
        DeleteMethod="Delete">
        <DeleteParameters>
            <asp:Parameter Name="Original_ProizvodID" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlKategorijePocetna" Name="KategorijaID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:Label ID="LabelDDLKategorije" runat="server" Text="Odaberite kategoriju:" Font-Size="Medium"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlKategorijePocetna" runat="server" AutoPostBack="True" 
    DataSourceID="ObjectDataSource1" DataTextField="NazivKategorije" 
    DataValueField="KategorijaID" Width="200px">
</asp:DropDownList>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProizvodID" 
        DataSourceID="ObjectDataSource2" BorderColor="#CC9966" 
    BorderStyle="None" BorderWidth="1px" 
        BackColor="White" style="margin-top: 0px" Font-Size="Large">
        <Columns>
            <asp:ImageField DataImageUrlField="ProizvodID" 
                DataImageUrlFormatString="Slika.aspx?ProizvodID={0}" HeaderText="Slika">
            </asp:ImageField>
            <asp:BoundField DataField="NazivProizvoda" HeaderText="Naziv" 
                SortExpression="NazivProizvoda" />
            <asp:BoundField DataField="BarKod" HeaderText="BarKod" 
                SortExpression="BarKod" />
            <asp:BoundField DataField="JedinicnaCena" HeaderText="Cena" 
                SortExpression="JedinicnaCena" />
            <asp:CheckBoxField DataField="Akcija" HeaderText="Akcija" 
                SortExpression="Akcija" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    <br />
    <br />
    <br />

    </asp:Content>
        <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </asp:Content>
