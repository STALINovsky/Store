using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Store.Controllers;
using Store.Data;
using Store.Models;
using Xunit;
using Store.Infrastructure;
using Store.Models.ViewModels;

namespace Store.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void ProductListTest()
        {

            Product[] startProducts = new Product[]
            {
                new Product { Id = 1, Name = "p1" },
                new Product { Id = 2, Name = "p2" },
                new Product { Id = 3, Name = "p2" },
                new Product { Id = 4, Name = "p2" },
                new Product { Id = 5, Name = "p2" },
            };

            Mock mockRepository = new Mock<IProductRepository>();
            mockRepository.As<IProductRepository>()
            .SetupGet(repos => repos.Products).Returns(startProducts.AsQueryable<Product>());

            int ItemsPerPage = 2;
            ProductController controller = new ProductController(mockRepository.As<IProductRepository>().Object)
            {
                ItemsPerPage = ItemsPerPage,
            };

            int productPage = 2;
            ProductsListViewModel resultModel = controller.List(null, productPage).ViewData.Model as ProductsListViewModel;
            Product[] resultProducts = resultModel.Products.ToArray();


            Assert.True(resultModel.PagingInfo.ItemsPerPage == ItemsPerPage);
            Assert.Equal(resultProducts[0], startProducts[ItemsPerPage]);
            Assert.Equal(resultProducts[1], startProducts[ItemsPerPage + 1]);

        }

        [Fact]
        public void ProductCategoryFilterTest()
        {
            string firstCategory = "First";
            string secondCategory = "Second";
            Product[] startProducts = new Product[]
            {
                new Product { Id = 1, Category = firstCategory },
                new Product { Id = 2, Category = firstCategory },
                new Product { Id = 3, Category = firstCategory },
                new Product { Id = 4, Category = secondCategory },
                new Product { Id = 5, Category = secondCategory },
            };

            Mock mockRepsitory = new Mock<IProductRepository>();
            mockRepsitory.As<IProductRepository>()
            .SetupGet(repos => repos.Products).Returns(startProducts.AsQueryable<Product>());

            ProductController controller = new ProductController(mockRepsitory.As<IProductRepository>().Object);
            controller.ItemsPerPage = 5;

            ProductsListViewModel resultModel = controller.List(firstCategory).ViewData.Model 
            as ProductsListViewModel;
            Product[] resultProducts = resultModel.Products.ToArray();

            Assert.Equal(resultProducts[0], startProducts[0]);
            Assert.Equal(resultProducts[1], startProducts[1]);
            Assert.Equal(resultProducts[2], startProducts[2]);
            
        }
    }
}
