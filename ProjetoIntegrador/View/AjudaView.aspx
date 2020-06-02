<%@ Page Title="Ajuda unNamed" Language="C#" MasterPageFile="~/View/_LayoutPaginaAssistente.Master" AutoEventWireup="true" CodeBehind="AjudaView.aspx.cs" Inherits="ProjetoIntegrador.View.AjudaView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Style/EstiloPaginaAssistente.css" rel="stylesheet" />
    <h1>Ajuda</h1>
    <p>Criado por João Paulo Bráulio.</p>
    <br />
    <p>Contato:</p>
    <p>Email: jpbraulio@live.com</p>
    <p>Telefone: +55 38 99745-5797</p>
    <br />
    <p>Email Suporte Técnico: unnamed.suporte@gmail.com</p>
    <asp:Button ID="bttVoltar" runat="server" Text="Voltar" OnClick="bttVoltar_Click" CssClass="bttVoltar" />
</asp:Content>
