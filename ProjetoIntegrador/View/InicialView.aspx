<%@ Page Title="unNamed - Tela Inicial" Language="C#" MasterPageFile="~/View/_LayoutPrincipal.Master" AutoEventWireup="true" CodeBehind="InicialView.aspx.cs" Inherits="ProjetoIntegrador.View.InicialView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlConfirmacao" runat="server" CssClass="BlockBoxConfirmacao font">
        <div class="divConfirmacao">
            <asp:Label ID="lblMensagemShow" runat="server" Text="#mensagem"></asp:Label>
            <br />
            <div class="divConfirmacaoButao">
                <asp:Button ID="bttSim" runat="server" Text="Sim" CssClass="botaoConfirmacao Sim" CommandArgument="true" OnCommand="Escolha_Command" />
                <asp:Button ID="bttNao" runat="server" Text="Não" CssClass="botaoConfirmacao Nao" CommandArgument="false" OnCommand="Escolha_Command" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlComentario" runat="server" CssClass="BlockBox font">
        <div class="ComentarioAreainterna">
            <asp:Label ID="lblComentarios" runat="server" Text="Comentários:" CssClass="tituloNotificacoes"></asp:Label>
            <asp:ImageButton ID="imgbttFecharComentarios" runat="server" ImageUrl="https://i.imgur.com/KrOjclG.png" CssClass="imgFechaComentarios" OnClick="imgbttFecharComentarios_Click" />
            <asp:Repeater ID="rptPostComentario" runat="server" ValidateRequestMode="Enabled">
                <ItemTemplate>
                    <asp:Panel ID="pnlPostagemBox" runat="server" CssClass="postagemBox font">
                        <div id="HeaderPostagem">
                            <div id="box" class="boxHeader">
                                <asp:ImageButton ID="imgPerfilPost" runat="server" ImageUrl='<%# Eval("LinkfotoUsuario") %>' CssClass="imgPostagemPerfil" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" />
                                <div>
                                    <asp:LinkButton ID="lnkUsuarioPostagem" runat="server" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" CssClass="lnkPerfil">
                                        <asp:Label ID="lblNome" runat="server" Text='<%# Eval("NomeUsuario") + " (" + Eval("NicknameUsuario") + ")" %>'></asp:Label>
                                    </asp:LinkButton>
                                    <br />
                                    <asp:Label ID="lblDataPostagem" runat="server" Text='<%# Eval("DataPostagem")%>' CssClass="dataPost"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div id="BodyPostagem" class="bodyPostagem">
                            <%# Eval("ConteudoPost") %>
                        </div>
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>
            <div class="AreaComentarios">
                <asp:Repeater ID="rptComentario" runat="server" ValidateRequestMode="Enabled" OnItemDataBound="rptComentario_ItemDataBound">
                    <ItemTemplate>
                        <asp:Panel ID="pnlComentarioBox" runat="server" CssClass="comentarioBox font">
                            <div id="HeaderComentario">
                                <div id="box" class="boxHeader">
                                    <asp:ImageButton ID="imgPerfilPost" runat="server" ImageUrl='<%# Eval("LinkfotoUsuario") %>' CssClass="imgPostagemPerfil" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" />
                                    <div class="divHeader">
                                        <asp:LinkButton ID="lnkUsuarioComentario" runat="server" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" CssClass="lnkPerfil">
                                            <asp:Label ID="lblNome" runat="server" Text='<%# Eval("NomeUsuario") + " (" + Eval("NicknameUsuario") + ")" %>'></asp:Label>
                                        </asp:LinkButton>
                                        <div class="divHeader2">
                                            <asp:ImageButton ID="imgExcluiComentario" runat="server" CssClass="bttExcluiPost" ImageUrl="https://i.imgur.com/KrOjclG.png" CommandArgument='<%# Eval("id_comentario") %>' OnCommand="imgExcluiComentario_Command" />
                                        </div>
                                        <br />
                                        <asp:Label ID="lblDataPostagem" runat="server" Text='<%#Eval("DataComentario")%>' CssClass="dataPost"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div id="BodyPostagem" class="bodyComentario">
                                <%# Eval("ConteudoComentario") %>
                            </div>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="AreaComentar">
                <asp:TextBox ID="txtComentario" runat="server" CssClass="txtNovoPostagem" TextMode="MultiLine" placeholder="Comente algo..." Rows="1"></asp:TextBox>
                <asp:Button ID="bttPostaComentario" runat="server" Text="Comentar" CssClass="bttNovoComentario" OnCommand="bttPostaComentario_Command" CommandArgument='<%# Eval("iddopost") %>' />
            </div>
        </div>
    </asp:Panel>
    <div class="areaPostagem">
        <asp:TextBox ID="txtPostagem" runat="server" CssClass="txtNovoPostagem" TextMode="MultiLine" placeholder="Poste algo hoje..." autocomplete="off" Rows="1"></asp:TextBox>
        <asp:Button ID="bttPostar" runat="server" Text="Postar" CssClass="bttNovoPost" OnClick="bttPostar_Click" />
    </div>
    <asp:Repeater ID="rptPostagem" runat="server" ValidateRequestMode="Enabled" OnItemDataBound="rptPostagem_ItemDataBound">
        <ItemTemplate>
            <div class="divPostTimeline">
                <asp:Panel ID="pnlPostagemBox" runat="server" CssClass="postagemBox font">
                    <div id="HeaderPostagem">
                        <div id="box" class="boxHeader">
                            <asp:ImageButton ID="imgPerfilPost" runat="server" ImageUrl='<%# Eval("LinkfotoUsuario") %>' CssClass="imgPostagemPerfil" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" />
                            <div class="divHeader">
                                <asp:LinkButton ID="lnkUsuarioPostagem" runat="server" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" CssClass="lnkPerfil">
                                    <asp:Label ID="lblNome" runat="server" Text='<%# Eval("NomeUsuario") + " (" + Eval("NicknameUsuario") + ")" %>'></asp:Label>
                                </asp:LinkButton>
                                <div class="divHeader2">
                                    <asp:ImageButton ID="imgExcluiPost" runat="server" CssClass="bttExcluiPost" ImageUrl="https://i.imgur.com/KrOjclG.png" CommandArgument='<%# Eval("id_post") %>' OnCommand="imgExcluiPost_Command" />
                                </div>
                                <br />
                                <asp:Label ID="lblDataPostagem" runat="server" Text='<%# Eval("DataPostagem")%>' CssClass="dataPost"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div id="BodyPostagem" class="bodyPostagem">
                        <%# Eval("ConteudoPost") %>
                    </div>
                    <div id="FunctionPostagem" class="funcaoPostagem">
                        <asp:Button ID="bttComentar" runat="server" Text="Comentar" CssClass="bttComentar" CommandArgument='<%#Eval("id_post") %>' OnCommand="bttComentar_Command" />
                    </div>
                </asp:Panel>
                <div class="AreaComentariosIV">
                    <asp:Repeater ID="rptComentarioPost" runat="server" ValidateRequestMode="Enabled" OnItemDataBound="rptComentarioPost_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel ID="pnlComentarioBox" runat="server" CssClass="comentarioBox font">
                                <div id="HeaderComentario">
                                    <div id="box" class="boxHeader">
                                        <asp:ImageButton ID="imgPerfilPost" runat="server" ImageUrl='<%# Eval("LinkfotoUsuario") %>' CssClass="imgPostagemPerfil" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" />
                                        <div class="divHeader">
                                            <asp:LinkButton ID="lnkUsuarioComentario" runat="server" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" CssClass="lnkPerfil">
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("NomeUsuario") + " (" + Eval("NicknameUsuario") + ")" %>'></asp:Label>
                                            </asp:LinkButton>
                                            <div class="divHeader2">
                                                <asp:ImageButton ID="imgExcluiComentario" runat="server" CssClass="bttExcluiPost" ImageUrl="https://i.imgur.com/KrOjclG.png" CommandArgument='<%# Eval("id_comentario") %>' OnCommand="imgExcluiComentario_Command" />
                                            </div>
                                            <br />
                                            <asp:Label ID="lblDataPostagem" runat="server" Text='<%#Eval("DataComentario")%>' CssClass="dataPost"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div id="BodyPostagem" class="bodyComentario">
                                    <%# Eval("ConteudoComentario") %>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
