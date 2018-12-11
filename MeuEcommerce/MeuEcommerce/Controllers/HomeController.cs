using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuEcommerce.Models;


namespace MeuEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private CarrinhoCompras GetCarrinho()
        {
            if(Session["carrinho"] == null)
            {
                Session["carrinho"] = new CarrinhoCompras();
            }
            return (CarrinhoCompras)Session["Carrinho"];
        }

        public ActionResult Index(int? categoria)
        {


            int valor = 1;
            Session["chave"] = valor;
            valor = (int)Session["chave"];


            ViewBag.Carrinho = GetCarrinho();

            var model = new Models.HomeIndexViewModel();

            model.CategoriaSelecionada = categoria;

            model.Produtos = new Models.Produto[]
            
            
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

           
            model.Categorias = new Models.Categoria[]
            {
                new Models.Categoria("TVs", 2),
                new Models.Categoria("Celulares", 1),
                new Models.Categoria("VideoGames", 3),
                new Models.Categoria("Notebooks", 4),
               
            };

            if(categoria != null)
            {
                model.Produtos = model.Produtos
                    .Where(p => p.IdCategoria == categoria)
                    .ToArray();
            }

            

            return View(model);

            
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}