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
    public partial class Default : System.Web.UI.Page
    {
        ProdutoBLL produtosBLL = new ProdutoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarProdutos();
            }
            if (Session["cliente"] != null) 
            {
                var hyperlink1 = (HyperLink)Master.FindControl("HyperLinkCadastro");
                hyperlink1.Visible = false;

                var hyperlink2 = (HyperLink)Master.FindControl("recuperaSenha");
                hyperlink2.Visible = false;
            }
        }

        public void BuscarProdutos()
        {
            dtlprodutos.DataSource = produtosBLL.RetornarQdtProdutos();
            dtlprodutos.DataBind();
        }

        protected void dtlProdutos_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                ((HyperLink)e.Item.FindControl("lnkNomeProduto")).Text = ((PRODUTO)e.Item.DataItem).NOME;
                ((HyperLink)e.Item.FindControl("lnkNomeProduto")).NavigateUrl = "Detalhes.aspx?produtos=" + ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();

                ((HyperLink)e.Item.FindControl("lnkImgProduto")).NavigateUrl = "Detalhes.aspx?produtos=" + ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();
                ((Image)e.Item.FindControl("imgProduto")).ImageUrl = "http://allan.com.rws6.my-hosting-panel.com/Produtos/" + ((PRODUTO)e.Item.DataItem).FOTO.ToString();

                ((Label)e.Item.FindControl("lblPrecoProduto")).Text = ((PRODUTO)e.Item.DataItem).VALOR.ToString("C");
                ((ImageButton)e.Item.FindControl("btnCarrinho")).CommandArgument = ((PRODUTO)e.Item.DataItem).IDT_PRODUTO.ToString();
 
            }
        }

        protected void dtlProdutos_ItemCommand(object sender, DataListCommandEventArgs e) 
        {
            Carrinho carrinho = new Carrinho();
            ITEM_VENDA item = new ITEM_VENDA();
            PRODUTO produto = new PRODUTO();            

            if (e.CommandName == "carrinho") 
            {
                int codProduto = int.Parse(e.CommandArgument.ToString());
                produto = produtosBLL.Find(p => p.IDT_PRODUTO == codProduto).First();
                
                item.IDT_PRODUTO = int.Parse(e.CommandArgument.ToString());
                item.QUANTIDADE = 1;
                item.VALOR_UNITARIO = produto.VALOR;

                carrinho.adicionarItem(item);
                Response.Redirect("CarrinhoCompra.aspx");
            }
        }
    }
}