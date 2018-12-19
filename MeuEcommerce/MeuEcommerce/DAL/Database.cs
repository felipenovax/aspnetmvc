using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeuEcommerce.Models;
using System.Data.Entity;

namespace MeuEcommerce.DAL
{
    public class Database : DbContext
    {

        


        public IDbSet<Produto> Produtos { get; set; }
        public IDbSet<Categoria> Categorias { get; set; }
        public IDbSet<Fornecedor> Fornecedores { get; set; }
        public IDbSet<Compra> Compras {get; set;}
        public IDbSet<CompraItem> CompraItens { get; set; }
        public IDbSet<Cliente> Clientes { get; set; }
        

       

        public Produto GetProdutoPorId(int id)
        {
            foreach (var item in Produtos)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
            
        }


       
        
    }
}