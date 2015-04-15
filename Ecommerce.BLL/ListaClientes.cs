using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.DAO;

namespace Ecommerce.BLL
{
    public static class ListaClientes
    {
        public static object ClienteLista(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            try
            {
                int clienteCount = clienteDAO.getAll().Count();
                List<CLIENTE> clientes = clienteDAO.GetClientes(jtStartIndex, jtPageSize, jtSorting);

                return new { Result = "OK", Records = clientes, TotalRecordCount = clienteCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }
    }
}
