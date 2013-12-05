using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Diagnostics;
using Test.Models;
using System.Web.Mvc;
using Test.ViewModels;

namespace Test.Controllers
{
    public class PayPalController : Controller
    {
        //
        // GET: /PayPal/

        public ActionResult RedirectFromPayPal()
        {
            return View();
        }

        public ActionResult CancelFromPayPal()
        {
            return View();
        }

        public ActionResult NotifyFromPayPal()
        {
            return View();
        }

        public ActionResult ValidateCommand()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            //Set up the ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = Convert.ToDecimal(cart.GetTotal())
            };

            return View(viewModel);
        }

    }
}
