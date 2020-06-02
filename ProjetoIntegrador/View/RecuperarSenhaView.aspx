<%@ Page Title="Recuperar Senha" Language="C#" MasterPageFile="~/View/_LayoutLogin.Master" AutoEventWireup="true" CodeBehind="RecuperarSenhaView.aspx.cs" Inherits="ProjetoIntegrador.View.RecuperarSenhaView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" type="image/png" href="https://i.imgur.com/0QEPNLa.png" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lbltitulo" runat="server" Text="Bem-vindo(a)" CssClass="tmnLbl"></asp:Label>
    <br />
    <asp:Label ID="lblDescricao" runat="server" Text="Recuperação de Senha" CssClass="lblEmailLogin"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Digite seu Email ou Usuario:" CssClass="lblLogin"></asp:Label>
    <br />
    <asp:TextBox runat="server" ID="txtEmail" CssClass="txtLogin"></asp:TextBox>
    <br />
    <asp:Label ID="lblAviso" runat="server" Text="" CssClass="lblAviso"></asp:Label>
    <br />
    <asp:Panel ID="pnlChcemail" runat="server">
        <asp:Label ID="lblEscolha" runat="server" Text="Escolha para qual email enviar:"></asp:Label>
        <asp:CheckBoxList ID="chcEmail" runat="server" OnSelectedIndexChanged="chcEmail_SelectedIndexChanged" AutoPostBack="True"></asp:CheckBoxList>
    </asp:Panel>
    <br />
    <div class="divButtons">
        <asp:Button ID="bttEnviar" runat="server" Text="Enviar" CssClass="Button cursor shadow font" OnClick="bttEnviar_Click" />
        <asp:Button ID="bttVoltar" runat="server" Text="Voltar" CssClass="Button cursor shadow font" OnClick="bttVoltar_Click" />
    </div>
</asp:Content>
