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
    public partial class ListarVendas : System.Web.UI.Page
    {
        int idtVenda = 0;
        VendaBLL vendaBLL = new VendaBLL();
        VENDA venda = new VENDA();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                BuscarVendas();
            }
        }

        public void BuscarVendas()
        {
            GrvVendas.DataSource = vendaBLL.getAll();
            GrvVendas.DataBind();
        }

        protected void GrvVendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui posso fazer um cast ou uma conversão!

            idtVenda = (int)GrvVendas.SelectedValue;

            //Listar Itens de Venda
            Session.Add("idtVenda", idtVenda);
            Response.Redirect("ListarItensVenda.aspx");

            vendaBLL = null;
            venda = null;
        }

        protected void GrvVendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                VENDA venda = (VENDA)e.Row.DataItem;

                ((Label)e.Row.FindControl("lblCliente")).Text = venda.CLIENTE.NOME;
            }
        }
    }
}