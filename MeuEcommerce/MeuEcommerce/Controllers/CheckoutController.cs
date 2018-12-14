using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuEcommerce.DAL;
using MeuEcommerce.Models;

namespace MeuEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        
        // GET: Checkout
        public ActionResult Index()
        {
            var model = new CheckoutIndexViewModel();
            model.Carrinho = GetCarrinhoDaSessao();
            
            return View(model);
        }


        public ActionResult IncrementaItem(int id)
        {
                    
            var carrinho = GetCarrinhoDaSessao();

            carrinho.Incrementa(id);

            return RedirectToAction("Index");
        }

        public ActionResult DecremtaItem(int id)
        {

            var carrinho = GetCarrinhoDaSessao();

            carrinho.Decrementa(id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveItem(int id)
        {

            var carrinho = GetCarrinhoDaSessao();

            carrinho.RemoveItem(id);

            return RedirectToAction("Index");
        }

        public ActionResult Limpar()
        {

            var carrinho = GetCarrinhoDaSessao();

            carrinho.LimparCarrinho();

            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}