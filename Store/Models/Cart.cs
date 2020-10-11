using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();
        public virtual void AddNewProduct(Product product, int quantity)
        {
            CartLine cartLine = CartLines
            .Where(line => line.Product.Id == product.Id).FirstOrDefault();
            if (cartLine == null)
            {
                CartLines.Add(new CartLine { Product = product, ProductCount = quantity });
            }
            else
            {
                cartLine.ProductCount += quantity;
            }
        }

        public virtual void RemoveLine(Product product)
        {
            CartLines.RemoveAll(line => line.Product.Id == product.Id);
        }

        public decimal TotalValue
        {
            get
            {
                return CartLines.Sum(line => line.Product.Price * line.ProductCount);
            }
        }

        public virtual void Clear()
        {
            CartLines.Clear();
        }
    }
    
    public class CartLine
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        public decimal LinePrice { get { return Product.Price * ProductCount; } }
    }

}
