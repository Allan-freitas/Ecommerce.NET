using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.DAO;
using Ecommerce.BLL;
using System.Web.Services;
using System.Web.Script.Services;

namespace Ecommerce.WEB
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        Carrinho carrinho = new Carrinho();
        CategoriaBLL categoriasBLL = new CategoriaBLL();
        ProdutoBLL produtoBLL = new ProdutoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            CLIENTE cliente = new CLIENTE();

            lnkSair.Visible = false;

            AtualizarCarrinho();
            lblCliente.Visible = false;

            if (Session["cliente"] != null)
            {
                cliente = (CLIENTE)Session["cliente"];
                lblCliente.Visible = true;
                lnkSair.Visible = true;
                lblCliente.Text = "Olá, " + cliente.NOME;
                cliente = null;
            }

            if (!IsPostBack)
            {
                BuscarCategorias();
                BuscarFabricantes();
                BuscarBanners();
                BuscaProdutosEspeciais();
                string txtPesquisaJs = txtPesquisa.Text;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<PRODUTO> BuscarProdutosNomeJs(string txtPesquisaJs)
        {
            List<PRODUTO> produtos = produtoBLL.buscarProdutoNome(txtPesquisaJs);
            return produtos;
        }

        public void AtualizarCarrinho()
        {
            if (carrinho.Itens.Count > 0)
            {
                lblCarrinhoItens.Text = carrinho.Itens.Count.ToString();
                lblValor.Text = carrinho.ValorTotal().ToString("C");
            }
            else
            {
                lblCarrinhoItens.Text = "Carrinho Vazinho, Vamos Comprar!";
                lblValor.Text = "R$ 0,00";
            }
        }

        public void BuscarCategorias()
        {
            DtlCategorias.DataSource = categoriasBLL.getAll();
            DtlCategorias.DataBind();
        }

        public void BuscarFabricantes()
        {
            FabricanteBLL fabricanteBLL = new FabricanteBLL();

            dtlFabricantes.DataSource = fabricanteBLL.getAll();
            dtlFabricantes.DataBind();
        }

        public void BuscarBanners()
        {
            BannerBLL bannerBLL = new BannerBLL();

            AdRotator1.DataSource = bannerBLL.getAll();
            AdRotator1.DataBind();
        }

        public void BuscaProdutosEspeciais()
        {          
            List<PRODUTO> produtos = new List<PRODUTO>();
            List<PRODUTO> produtosSorteio = new List<PRODUTO>();
            produtosSorteio = produtoBLL.RetornarParaSorteio();

            Random rand = new Random();

            int pr = rand.Next(1, produtosSorteio.Count);
            produtos.Add(produtoBLL.buscarEspecial(pr));

            dtlProdutosEspeciais.DataSource = produtos;
            dtlProdutosEspeciais.DataBind();

            produtosSorteio = null;
            rand = null;
        }

        protected void DtlCategorias_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {

                ((HyperLink)e.Item.FindControl("lnkCategoria")).Text = ((CATEGORIA)e.Item.DataItem).NOME;
                ((HyperLink)e.Item.FindControl("lnkCategoria")).NavigateUrl = "Produtos.aspx?categoria=" + ((CATEGORIA)e.Item.DataItem).IDT_CATEGORIA.ToString();
            }
        }

        protected void dtlFabricantes_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {

                ((HyperLink)e.Item.FindControl("lnkFabricante")).Text = ((FABRICANTE)e.Item.DataItem).NOME;
                ((HyperLink)e.Item.FindControl("lnkFabricante")).NavigateUrl = "Produtos.aspx?fabricante=" + ((FABRICANTE)e.Item.DataItem).IDT_FABRICANTE.ToString();
            }
        }

        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("pesquisa", txtPesquisa.Text);
            Response.Redirect("ResultadoPesquisa.aspx");
        }

        protected void dtlProdutosEspeciais_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                ((HyperLink)e.Item.FindControl("lnkNomeProdutosEspeciais")).Text = ((PRODUTO)e.Item.DataItem).NOME;
                ((HyperLink)e.Item.FindControl("lnkNomeProdutosEspeciais")).NavigateUrl = "Detalhes.aspx?produtos=" + ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();

                ((HyperLink)e.Item.FindControl("lnkImgProdutoEspeciais")).NavigateUrl = "Detalhes.aspx?produtos=" + ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();
                ((Image)e.Item.FindControl("imgProdutoEspecial")).ImageUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + ((PRODUTO)e.Item.DataItem).FOTO.ToString();
                ((Label)e.Item.FindControl("lblPrecoEspecial")).Text = ((PRODUTO)e.Item.DataItem).VALOR.ToString("C");
            }
        }
    }
}