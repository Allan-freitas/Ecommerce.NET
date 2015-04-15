using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.BLL;
using System.Text.RegularExpressions;

namespace Ecommerce.WEB
{
    public partial class Contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblContato.Text = "Contate-nos!";  

            txtEmail.Attributes.Add("onblur", "ValidaEmail(this)");
            txtTelefone.Attributes.Add("onkeydown", "MascaraTelefone(this)");

            if (Session["cliente"] != null)
            {
                var hyperlink1 = (HyperLink)Master.FindControl("HyperLinkCadastro");
                hyperlink1.Visible = false;
            }
        }

        public void limpaTextBox() 
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtMensagem.Text = "";
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            Regex regexTelefone = new Regex(@"^\(\d{2}\)\d{4}-\d{4}$");

            if (txtNome.Text.Length < 3) 
            {
                lblContato.Visible = false;
                lblNome.Text = "Nome deve ter menos de 3 caracteres!";
            }

            if (regex.IsMatch(txtEmail.Text) == false) 
            {
                lblContato.Visible = false;
                lblEmail.Text = "E-mail digitado é inválido";
            }

            if (regexTelefone.IsMatch(txtTelefone.Text) == false) 
            {
                lblContato.Visible = false;
                lblTelefone.Text = "Telefone digitado não é válido!";
            }

            bool mensagemEnviada = Util.EnviarEmailContato(txtNome.Text, txtEmail.Text, txtTelefone.Text, txtMensagem.Text);

            if (mensagemEnviada == true) 
            {
                lblContato.Visible = false;
                limpaTextBox();
                lblMensagem.Text = "Mensagem Enviada com sucesso!";
            }
        }
    }
}