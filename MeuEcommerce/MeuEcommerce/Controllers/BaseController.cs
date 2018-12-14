using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuEcommerce.Models;
using MeuEcommerce.DAL;


namespace MeuEcommerce.Controllers
{
    public class BaseController : Controller

    {
        protected DBContext _dbc = new DBContext();



        protected override void OnActionExecuting(
            ActionExecutingContext filterContext)

        {
            ViewBag.Carrinho = GetCarrinhoDaSessao();
            base.OnActionExecuting(filterContext);
        }


        protected CarrinhoCompras GetCarrinhoDaSessao()
        {
            if (Session["carrinho"] == null)
            {
                Session["carrinho"] = new CarrinhoCompras();
            }
            return (CarrinhoCompras)Session["Carrinho"];
        }
    }
}