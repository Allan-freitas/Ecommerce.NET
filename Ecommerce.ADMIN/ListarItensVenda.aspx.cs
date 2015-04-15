using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.DAO;
using Ecommerce.BLL;

namespace Ecommerce.ADMIN
{
    public partial class ListarItensVenda : System.Web.UI.Page
    {
        List<ITEM_VENDA> itensVenda = new List<ITEM_VENDA>();
        ItemVendaBLL itemVendaBLL = new ItemVendaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idtVenda = 0;

            if (Session["idtVenda"] != null) 
            {
                idtVenda = int.Parse(Session["idtVenda"].ToString());

                itensVenda = itemVendaBLL.BuscarItensVenda(idtVenda);
                GrvItens.DataSource = itensVenda;
                GrvItens.DataBind();
            }
        }

        protected void GrvItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ITEM_VENDA itemVenda = (ITEM_VENDA)e.Row.DataItem;

                ((Label)e.Row.FindControl("lblProduto")).Text = itemVenda.PRODUTO.NOME;
            }
        }
    }
}