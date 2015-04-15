using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.DAO.Interfaces;

namespace Ecommerce.DAO
{
    public class ClienteDAO : AbstractCRUD<CLIENTE>, IClienteDAO
    {

        public CLIENTE AutenticarCliente(string email, string senha)
        {
            return Find(c => c.EMAIL.Trim().Equals(email) && c.SENHA.Trim().Equals(senha)).FirstOrDefault();
        }

        public CLIENTE RecuperaSenha(string email) 
        {
            return Find(c => c.EMAIL.Trim().Equals(email)).FirstOrDefault();
        }

        public CLIENTE SalvaCliente(CLIENTE cliente)
        {
            Add(cliente);
            SaveChanges();

            return cliente;
        }

        public bool VerificaClienteExist(string email) 
        {
            int qtdCliente = 0;

            qtdCliente = Find(c => c.EMAIL.Trim().Equals(email)).Count();

            if (qtdCliente.Equals(0))
            {
                //Cliente não exite
                return false;
            }
            else 
            {
                //Cliente existe
                return true;
            }
        }

        public List<CLIENTE> GetClientes(int startIndex, int count, string sorting) 
        {
            IEnumerable<CLIENTE> query = getAll();

            if (string.IsNullOrEmpty(sorting) || sorting.Equals("Name ASC")) 
            {
                query = query.OrderBy(c => c.NOME);
            }
            else if (sorting.Equals("Name DESC"))
            {
                query = query.OrderByDescending(c => c.NOME);
            }
            else 
            {
                query = query.OrderBy(c => c.NOME);
            }

            return count > 0 ? query.Skip(startIndex).Take(count).ToList() : query.ToList();
        }
    }
}
