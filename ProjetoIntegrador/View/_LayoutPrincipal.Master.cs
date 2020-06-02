using System;
using System.Collections;
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
    public partial class _LayoutPrincipal : System.Web.UI.MasterPage
    {
        //public static double LatitudeAtual, LongitudeAtual;
        //public static Boolean jsPesquisaAtivo = false, jsMensagemAtivo = false, jsNotificacaoAtivo = false, jsTimelineAtivo = false;
        MensagemRepository MR = new MensagemRepository();
        UsuarioMensagemRepository UMR = new UsuarioMensagemRepository();
        UsuarioRepository UR = new UsuarioRepository();
        NotificacaoRepository NR = new NotificacaoRepository();
        usuario UsuarioAtual;

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioAtual = (usuario)Session["UsuarioAtual"];

            if (UsuarioAtual == null)
            {
                Response.Redirect("~/View/EmailView.aspx");
            }
            else
            {
                lnkNomePerfil.Text = UsuarioAtual.nicknameusuario;
                if (string.IsNullOrEmpty(UsuarioAtual.linkfoto))
                {
                    imgPerfil.ImageUrl = "https://i.imgur.com/6BPMqMa.png";
                }
                else
                {
                    imgPerfil.ImageUrl = UsuarioAtual.linkfoto;
                }
            }

            if (!Page.IsPostBack)
            {
                //CarregaNotificacao();
                //OnClick = "javascript:clickAreaOpcoes()"
                imgNotificacao.Attributes.Add("OnClick", "javascript:clickNotificacaoButtom()");
                imgMensagem.Attributes.Add("OnClick", "javascript:clickMensagemButtom()");
                //lblunNamed.Attributes.Add("OnClick", "javascript:clickAreaOpcoes()");
                Session["jsPesquisaAtivo"] = false;
            }
        }
        public void CarregaMensagem()
        {
            DataTable tablemensagem = new DataTable();
            tablemensagem.Columns.Add("idRemetenteMensagem");
            tablemensagem.Columns.Add("idDestinatarioMensagem");
            tablemensagem.Columns.Add("DataMensagem");
            tablemensagem.Columns.Add("HoraMensagem");
            tablemensagem.Columns.Add("AnoMensagem");
            tablemensagem.Columns.Add("DataHoraAnoMensagem");
            tablemensagem.Columns.Add("NomeUsuarioMensagem");
            tablemensagem.Columns.Add("NicknameUsuarioMensagem");
            tablemensagem.Columns.Add("LinkfotoUsuarioMensagem");
            tablemensagem.Columns.Add("ConteudoMensagem");
            tablemensagem.Columns.Add("idMensagem");
            tablemensagem.Columns.Add("TempoMensagem");
            tablemensagem.Columns.Add("Visualizado");
            DataTable tablearruma = tablemensagem.Clone();
            List<usuariomensagem> listausuariomensagem = UMR.GetAll(UsuarioAtual.id_usuario, UsuarioAtual.id_usuario);
            List<mensagem> mensagemvelha = new List<mensagem>();
            if (0 == 0)
            {
                DataRow datarow = tablemensagem.NewRow();
                datarow["idRemetenteMensagem"] = 0;
                datarow["idDestinatarioMensagem"] = 0;
                datarow["Visualizado"] = true;
                datarow["TempoMensagem"] = DateTime.Now - DateTime.Now;
                datarow["DataMensagem"] = DateTime.Now.ToString("dd/MM");
                datarow["AnoMensagem"] = DateTime.Now.ToString("yyyy");
                datarow["HoraMensagem"] = DateTime.Now.ToString("HH:mm");
                datarow["DataHoraAnoMensagem"] = DateTime.Now;
                datarow["ConteudoMensagem"] = "Esta área ainda está em construção!";
                datarow["idMensagem"] = 0;
                datarow["LinkfotoUsuarioMensagem"] = "http://sistemapdv.com.br/site/img/ico-consulte.png";
                datarow["NicknameUsuarioMensagem"] = "Lamentamos";
                datarow["NomeUsuarioMensagem"] = "";
                tablemensagem.Rows.Add(datarow);
            }
            /*else
            {
                mensagem MensagemOld = new mensagem();
                for (int i = 0; i < listausuariomensagem.Count; i++)
                {
                    List<usuariomensagem> lista = UMR.GetAll(listausuariomensagem[i].id_usuarioremetente, listausuariomensagem[i].id_usuariodestinatario);
                    ArrayList Arraymensagem = new ArrayList();
                    for (int j = 0; j < lista.Count -1; j++)
                    {
                        Arraymensagem.Add(MR.GetOne(lista[i].id_mensagem));
                    }
                    for(int x = 0; x < Arraymensagem.Count; x++)
                    {
                        mensagem MensagemX = (mensagem)Arraymensagem[x];
                        for (int w = 0; w < Arraymensagem.Count; w++) 
                        {
                            mensagem MensagemW = (mensagem)Arraymensagem[w];
                            if (MensagemX.datamensagem.ToBinary() > MensagemW.datamensagem.ToBinary())
                            {
                                MensagemOld = MensagemX;
                            }
                        }
                        mensagemvelha.Add(MensagemOld);
                    }
                    /*usuario Usuario1 = UR.GetOne(listausuariomensagem[i].id_usuarioremetente);
                    usuario Usuario2 = UR.GetOne(listausuariomensagem[i].id_usuariodestinatario);
                    if (Usuario1 != null && Usuario2 != null)
                    {
                        DataRow datarow = tablemensagem.NewRow();
                        datarow["idRemetenteMensagem"] = listausuariomensagem[i].id_usuarioremetente;
                        datarow["idDestinatarioMensagem"] = listausuariomensagem[i].id_usuariodestinatario;
                        datarow["idMensagem"] = listausuariomensagem[i].id_mensagem;

                        if (listausuariomensagem[i].id_usuarioremetente == UsuarioAtual.id_usuario)
                        {
                            if (string.IsNullOrEmpty(Usuario2.linkfoto))
                            {
                                datarow["LinkfotoUsuarioMensagem"] = "https://i.imgur.com/6BPMqMa.png";
                            }
                            else
                            {
                                datarow["LinkfotoUsuarioMensagem"] = Usuario2.linkfoto;
                            }
                            datarow["NomeUsuarioMensagem"] = Usuario2.nomeusuario;
                            datarow["NicknameUsuarioMensagem"] = Usuario2.nicknameusuario;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(Usuario1.linkfoto))
                            {
                                datarow["LinkfotoUsuarioMensagem"] = "https://i.imgur.com/6BPMqMa.png";
                            }
                            else
                            {
                                datarow["LinkfotoUsuarioMensagem"] = Usuario1.linkfoto;
                            }
                            datarow["NomeUsuarioMensagem"] = Usuario1.nomeusuario;
                            datarow["NicknameUsuarioMensagem"] = Usuario1.nicknameusuario;
                        }

                        mensagem Mensagem = MR.GetOne(listausuariomensagem[i].id_mensagem);
                        
                        datarow["TempoMensagem"] = DateTime.Now.ToBinary() - Mensagem.datamensagem.ToBinary();
                        datarow["DataMensagem"] = Mensagem.datamensagem.ToString("dd/MM");
                        datarow["AnoMensagem"] = Mensagem.datamensagem.ToString("yyyy");
                        datarow["HoraMensagem"] = Mensagem.datamensagem.ToString("HH:mm");
                        datarow["DataHoraAnoMensagem"] = Mensagem.datamensagem;
                        datarow["Visualizado"] = Mensagem.visualizadomensagem;
                        datarow["ConteudoMensagem"] = Mensagem.contentmensagem;
                        tablemensagem.Rows.Add(datarow);
                    }*/
            //}
            /*for (int i = 0; i < mensagemvelha.Count; i++)
            {
                usuariomensagem UsuarioMensagem = UMR.getOne(mensagemvelha[i].id_mensagem);

                usuario Usuario1 = UR.GetOne(UsuarioMensagem.id_usuarioremetente);
                usuario Usuario2 = UR.GetOne(UsuarioMensagem.id_usuariodestinatario);

                if (Usuario1 != null && Usuario2 != null)
                {
                    DataRow datarow = tablemensagem.NewRow();

                    datarow["idRemetenteMensagem"] = UsuarioMensagem.id_usuarioremetente;
                    datarow["idDestinatarioMensagem"] = UsuarioMensagem.id_usuariodestinatario;
                    datarow["idMensagem"] = UsuarioMensagem.id_mensagem;

                    if (UsuarioMensagem.id_usuarioremetente == UsuarioAtual.id_usuario)
                    {
                        if (string.IsNullOrEmpty(Usuario2.linkfoto))
                        {
                            datarow["LinkfotoUsuarioMensagem"] = "https://i.imgur.com/6BPMqMa.png";
                        }
                        else
                        {
                            datarow["LinkfotoUsuarioMensagem"] = Usuario2.linkfoto;
                        }
                        datarow["NomeUsuarioMensagem"] = Usuario2.nomeusuario;
                        datarow["NicknameUsuarioMensagem"] = Usuario2.nicknameusuario;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(Usuario1.linkfoto))
                        {
                            datarow["LinkfotoUsuarioMensagem"] = "https://i.imgur.com/6BPMqMa.png";
                        }
                        else
                        {
                            datarow["LinkfotoUsuarioMensagem"] = Usuario1.linkfoto;
                        }
                        datarow["NomeUsuarioMensagem"] = Usuario1.nomeusuario;
                        datarow["NicknameUsuarioMensagem"] = Usuario1.nicknameusuario;
                    }

                    mensagem Mensagem = mensagemvelha[i];

                    datarow["TempoMensagem"] = DateTime.Now.ToBinary() - Mensagem.datamensagem.ToBinary();
                    datarow["DataMensagem"] = Mensagem.datamensagem.ToString("dd/MM");
                    datarow["AnoMensagem"] = Mensagem.datamensagem.ToString("yyyy");
                    datarow["HoraMensagem"] = Mensagem.datamensagem.ToString("HH:mm");
                    datarow["DataHoraAnoMensagem"] = Mensagem.datamensagem;
                    datarow["Visualizado"] = Mensagem.visualizadomensagem;
                    datarow["ConteudoMensagem"] = Mensagem.contentmensagem;
                    tablemensagem.Rows.Add(datarow);
                }
            }*/
            /*ArrayList ArrayMensagem = new ArrayList();
            for (int i = 0; i < tablemensagem.Rows.Count; i++)
            {
                for (int j = 0; j < tablemensagem.Rows.Count; j++)
                {
                    if (DateTime.Parse(tablemensagem.Rows[i]["DataHoraAnoMensagem"].ToString()).ToBinary() > DateTime.Parse(tablemensagem.Rows[j]["DataHoraAnoMensagem"].ToString()).ToBinary()
                        && (tablemensagem.Rows[i]["idRemetenteMensagem"].ToString() == tablemensagem.Rows[j]["idRemetenteMensagem"].ToString()
                        && tablemensagem.Rows[i]["idDestinatarioMensagem"].ToString() == tablemensagem.Rows[j]["idDestinatarioMensagem"].ToString()
                        || tablemensagem.Rows[i]["idRemetenteMensagem"].ToString() == tablemensagem.Rows[j]["idDestinatarioMensagem"].ToString()
                        && tablemensagem.Rows[i]["idDestinatarioMensagem"].ToString() == tablemensagem.Rows[j]["idRemetenteMensagem"].ToString()))
                    {
                        ArrayMensagem.Add(tablemensagem.Rows[i]);
                    }
                    if (ArrayMensagem.Count != 0)
                    {
                        for (int x = 0; x < ArrayMensagem.Count; x++)
                        {
                            DataRow datarow = tablemensagem.NewRow();
                            datarow = (DataRow)ArrayMensagem[x];

                            if (DateTime.Parse(datarow["DataHoraAnoMensagem"].ToString()).ToBinary() > DateTime.Parse(tablemensagem.Rows[i]["DataHoraAnoMensagem"].ToString()).ToBinary()
                                && (tablemensagem.Rows[i]["idRemetenteMensagem"].ToString() == datarow["idRemetenteMensagem"].ToString()
                                && tablemensagem.Rows[i]["idDestinatarioMensagem"].ToString() == datarow["idDestinatarioMensagem"].ToString()
                                || tablemensagem.Rows[i]["idRemetenteMensagem"].ToString() == datarow["idDestinatarioMensagem"].ToString()
                                && tablemensagem.Rows[i]["idDestinatarioMensagem"].ToString() == datarow["idRemetenteMensagem"].ToString()))
                            {
                                ArrayMensagem[x] = datarow;
                            }
                            else
                            {
                                for(int z = ArrayMensagem.Count -1; z > -1; z--)
                                {
                                    if ((DataRow)ArrayMensagem[z] == tablemensagem.Rows[i])
                                    {
                                        ArrayMensagem.Remove(ArrayMensagem[z]);
                                    }
                                }
                                //ArrayMensagem[x] = tablemensagem.Rows[i];
                            }
                        }
                    }
                }
            }*/
            /*for (int i = ArrayMensagem.Count - 1; i > -1; i--)
            {
                tablemensagem.Rows.Remove(tablemensagem.Rows[int.Parse(ArrayMensagem[i].ToString())]);
            }*/
            /*for(int i = ArrayMensagem.Count - 1; i>-1; i--)
            {
                tablearruma.ImportRow((DataRow)ArrayMensagem[i]);
            }

        }*/

            DataView dv = new DataView(tablemensagem);
            dv.Sort = ("TempoMensagem DESC");
            rptMensagem.DataSource = dv.ToTable();
            rptMensagem.DataBind();
        }

        public void CarregaNotificacao()
        {
            DataTable tablenotificacao = new DataTable();
            tablenotificacao.Columns.Add("idRemetenteNotificacao");
            tablenotificacao.Columns.Add("idDestinatarioNotificacao");
            tablenotificacao.Columns.Add("DataNotificacao");
            tablenotificacao.Columns.Add("HoraNotificacao");
            tablenotificacao.Columns.Add("AnoNotificacao");
            tablenotificacao.Columns.Add("NicknameUsuarioNotificacao");
            tablenotificacao.Columns.Add("LinkfotoUsuarioNotificacao");
            tablenotificacao.Columns.Add("DsNotificacao");
            tablenotificacao.Columns.Add("idNotificacao");
            tablenotificacao.Columns.Add("TempoNotificacao");
            List<notificacao> listausuarionotificacao = NR.GetAll(UsuarioAtual.id_usuario);
            if (listausuarionotificacao.Count == 0)
            {
                DataRow datarow = tablenotificacao.NewRow();
                datarow["idRemetenteNotificacao"] = 0;
                datarow["idDestinatarioNotificacao"] = 0;
                datarow["TempoNotificacao"] = DateTime.Now - DateTime.Now;
                datarow["DataNotificacao"] = DateTime.Now.ToString("dd/MM");
                datarow["AnoNotificacao"] = DateTime.Now.ToString("yyyy");
                datarow["HoraNotificacao"] = DateTime.Now.ToString("HH:mm");
                datarow["DsNotificacao"] = "Nenhuma notificação por enquanto!";
                datarow["idNotificacao"] = 0;
                datarow["LinkfotoUsuarioNotificacao"] = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/512/confirm-notification-icon.png";
                datarow["NicknameUsuarioNotificacao"] = "Lamentamos";
                tablenotificacao.Rows.Add(datarow);
            }
            else
            {
                for (int i = 0; i < listausuarionotificacao.Count; i++)
                {
                    if (listausuarionotificacao[i].id_usuario != UsuarioAtual.id_usuario)
                    {
                        usuario UsuarioRemetente = UR.GetOne(listausuarionotificacao[i].id_usuario);
                        if (UsuarioRemetente != null)
                        {
                            DataRow datarow = tablenotificacao.NewRow();
                            datarow["idRemetenteNotificacao"] = UsuarioRemetente.id_usuario;
                            datarow["idDestinatarioNotificacao"] = listausuarionotificacao[i].usuario_id_usuario;
                            datarow["idNotificacao"] = listausuarionotificacao[i].id_notificacao;
                            if (string.IsNullOrEmpty(UsuarioRemetente.linkfoto))
                            {
                                datarow["LinkfotoUsuarioNotificacao"] = "https://i.imgur.com/6BPMqMa.png";
                            }
                            else
                            {
                                datarow["LinkfotoUsuarioNotificacao"] = UsuarioRemetente.linkfoto;
                            }
                            datarow["NicknameUsuarioNotificacao"] = UsuarioRemetente.nicknameusuario;
                            datarow["TempoNotificacao"] = DateTime.Now.ToBinary() - listausuarionotificacao[i].dataacao.ToBinary();
                            datarow["DataNotificacao"] = listausuarionotificacao[i].dataacao.ToString("dd/MM");
                            datarow["AnoNotificacao"] = listausuarionotificacao[i].dataacao.ToString("yyyy");
                            datarow["HoraNotificacao"] = listausuarionotificacao[i].dataacao.ToString("HH:mm");
                            datarow["DsNotificacao"] = listausuarionotificacao[i].ds_acao;
                            tablenotificacao.Rows.Add(datarow);
                        }
                    }
                }
            }

            DataView dv = new DataView(tablenotificacao);
            dv.Sort = ("TempoNotificacao DESC");
            rptNotificacao.DataSource = dv.ToTable();
            rptNotificacao.DataBind();
        }

        public void PesquisarUsuario()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id_usuario");
            table.Columns.Add("EmailUsuario");
            table.Columns.Add("NicknameUsuario");
            table.Columns.Add("NomeUsuario");
            table.Columns.Add("LinkfotoUsuario");
            List<usuario> listapesquisa = UR.GetAll(txtPesquisar.Text, txtPesquisar.Text, txtPesquisar.Text);
            List<usuario> Tamanholista = UR.GetAll();
            if (listapesquisa.Count == Tamanholista.Count && (Boolean)Session["jsPesquisaAtivo"] == true)
            {
                if (txtPesquisar.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MostraPesquisa", "clickMostraAreaPesquisa()", true);
                    Session["jsPesquisaAtivo"] = false;
                }
            }
            else if (listapesquisa.Count > 0)
            {
                //pnlRetornoPesquisa.Attributes.Add("style", "Display: unset");

                for (int i = 0; i < listapesquisa.Count; i++)
                {
                    if (listapesquisa[i].id_usuario != UsuarioAtual.id_usuario)
                    {
                        DataRow datarow = table.NewRow();
                        datarow["id_usuario"] = listapesquisa[i].id_usuario;
                        datarow["EmailUsuario"] = listapesquisa[i].emailusuario;
                        datarow["NicknameUsuario"] = listapesquisa[i].nicknameusuario;
                        datarow["NomeUsuario"] = listapesquisa[i].nomeusuario;
                        if (string.IsNullOrEmpty(listapesquisa[i].linkfoto))
                        {
                            datarow["LinkfotoUsuario"] = "https://i.imgur.com/6BPMqMa.png";
                        }
                        else
                        {
                            datarow["LinkfotoUsuario"] = listapesquisa[i].linkfoto;
                        }
                        table.Rows.Add(datarow);
                    }
                }

                if ((Boolean)Session["jsPesquisaAtivo"] == false && txtPesquisar.Text != "" && listapesquisa.Count != Tamanholista.Count && listapesquisa.Count == table.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MostraPesquisa", "clickMostraAreaPesquisa()", true);
                    Session["jsPesquisaAtivo"] = true;
                }
                rptPesquisa.DataSource = table;
                rptPesquisa.DataBind();
            }
        }

        protected void imgPerfil_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove("UsuarioPerfil");
            Response.Redirect("~/View/PerfilView.aspx");
        }

        protected void imgPaginainicial_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove("UsuarioPerfil");
            Response.Redirect("~/View/InicialView.aspx");
        }

        protected void lnkPerfilUsuarioPesquisado_Command(object sender, CommandEventArgs e)
        {
            Session["UsuarioPerfil"] = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/View/PerfilView.aspx");
        }

        protected void lnkSair_Command(object sender, CommandEventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/View/EmailView.aspx");
        }

        protected void lnkUsuarioNotificacao_Command(object sender, CommandEventArgs e)
        {
            if (int.Parse(e.CommandArgument.ToString()) != 0)
            {
                Session["UsuarioPerfil"] = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("~/View/PerfilView.aspx");
            }
        }

        protected void tmrCounterNotificacoes_Tick(object sender, EventArgs e)
        {
            PesquisarUsuario();
            CarregaMensagem();
            CarregaNotificacao();
            if (hdnLocalizacaoLat.Value != "" && hdnLocalizacaoLon.Value != "")
            {
                string latitude, longitude;
                if (hdnLocalizacaoLat.Value.Length != 11)
                {
                    latitude = hdnLocalizacaoLat.Value;
                    for (int i = latitude.Length; i < 11; i++)
                    {
                        latitude = latitude + "0";
                    }
                }
                else
                {
                    latitude = hdnLocalizacaoLat.Value;
                }

                if (hdnLocalizacaoLon.Value.Length != 11)
                {
                    longitude = hdnLocalizacaoLon.Value;
                    for (int i = longitude.Length; i < 11; i++)
                    {
                        longitude = longitude + "0";
                    }
                }
                else
                {
                    longitude = hdnLocalizacaoLon.Value;
                }
                latitude = latitude.Substring(0, 11);
                longitude = longitude.Substring(0, 11);

                Session["LatitudeAtual"] = double.Parse(latitude) * 0.0000001;
                Session["LongitudeAtual"] = double.Parse(longitude) * 0.0000001;/* * 0.0000001); (double.Parse(hdnLocalizacaoLon.Value) * 0.0000001);*/
            }
        }

        protected void lnkNomePerfil_Click(object sender, EventArgs e)
        {
            imgPerfil_Click(null, null);
        }

        protected void imgDescobrimentoLocal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/View/DescobrimentoLocalView.aspx");
        }

        protected void lnkSobre_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/View/SobreView.aspx");
        }

        protected void lnkAjuda_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/View/AjudaView.aspx");
        }

        protected void lnkClickOpcoes_Command(object sender, CommandEventArgs e)
        {
            if (lblunNamed.Text == "unN ▼ med")
            {
                lblunNamed.Text = "unN ▲ med";
            }
            else if (lblunNamed.Text == "unN ▲ med")
            {
                lblunNamed.Text = "unN ▼ med";
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MostraOpcoes", "clickAreaOpcoes()", true);
        }

        public bool Show(string mensagem)
        {
            Session.Remove("resposta");
            pnlConfirmacao.Attributes.Add("style", "Display: flex");
            lblMensagemShow.Text = lblMensagemShow.Text.Replace("#mensagem", mensagem);
            while (Session["resposta"] == null)
            {

            }
            if ((string)Session["resposta"] == "sim")
            {
                Session.Remove("resposta");
                return true;
            }
            else
            {
                Session.Remove("resposta");
                return false;
            }
        }

        protected void bttSim_Click(object sender, EventArgs e)
        {
            Session["resposta"] = "sim";
        }

        protected void bttNao_Click(object sender, EventArgs e)
        {
            Session["resposta"] = "não";
        }
    }
}