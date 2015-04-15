using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.DAO;
using Ecommerce.BLL;

namespace Ecommerce.WEB
{
    public partial class RecuperaSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var hyperlink = (HyperLink)Master.FindControl("HyperLinkCadastro");
            hyperlink.Visible = false;

            lblMsg.Visible = false;

            if (!IsPostBack) 
            {
                if (Session["cliente"] != null) 
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }

        protected void btnRecupera_Click(object sender, EventArgs e)
        {
            CLIENTE cliente = new CLIENTE();
            ClienteBLL clienteBLL = new ClienteBLL();

            if (txtEmail.Text != null) 
            {
                if (txtEmail.Text.Count() > 8) 
                {
                    if (clienteBLL.VerificaClienteExist(txtEmail.Text.Trim())) 
                    {
                        cliente = clienteBLL.RecuperaSenha(txtEmail.Text.Trim());
                        Util.EnviarEmailSenha(cliente.NOME, txtEmail.Text.Trim(), cliente.SENHA.ToString());

                        lblMsg.Visible = true;
                        lblMsg.Text = "Um e-mail foi enviado para você contendo informações necessárias para seu Login.";
                        txtEmail.Text = "";
                    }
                }
            }
        }
    }
}