using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class CarrinhoItem
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoUnidade { get; set; }
        public int Qtd { get; set; }




        public CarrinhoItem(
            int idProduto,
            string nomeProduto,
            decimal precoUnidade)

        {
            this.IdProduto = idProduto;
            this.NomeProduto = nomeProduto;
            this.Qtd = 1;
            this.PrecoUnidade = precoUnidade;

        }

        public decimal PrecoTotal => PrecoUnidade * Qtd;
    }
}