<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="Crud_Formulario.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Empleados</h1>
    <asp:Label ID="lbl_codigo" runat="server" Text="Codigo" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:TextBox ID="txt_codigo" runat="server" CssClass="form-control" placeholder="Codigo"></asp:TextBox>

</asp:Content>
