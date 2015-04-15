using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.BLL;

namespace Ecommerce.WEB
{
    public partial class Teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                BuscarClientes();
            }
        }

        public void BuscarClientes() 
        {
            ClienteBLL cliente = new ClienteBLL();

            grdClientes.DataSource = cliente.getAll();
            grdClientes.DataBind();

            cliente = null;

        }
    }
}