using System;
using System.Linq;
using Ecommerce.BLL;
using Ecommerce.DAO;
using Ecommerce.ADMIN.Classes;

namespace Ecommerce.ADMIN
{
    public partial class Categoria : System.Web.UI.Page
    {
        CategoriaBLL categoriaBLL = new CategoriaBLL();
        CATEGORIA categoria = new CATEGORIA();
        CategoriaDAO categorias = new CategoriaDAO();
        int idCategoria = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ListarCategorias();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != string.Empty) 
            {
                AtualizarCategoria();
            }
            else 
            {
                if (txtCategoria == null || txtCategoria.Text.Length < 3)
                {
                    Util.showMessage(Page, "O Campo Categoria não pode estar vazio ou conter menos de 3 caracteres, favor digite o nome corretamente");
                }
                else 
                {
                    categoria.NOME = txtCategoria.Text;
                    categoriaBLL.Add(categoria);
                    categoriaBLL.SaveChanges();

                    ListarCategorias();

                    Util.showMessage(Page, "Categoria salva com sucesso!");

                    categoria = null;
                    categoriaBLL = null;
                    LimparCampos();
                }

            }
        }

        public void ListarCategorias() 
        {
            GrvCategorias.DataSource = categorias.getAll();
            GrvCategorias.DataBind();
        }

        public void AtualizarCategoria() 
        {
            idCategoria = int.Parse(TxtCodigo.Text);

            categoria = categorias.Find(c => c.IDT_CATEGORIA == idCategoria).First<CATEGORIA>();

            categoria.NOME = txtCategoria.Text;

            if (txtCategoria == null || txtCategoria.Text.Length < 3)
            {
                Util.showMessage(Page, "O Campo Categoria não pode estar vazio ou conter menos de 3 caracteres, favor digite o nome corretamente");
            }
            else 
            {
                categorias.Update(categoria);
                categorias.SaveChanges();

                ListarCategorias();

                categoria = null;
                categoriaBLL = null;

                LimparCampos();
            }
        }

        public void LimparCampos() 
        {
            txtCategoria.Text = "";
            TxtCodigo.Text = "";
            btnSalvar.Text = "Salvar";
        }

        protected void GrvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui posso fazer um cast ou uma conversão!
            btnSalvar.Text = "Atualizar";

            idCategoria = (int) GrvCategorias.SelectedValue;
     
            //Expressão lambda para encontrar o primeiro registro, por isso "first<CATEGORIA>, é necessário especificar o tipo que será retornado.
            categoria = categorias.Find(c => c.IDT_CATEGORIA == idCategoria).First<CATEGORIA>();

            TxtCodigo.Text = categoria.IDT_CATEGORIA.ToString();
            txtCategoria.Text = categoria.NOME;

            categoria = null;
            categoriaBLL = null;
        }

        protected void GrvCategorias_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            idCategoria = int.Parse(GrvCategorias.DataKeys[e.RowIndex].Value.ToString());

            categoria = categorias.Find(c => c.IDT_CATEGORIA == idCategoria).First<CATEGORIA>();

            categorias.Delete(categoria);
            categorias.SaveChanges();

            categoria = null;
            categoriaBLL = null;

            ListarCategorias();
        }
    }
}