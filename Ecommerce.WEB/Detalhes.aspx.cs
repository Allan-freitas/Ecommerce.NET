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
    public partial class Detalhes : System.Web.UI.Page
    {
        int codigoProduto = 0;        
        PRODUTO produto = new PRODUTO();
        ProdutoBLL produtoBLL = new ProdutoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["produtos"] != null) 
            {
                codigoProduto = int.Parse(Request.QueryString["produtos"].ToString());
                BuscarProdutos();
                CarregaProdutoSimilar();
            }

        }

        public void CarregaProdutoSimilar() 
        {
            
            int codigoCategoria = produto.IDT_CATEGORIA;

            dtlSimilar.DataSource = produtoBLL.getAll().Where(c => c.IDT_CATEGORIA == codigoCategoria).Take(3);
            dtlSimilar.DataBind();

        }

        public void BuscarProdutos() 
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();          

            produto = produtoBLL.Find(p => p.IDT_PRODUTO.Equals(codigoProduto)).First();

            imgProduto.ImageUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO.ToString();
            LinkImgPrincipal.NavigateUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO.ToString();

            if (produto.FOTO2 != null && produto.FOTO2 != "") 
            {
                Img1.ImageUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO2.ToString();
                lnkImg1Produto.NavigateUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO2.ToString();
            }

            if (produto.FOTO3 != null && produto.FOTO3 != "")
            {
                Img2.ImageUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO3.ToString();
                lnkImg2Produto.NavigateUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO3.ToString();
            }

            if (produto.FOTO4 != null && produto.FOTO4 != "")
            {
                Img3.ImageUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO4.ToString();
                lnkImg3Produto.NavigateUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + produto.FOTO4.ToString();
            }

            lblNomeProduto.Text = produto.NOME;
            lblDescricao.Text = produto.DESCRICAO;
            lblGarantia.Text = produto.GARANTIA;
            lblValor.Text = produto.VALOR.ToString("C");

        }

        protected void dtlSimilar_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                ((HyperLink)e.Item.FindControl("lnkLabel")).Text = ((PRODUTO)e.Item.DataItem).NOME;
                ((HyperLink)e.Item.FindControl("lnkLabel")).NavigateUrl = "?produtos=" + ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();

                ((HyperLink)e.Item.FindControl("lnkImgProdSimilar")).NavigateUrl = "?produtos=" + ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();
                ((Image)e.Item.FindControl("imgProdSimilar")).ImageUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + ((PRODUTO)e.Item.DataItem).FOTO.ToString(); ;

                ((Label)e.Item.FindControl("lblPrecoSimilar")).Text = ((PRODUTO)e.Item.DataItem).VALOR.ToString("C");
                //((ImageButton)e.Item.FindControl("btnCarrinho")).CommandArgument = ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();

            }
        }

        protected void dtlSimilar_ItemCommand(object source, DataListCommandEventArgs e)
        {
            PRODUTO produto = new PRODUTO();
            ITEM_VENDA item = new ITEM_VENDA();
            Carrinho carrinho = new Carrinho();

            if (e.CommandName == "CarrinhoSimilar")
            {

                int codProduto = int.Parse(e.CommandArgument.ToString());
                produto = produtoBLL.Find(p => p.IDT_PRODUTO == codigoProduto).First();

                item.IDT_PRODUTO = int.Parse(e.CommandArgument.ToString());
                item.QUANTIDADE = 1;
                item.VALOR_UNITARIO = produto.VALOR;

                carrinho.adicionarItem(item);
                Response.Redirect("CarrinhoCompra.aspx");
            }
        }

        protected void btnCarrinho_Click(object sender, ImageClickEventArgs e)
        {
            Carrinho carrinho = new Carrinho();
            ITEM_VENDA itemVenda = new ITEM_VENDA();

            itemVenda.IDT_PRODUTO = codigoProduto;
            itemVenda.QUANTIDADE = 1;
            itemVenda.VALOR_UNITARIO = produto.VALOR;

            carrinho.adicionarItem(itemVenda);

            Response.Redirect("CarrinhoCompra.aspx");
                
        }

    }
}