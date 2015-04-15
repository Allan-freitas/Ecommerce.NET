using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.DAO.Interfaces;

namespace Ecommerce.DAO
{
    public class ItemVendaDAO : AbstractCRUD<ITEM_VENDA>, IItemVendaDAO
    {
        public List<ITEM_VENDA> BuscarItensVenda(int idtVenda) 
        {
            return Find(i => i.IDT_VENDA.Equals(idtVenda)).ToList();
        }
    }
}
