using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.BLL;
using Ecommerce.DAO;

namespace Ecommerce.WEB
{
    public partial class Autenticar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var hyperlink = (HyperLink)Master.FindControl("HyperLinkCadastro");
            hyperlink.Visible = false;

            if (!IsPostBack) 
            {
                if (Session["cliente"] != null) 
                {
                    Response.Redirect("Default.aspx");
                }
            }
            lblMsg.Visible = false;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            CLIENTE cliente = new CLIENTE();

            cliente = clienteBLL.AutenticarCliente(txtEmail.Text.Trim(), txtSenha.Text.Trim());

            if (cliente != null)
            {
                Session.Add("cliente", cliente);

                //Garbage coletor ao ver o objeto nulo manda ele pro espaço!
                cliente = null;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "E-mail ou senha inválidos! Favor Digitar corretamente!";
            }
        }
    }
}