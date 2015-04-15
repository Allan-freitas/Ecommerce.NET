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
    public partial class CarrinhoCompra : System.Web.UI.Page
    {
        ProdutoBLL produtoBLL = new ProdutoBLL();
        Carrinho carrinho = new Carrinho();
        int codProduto = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            BuscarItens();

            if (Session["cliente"] == null) 
            {
                Response.Redirect("Autenticar.aspx");
            }
            if (Session["cliente"] != null)
            {
                var hyperlink1 = (HyperLink)Master.FindControl("HyperLinkCadastro");
                hyperlink1.Visible = false;

                var hyperlink2 = (HyperLink)Master.FindControl("recuperaSenha");
                hyperlink2.Visible = false;
            }
        }

        public void BuscarItens() 
        {
            if (carrinho.Itens.Count > 0)
            {
                grvCarrinho.DataSource = carrinho.Itens;
                grvCarrinho.DataBind();
            }
            else 
            {
                lblMsg.Text = "Não há itens no carrinho de compras!";
                lblMsg.Visible = true;
                grvCarrinho.DataBind();
            }
        }

        protected void grvCarrinho_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {

                codProduto = ((ITEM_VENDA)e.Row.DataItem).IDT_PRODUTO;
                ProdutoBLL produtoBLL = new ProdutoBLL();

                PRODUTO produto = produtoBLL.Find(p => p.IDT_PRODUTO == codProduto).First();

                ((Label)e.Row.FindControl("lblDescricao")).Text = produto.NOME;
            }
            else 
            {
                e.Row.Cells[1].Text = "Total de itens selecionados: " + carrinho.QuantidadeTotal().ToString();
                e.Row.Cells[4].Text = String.Format("{0:C}", carrinho.ValorTotal());
            }
        }

        protected void grvCarrinho_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (carrinho.ExcluirItem(int.Parse(grvCarrinho.DataKeys[e.RowIndex].Value.ToString())))
            {
                BuscarItens();
                Master.AtualizarCarrinho();
            }
        }

        protected void btnPagar_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["cliente"] != null)
            {
                CLIENTE cliente = new CLIENTE();
                cliente = (CLIENTE)Session["cliente"];

                PRODUTO prd = null;

                //Finaliza a compra do Cliente
                int idCodigoVenda = carrinho.FinalizarVenda(cliente.IDT_CLIENTE, 5);

                VendaPagSeguro1.CodigoReferencia = idCodigoVenda.ToString();

                VendaPagSeguro1.Produtos = new List<UOL.PagSeguro.Produto>();

                foreach (ITEM_VENDA item in carrinho.Itens)
                {
                    UOL.PagSeguro.Produto produto = new UOL.PagSeguro.Produto();
                    produto.Codigo = item.IDT_PRODUTO.ToString();

                    prd = new PRODUTO();
                    prd = produtoBLL.buscarProduto(item.IDT_PRODUTO);

                    produto.Descricao = prd.NOME;
                    produto.Quantidade = item.QUANTIDADE;
                    produto.Valor = double.Parse(item.VALOR_UNITARIO.ToString());

                    VendaPagSeguro1.Produtos.Add(produto);
                }

                prd = null;

                VendaPagSeguro1.Cliente = new UOL.PagSeguro.Cliente();
                VendaPagSeguro1.Cliente.Nome = cliente.NOME;
                VendaPagSeguro1.Executar(this.Response);
            }
            else 
            {

            }
        }
    }
}