using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
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

        public ActionResult Suggest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Suggest(EmailModel model)
        {
            Email.Send(model.FromAdress, model.Subject, model.Body);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ViewResults(string filter)
        {

            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(filter))
            {
                products = products.Where(p => p.Title.ToUpper().Contains(filter.ToUpper()) 
                                                || p.Description.ToUpper().Contains(filter.ToUpper()));
            }
            ViewBag.filter = filter;
            return View(products.ToList());
        }

        [OutputCache(Duration = 30)]
        public PartialViewResult MostrarResultado()
        {
            Thread.Sleep(2000);
            ViewBag.ServerTime = DateTime.Now;

            return PartialView(new List<Persona>() 
            { 
                new Persona{ Nombre = "Efrain", Apellido = "Toribio"}, 
                new Persona { Nombre ="Otro", Apellido = "NUEvo"}, 
                new Persona {Nombre = "JAJAJ", Apellido = "Jimenez"}
            });
        }

        [HttpGet]
        public JsonResult FindWordInDB(string filter)
        {

            var products = from p in db.Products
                           select p;

            Product[] valuesReturn = null;

            if (!String.IsNullOrEmpty(filter))
            {
                valuesReturn = products.Where(p => p.Title.ToUpper().Contains(filter.ToUpper())).ToArray();
            }

            return new JsonResult()
            {
                Data = valuesReturn,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
           
        }
    }
}
