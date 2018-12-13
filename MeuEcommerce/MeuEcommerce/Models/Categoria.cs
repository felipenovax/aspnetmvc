using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Categoria
    {
        public string Nome { get; set; }
        public int Id { get; set; }



        public Categoria(string nome, int id)
        {
            Nome = nome;
            Id = id;


        }

    }
}