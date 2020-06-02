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
    public partial class DescobrimentoLocalView : System.Web.UI.Page
    {
        //static int idpostaberto;
        double lat, lon, distancia;
        UsuarioRepository UR = new UsuarioRepository();
        FollowUsuarioRepository FUR = new FollowUsuarioRepository();
        ComentarioRepository CR = new ComentarioRepository();
        usuario UsuarioAtual;
        PostRepository PR = new PostRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioAtual = (usuario)Session["UsuarioAtual"];
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioPerfil"] != null)
                {
                    Session.Remove("UsuarioPerfil");
                }

                if (UsuarioAtual == null)
                {
                    Response.Redirect("~/View/EmailView.aspx");
                }
                distancia = 5000;
                CriaTimeline();
                lat = (double)Session["LatitudeAtual"];
                lon = (double)Session["LongitudeAtual"];
            }
        }

        public void CriaTimeline()
        {
            if (txtDistancia.Text != "")
                distancia = double.Parse(txtDistancia.Text) * 1000;

            DataTable table = new DataTable();
            table.Columns.Add("TempoPostagem");
            table.Columns.Add("DataPostagem");
            table.Columns.Add("NomeUsuario");
            table.Columns.Add("NicknameUsuario");
            table.Columns.Add("LinkfotoUsuario");
            table.Columns.Add("ConteudoPost");
            table.Columns.Add("id_usuario");
            table.Columns.Add("iddopost");

            lat = (double)Session["LatitudeAtual"];
            lon = (double)Session["LongitudeAtual"];

            List<post> lista = PR.GetAllByLocation(lat, lon, distancia);

            for (int i = 0; i < lista.Count; i++)
            {
                DataRow datarow = table.NewRow();
                datarow["TempoPostagem"] = DateTime.Now.ToBinary() - lista[i].datapostagem.ToBinary();
                datarow["DataPostagem"] = lista[i].datapostagem.ToString("dd/MM/yyyy HH:mm");
                datarow["iddopost"] = lista[i].id_post;
                datarow["ConteudoPost"] = lista[i].contentpost;
                usuario UsuarioPost = UR.GetOne(lista[i].id_usuario);
                datarow["id_usuario"] = UsuarioPost.id_usuario;
                datarow["NomeUsuario"] = UsuarioPost.nomeusuario;
                datarow["NicknameUsuario"] = UsuarioPost.nicknameusuario;
                datarow["LinkfotoUsuario"] = UsuarioPost.linkfoto;
                table.Rows.Add(datarow);
            }
            if (table.Rows.Count == 0)
            {
                DataRow datarow = table.NewRow();
                datarow["TempoPostagem"] = DateTime.Now.ToBinary() - DateTime.Now.ToBinary();
                datarow["DataPostagem"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                datarow["id_usuario"] = 0;
                datarow["iddopost"] = 0;
                datarow["ConteudoPost"] = "Não achamos nada na sua Região!";
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

        /*public void CriaComentario(int idpost)
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

            DataView dvc = new DataView(table);
            dvc.Sort = ("TempoComentario ASC");
            rptComentario.DataSource = dvc.ToTable();
            rptComentario.DataBind();
        }*/

        protected void PerfilUsuario_Command(object sender, CommandEventArgs e)
        {
            if (int.Parse(e.CommandArgument.ToString()) != 0)
            {
                Session["UsuarioPerfil"] = int.Parse(e.CommandArgument.ToString());
                Session.Remove("idpostaberto");
                Response.Redirect("~/View/PerfilView.aspx");
            }
        }

        /*protected void bttComentar_Command(object sender, CommandEventArgs e)
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
                CriaComentario(int.Parse(e.CommandArgument.ToString()));
            }
        }*/

        /*protected void imgbttFecharComentarios_Click(object sender, ImageClickEventArgs e)
        {
            pnlComentario.Attributes.Add("style", "Display: none");
            Session.Remove("idpostaberto");
        }*/

        protected void bttAtualizar_Click(object sender, EventArgs e)
        {
            if (double.Parse(txtDistancia.Text) > 7)
                txtDistancia.Text = "7";
            if (double.Parse(txtDistancia.Text) < 1)
                txtDistancia.Text = "1";
            CriaTimeline();
        }

        /*protected void bttPostaComentario_Command(object sender, CommandEventArgs e)
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
        }*/

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
                table.Columns.Add("id_post");

                DataRow datarow = table.NewRow();
                datarow["id_usuario"] = Postagem.id_usuario;
                datarow["DataPostagem"] = Postagem.datapostagem;
                datarow["ConteudoPost"] = Postagem.contentpost;
                datarow["NomeUsuario"] = Usuario.nomeusuario;
                datarow["NicknameUsuario"] = Usuario.nicknameusuario;
                datarow["LinkfotoUsuario"] = Usuario.linkfoto;
                datarow["id_post"] = Postagem.id_post;
                table.Rows.Add(datarow);

                rptPostComentario.DataSource = table;
                rptPostComentario.DataBind();

                CriaComentario(int.Parse(e.CommandArgument.ToString()));
            }
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
            table.Columns.Add("id_post");
            table.Columns.Add("id_comentario");

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
                    datarow["id_post"] = Session["idpostaberto"];
                    datarow["id_comentario"] = listacomentario[lc].id_comentario;
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
        protected void imgbttFecharComentarios_Click(object sender, ImageClickEventArgs e)
        {
            pnlComentario.Attributes.Add("style", "Display: none");
            Session.Remove("idpostaberto");
            Response.Redirect("~/View/DescobrimentoLocalView.aspx");
        }
        protected void imgExcluiComentario_Command(object sender, CommandEventArgs e)
        {
            comentario Comentario = CR.GetOne(int.Parse(e.CommandArgument.ToString()));
            post Postagem = PR.GetOne(Comentario.id_post);
            if (Comentario.id_usuarioremetente == UsuarioAtual.id_usuario || Postagem.id_usuario == UsuarioAtual.id_usuario)
            {
                CR.Delete(Comentario.id_comentario);
                //CriaTimeline();
                /*rptComentario.DataBind();
                rptPostagem.DataBind();*/
                CriaComentario(Postagem.id_post);
            }
        }

        protected void rptComentario_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ImageButton deleta = (ImageButton)e.Item.FindControl("imgExcluiComentario");
            LinkButton Link = (LinkButton)e.Item.FindControl("lnkUsuarioComentario");

            if (int.Parse(Link.CommandArgument) == UsuarioAtual.id_usuario)
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
            //CriaComentario((int)Session["idpostaberto"]);
            /*rptComentario.DataBind();
            rptPostagem.DataBind();*/
            //CriaTimeline();
            CriaComentario((int)Session["idpostaberto"]);
        }
    }
}