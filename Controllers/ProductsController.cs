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
    public class ProductsController : Controller
    {
        private GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {   
            return View(db.Products.ToList());
        }



    }
}
