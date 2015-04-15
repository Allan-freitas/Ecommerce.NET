using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.DAO;
using System.Web;

namespace Ecommerce.BLL
{
    public class Carrinho
    {
        public List<ITEM_VENDA> Itens { get { return BuscarLista(); } }

        public void adicionarItem(ITEM_VENDA item) 
        {
            List<ITEM_VENDA> lista = Itens;

            //Verificar se o produto já existe na Lista
            var resultado = lista.Where(i => i.IDT_PRODUTO == item.IDT_PRODUTO);
            if (resultado != null && resultado.Count() > 0)
            {
                //Atualizar a quantidade de produtos
                AtualizarLista(item);
            }
            else 
            {
                item.SUBTOTAL = (item.VALOR_UNITARIO * item.QUANTIDADE);
                lista.Add(item);
                HttpContext.Current.Session["lista"] = lista;
            }
        }

        public bool ExcluirItem(int codProduto)
        {
            List<ITEM_VENDA> lista = Itens;

            //Verificar se o produto já existe na Lista
            var resultado = lista.Where(i => i.IDT_PRODUTO == codProduto);
            if (resultado != null && resultado.Count() > 0)
            {
                ITEM_VENDA itemEncontrado = resultado.First();
                lista.Remove(itemEncontrado);

                HttpContext.Current.Session["lista"] = lista;
                return true;
            }
            return false;
        }

        public int QuantidadeTotal() 
        {
            return Itens.Count();
        }

        public decimal ValorTotal() 
        {
            decimal total = 0;

            foreach (ITEM_VENDA item in Itens) 
            {
                total += (decimal)item.SUBTOTAL;
            }
            return total;
        }

        public int FinalizarVenda(int idCliente, int IdtTipoVenda)
        {
            try
            {
                VENDA venda = new VENDA();
                ItemVendaBLL itemVendaBLL = new ItemVendaBLL();
                VendaBLL vendaBLL = new VendaBLL();

                venda.IDT_CLIENTE = idCliente;
                venda.IDT_TIPO_VENDA = IdtTipoVenda;
                venda.DATA_VENDA = DateTime.Now;
                venda.VALOR_TOTAL = this.ValorTotal();

                vendaBLL.Add(venda);
                vendaBLL.SaveChanges();

                foreach (ITEM_VENDA itemvenda in Itens)
                {
                    itemvenda.IDT_VENDA = venda.IDT_VENDA;
                    itemVendaBLL.Add(itemvenda);
                    itemVendaBLL.SaveChanges();
                }

                venda = null;
                itemVendaBLL = null;
                vendaBLL = null;

                return venda.IDT_VENDA;
            }
            catch 
            {
                return 0;
            }

        }

        #region "Métodos Privados"

        private void AtualizarLista(ITEM_VENDA item) 
        {
            List<ITEM_VENDA> lista = Itens;

            //Verificar se o produto já existe na Lista
            var resultado = lista.Where(i => i.IDT_PRODUTO == item.IDT_PRODUTO);

            if (resultado != null && resultado.Count() > 0)
            {
                ITEM_VENDA itemEncontrado = resultado.First();

                itemEncontrado.QUANTIDADE += item.QUANTIDADE;
                itemEncontrado.SUBTOTAL = (itemEncontrado.QUANTIDADE * itemEncontrado.VALOR_UNITARIO);
                HttpContext.Current.Session["lista"] = lista;
            }
        }

        private List<ITEM_VENDA> BuscarLista() 
        {
            List<ITEM_VENDA> lista;

            if (HttpContext.Current.Session["lista"] != null)
            {
                lista = (List<ITEM_VENDA>)HttpContext.Current.Session["lista"];
            }
            else 
            {
                lista = new List<ITEM_VENDA>();
            }

            return lista;
        }

        #endregion "Métodos Privados"
    }
}

/*
 * Quando a propriedade Itens da classe "Carrinho" for chamada o método get vai retornar uma lista (BuscarLista) que por sua vez vai pegar a lista da sessão
 * e transformá-la em um List<> por isso foi usado um cast para transformar Session lista para um List<>
*/