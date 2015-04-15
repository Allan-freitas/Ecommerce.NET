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
    public partial class AlterarDetalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsgTitutlo.Text = "Alterar Dados!";
            lblMsgTitutlo.Visible = true;

            if (!IsPostBack) 
            {
                if (Session["cliente"] != null)
                {
                    var hyperlink1 = (HyperLink)Master.FindControl("HyperLinkCadastro");
                    hyperlink1.Visible = false;

                    var hyperlink2 = (HyperLink)Master.FindControl("recuperaSenha");
                    hyperlink2.Visible = false;
                }

                if (Session["cliente"] == null)
                {
                    string redirecionar = "Autenticar.aspx";                    
                    Util.showMessage(Page, "Sua sessão expirou. Favor logar novamente!", redirecionar);
                }
                else 
                {
                    CarregaCliente();
                }
            }

        }

        public void CarregaCliente() 
        {
            try
            {
                CLIENTE cliente = (CLIENTE)Session["cliente"];

                txtNome.Text = cliente.NOME;
                txtEmail.Text = cliente.EMAIL;               
                txtTelefone.Text = cliente.TELEFONE;
            }
            catch (Exception)
            {
                lblAviso.Visible = false;
                lblAviso.Visible = true;
                lblAviso.Text = "Não foi possível carregar seus Dados, tente novamente ou entre em contato!";
            }
        }

        public void LimparCampos() 
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtTelefone.Text = "";
        }

        protected void btnAlterarCadastro_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            Regex regexTelefone = new Regex(@"^\(\d{2}\)\d{4}-\d{4}$");

            try
            {
                CLIENTE clienteAntigo = (CLIENTE)Session["cliente"];
                CLIENTE cliente = null;

                using (LojaVirtual banco = new LojaVirtual())
                {
                    var c = from ca in banco.CLIENTE
                            where ca.IDT_CLIENTE.Equals(clienteAntigo.IDT_CLIENTE)
                            select ca;

                    cliente = c.FirstOrDefault();

                    if (cliente != null)
                    {
                        if (txtNome.Text.Length < 3)
                        {
                            lblMsgTitutlo.Visible = false;
                            lblAviso.Text = "Nome deve ter pelo menos 3 caracteres!";
                        }

                        if (regex.IsMatch(txtEmail.Text) == false)
                        {
                            lblMsgTitutlo.Visible = false;
                            lblAviso.Text = "E-mail digitado é inválido";
                        }

                        if (regexTelefone.IsMatch(txtTelefone.Text) == false)
                        {
                            lblMsgTitutlo.Visible = false;
                            lblAviso.Text = "Telefone digitado não é válido!";
                        }

                        if ((txtNome.Text.Length >= 3) && (regexTelefone.IsMatch(txtTelefone.Text) == true) && (regex.IsMatch(txtEmail.Text) == true)) 
                        {
                            cliente.NOME = this.txtNome.Text;
                            cliente.EMAIL = this.txtEmail.Text;
                            cliente.SENHA = this.txtSenha.Text;
                            cliente.TELEFONE = this.txtTelefone.Text;

                            banco.SaveChanges();
                            
                            Util.EnviarEmailCadastroAlterado(this.txtNome.Text, this.txtEmail.Text, this.txtTelefone.Text, "NOTIFICAÇÃO DADOS ALTERADOS");
                            LimparCampos();
                            lblMsgTitutlo.Visible = false;
                            lblAviso.Text = "Dados Alterados com Sucesso!";
                        }
                    }
                }
            }
            catch (Exception)
            {
                Util.showMessage(Page, "Não foi possível alterar seus dados!");
            }
        }
    }
}