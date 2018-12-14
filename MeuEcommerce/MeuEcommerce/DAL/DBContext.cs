using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeuEcommerce.Models;

namespace MeuEcommerce.DAL
{
    public class DBContext
    {

        static Produto[] _produtos;
        static Categoria[] _categorias;




        public Produto[] GetProdutos()
        {
            if (_produtos == null)
            {
                _produtos = new Produto[]
                {
                new Models.Produto("Iphone X", 1,"iphone", 1),
                new Models.Produto("Galaxy S9", 1,"s9", 1),
                new Models.Produto("TV Led", 2,"TV Led", 2),
                new Models.Produto("TV Led", 2,"TV Philco", 2),
                new Models.Produto("Playstation 4", 3,"Playstation 4", 3),
                new Models.Produto("X BOX One", 3,"xbox", 3),
                new Models.Produto("Notebook Samsung", 4,"samsung", 4),
                new Models.Produto("Notebook Dell I7", 4,"Notebook Dell I7", 4),

                };
            }

            return _produtos;
        }

        public Produto GetProdutoPorId(int id)
        {
            foreach (var item in GetProdutos())
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;

            // return GetProdutos().First(item => item.Id == id);
        }
       
        public Categoria[] GetCategorias()
        {
            if (_categorias == null)
            {
                _categorias = new Categoria[]
                {
                new Models.Categoria("TVs", 2),
                new Models.Categoria("Celulares", 1),
                new Models.Categoria("VideoGames", 3),
                new Models.Categoria("Notebooks", 4),
                };

            }
            return _categorias;
        }
    }
}