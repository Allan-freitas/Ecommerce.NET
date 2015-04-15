using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.BLL;
using Ecommerce.DAO;

namespace Ecommerce.WEB.Admin
{
    public partial class Produtos : System.Web.UI.Page
    {
        FabricanteBLL fabricantesBLL = new FabricanteBLL();
        CategoriaBLL categoriasBLL = new CategoriaBLL();
        ProdutoBLL produtosBLL = new ProdutoBLL();
        PRODUTO produto = new PRODUTO();
        ProdutoDAO produtos = new ProdutoDAO();

        int idProduto = 0;
        //string diretorio = "";
        string nomefoto = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            imgProduto.Visible = false;
            if (!IsPostBack)
            {
                ListarFabricantes();
                ListarCategorias();
                ListarProdutos();
            }
        }

        public void ListarProdutos()
        {
            GrvProdutos.DataSource = produtosBLL.getAll();

            GrvProdutos.DataBind();
        }

        public void ListarFabricantes()
        {
            ddlFabricante.DataSource = fabricantesBLL.getAll();

            ddlFabricante.DataTextField = "NOME";
            ddlFabricante.DataValueField = "IDT_FABRICANTE";
            ddlFabricante.DataBind();
        }

        public void ListarCategorias()
        {
            dllCategoria.DataSource = categoriasBLL.getAll();

            dllCategoria.DataTextField = "NOME";
            dllCategoria.DataValueField = "IDT_CATEGORIA";
            dllCategoria.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            imgProduto.Visible = false;
            if (!IsPostBack)
            {
                BuscarFabricantes();
                BuscarCategorias();
                BuscarProdutos();
            }
        }

        public void BuscarCategorias()
        {
            dllCategoria.DataSource = categoriasBLL.getAll();

            dllCategoria.DataTextField = "NOME";
            dllCategoria.DataValueField = "IDT_CATEGORIA";

            dllCategoria.DataBind();
        }

        public void BuscarFabricantes()
        {
            ddlFabricante.DataSource = fabricantesBLL.getAll();

            ddlFabricante.DataTextField = "NOME";
            ddlFabricante.DataValueField = "IDT_FABRICANTE";

            ddlFabricante.DataBind();
        }

        public void BuscarProdutos()
        {
            GrvProdutos.DataSource = produtosBLL.getAll();
            GrvProdutos.DataBind();
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            string diretorio = MapPath("~/Produtos/");

            if (TxtIdProduto.Text != string.Empty)
            {
                AtualizarProduto();
            }
            else
            {
                produto.NOME = txtNomeProduto.Text;
                produto.DESCRICAO = txtDescricao.Text;

                if (fileFotoProduto.HasFile)
                {
                    Random rdm = new Random();


                    nomefoto = "produto" + rdm.Next(0, 99999).ToString() + fileFotoProduto.FileName.Substring(fileFotoProduto.FileName.LastIndexOf("."), 4);

                    fileFotoProduto.SaveAs(diretorio + nomefoto);

                    produto.FOTO = nomefoto;

                    rdm = null;
                }

                if (Image1Produto.HasFile)
                {
                    Random rdm = new Random();


                    nomefoto = "produto" + rdm.Next(10, 99999).ToString() + Image1Produto.FileName.Substring(Image1Produto.FileName.LastIndexOf("."), 4);

                    Image1Produto.SaveAs(diretorio + nomefoto);

                    produto.FOTO2 = nomefoto;

                    rdm = null;
                }

                if (Image2Produto.HasFile)
                {
                    Random rdm = new Random();


                    nomefoto = "produto" + rdm.Next(20, 99999).ToString() + Image2Produto.FileName.Substring(Image2Produto.FileName.LastIndexOf("."), 4);

                    Image2Produto.SaveAs(diretorio + nomefoto);

                    produto.FOTO3 = nomefoto;

                    rdm = null;
                }

                if (Image3Produto.HasFile)
                {
                    Random rdm = new Random();


                    nomefoto = "produto" + rdm.Next(30, 99999).ToString() + Image3Produto.FileName.Substring(Image3Produto.FileName.LastIndexOf("."), 4);

                    Image3Produto.SaveAs(diretorio + nomefoto);

                    produto.FOTO4 = nomefoto;

                    rdm = null;
                }

                produto.IDT_CATEGORIA = int.Parse(dllCategoria.SelectedValue);

                produto.IDT_FABRICANTE = int.Parse(ddlFabricante.SelectedValue);

                produto.DESTAQUE = chkDestaque.Checked == true ? "S" : "N";

                produto.DATA_CADASTRO = DateTime.Now;

                produto.VALOR = decimal.Parse(TxtValor.Text);

                produtosBLL.Add(produto);
                produtosBLL.SaveChanges();

                BuscarFabricantes();
                BuscarCategorias();
                BuscarProdutos();

                produtosBLL = null;
                produto = null;

                LimparCampos();
            }
        }

