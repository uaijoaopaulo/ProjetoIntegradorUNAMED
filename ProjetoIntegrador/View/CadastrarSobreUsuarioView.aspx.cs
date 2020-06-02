using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoIntegrador.Model;
using ProjetoIntegrador.Repository;

namespace ProjetoIntegrador.View
{
    public partial class CadastrarSobreUsuarioView : System.Web.UI.Page
    {
        usuario Usuario;
        sobre Sobre;

        SobreRepository SR = new SobreRepository();
        UsuarioRepository UR = new UsuarioRepository();
        DadosSegurancaRepository DSR = new DadosSegurancaRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioAtual"] != null)
            {
                Usuario = (usuario)Session["UsuarioAtual"];
                Sobre = SR.GetOne(Usuario.id_usuario);
                if (Sobre != null)
                {
                    drpGenero.SelectedValue = Sobre.genero;
                    drpRelacionamento.SelectedValue = Sobre.relacionamento;
                    txtclnDatanascimento.Text = Sobre.datanascimento.ToShortDateString().ToString();
                    txtBiografia.Text = Sobre.biografia;

                    lblTituloPagina.Text = "Alterar dados sobre você";
                }
                else
                {
                    Sobre = new sobre();
                    Sobre.id_usuario = Usuario.id_usuario;
                    lblTituloPagina.Text = "Conte mais sobre você";
                }
            }
            else
            {
                Response.Redirect("~/View/EmailView.aspx");
            }
        }

        protected void Salvar()
        {
            if (txtclnDatanascimento.Text != "")
            {
                Sobre.id_usuario = Usuario.id_usuario;
                Sobre.datanascimento = DateTime.Parse(txtclnDatanascimento.Text.ToString());
                SR.Salvar(Sobre);
            }

            Session.RemoveAll();
            Session["UsuarioAtual"] = Usuario;
            Response.Redirect("~/View/PerfilView.aspx");
        }

        protected void bttPular_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/PerfilView.aspx");
        }

        protected void bttVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CadastrarDadosSegurancaView.aspx");
        }

        protected void bttProximo_Click(object sender, EventArgs e)
        {
            if (txtclnDatanascimento.Text == "")
            {
                txtclnDatanascimento.Attributes.Add("Style", "Border-color: red");
                lblAvisoCalendario.Text = " ... ... A data de seu aniversario é obrigatoria!";
                return;
            }
            else
            {
                txtclnDatanascimento.Attributes.Add("Style", "Border-color: #a800ff");
                lblAvisoCalendario.Text = "";
            }
            Salvar();
        }
    }
}