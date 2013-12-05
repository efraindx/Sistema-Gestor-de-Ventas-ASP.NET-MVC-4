using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class ShoppingCartController : Controller
    {
        TestContext db = new TestContext();

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            //Set up the ViewModel
            var viewModel = new ShoppingCartViewModel 
            {
                CartItems = cart.GetCartItems(),
                CartTotal = Convert.ToDecimal(cart.GetTotal())
            };

            //Return the view
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedProduct = db.Products.Single(p => p.ProductID == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedProduct);

           // return HttpNotFound("" + id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            //Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            //Get the name of product to display information
            string productName = db.Carts.Single(
                    item => item.RecordId == id).Product.Title;
            
            //Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            //Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + 
                    "\nHa sido eliminado desde su carro de compras.",
                    CartTotal = Convert.ToDecimal(cart.GetTotal()),
                    CartCount = cart.GetCount(),
                    ItemCount = itemCount,
                    DeleteId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }

    }
}
