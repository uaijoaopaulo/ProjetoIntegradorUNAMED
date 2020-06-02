<%@ Page Title="" Language="C#" MasterPageFile="~/View/_LayoutLogin.Master" AutoEventWireup="true" CodeBehind="SenhaView.aspx.cs" Inherits="ProjetoIntegrador.View.SenhaView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lbltitulo" runat="server" Text="Bem-vindo(a)" CssClass="tmnLbl"></asp:Label>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text=" " CssClass="lblEmailLogin"></asp:Label>
    <br />
    <asp:Label ID="lblSenha" runat="server" Text="Digite Sua Senha:" CssClass="lblLogin"></asp:Label>
    <br />
    <asp:TextBox runat="server" ID="txtSenha" CssClass="txtLogin" TextMode="Password" placeholder="Senha"></asp:TextBox>
    <br />
    <asp:Label ID="lblAviso" runat="server" Text="" CssClass="lblAviso"></asp:Label>
    <br />
    <div class="divButtons">
        <asp:Button ID="bttLogin" runat="server" Text="Fazer Login" CssClass="Button cursor shadow font" OnClick="bttLogin_Click" />
        <asp:Button ID="bttVoltar" runat="server" Text="Voltar" CssClass="Button cursor shadow font" OnClick="bttVoltar_Click" />
        <asp:Button ID="bttEsqueceuSenha" runat="server" Text="Esqueceu a senha?" CssClass="Button cursor shadow font" OnClick="bttEsqueceuSenha_Click" />
    </div>
</asp:Content>
