<%@ Page Title="" Language="C#" MasterPageFile="~/View/_LayoutPaginaAssistente.Master" AutoEventWireup="true" CodeBehind="CadastrarSobreUsuarioView.aspx.cs" Inherits="ProjetoIntegrador.View.CadastrarSobreUsuarioView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divTitulo">
        <asp:Label ID="lblTituloPagina" runat="server" Text="Sobre Você"></asp:Label>
    </div>
    <div class="divFormatoPagina">
        <div class="divFormularioSobre">
            <asp:Label ID="lblDataNascimento" runat="server" Text="Data de nascimento:" CssClass="estiloLabel"></asp:Label>
            <asp:UpdatePanel ID="updCalndario" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtclnDatanascimento" runat="server" TextMode="Date" CssClass="estiloTextbox"></asp:TextBox>
                    <%--<asp:Calendar ID="clnDatanascimento" runat="server" CssClass="estiloCalendario" TitleFormat="Month"></asp:Calendar>--%>
                    <br />
                    <asp:Label ID="lblAvisoCalendario" runat="server" Text="" CssClass="estiloLabelAviso"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="divFormularioSobre">
            <div class="divCamposFormulario">
                <asp:Label ID="lblGenero" runat="server" Text="Gênero:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:DropDownList ID="drpGenero" runat="server" CssClass="estiloTextbox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Outros</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <br />
            <div class="divCamposFormulario">
                <asp:Label ID="lblRelacionamento" runat="server" Text="Relacionamento:" CssClass="estiloLabel"></asp:Label>
                <br />
                <asp:DropDownList ID="drpRelacionamento" runat="server" CssClass="estiloTextbox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Solteiro(a)</asp:ListItem>
                    <asp:ListItem>Casado(a)</asp:ListItem>
                    <asp:ListItem>Separado(a)</asp:ListItem>
                    <asp:ListItem>Divorciado(a)</asp:ListItem>
                    <asp:ListItem>Viúvo(a)</asp:ListItem>
                    <asp:ListItem>União estável</asp:ListItem>
                    <asp:ListItem>Namorando</asp:ListItem>
                    <asp:ListItem>Com uns rolo ae</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="divFormularioSobre">
            <asp:Label ID="lblBiografia" runat="server" Text="Biografia:" CssClass="estiloLabel"></asp:Label>
            <br />
            <asp:TextBox ID="txtBiografia" runat="server" TextMode="MultiLine" placeholder="Biografia" autocomplete="off" CssClass="estiloCampoBiografia"></asp:TextBox>
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
