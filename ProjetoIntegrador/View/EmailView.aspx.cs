using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoIntegrador.Repository;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.View
{
    public partial class EmailView : System.Web.UI.Page
    {
        UsuarioRepository UR = new UsuarioRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioAtual"] != null)
            {
                Response.Redirect("~/View/InicialView.aspx");
            }
            UR.GetAll();
            //lblEsqueceu.Attributes.Add("OnClick", "javascript:ChamaPaginaEsqueceu()");
            lblAviso.Text = "";
            txtEmail.Focus();
            txtEmail.Attributes.Add("Style", "Border-Color: #a800ff");
        }

        protected void bttProximo_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.Attributes.Add("Style", "Border-Color: Red");
                lblAviso.Text = "... ... Nenhum E-mail digitado!";
                return;
            }
            else
            {
                usuario Usuario = UR.GetUsuario(txtEmail.Text, txtEmail.Text);
                if (Usuario != null)
                {
                    Session["UsuarioLogin"] = Usuario;
                    txtEmail.Text = "";
                    Response.Redirect("~/View/SenhaView.aspx");
                }
                else
                {
                    txtEmail.Attributes.Add("Style", "Border-Color: Red");
                    lblAviso.Text = "... ... Usuario não encontrado!";
                    txtEmail.Text = "";
                    return;
                }

            }
        }

        protected void bttEsqueceuSenha_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RecuperarSenhaView.aspx");
        }

        protected void bttRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CadastrarUsuarioView.aspx");
        }
    }
}