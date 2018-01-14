using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummyBearKingdom.Models;


namespace GummyBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {   
            return View(db.Reviews.Include(x => x.Product).ToList());
        }

        public IActionResult Details(int id)
        {
            Review thisReview = db.Reviews
                               .Include(x => x.Product)
                               .FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review Review)
        {
            db.Reviews.Add(Review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            var thisReview = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            db.Reviews.Remove(thisReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
