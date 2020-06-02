using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoIntegrador.Model;
using ProjetoIntegrador.Repository;

namespace ProjetoIntegrador.View
{
    public partial class RecuperarSenhaView : System.Web.UI.Page
    {
        UsuarioRepository UR = new UsuarioRepository();
        DadosSegurancaRepository DSR = new DadosSegurancaRepository();
        static usuario UsuarioRecuperacao;
        static dadosseguranca Dadosseguranca;
        string email;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioAtual"] != null)
            {
                Response.Redirect("~/View/InicialView.aspx");
            }
            lblAviso.Text = " ";
            pnlChcemail.Attributes.Add("Style", "Display: none");
        }

        protected void bttEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblAviso.Text = "... ... Você não digitou nada!";
                return;
            }
            else
            {
                UsuarioRecuperacao = UR.GetUsuario(txtEmail.Text, txtEmail.Text);
                if (UsuarioRecuperacao != null)
                {
                    Dadosseguranca = DSR.GetOne(UsuarioRecuperacao.id_usuario);
                    if (Dadosseguranca == null)
                    {
                        email = UsuarioRecuperacao.emailusuario;
                        pnlChcemail.Attributes.Add("Style", "Display: none");
                        EnviarEmail();
                    }
                    else
                    {
                        pnlChcemail.Attributes.Add("Style", "Display: unset");
                        List<string> lista = new List<string>();
                        lista.Add(UsuarioRecuperacao.emailusuario);
                        lista.Add(Dadosseguranca.emailrecuperacao);

                        chcEmail.DataSource = lista;
                        chcEmail.DataBind();
                    }
                }
                else
                {
                    lblAviso.Text = " ... ... Nenhum usuario registrado com este Email";
                    txtEmail.Text = "";
                }
            }
        }

        protected void bttVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/EmailView.aspx");
        }

        protected void chcEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlChcemail.Attributes.Add("Style", "Display: none");
            email = chcEmail.SelectedItem.ToString();
            EnviarEmail();
        }

        public void EnviarEmail()
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("unnamed.suporte@gmail.com", "unnamedsenha123");

            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("unnamed.suporte@gmail.com", "unNamed");
            mail.From = new MailAddress(email, "Recuperação de Senha");
            mail.To.Add(new MailAddress(email, "Recuperação de Senha"));
            mail.Subject = "Recuperação de Senha Para unNamed";
            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/View/CorpoEmailHTML.html"));
            Body = Body.Replace("#Usuario#", UsuarioRecuperacao.nicknameusuario);
            Body = Body.Replace("#Nome#", UsuarioRecuperacao.nomeusuario);
            Body = Body.Replace("#Senha#", UsuarioRecuperacao.senhausuario);
            mail.Body = Body;
            mail.Priority = MailPriority.High;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;

            try
            {
                client.Send(mail);
                lblAviso.Text = "Email enviado com sucesso para: " + email;
                txtEmail.Text = "";
            }
            catch (Exception)
            {
                lblAviso.Text = " ... ... Algo ocorreu ao enviar o Email!";
            }
        }
    }
}