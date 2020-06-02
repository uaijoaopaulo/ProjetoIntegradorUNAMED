using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoIntegrador.Model;
using ProjetoIntegrador.Repository;

namespace ProjetoIntegrador.View
{
    public partial class PerfilView : System.Web.UI.Page
    {
        PostRepository PR = new PostRepository();
        UsuarioRepository UR = new UsuarioRepository();
        FollowUsuarioRepository FUR = new FollowUsuarioRepository();
        ComentarioRepository CR = new ComentarioRepository();
        SobreRepository SR = new SobreRepository();
        usuario UsuarioPerfil, UsuarioAtual;

        protected void Page_Load(object sender, EventArgs e)
        {

            UsuarioAtual = (usuario)Session["UsuarioAtual"];

            if (Session["UsuarioPerfil"] != null)
            {
                UsuarioPerfil = UR.GetOne((int)Session["UsuarioPerfil"]);
                if (!Page.IsPostBack)
                {
                    CriaPerfil();

                }
            }
            else if (Session["UsuarioAtual"] != null)
            {
                UsuarioPerfil = (usuario)Session["UsuarioAtual"];
                if (!Page.IsPostBack)
                {
                    CriaPerfil();
                }
            }
            if (!Page.IsPostBack)
            {
                Session["jsPesquisaAtivo"] = false;
                Session["sobreAtivo"] = false;
            }
            if (string.IsNullOrEmpty(UsuarioPerfil.linkfoto))
            {
                imgPerfil.ImageUrl = "https://i.imgur.com/6BPMqMa.png";
            }
            else
            {
                imgPerfil.ImageUrl = UsuarioPerfil.linkfoto;
            }
            this.Page.Title = UsuarioPerfil.nicknameusuario + " - unNamed";
            bttEnviarMensagem.Enabled = false;
        }
        public void CriaPerfil()
        {
            imgPerfil.ImageUrl = UsuarioPerfil.linkfoto;
            lblNomePerfil.Text = UsuarioPerfil.nomeusuario;
            lblNickname.Text = UsuarioPerfil.nicknameusuario;

            CriaTimeline();
            verificaperfil();

        }
        public void verificaperfil()
        {
            List<post> contadorpost = PR.GetAllById(UsuarioPerfil.id_usuario);
            lblQntpost.Text = contadorpost.Count.ToString();
            List<comentario> contadorcomentario = CR.GetAllByIdPerfil(UsuarioPerfil.id_usuario);
            lblQntcomentarios.Text = contadorcomentario.Count.ToString();
            List<followusuario> contadorseguido = FUR.GetAllSeguido(UsuarioPerfil.id_usuario);
            lblQntFollow.Text = contadorseguido.Count.ToString();
            List<followusuario> contadorseguindo = FUR.GetAllById(UsuarioPerfil.id_usuario);
            lblQntfollowing.Text = contadorseguindo.Count.ToString();

            if (UsuarioPerfil.id_usuario == UsuarioAtual.id_usuario)
            {
                bttEnviarMensagem.Attributes.Add("style", "Display: none");
                bttSeguir.Attributes.Add("style", "Display: none");
                bttEditarPerfil.Attributes.Add("style", "Display: unset");
            }
            else
            {
                bttEditarPerfil.Attributes.Add("style", "Display: none");
                followusuario verificafollowusuario = FUR.GetOne(UsuarioAtual.id_usuario, UsuarioPerfil.id_usuario);
                if (verificafollowusuario == null)
                {
                    bttEnviarMensagem.Attributes.Add("style", "Display: none");
                    bttSeguir.Enabled = true;
                    bttSeguir.Text = "Seguir";
                    bttSeguir.Attributes.Add("style", "Background-color: #a800ff");
                }
                else
                {
                    bttEnviarMensagem.Enabled = true;
                    bttSeguir.Enabled = true;
                    bttSeguir.Text = "Seguindo";
                    bttSeguir.Attributes.Add("style", "Background-color: #000000");
                    bttEnviarMensagem.Attributes.Add("style", "Display: inline-block");
                }
            }
            sobre Sobre = SR.GetOne(UsuarioPerfil.id_usuario);
            if (Sobre == null)
            {
                bttSobre.Enabled = false;
                bttSobre.Attributes.Add("Title", "Usuario ainda não adicionou dados adicionais!");
            }
            else
            {
                lblDataNascimento.Text = lblDataNascimento.Text.Replace("#ano", Sobre.datanascimento.ToString("MM/yyyy"));

                if (Sobre.genero == null)
                    lblGenero.Text = "";
                else
                    lblGenero.Text = lblGenero.Text.Replace("#genero", Sobre.genero);

                if (Sobre.relacionamento == null)
                    lblRelacionamento.Text = "";
                else
                    lblRelacionamento.Text = lblRelacionamento.Text.Replace("#relacionamento", Sobre.relacionamento);

                if (Sobre.biografia == null)
                    lblBiografia.Text = "";
                else
                    lblBiografia.Text = lblBiografia.Text.Replace("#biografia", Sobre.biografia);
            }
        }

