<%@ Page Title="Cadastro unNamed" Language="C#" MasterPageFile="~/View/_LayoutPaginaAssistente.Master" AutoEventWireup="true" CodeBehind="CadastrarUsuarioView.aspx.cs" Inherits="ProjetoIntegrador.View.CadastrarUsuarioView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divTitulo">
        <asp:Label ID="lblTituloPagina" runat="server" Text=""></asp:Label>
    </div>
    <div class="divFormatoPagina">
        <div class="divFormulario">
            <div class="divCamposFormulario">
                <asp:Label ID="lblNome" runat="server" Text="Nome:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" autocomplete="off" CssClass="estiloTextbox"></asp:TextBox>
                <br />
                <asp:Label ID="lblAvisoNome" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
            <div class="divCamposFormulario">
                <asp:Label ID="lblNick" runat="server" Text="Nickname:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtNick" runat="server" placeholder="Nickname" autocomplete="off" CssClass="estiloTextbox"></asp:TextBox>
                <br />
                <asp:Label ID="lblAvisoNick" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
            <div class="divCamposFormulario">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" autocomplete="off" CssClass="estiloTextbox" TextMode="Email"></asp:TextBox>
                <br />
                <asp:Label ID="lblAvisoEmail" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
            <div class="divCamposFormulario">
                <asp:Label ID="lblConfirmaemail" runat="server" Text="Confirme o Email:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtConfirmaemail" runat="server" placeholder="Email" autocomplete="off" CssClass="estiloTextbox" TextMode="Email"></asp:TextBox>
                <br />
                <asp:Label ID="lblAvisoConfirmaEmail" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
            <div class="divCamposFormulario">
                <asp:Label ID="lblSenha" runat="server" Text="Senha:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" autocomplete="off" CssClass="estiloTextbox" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Label ID="lblAvisoSenha" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
            <div class="divCamposFormulario">
                <asp:Label ID="lblConfirmaSenha" runat="server" Text="Senha:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:TextBox ID="txtConfirmaSenha" runat="server" placeholder="Confirmar Senha" AutoComplete="off" CssClass="estiloTextbox" TextMode="Password"></asp:TextBox>
                <%--<div class="divForcaSenha">
                    <asp:Panel ID="NivelSenha" runat="server" CssClass="pnlNivelSenha"></asp:Panel>
                    <asp:Label ID="lblForcaSenha" runat="server" Text="Força da Senha:" CssClass="estiloLabel"></asp:Label>
                    <asp:Label ID="lblNivelSenha" runat="server" Text="~Neutro" CssClass="estiloLabel"></asp:Label>
                </div>--%>
                <br />
                <asp:Label ID="lblAvisoConfirmaSenha" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
            </div>
        </div>
        <div class="divFoto">
            <asp:Label ID="lblFoto1" runat="server" Text="Arraste ou Clique" CssClass="estiloLabel"></asp:Label>
            <br />
            <asp:Label ID="lblFoto2" runat="server" Text="abaixo para adicionar uma foto:" CssClass="estiloLabel"></asp:Label>
            <br />
            <asp:FileUpload ID="flpFotoPerfil" runat="server" CssClass="file-upload" />
        </div>
    </div>
    <div class="divFuncoes">
        <div class="divFuncao">
            <asp:Button ID="bttVoltar" runat="server" Text="Voltar" CssClass="estiloButton" OnClick="bttVoltar_Click" />
            <asp:Button ID="bttProximo" runat="server" Text="Próximo" CssClass="estiloButton" OnClick="bttProximo_Click" />
        </div>
    </div>
</asp:Content>

