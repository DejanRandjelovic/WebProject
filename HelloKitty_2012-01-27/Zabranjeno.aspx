<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Zabranjeno.aspx.cs" Inherits="Zabranjeno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <br/>
<h2>Nemate pravo pristupa web sajtu.</h2>
<br />
    <asp:Label ID="lblPorukaIP" runat="server" Font-Bold="True" Font-Size="Medium" 
        ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

