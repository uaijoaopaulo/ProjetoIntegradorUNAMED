using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoIntegrador.Model;
using ProjetoIntegrador.Repository;

namespace ProjetoIntegrador.View
{
    public partial class CadastrarDadosSegurancaView : System.Web.UI.Page
    {
        usuario Usuario;
        dadosseguranca Dados;
        DadosSegurancaRepository DSR = new DadosSegurancaRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtTelefone.MaxLength = 11;
            LimpaVerificacao();
            if (Session["UsuarioAtual"] != null)
            {
                Usuario = (usuario)Session["UsuarioAtual"];
                Dados = DSR.GetOne(Usuario.id_usuario);
                if (Dados != null)
                {
                    txtEmail.Text = Dados.emailrecuperacao;
                    txtTelefone.Text = Dados.telefonerecuperacao;
                    lblTituloPagina.Text = "Alterar Dados de Segurança";
                }
                else
                {
                    Dados = new dadosseguranca();
                    lblTituloPagina.Text = "Criar Dados de Segurança";
                }
            }
            else
            {
                Response.Redirect("~/View/EmailView.aspx");
            }
        }

        protected bool VerificaNumero(string numero)
        {
            var input = numero;
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasUpperChar.IsMatch(input) || !hasLowerChar.IsMatch(input) || !hasSymbols.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void bttVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CadastrarUsuarioView.aspx");
        }

        protected void bttPular_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CadastrarSobreUsuarioView.aspx");
        }

        public void LimpaVerificacao()
        {
            txtTelefone.Attributes.Add("Style", "Border-Color: #a800ff");
            lblAvisoTelefone.Text = "";
            txtEmail.Attributes.Add("Style", "Border-Color: #a800ff");
            lblAvisoEmail.Text = "";
        }

        public void VerificaCampo()
        {
            if (txtTelefone.Text == "")
            {
                txtTelefone.Attributes.Add("Style", "Border-Color: red");
                lblAvisoTelefone.Text = " ... ... adicionar um telefone garante mais segurança a sua conta!";
            }
            if (VerificaNumero(txtTelefone.Text) == false || txtTelefone.Text.Length != 11)
            {
                txtTelefone.Attributes.Add("Style", "Border-Color: red");
                lblAvisoTelefone.Text = " ... ... formato para o telefone: 11988887777 (Apenas Números!)!";
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Attributes.Add("Style", "Border-Color: red");
                lblAvisoEmail.Text = " ... ... adicionar um email de recuperação garante mais segurança a sua conta!";
            }
            if (txtEmail.Text == Usuario.emailusuario)
            {
                txtEmail.Attributes.Add("Style", "Border-Color: red");
                txtEmail.Text = "";
                lblAvisoEmail.Text = " ... ... Email para verificação não pode ser igual ao seu! ";
            }
        }

        protected void bttProximo_Click(object sender, EventArgs e)
        {
            LimpaVerificacao();
            VerificaCampo();
            if (txtEmail.Text != "" && txtTelefone.Text != "")
            {
                if (VerificaNumero(txtTelefone.Text) == false || txtTelefone.Text.Length != 11)
                {
                    return;
                }
                else
                {
                    Dados.telefonerecuperacao = ("55" + txtTelefone.Text);
                    if (txtEmail.Text != Usuario.emailusuario)
                        Dados.emailrecuperacao = txtEmail.Text;
                    else
                    {
                        return;
                    }
                    Dados.id_usuario = Usuario.id_usuario;
                    DSR.Salvar(Dados);
                    Response.Redirect("~/View/CadastrarSobreUsuarioView.aspx");
                }
            }
            else
            {
                return;
            }
        }
    }
}