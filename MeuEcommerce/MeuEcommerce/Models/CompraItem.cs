using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    [Table("CompraItens")]
    public class CompraItem
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public decimal PrecoUnitario { get; set; }

        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }

        [NotMapped]
        public decimal PrecoTotal => PrecoUnitario * Qtd;

        public CompraItem()
        {

        }

        public CompraItem(int qtd, decimal precoUnitario, int produtoID)
        {
            this.Qtd = qtd;
            this.PrecoUnitario = precoUnitario;
            this.ProdutoID = produtoID;
        }
    }
}