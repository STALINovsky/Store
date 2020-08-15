using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
    public class StoreRepository : IProductRepository
    {
        private StoreDbContext context;
        public StoreRepository(StoreDbContext context)
        {
            this.context = context;
            Products = context.Products;
        }

        public IQueryable<Product> Products { get; set; } 
       
    }
}
