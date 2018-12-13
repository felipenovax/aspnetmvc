using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Produto
    {
        static Random _random = new Random();
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public string Descrição { get; set; }
        public int Id { get; set; }
        public int IdCategoria { get; set; }

        public Produto(string nome, int id, string img, int idCategoria)
        {
            Id = id;
            Nome = nome;
            Preco = _random.Next(10, 100) + (decimal)_random.NextDouble();
            Descrição = "Descrição - " + nome;
            Imagem = "/img/" + img + ".jpg";
            IdCategoria = idCategoria;

        }
    }
}