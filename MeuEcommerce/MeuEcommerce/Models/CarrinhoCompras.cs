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
        public int QuantidadeDeItens => Itens.Values.Sum(item => item.Qtd);
    }


   

}