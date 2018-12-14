using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class CarrinhoCompras
    {
        public Dictionary<int, CarrinhoItem> Itens;

        public CarrinhoCompras()
        {
            Itens = new Dictionary<int, CarrinhoItem>();
        }

        public void Add(Produto produto)
        {
            if(Itens.ContainsKey(produto.Id))
            {
                Itens[produto.Id].Qtd++;
            }
            else
            {
                var CarrinhoItem = new CarrinhoItem(produto.Id, produto.Nome, produto.Preco);
                Itens.Add(produto.Id, CarrinhoItem);
            }
        } 

        public void Decrementa(int IdProduto)
        {
            Itens[IdProduto].Qtd--;

            if (Itens[IdProduto].Qtd == 0)
            {
                Itens.Remove(IdProduto);
            }
        }

        public void Incrementa(int IdProduto)
        {
            Itens[IdProduto].Qtd++;
        }

        public void RemoveItem(int idProduto)
        {

            Itens.Remove(idProduto);
        }


        public void LimparCarrinho()
        {
            
            Itens.Clear();
        }


        public int QuantidadeDeItens => Itens.Values.Sum(item => item.Qtd);
    }


   

}