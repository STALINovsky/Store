using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using Store.Models.ViewModels;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        public int ItemsPerPage { get; set; } = 5;
        private IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }


        [Route("{category}/Page{productPage:int}", Order = 1)]
        [Route("Page{productPage:int}", Order = 2)]
        [Route("{category}",Order = 3)]
        [Route("", Order = 4)]
        public ViewResult List(string category, int productPage = 1)
        {
            int skipPagesCount = (productPage - 1) * ItemsPerPage;
            IQueryable<Product> categoryProducts = from product in repository.Products
                                                   where category == null || product.Category == category 
                                                   select product;

            IQueryable<Product> productsOnPage = categoryProducts.OrderBy(p => p.Id)
                                                 .Skip(skipPagesCount)
                                                 .Take(ItemsPerPage);

            PagingInfo paging = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = ItemsPerPage,
                TotalItems = categoryProducts.Count()
            };
            ProductsListViewModel model = new ProductsListViewModel()
            {
                PagingInfo = paging,
                Products = productsOnPage,
                CurrentCategory = category
            };

            return View(model);
        }
    }
}
