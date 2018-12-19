using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    [Table("Compras")]
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public CompraStatus Status { get; set; }
        public virtual List<CompraItem> CompraItens { get; set; }  //Virtual pq vier do BD nao vai ser uma lista, vai ser uma referencia
        //public object Itens { get; internal set; }

        [NotMapped]
        public decimal PrecoTotal
            => CompraItens.Sum(i => i.PrecoTotal);

        public Compra()
        {

        }

        public Compra(List<CompraItem> itens)
        {
            Data = DateTime.Now;
            Status = CompraStatus.AgPagamento;
            CompraItens = itens;
        }

    }


    public enum CompraStatus
    {
        AgPagamento = 1,
        SeparandoPedido = 2,
        EntregueTransportadora = 3,
        Finalizado = 4
    }

}