using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using
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
            
            return View();
        }
    }
}