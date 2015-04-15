using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.DAO;
using Ecommerce.BLL;
using System.Text.RegularExpressions;

namespace Ecommerce.WEB
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var hyperlink = (HyperLink)Master.FindControl("HyperLinkCadastro");
            hyperlink.Visible = false;

            var hyperlink2 = (HyperLink)Master.FindControl("recuperaSenha");
            hyperlink2.Visible = false;

            lblMsgTitutlo.Visible = true;
            lblMsgTitutlo.Text = "Cadastra-se!";            

            if (!IsPostBack)
            {
                if (Session["cliente"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            CLIENTE cliente = new CLIENTE();
            ClienteBLL clientebll = new ClienteBLL();

            cliente.NOME = txtNome.Text.Trim();
            cliente.EMAIL = txtEmailCliente.Text.Trim();
            cliente.SENHA = txtSenha.Text.Trim();
            cliente.DATA_CADASTRO = DateTime.Now;
            cliente.TELEFONE = txtTelefone.Text;

            bool clienteExiste = clientebll.VerificaClienteExist(txtEmailCliente.Text.Trim());

            if (clienteExiste)
            {
                //Cliente Existe
                lblMsgTitutlo.Visible = false;
                lblAviso.Text = "Você já se encontra cadastrado !";
                lblAviso.Visible = true;
            }
            else
            {
                clientebll.SalvaCliente(cliente);
                Util.EnviarEmailCadastroAdmin(cliente.NOME, cliente.EMAIL);
                Util.EnviarEmailCadastro(cliente.NOME, cliente.EMAIL, cliente.SENHA);

                Session.Add("cliente", cliente);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnRecuperaSenha_Click(object sender, EventArgs e)
        {
            CLIENTE cliente = new CLIENTE();
            ClienteBLL clienteBLL = new ClienteBLL();

            if (txtEmailCliente.Text != "")
            {
                if (clienteBLL.VerificaClienteExist(txtEmailCliente.Text.Trim()))
                {
                    cliente = clienteBLL.RecuperaSenha(txtEmailCliente.Text.Trim());

                    //cliente existe na base de dados
                    Util.EnviarEmailSenha(cliente.NOME, txtEmailCliente.Text.Trim(), cliente.SENHA.ToString());

                    lblMsgTitutlo.Visible = false;
                    lblAviso.Text = "Um e-mail com sua senha foi enviado!";
                    lblAviso.Visible = true;
                }
                else
                {
                    lblAviso.Text = "Você não é cadastrado em nosso site de vendas!";
                    lblAviso.Visible = true;
                }
            }
        }
    }
}