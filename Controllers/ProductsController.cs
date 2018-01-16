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
    public class ProductsController : Controller
    {
        private IProductRepository productRepo; 

        public ProductsController(IProductRepository repo = null)
        {
            if (repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = repo;
            }
        }

        public IActionResult Index()
        {   
            return View(productRepo.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            Product thisProduct = productRepo.Products
                               
                               .FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Save(product);
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {   

            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepo.Edit(product);   // Updated!
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            productRepo.Remove(thisProduct);  
            return RedirectToAction("Index");
        }
    }
}
