using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.DAO.Interfaces;

namespace Ecommerce.DAO
{
    public class VendaDAO : AbstractCRUD<VENDA>, IVendaDAO
    {
        public VENDA BuscarVenda(int idVnda) 
        {
            return Find(v => v.IDT_VENDA.Equals(idVnda)).FirstOrDefault();
        }
    }
}
