using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.DAO.Interfaces;

namespace Ecommerce.DAO
{
    public class ProdutoDAO : AbstractCRUD<PRODUTO>, IProdutoDAO
    {
        public int Quantidade { set; get; }

        public PRODUTO buscarProduto(int idProduto) 
        {
            return Find(p => p.IDT_PRODUTO.Equals(idProduto)).First();
        }

        public PRODUTO buscarEspecial(int idProduto)
        {
            return Find(p => p.IDT_PRODUTO.Equals(idProduto)).FirstOrDefault();
        }

        public List<PRODUTO> buscarProdutoNome(string txtPesquisa)
        {
            return Find(p => p.NOME.Contains(txtPesquisa)).ToList(); ;
        }

        public List<PRODUTO> RetornarQdtProdutos() 
        {
            return getAll().Take(12).ToList();
        }

        public List<PRODUTO> RetornarParaSorteio()
        {
            return getAll().ToList();
        }
    }
}
