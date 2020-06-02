<%@ Page Title="" Language="C#" MasterPageFile="~/View/_LayoutPaginaAssistente.Master" AutoEventWireup="true" CodeBehind="CadastrarDadosSegurancaView.aspx.cs" Inherits="ProjetoIntegrador.View.CadastrarDadosSegurancaView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divTitulo">
        <asp:Label ID="lblTituloPagina" runat="server" Text="Dados de Segurança"></asp:Label>
    </div>
    <div class="divFormatoPagina">
        <div class="divFormulario">
            <div class="divCamposFormulario">
                <asp:Label ID="lblTelefone" runat="server" Text="Telefone de Recuperação:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtTelefone" runat="server" placeholder="Telefone" autocomplete="off" CssClass="estiloTextbox" TextMode="Phone" title="Formato: 99888887777"></asp:TextBox>
                <br />
                <asp:Label ID="lblAvisoTelefone" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
            <div class="divCamposFormulario">
                <asp:Label ID="lblEmail" runat="server" Text="Email de Recuperação:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" autocomplete="off" CssClass="estiloTextbox" TextMode="Email"></asp:TextBox>
                <br />
                <asp:Label ID="lblAvisoEmail" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
        </div>
    </div>
    <div class="divFuncoes">
        <div class="divFuncao">
            <asp:Button ID="bttVoltar" runat="server" Text="Voltar" CssClass="estiloButton" OnClick="bttVoltar_Click" />
            <asp:Button ID="bttProximo" runat="server" Text="Próximo" CssClass="estiloButton" OnClick="bttProximo_Click" />
            <asp:Button ID="bttPular" runat="server" Text="Pular" CssClass="estiloButton" OnClick="bttPular_Click" />
        </div>
    </div>
</asp:Content>
