using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummyBearKingdom.Models.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        GummyBearKingdomDbContext db;

        public EFReviewRepository()
        {
            db = new GummyBearKingdomDbContext();
        }
        public EFReviewRepository(GummyBearKingdomDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Review Edit(Review Review)
        {
            db.Entry(Review).State = EntityState.Modified;
            db.SaveChanges();
            return Review;
        }

        public void Remove(Review Review)
        {
            db.Reviews.Remove(Review);
            db.SaveChanges();
        }

        public Review Save(Review Review)
        {
            db.Reviews.Add(Review);
            db.SaveChanges();
            return Review;
        }

        public void ClearAll()
        {
            List<Review> AllReviews = db.Reviews.ToList();
            db.Reviews.RemoveRange(AllReviews);
            db.SaveChanges();
        }
    }
}
