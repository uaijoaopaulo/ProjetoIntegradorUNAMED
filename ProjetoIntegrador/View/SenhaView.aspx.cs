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
    public partial class SenhaView : System.Web.UI.Page
    {
        usuario UsuarioLogin;
        UsuarioRepository UR = new UsuarioRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogin = (usuario)Session["UsuarioLogin"];
            if (Session["UsuarioAtual"] != null)
            {
                Response.Redirect("../View/InicialView.aspx");
            }
            //lblEsqueceu.Attributes.Add("OnClick", "javascript:ChamaPaginaEsqueceu()");
            lblEmail.Text = UsuarioLogin.nomeusuario;
            txtSenha.Focus();
            txtSenha.Attributes.Add("Style", "Border-Color: #a800ff");
        }

        protected void bttLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                txtSenha.Attributes.Add("Style", "Border-Color: Red");
                lblAviso.Text = " ... ... Nada Digitado!";
                return;
            }
            else
            {
                if (UsuarioLogin == null)
                {
                    txtSenha.Attributes.Add("Style", "Border-Color: Red");
                    lblAviso.Text = " ... ... Usuario não encontrado!";
                }
                else
                {
                    if (UsuarioLogin.senhausuario == txtSenha.Text)
                    {
                        Session["UsuarioAtual"] = UsuarioLogin;
                        Session.Remove("UsuarioLogin");
                        Response.Redirect("~/View/InicialView.aspx");
                    }
                    else
                    {
                        txtSenha.Attributes.Add("Style", "Border-Color: Red");
                        lblAviso.Text = " ... ... Senha Errada!";
                        return;
                    }
                }
            }
        }

        protected void bttEsqueceuSenha_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RecuperarSenhaView.aspx");
        }

        protected void bttVoltar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/View/EmailView.aspx");
        }
    }
}