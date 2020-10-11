using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(repository.Products);
        }

        [Authorize]
        public IActionResult Edit(int productId)
        {
            return View(repository.Products.FirstOrDefault(prod => prod.Id == productId));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit (Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            TempData["message"] = $"{product.Name} has been saved";
            repository.SaveProduct(product);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public ViewResult Create()
        {
            return View("Edit",new Product());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete (int productId)
        {
            Product deleted = repository.DeleteProduct(productId);
            string message;
            if (deleted != null)
                message = $"{deleted.Name} was deleted";
            else
                message = "Error!";
            TempData["message"] = message;
            return RedirectToAction(nameof(Index));
        }
    }
}
