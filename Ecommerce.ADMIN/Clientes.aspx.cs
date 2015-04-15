using System;
using System.Linq;
using Ecommerce.DAO;
using Ecommerce.BLL;
using Ecommerce.ADMIN.Classes;

namespace Ecommerce.ADMIN
{
    public partial class Clientes : System.Web.UI.Page
    {
        ClienteBLL clienteBLL = new ClienteBLL();
        CLIENTE cliente = new CLIENTE();
        ClienteDAO clientes = new ClienteDAO();
        int idCliente = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ListarClientes();
            }
        }

        public void ListarClientes()
        {
            GrvClientes.DataSource = clienteBLL.getAll();

            GrvClientes.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (TxtIdCliente.Text != string.Empty)
            {
                AtualizarProduto();
            }
            else
            {
                if (txtNomeCliente == null || txtNomeCliente.Text.Length < 3)
                {
                    Util.showMessage(Page, "O Campo Cliente não pode estar vazio ou conter menos de 3 caracteres, favor digite o nome corretamente");
                }
                else
                {
                    cliente.NOME = txtNomeCliente.Text;
                    cliente.EMAIL = txtEmail.Text;
                    cliente.SENHA = TxtSenha.Text;
                    cliente.DATA_CADASTRO = DateTime.Now;

                    clienteBLL.Add(cliente);
                    clienteBLL.SaveChanges();

                    ListarClientes();

                    Util.showMessage(Page, "Categoria salva com sucesso!");

                    cliente = null;
                    clienteBLL = null;
                    LimparCampos();
                }

            }
        }

        public void AtualizarProduto()
        {

            idCliente = int.Parse(TxtIdCliente.Text);

            cliente = clientes.Find(c => c.IDT_CLIENTE == idCliente).First<CLIENTE>();

            cliente.NOME = txtNomeCliente.Text;
            cliente.EMAIL = txtEmail.Text;
            cliente.SENHA = TxtSenha.Text;

            if (txtNomeCliente == null || txtNomeCliente.Text.Length < 3)
            {
                Util.showMessage(Page, "O Campo Produto não pode estar vazio ou conter menos de 3 caracteres, favor digite o nome corretamente");
            }
            else
            {
                clientes.Update(cliente);
                clientes.SaveChanges();

                ListarClientes();

                cliente = null;
                clientes = null;

                LimparCampos();
            }
        }

        public void LimparCampos()
        {
            txtNomeCliente.Text = "";
            txtEmail.Text = "";
            TxtIdCliente.Text = "";
            TxtSenha.Text = "";
            txtConfirmaSenha.Text = "";

            btnSalvar.Text = "Salvar";
        }

        protected void GrvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui posso fazer um cast ou uma conversão!
            btnSalvar.Text = "Atualizar";

            idCliente = (int)GrvClientes.SelectedValue;

            //Expressão lambda para encontrar o primeiro registro, por isso "first<CATEGORIA>, é necessário especificar o tipo que será retornado.
            cliente = clientes.Find(c => c.IDT_CLIENTE == idCliente).First<CLIENTE>();

            TxtIdCliente.Text = cliente.IDT_CLIENTE.ToString();
            txtNomeCliente.Text = cliente.NOME;
            txtEmail.Text = cliente.EMAIL;

            cliente = null;
            clientes = null;
        }

        protected void GrvClientes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            btnSalvar.Text = "Salvar";

            idCliente = int.Parse(GrvClientes.DataKeys[e.RowIndex].Value.ToString());

            cliente = clientes.Find(c => c.IDT_CLIENTE == idCliente).First<CLIENTE>();

            clientes.Delete(cliente);
            clientes.SaveChanges();

            cliente = null;
            clientes = null;

            ListarClientes();
            LimparCampos();
        }

    }
}