        public void AtualizarProduto()
        {
            string diretorio = MapPath("~/Produtos/");

            idProduto = int.Parse(TxtIdProduto.Text);

            produto = produtos.Find(c => c.IDT_PRODUTO == idProduto).First<PRODUTO>();

            produto.NOME = txtNomeProduto.Text;
            produto.DESCRICAO = txtDescricao.Text;

            produto.VALOR = decimal.Parse(TxtValor.Text);
            produto.DESTAQUE = chkDestaque.Checked == true ? "S" : "N";
            produto.IDT_CATEGORIA = int.Parse(dllCategoria.SelectedValue);
            produto.IDT_FABRICANTE = int.Parse(ddlFabricante.SelectedValue);

            if (fileFotoProduto.HasFile)
            {
                diretorio = MapPath("~/Produtos/");
                nomefoto = produto.FOTO;
                fileFotoProduto.SaveAs(diretorio + nomefoto);
                produto.FOTO = nomefoto;
            }

            if (Image1Produto.HasFile)
            {
                Random rdm = new Random();


                nomefoto = "produto" + rdm.Next(10, 99999).ToString() + Image1Produto.FileName.Substring(Image1Produto.FileName.LastIndexOf("."), 4);

                Image1Produto.SaveAs(diretorio + nomefoto);

                produto.FOTO2 = nomefoto;

                rdm = null;
            }

            if (Image2Produto.HasFile)
            {
                Random rdm = new Random();


                nomefoto = "produto" + rdm.Next(20, 99999).ToString() + Image2Produto.FileName.Substring(Image2Produto.FileName.LastIndexOf("."), 4);

                Image2Produto.SaveAs(diretorio + nomefoto);

                produto.FOTO3 = nomefoto;

                rdm = null;
            }

            if (Image3Produto.HasFile)
            {
                Random rdm = new Random();


                nomefoto = "produto" + rdm.Next(30, 99999).ToString() + Image3Produto.FileName.Substring(Image3Produto.FileName.LastIndexOf("."), 4);

                Image3Produto.SaveAs(diretorio + nomefoto);

                produto.FOTO4 = nomefoto;

                rdm = null;
            }

            if (txtNomeProduto == null || txtNomeProduto.Text.Length < 3)
            {
                Util.showMessage(Page, "O Campo Produto não pode estar vazio ou conter menos de 3 caracteres, favor digite o nome corretamente");
            }
            else
            {
                produtos.Update(produto);
                produtos.SaveChanges();

                ListarFabricantes();
                ListarCategorias();
                ListarProdutos();

                produto = null;
                produtosBLL = null;

                LimparCampos();
            }
        }

        public void LimparCampos()
        {
            txtNomeProduto.Text = "";
            txtDescricao.Text = "";
            TxtIdProduto.Text = "";
            TxtValor.Text = "";
            imgProduto.Visible = false;

            btSalvar.Text = "Salvar";
        }

        protected void GrvProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui posso fazer um cast ou uma conversão!
            btSalvar.Text = "Atualizar";

            idProduto = (int)GrvProdutos.SelectedValue;

            //Expressão lambda para encontrar o primeiro registro, por isso "first<CATEGORIA>, é necessário especificar o tipo que será retornado.
            produto = produtos.Find(c => c.IDT_PRODUTO == idProduto).First<PRODUTO>();

            TxtIdProduto.Text = produto.IDT_PRODUTO.ToString();
            txtNomeProduto.Text = produto.NOME;
            txtDescricao.Text = produto.DESCRICAO;

            imgProduto.Visible = true;
            imgProduto.ImageUrl = "~/Produtos/" + produto.FOTO;
            imgProduto.ToolTip = produto.FOTO;
            TxtValor.Text = produto.VALOR.ToString();
            chkDestaque.Checked = produto.DESTAQUE == "S" ? true : false;
            dllCategoria.SelectedValue = produto.IDT_CATEGORIA.ToString();
            ddlFabricante.SelectedValue = produto.IDT_FABRICANTE.ToString();

            produto = null;
            produtos = null;
        }

        protected void GrvProdutos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            btSalvar.Text = "Salvar";

            idProduto = int.Parse(GrvProdutos.DataKeys[e.RowIndex].Value.ToString());

            produto = produtos.Find(c => c.IDT_PRODUTO == idProduto).First<PRODUTO>();

            produtos.Delete(produto);
            produtos.SaveChanges();

            produto = null;
            produtos = null;

            ListarProdutos();
            LimparCampos();
        }

    }
}