        protected void bttSeguir_Click(object sender, EventArgs e)
        {
            followusuario verificafollowusuario = FUR.GetOne(UsuarioAtual.id_usuario, UsuarioPerfil.id_usuario);
            if (verificafollowusuario == null)
            {
                verificafollowusuario = new followusuario();
                verificafollowusuario.id_usuario = UsuarioAtual.id_usuario;
                verificafollowusuario.usuario_id_usuario = UsuarioPerfil.id_usuario;
                verificafollowusuario.datafollow = DateTime.Now;
                FUR.Salvar(verificafollowusuario);
            }
            else
            {
                FUR.Delete(verificafollowusuario);
            }
            verificaperfil();
        }

        public void CriaTimeline()
        {
            DataTable table = new DataTable();
            table.Columns.Add("TempoPostagem");
            table.Columns.Add("DataPostagem");
            table.Columns.Add("NomeUsuario");
            table.Columns.Add("NicknameUsuario");
            table.Columns.Add("LinkfotoUsuario");
            table.Columns.Add("ConteudoPost");
            table.Columns.Add("id_usuario");
            table.Columns.Add("iddopost");
            List<post> lista = PR.GetAllById(UsuarioPerfil.id_usuario);
            for (int i = 0; i < lista.Count; i++)
            {
                DataRow datarow = table.NewRow();
                datarow["TempoPostagem"] = DateTime.Now.ToBinary() - lista[i].datapostagem.ToBinary();
                datarow["DataPostagem"] = lista[i].datapostagem.ToString("dd/MM/yyyy HH:mm");
                datarow["id_usuario"] = lista[i].id_usuario;
                datarow["iddopost"] = lista[i].id_post;
                datarow["ConteudoPost"] = lista[i].contentpost;
                usuario Usuario = UR.GetOne(lista[i].id_usuario);
                if (Usuario != null)
                {
                    datarow["NicknameUsuario"] = Usuario.nicknameusuario;
                    datarow["NomeUsuario"] = Usuario.nomeusuario;
                    datarow["LinkfotoUsuario"] = Usuario.linkfoto;
                    table.Rows.Add(datarow);
                }
            }
            if (table.Rows.Count == 0)
            {
                DataRow datarow = table.NewRow();
                datarow["TempoPostagem"] = DateTime.Now - DateTime.Now;
                datarow["DataPostagem"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                datarow["id_usuario"] = 0;
                datarow["iddopost"] = 0;
                if (UsuarioPerfil.id_usuario == UsuarioAtual.id_usuario)
                {
                    datarow["ConteudoPost"] = "Tudo vazio por aqui! Poste Algo!";
                }
                else
                {
                    datarow["ConteudoPost"] = "Tudo vazio por aqui! Este Usuario ainda não postou nada! :(";
                }
                datarow["NomeUsuario"] = "... ... hmm";
                datarow["NicknameUsuario"] = "'-'";
                datarow["LinkfotoUsuario"] = "https://i.imgur.com/x68EUuw.png";
                table.Rows.Add(datarow);
            }
            DataView dv = new DataView(table);
            dv.Sort = ("TempoPostagem DESC");
            rptPostagem.DataSource = dv.ToTable();
            rptPostagem.DataBind();
        }

        public void CriaComentario(int idpost)
        {
            DataTable table = new DataTable();
            table.Columns.Add("TempoComentario");
            table.Columns.Add("DataComentario");
            table.Columns.Add("NomeUsuario");
            table.Columns.Add("NicknameUsuario");
            table.Columns.Add("LinkfotoUsuario");
            table.Columns.Add("ConteudoComentario");
            table.Columns.Add("id_usuario");
            table.Columns.Add("iddopost");
            table.Columns.Add("iddocomentario");

            List<comentario> listacomentario = CR.GetAllById(idpost);

            for (int lc = 0; lc < listacomentario.Count; lc++)
            {
                usuario UsuarioComentario = UR.GetOne(listacomentario[lc].id_usuarioremetente);
                if (UsuarioComentario != null)
                {
                    DataRow datarow = table.NewRow();
                    datarow["TempoComentario"] = DateTime.Now.ToBinary() - listacomentario[lc].datacomentario.ToBinary();
                    datarow["DataComentario"] = listacomentario[lc].datacomentario.ToString("dd/MM/yyyy HH:mm");
                    datarow["id_usuario"] = UsuarioComentario.id_usuario;
                    datarow["iddopost"] = idpost;
                    datarow["ConteudoComentario"] = listacomentario[lc].comentariocontent;
                    datarow["NomeUsuario"] = UsuarioComentario.nomeusuario;
                    datarow["NicknameUsuario"] = UsuarioComentario.nicknameusuario;
                    datarow["LinkfotoUsuario"] = UsuarioComentario.linkfoto;
                    table.Rows.Add(datarow);
                }
            }
            DataView dv = new DataView(table);
            dv.Sort = ("TempoComentario ASC");
            rptComentario.DataSource = dv.ToTable();
            rptComentario.DataBind();
        }
        protected void PerfilUsuario_Command(object sender, CommandEventArgs e)
        {
            if (int.Parse(e.CommandArgument.ToString()) != 0)
            {
                Session["UsuarioPerfil"] = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("~/View/PerfilView.aspx");
            }
        }
        protected void bttComentar_Command(object sender, CommandEventArgs e)
        {
            if (int.Parse(e.CommandArgument.ToString()) != 0)
            {
                pnlComentario.Attributes.Add("style", "Display: flex");
                Session["idpostaberto"] = int.Parse(e.CommandArgument.ToString());
                post Postagem = PR.GetOne((int)Session["idpostaberto"]);
                followusuario Seguindo = FUR.GetOne(UsuarioAtual.id_usuario, Postagem.id_usuario);
                usuario Usuario = UR.GetOne(Postagem.id_usuario);
                txtComentario.Text = "";
                txtComentario.Enabled = true;
                bttPostaComentario.Enabled = true;

                if (Seguindo == null && Postagem.id_usuario != UsuarioAtual.id_usuario)
                {
                    txtComentario.Text = "Você não segue " + Usuario.nicknameusuario + " para comentar em seu post!";
                    txtComentario.Enabled = false;
                    bttPostaComentario.Enabled = false;
                }

                DataTable table = new DataTable();
                table.Columns.Add("DataPostagem");
                table.Columns.Add("NomeUsuario");
                table.Columns.Add("NicknameUsuario");
                table.Columns.Add("LinkfotoUsuario");
                table.Columns.Add("ConteudoPost");
                table.Columns.Add("id_usuario");

                DataRow datarow = table.NewRow();
                datarow["id_usuario"] = Postagem.id_usuario;
                datarow["DataPostagem"] = Postagem.datapostagem;
                datarow["ConteudoPost"] = Postagem.contentpost;
                datarow["NomeUsuario"] = Usuario.nomeusuario;
                datarow["NicknameUsuario"] = Usuario.nicknameusuario;
                datarow["LinkfotoUsuario"] = Usuario.linkfoto;
                table.Rows.Add(datarow);

                rptPostComentario.DataSource = table;
                rptPostComentario.DataBind();

                CriaComentario(int.Parse(e.CommandArgument.ToString()));
            }
        }

        protected void imgbttFecharComentarios_Click(object sender, ImageClickEventArgs e)
        {
            pnlComentario.Attributes.Add("style", "Display: none");
            Session.Remove("idpostaberto");
        }

        protected void imgExcluiPost_Command(object sender, CommandEventArgs e)
        {
            post Post = PR.GetOne(int.Parse(e.CommandArgument.ToString()));
            if (Post.id_usuario == UsuarioAtual.id_usuario)
            {
                List<comentario> listacomentario = CR.GetAllById(Post.id_post);
                if (listacomentario.Count > 0)
                {
                    for (int i = 0; i < listacomentario.Count; i++)
                    {
                        CR.Delete(listacomentario[i].id_comentario);
                    }
                }
                PR.Delete(Post.id_post);
                CriaTimeline();
            }
        }

        protected void bttEditarPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CadastrarUsuarioView.aspx");
        }

