<%@ Page Title="" Language="C#" MasterPageFile="~/View/_LayoutPrincipal.Master" AutoEventWireup="true" CodeBehind="PerfilView.aspx.cs" Inherits="ProjetoIntegrador.View.PerfilView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Style/JavaScriptPaginaPrincipal.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                        <br />
                                        <asp:Label ID="lblDataPostagem" runat="server" Text='<%# Eval("DataPostagem")%>' CssClass="dataPost"></asp:Label>
                                    </asp:LinkButton>
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
                <asp:Repeater ID="rptComentario" runat="server" ValidateRequestMode="Enabled">
                    <ItemTemplate>
                        <asp:Panel ID="pnlComentarioBox" runat="server" CssClass="comentarioBox font">
                            <div id="HeaderComentario">
                                <div id="box" class="boxHeader">
                                    <asp:ImageButton ID="imgPerfilPost" runat="server" ImageUrl='<%# Eval("LinkfotoUsuario") %>' CssClass="imgPostagemPerfil" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" />
                                    <div>
                                        <asp:LinkButton ID="lnkUsuarioComentario" runat="server" CommandArgument='<%#Eval("id_usuario") %>' OnCommand="PerfilUsuario_Command" CssClass="lnkPerfil">
                                            <asp:Label ID="lblNome" runat="server" Text='<%# Eval("NomeUsuario") + " (" + Eval("NicknameUsuario") + ")" %>'></asp:Label>
                                        </asp:LinkButton>
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
    <div class="areaPerfil1 font">
        <div>
            <asp:Image ID="imgPerfil" runat="server" CssClass="imgdoPerfil" />
        </div>
        <div class="areaPerfil2 font">
            <asp:Label ID="lblNickname" runat="server" Text="" CssClass="lblNickname"></asp:Label>
            <asp:Button ID="bttSeguir" runat="server" Text="" CssClass="BttsPerfil" OnClick="bttSeguir_Click" />
            <asp:Button ID="bttEnviarMensagem" runat="server" Text="Enviar Mensagem" CssClass="BttsPerfil" />
            <asp:Button ID="bttEditarPerfil" runat="server" Text="Editar Perfil" CssClass="BttsPerfil" OnClick="bttEditarPerfil_Click" />
            <asp:Button ID="bttSobre" runat="server" Text="Sobre" CssClass="BttsPerfil" OnClick="bttSobre_Click" />
        </div>
        <div class="areaDescricoes">
            <asp:Label ID="lblNomePerfil" runat="server" Text="" CssClass="nomePerfil"></asp:Label>
            <div class="GrupoDescricoes">
                <div class="Descricoes">
                    <asp:Label ID="lblDSqntpost" runat="server" Text="Postagens:"></asp:Label>
                    <br />
                    <asp:Label ID="lblQntpost" runat="server" Text=""></asp:Label>
                </div>
                <div class="Descricoes">
                    <asp:Label ID="lblDSqntcomentarios" runat="server" Text="Comentarios:"></asp:Label>
                    <br />
                    <asp:Label ID="lblQntcomentarios" runat="server" Text=""></asp:Label>
                </div>
                <div class="Descricoes">
                    <asp:Label ID="lblDSqntfollow" runat="server" Text="Seguidores:"></asp:Label>
                    <br />
                    <asp:Label ID="lblQntFollow" runat="server" Text=""></asp:Label>
                </div>
                <div class="Descricoes">
                    <asp:Label ID="lblDSqntfollowing" runat="server" Text="Seguindo:"></asp:Label>
                    <br />
                    <asp:Label ID="lblQntfollowing" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="pdtSobre" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="bttSobre" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:Panel ID="pnlAreaSobre" runat="server" CssClass="AreaSobre">
                    <asp:Label ID="lblDataNascimento" runat="server" Text="Ano Nascimento: #ano"></asp:Label>
                    <br />
                    <asp:Label ID="lblGenero" runat="server" Text="Gênero: #genero"></asp:Label>
                    <br />
                    <asp:Label ID="lblRelacionamento" runat="server" Text="Relacionamento: #relacionamento"></asp:Label>
                    <br />
                    <asp:Label ID="lblBiografia" runat="server" Text="Biografia: #biografia"></asp:Label>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:Repeater ID="rptPostagem" runat="server" ValidateRequestMode="Enabled" OnItemDataBound="rptPostagem_ItemDataBound">
        <ItemTemplate>
            <asp:Panel ID="pnlPostagemBox" runat="server" CssClass="postagemBox font">
                <div id="HeaderPostagem">
                    <div id="box" class="boxHeader">
                        <asp:Image ID="imgPost" runat="server" ImageUrl='<%# Eval("LinkfotoUsuario") %>' CssClass="imgPostagemPerfil" />
                        <div class="divHeader">
                            <asp:Label ID="lblNome" runat="server" Text='<%# Eval("NomeUsuario") + " (" + Eval("NicknameUsuario") + ")" %>'></asp:Label>
                            <div class="divHeader2">
                                <asp:ImageButton ID="imgExcluiPost" runat="server" CssClass="bttExcluiPost" ImageUrl="https://i.imgur.com/KrOjclG.png" CommandArgument='<%#Eval("iddopost") %>' OnCommand="imgExcluiPost_Command" />
                            </div>
                            <br />
                            <asp:Label ID="lblDataPostagem" runat="server" Text='<%#Eval("DataPostagem")%>' CssClass="dataPost"></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="BodyPostagem" class="bodyPostagem">
                    <%# Eval("ConteudoPost") %>
                </div>
                <div id="FunctionPostagem" class="funcaoPostagem">
                    <asp:Button ID="bttComentar" runat="server" Text="Comentar" CssClass="bttComentar" CommandArgument='<%#Eval("iddopost") %>' OnCommand="bttComentar_Command" />
                </div>
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
