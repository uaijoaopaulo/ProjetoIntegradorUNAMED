using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Npgsql;
using ProjetoIntegrador.Model;
using ProjetoIntegrador.Repository;
using System;

namespace ProjetoIntegrador.View
{

    public partial class CadastrarUsuarioView : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=bancodedados;User ID=postgres;Password=123456;");

        usuario Usuario;

        UsuarioRepository UR = new UsuarioRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            LimpaVerificacao();
            if (Session["UsuarioAtual"] != null)
            {
                Usuario = (usuario)Session["UsuarioAtual"];
                if (!Page.IsPostBack)
                {
                    txtNome.Text = Usuario.nomeusuario;
                    txtEmail.Text = Usuario.emailusuario;
                    txtNick.Text = Usuario.nicknameusuario;
                    txtSenha.Text = Usuario.senhausuario;
                    if (Usuario.linkfoto != "")
                        flpFotoPerfil.Attributes.CssStyle.Add("Background-image", "url(" + Usuario.linkfoto + ")");
                }
                lblTituloPagina.Text = "Alterar Perfil";
            }
            else
            {
                Usuario = new usuario();
                lblTituloPagina.Text = "Criar Perfil";
            }
        }

        public string UploadImage()
        {
            try
            {
                var client = new ImgurClient("3123b60aeca7a22", "eefad4cbef84e409672fc1ee1716ecbb76bff5dc");
                var endpoint = new ImageEndpoint(client);
                IImage image;
                using (var fs = flpFotoPerfil.PostedFile.InputStream/*new FileStream(link, FileMode.Open)*/)
                {
                    image = endpoint.UploadImageStreamAsync(fs).GetAwaiter().GetResult();
                }
                return image.Link;
            }
            catch (ImgurException)
            {
                return null;
            }
        }

        protected void bttVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/EmailView.aspx");
        }

        public void LimpaVerificacao()
        {
            txtNome.Attributes.Add("Style", "Border-Color: #a800ff");
            //txtNome.Attributes.Add("Style", "Background-Color: white;");
            lblAvisoNome.Text = "";
            txtNick.Attributes.Add("Style", "Border-Color: #a800ff");
            //txtNick.Attributes.Add("Style", "Background-Color: white;");
            lblAvisoNick.Text = "";
            txtEmail.Attributes.Add("Style", "Border-Color: #a800ff");
            //txtEmail.Attributes.Add("Style", "Background-Color: white;");
            lblAvisoEmail.Text = "";
            txtConfirmaemail.Attributes.Add("Style", "Border-Color: #a800ff");
            //txtConfirmaemail.Attributes.Add("Style", "Background-Color: white;");
            lblAvisoConfirmaEmail.Text = "";
            txtSenha.Attributes.Add("Style", "Border-Color: #a800ff");
            //txtSenha.Attributes.Add("Style", "Background-Color: white;");
            lblAvisoSenha.Text = "";
            txtConfirmaSenha.Attributes.Add("Style", "Border-Color: #a800ff");
            //txtConfirmaSenha.Attributes.Add("Style", "Background-Color: white;");
            lblAvisoConfirmaSenha.Text = "";
        }

        public void VerificaCampos()
        {
            if (txtNome.Text == "")
            {
                txtNome.Attributes.Add("Style", "Border-Color: red");
                //txtNome.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                lblAvisoNome.Text = " ... ... Você precisa de um nome! ~já eu não";
            }
            if (txtNick.Text == "")
            {
                txtNick.Attributes.Add("Style", "Border-Color: red");
                //txtNick.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                lblAvisoNick.Text = " ... ... acho que você precisa de um nick ÚNICO NO MUNDO!";
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Attributes.Add("Style", "Border-Color: red");
                //txtEmail.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                lblAvisoEmail.Text = " ... ... acredito que você tenha um email!";
            }
            if (txtConfirmaemail.Text == "")
            {
                txtConfirmaemail.Attributes.Add("Style", "Border-Color: red");
                //txtConfirmaemail.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                lblAvisoConfirmaEmail.Text = " ... ... Ouu digite o email novamente para confirmar";
            }
            if (txtEmail.Text != txtConfirmaemail.Text)
            {
                txtEmail.Attributes.Add("Style", "Border-Color: red");
                //txtEmail.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                txtConfirmaemail.Attributes.Add("Style", "Border-Color: red");
                //txtConfirmaemail.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                txtConfirmaemail.Text = "";

                lblAvisoConfirmaEmail.Text = " ... ... Ouu o email para confirmar o email tem que ser igual o email!";
            }
            if (txtSenha.Text == "")
            {
                txtSenha.Attributes.Add("Style", "Border-Color: red");
                //txtSenha.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                lblAvisoSenha.Text = " ... ... senhas são necessarias!";
            }
            if (txtConfirmaSenha.Text == "")
            {
                txtConfirmaSenha.Attributes.Add("Style", "Border-Color: red");
                //txtConfirmaSenha.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                lblAvisoConfirmaSenha.Text = " ... ... deve-se confirmar a senha!";
            }
            if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                txtSenha.Attributes.Add("Style", "Border-Color: red");
                //txtSenha.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                txtConfirmaSenha.Attributes.Add("Style", "Border-Color: red");
                //txtConfirmaSenha.Attributes.Add("Style", "Background-Color: #ffe5eb;");
                txtConfirmaSenha.Text = "";

                lblAvisoConfirmaSenha.Text = " ... ... as senhas devem coincidir!";
            }
        }

        protected void bttProximo_Click(object sender, EventArgs e)
        {
            LimpaVerificacao();
            VerificaCampos();
            if (txtNome.Text != "" && txtNick.Text != "" && txtEmail.Text != "" && txtConfirmaemail.Text != "" && txtSenha.Text != "" && txtConfirmaSenha.Text != "" && txtEmail.Text == txtConfirmaemail.Text && txtSenha.Text == txtConfirmaSenha.Text)
            {
                usuario VerificaNick;
                Usuario.nomeusuario = txtNome.Text;
                if (txtNick.Text.StartsWith("@"))
                {
                    VerificaNick = UR.GetUsuario(null, txtNick.Text.Replace("@", ""));
                }
                else
                {
                    VerificaNick = UR.GetUsuario(null, txtNick.Text);
                }
                if (VerificaNick == null || (Usuario.id_usuario == VerificaNick.id_usuario && VerificaNick != null))
                {
                    if (txtNick.Text.StartsWith("@"))
                        Usuario.nicknameusuario = txtNick.Text;
                    else
                        Usuario.nicknameusuario = ("@" + txtNick.Text);
                }
                else
                {
                    txtNick.Attributes.Add("Style", "Border-Color: red");
                    lblAvisoNick.Text = " ... ... este nick já está sendo utilizado! '-'";
                    return;
                }

                Usuario.emailusuario = txtEmail.Text;
                Usuario.senhausuario = txtSenha.Text;

                if (flpFotoPerfil.HasFile)
                    Usuario.linkfoto = UploadImage();
                else
                {
                    if (string.IsNullOrEmpty(Usuario.linkfoto))
                        Usuario.linkfoto = "";
                }
                Session["UsuarioAtual"] = Usuario;
                if (string.IsNullOrEmpty(Usuario.id_usuario.ToString()))
                {
                    UR.Salvar(Usuario);
                }
                else
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("update usuario set nomeusuario = @nomeusuario, nicknameusuario = @nicknameusuario, emailusuario = @emailusuario, senhausuario = @senhausuario, linkfoto = @linkfoto where id_usuario = @id_usuario", conn);
                    command.Parameters.AddWithValue("@nomeusuario", Usuario.nomeusuario);
                    command.Parameters.AddWithValue("@nicknameusuario", Usuario.nicknameusuario);
                    command.Parameters.AddWithValue("@emailusuario", Usuario.emailusuario);
                    command.Parameters.AddWithValue("@senhausuario", Usuario.senhausuario);
                    command.Parameters.AddWithValue("@linkfoto", Usuario.linkfoto);
                    command.Parameters.AddWithValue("@id_usuario", Usuario.id_usuario);
                    command.ExecuteNonQuery();
                    conn.Close();
                }

                Response.Redirect("~/View/CadastrarDadosSegurancaView.aspx");
            }
            else
            {
                VerificaCampos();
                return;
            }
        }
    }
}