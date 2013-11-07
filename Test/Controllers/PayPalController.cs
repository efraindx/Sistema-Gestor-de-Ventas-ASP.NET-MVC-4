using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using Test.Models;
using System.Web.Mvc;

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

        public ActionResult ValidateCommand(string product, string totalPrice)
        {
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandbox);

            paypal.item_name = product;
            paypal.amount = totalPrice;
            return View(paypal);
        }

    }
}
