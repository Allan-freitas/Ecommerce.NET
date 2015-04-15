using System;
using System.Linq;
using Ecommerce.DAO;
using Ecommerce.BLL;
using Ecommerce.ADMIN.Classes;

namespace Ecommerce.ADMIN
{
    public partial class Fabricante : System.Web.UI.Page
    {
        FabricanteBLL fabricanteBLL = new FabricanteBLL();
        FABRICANTE fabricante = new FABRICANTE();
        FabricanteDAO fabricantes = new FabricanteDAO();
        int idFabricante = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarFabricantes();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtIdFabricante.Text != string.Empty)
            {
                AtualizarFabricante();
            }
            else
            {
                if (txtNomeFabricante == null || txtNomeFabricante.Text.Length < 3)
                {
                    Util.showMessage(Page, "O Campo Fabricante não pode estar vazio ou conter menos de 3 caracteres, favor digite o nome corretamente");
                }
                else
                {
                    fabricante.NOME = txtNomeFabricante.Text;
                    fabricanteBLL.Add(fabricante);
                    fabricanteBLL.SaveChanges();

                    ListarFabricantes();

                    Util.showMessage(Page, "Fabricante salva com sucesso!");

                    fabricante = null;
                    fabricanteBLL = null;
                    LimparCampos();
                }

            }
        }

        public void ListarFabricantes()
        {
            GrvFabricantes.DataSource = fabricantes.getAll();
            GrvFabricantes.DataBind();
        }

        public void AtualizarFabricante()
        {
            idFabricante = int.Parse(TxtIdFabricante.Text);

            fabricante = fabricantes.Find(c => c.IDT_FABRICANTE == idFabricante).First<FABRICANTE>();

            fabricante.NOME = txtNomeFabricante.Text;

            if (TxtIdFabricante == null || txtNomeFabricante.Text.Length < 3)
            {
                Util.showMessage(Page, "O Campo Fabricante não pode estar vazio ou conter menos de 3 caracteres, favor digite o nome corretamente");
            }
            else
            {
                fabricantes.Update(fabricante);
                fabricantes.SaveChanges();

                ListarFabricantes();

                fabricantes = null;
                fabricante = null;

                LimparCampos();
            }
        }

        public void LimparCampos()
        {
            txtNomeFabricante.Text = "";
            TxtIdFabricante.Text = "";
            btnSalvar.Text = "Salvar";
        }

        protected void GrvFabricantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui posso fazer um cast ou uma conversão!
            btnSalvar.Text = "Atualizar";

            idFabricante = (int)GrvFabricantes.SelectedValue;

            //Expressão lambda para encontrar o primeiro registro, por isso "first<Fabricante>, é necessário especificar o tipo que será retornado.
            fabricante = fabricantes.Find(c => c.IDT_FABRICANTE == idFabricante).First<FABRICANTE>();

            TxtIdFabricante.Text = fabricante.IDT_FABRICANTE.ToString();
            txtNomeFabricante.Text = fabricante.NOME;

            fabricantes = null;
            fabricante = null;
        }

        protected void GrvFabricantes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            idFabricante = int.Parse(GrvFabricantes.DataKeys[e.RowIndex].Value.ToString());

            fabricante = fabricantes.Find(c => c.IDT_FABRICANTE == idFabricante).First<FABRICANTE>();

            fabricantes.Delete(fabricante);
            fabricantes.SaveChanges();

            fabricante = null;
            fabricanteBLL = null;

            ListarFabricantes();
        }
    }
}