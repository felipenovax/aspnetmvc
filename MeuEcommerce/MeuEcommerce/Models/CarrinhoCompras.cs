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


    public class CarrinhoItem
    {
        
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoUnidade { get; set; }
        public int Qtd { get; set; }


        
        
        public CarrinhoItem (
            int idProduto,
            string nomeProduto, 
            decimal precoUnidade)

        {
            this.IdProduto = idProduto;
            this.NomeProduto = nomeProduto;
            this.Qtd = 1;
            this. PrecoUnidade = precoUnidade;
           
        }

        public decimal PrecoTotal => PrecoTotal * Qtd;
    }

}