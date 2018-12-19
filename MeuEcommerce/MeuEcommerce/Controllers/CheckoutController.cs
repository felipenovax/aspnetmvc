using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuEcommerce.DAL;
using MeuEcommerce.Models;
using System.Data.Entity;


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

        public ActionResult CompraRealizada()
        {
            var carrinho = GetCarrinhoDaSessao();

            var compraItens = new List<CompraItem>();

            foreach (var item in carrinho.Itens)
            {
                compraItens.Add(new CompraItem(
                    item.Value.Qtd,
                    item.Value.PrecoUnidade,
                    item.Value.IdProduto));
            }

            var compra = new Compra(compraItens);

            _dal.Compras.Add(compra);
            _dal.SaveChanges();
            compra = _dal.Compras
                .Include(c => c.CompraItens)
                .Include(c => c.CompraItens.Select(i => i.Produto))
                .FirstOrDefault(item => item.Id == compra.Id);
                


            return View(compra);
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