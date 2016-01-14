using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetailExample.Models;

namespace DetailExample.Models.Factories
{
    public class ProductFac
    {
        List<Product> products = new List<Product>()
        {
            new Product()
            {
                ProductID = 1,
                Name = "Nike Sneakers",
                Description = "These nike sneakers fit your feet awesome",
                InStorage = true,
                Price = 19.99f,
                Image = "shoe1.jpg"
            },
            new Product()
            {
                ProductID = 2,
                Name = "Converse",
                Description = "These Converse shoes are old as hell",
                InStorage = true,
                Price = 9.99f,
                Image = "shoe2.jpg"
            },
            new Product()
            {
                ProductID = 3,
                Name = "Nike Mario Sneakers",
                Description = "Mario, because why the fuck not",
                InStorage = false,
                Price = 89.99f,
                Image = "shoe3.jpg"
            },
            new Product()
            {
                ProductID = 4,
                Name = "Peoples shoes",
                Description = "To thee who has no life.",
                InStorage=true,
                Price = 2.99f,
                Image = "shoe4.png"
            }
        };

        List<Product> tempSessionList = new List<Product>();

        private HttpContextBase Context { get; set; }

        public ProductFac(HttpContextBase context)
        {
            this.Context = context;

            if (Context.Session["SessionProduct"] != null)
            {
                this.products = Context.Session["SessionProduct"] as List<Product>;
            }
        }

        public List<Product> Products()
        {
            return products;
        }

        public void AddProduct(Product productToAdd)
        {
            productToAdd.ProductID = products.Count + 1;
            products.Add(productToAdd);
            Context.Session["SessionProduct"] = products;
        }
    }
}