using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D06_MVCBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace D06_MVCBasic.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>();

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _products.Add(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int masp)
        {
            var sp = _products.SingleOrDefault(p => p.Id == masp);
            if(sp != null)//nếu có
            {
                return View(sp);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var sp = _products.SingleOrDefault(p => p.Id == product.Id);
            if (sp != null)//nếu có
            {
                sp.Name = product.Name;
                sp.Price = product.Price;
                sp.Quantity = product.Quantity;
            }

            return RedirectToAction("Index");
        }
    }
}