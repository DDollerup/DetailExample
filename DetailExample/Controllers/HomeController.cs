using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using DetailExample.Models;
using DetailExample.Models.Factories;

namespace DetailExample.Controllers
{
    public class HomeController : Controller
    {
        ProductFac productFac;


        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Products()
        {
            productFac = new ProductFac(this.HttpContext);
            List<Product> products = productFac.Products();
            return View(products);
        }

        public ActionResult ShowProduct(int id)
        {
            productFac = new ProductFac(this.HttpContext);

            List<Product> products = productFac.Products();

            Product product = products.Find(x => x.ProductID == id);
            return View(product);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product newProduct, HttpPostedFileBase file)
        {
            productFac = new ProductFac(this.HttpContext);

            if (file.ContentLength > 0 && file != null)
            {
                string filePath = HttpContext.Request.PhysicalApplicationPath;
                file.SaveAs(filePath + "/Content/Images/Products/" + file.FileName);
                newProduct.Image = file.FileName;
            }
            else
            {
                newProduct.Image = "coming_soon.png";
            }

            TempData["MSG"] = "A product with name " + newProduct.Name + " has been created.";



            productFac.AddProduct(newProduct);
                
            return View("AddProduct");
        }
    }
}