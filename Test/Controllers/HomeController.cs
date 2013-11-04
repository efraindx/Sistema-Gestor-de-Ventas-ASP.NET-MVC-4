using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private TestContext db = new TestContext();
        public ActionResult Index()
        {
            ViewBag.Message = "Articulos mas destacados";
            var products = db.Products.ToList();
            ViewBag.Products = products;
            var images = db.Images.ToList();
            ViewBag.ProductsImages = images;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }
    }
}
