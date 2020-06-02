<%@ Page Title="" Language="C#" MasterPageFile="~/View/_LayoutLogin.Master" AutoEventWireup="true" CodeBehind="EmailView.aspx.cs" Inherits="ProjetoIntegrador.View.EmailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbltitulo" runat="server" Text="Bem-vindo(a)" CssClass="tmnLbl"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Digite seu Email ou Usuário:" CssClass="lblLogin"></asp:Label>
    <br />
    <asp:TextBox runat="server" ID="txtEmail" CssClass="txtLogin" placeholder="Email ou Usuário"></asp:TextBox>
    <br />
    <asp:Label ID="lblAviso" runat="server" Text="" CssClass="lblAviso"></asp:Label>
    <br />
    <div class="divButtons">
        <asp:Button ID="bttProximo" runat="server" Text="Próximo" CssClass="Button cursor shadow font" OnClick="bttProximo_Click" />
        <asp:Button ID="bttRegistrar" runat="server" Text="Registrar-se" CssClass="Button cursor shadow font" OnClick="bttRegistrar_Click" />
        <asp:Button ID="bttEsqueceuSenha" runat="server" Text="Esqueceu a senha?" CssClass="Button cursor shadow font" OnClick="bttEsqueceuSenha_Click" />
    </div>
</asp:Content>
