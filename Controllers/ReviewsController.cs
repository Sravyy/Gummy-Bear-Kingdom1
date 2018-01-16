using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;

namespace GummyBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;

        public ReviewsController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        private GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();
        public IActionResult Index()
        {
            return View(reviewRepo.Reviews. ToList());
        }

        public IActionResult Details(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepo.Save(review);   // Updated
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View(thisReview);
        }
        [HttpPost]
        public IActionResult Edit(Review review)
        {
            reviewRepo.Edit(review);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
            reviewRepo.Remove(thisReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
