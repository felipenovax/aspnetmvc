using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuEcommerce.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Eu(string id)
        {
            return View();
        }

        public ActionResult Voce(string id)
        {
            ViewBag.variavel = id;
            return View();
        }
    }
}