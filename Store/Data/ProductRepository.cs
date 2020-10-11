using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
    public class ProductRepository : IProductRepository
    {
        private StoreDbContext context;
        public ProductRepository(StoreDbContext context)
        {
            this.context = context;
            Products = context.Products;
        }

        public IQueryable<Product> Products { get; private set; }

        public Product DeleteProduct(int productId)
        {
            Product entry = context.Products.FirstOrDefault(product => product.Id == productId);
            if (entry != null)
            {
                context.Products.Remove(entry);
                context.SaveChanges();
            }
            return entry;
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product entry = context.Products.FirstOrDefault(prod => prod.Id == product.Id);
                if (entry != null)
                {
                    entry.Name = product.Name;
                    entry.Description = product.Description;
                    entry.Price = product.Price;
                    entry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
    }
}