        protected void bttSobre_Click(object sender, EventArgs e)
        {
            if ((bool)Session["sobreAtivo"] == false)
            {
                pnlAreaSobre.BorderStyle = BorderStyle.Outset;
                pnlAreaSobre.Attributes.Add("style", "display: inline-grid");
                Session["sobreAtivo"] = true;
            }
            else
            {
                pnlAreaSobre.BorderStyle = BorderStyle.None;
                pnlAreaSobre.Attributes.Add("style", "display: none");
                Session["sobreAtivo"] = false;
            }

        }

        protected void rptPostagem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ImageButton deleta = (ImageButton)e.Item.FindControl("imgExcluiPost");
            if (UsuarioPerfil.id_usuario == UsuarioAtual.id_usuario)
            {
                deleta.Visible = true;
                deleta.Enabled = true;
            }
            else
            {
                deleta.Visible = false;
                deleta.Enabled = false;
            }
        }

        protected void bttPostaComentario_Command(object sender, CommandEventArgs e)
        {
            if (txtComentario.Text != "")
            {
                comentario Comentario = new comentario();
                Comentario.id_post = (int)Session["idpostaberto"];
                Comentario.id_usuarioremetente = UsuarioAtual.id_usuario;
                Comentario.comentariocontent = txtComentario.Text;
                Comentario.datacomentario = DateTime.Now;
                CR.Salvar(Comentario);

                txtComentario.Text = "";
            }
            CriaComentario((int)Session["idpostaberto"]);
        }
    }
}