using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummyBearKingdom.Models.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        GummyBearKingdomDbContext db;

        public EFProductRepository()
        {
            db = new GummyBearKingdomDbContext();
        }
        public EFProductRepository(GummyBearKingdomDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Product Edit(Product Product)
        {
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            return Product;
        }

        public void Remove(Product Product)
        {
            db.Products.Remove(Product);
            db.SaveChanges();
        }

        public Product Save(Product Product)
        {
            db.Products.Add(Product);
            db.SaveChanges();
            return Product;
        }

        public void ClearAll()
        {
            List<Product> AllProducts = db.Products.ToList();
            db.Products.RemoveRange(AllProducts);
            db.SaveChanges();
        }
    }

}