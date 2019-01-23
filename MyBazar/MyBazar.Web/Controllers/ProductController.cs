using MyBazar.Entities;
using MyBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService ProductService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsTable(string search)
        {
            var products = ProductService.GetProducts();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x =>x.Name !=null && x.Name.ToLower().Contains(search.ToLower())).ToList();
            }
           
            return PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductService.SaveProduct(product);
            return RedirectToAction("ProductsTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = ProductService.GetProduct(ID);
                return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductService.UpdateProduct(product);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Product  product)
        {
            product = ProductService.GetProduct(product.ID);
            ProductService.DeleteProduct(product.ID);

            return RedirectToAction("Index");
        }
    }
}