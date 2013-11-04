using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace MarketPlace.Controllers
{
    public class ProductController : Controller
    {
        private TestContext db = new TestContext();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var products = db.Products.Include(p => p.Category).Include(p => p.ProductCondition);
                return View(products.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            Image image = db.Images.Where(img => img.ProductID == id).First();
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageActual = image;
            var commentsOfProduct = (from n in db.ProductsReviews
                                     where n.ProductID == id
                                     select n).ToList();
            ViewBag.Comments = commentsOfProduct;
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
                ViewBag.ProductConditionID = new SelectList(db.ProductsConditions, "ProductConditionID", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Product product)
        {
            string path = "";
            string fileName = "";
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    fileName = System.IO.Path.GetFileName(file.FileName);
                    path = System.IO.Path.Combine(Server.MapPath("~/Images"), fileName);

                    //file saved
                    file.SaveAs(path);
                }

                int productId = product.ProductID;
                Image image = new Image(productId, "/Images/" + fileName);
                db.Images.Add(image);

                product.DateOfPublication = DateTime.Now;
                product.Owner = User.Identity.Name;

                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.ProductConditionID = new SelectList(db.ProductsConditions, "ProductConditionID", "Name", product.ProductConditionID);
            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.ProductConditionID = new SelectList(db.ProductsConditions, "ProductConditionID", "Name", product.ProductConditionID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.ProductConditionID = new SelectList(db.ProductsConditions, "ProductConditionID", "Name", product.ProductConditionID);
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            Image image = db.Images.Where(img => img.ProductID == id).First();

            db.Images.Remove(image);
            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
           
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}