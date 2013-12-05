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
    public class CommentController : Controller
    {
        private TestContext db = new TestContext();

        //
        // GET: /Comment/

        public ActionResult Index()
        {
            var productsreviews = db.ProductsReviews.Include(p => p.Product);
            return View(productsreviews.ToList());
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductReview productreview = db.ProductsReviews.Find(id);
            if (productreview == null)
            {
                return HttpNotFound();
            }
            return View(productreview);
        }

        public ActionResult PayPal() 
        {
            return View();
        }

        //
        // GET: /Comment/Create

        public ActionResult Create(int ProductID = 0)
        {
            ViewBag.Product = db.Products.Find(ProductID);
            ViewBag.ImageProduct = db.Images.Where(i => i.ProductID == ProductID).FirstOrDefault();
            var commentsOfProduct = (from n in db.ProductsReviews
                                     where n.ProductID == ProductID
                                     select n).ToList();
            ViewBag.Comments = commentsOfProduct;
            ViewBag.productId = ProductID;
            return View();
        }

        //
        // POST: /Comment/Create

        [HttpPost]
        public ActionResult Create(string rating, ProductReview productreview)
        {
            if (ModelState.IsValid)
            {
                productreview.User = User.Identity.Name;
                productreview.Date = DateTime.Now;
                productreview.Rating = Convert.ToInt32(rating);
                db.ProductsReviews.Add(productreview);
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", productreview.ProductID);
            return View(productreview);
        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductReview productreview = db.ProductsReviews.Find(id);
            if (productreview == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", productreview.ProductID);
            return View(productreview);
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductReview productreview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productreview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", productreview.ProductID);
            return View(productreview);
        }

        //
        // GET: /Comment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductReview productreview = db.ProductsReviews.Find(id);
            if (productreview == null)
            {
                return HttpNotFound();
            }
            return View(productreview);
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductReview productreview = db.ProductsReviews.Find(id);
            db.ProductsReviews.Remove(productreview);
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