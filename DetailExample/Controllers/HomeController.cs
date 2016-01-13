using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DetailExample.Models;
using DetailExample.Models.Factories;

namespace DetailExample.Controllers
{
    public class HomeController : Controller
    {
        ProductFac productFac = new ProductFac();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            List<Product> products = productFac.Products();
            return View(products);
        }

        public ActionResult ShowProduct(int id)
        {
            List<Product> products = productFac.Products();

            Product product = products.Find(x => x.ProductID == id);

            return View(product);
        }
    }
}