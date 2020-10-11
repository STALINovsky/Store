using Microsoft.EntityFrameworkCore;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Store.Data
{
    public class OrderRepository : IOrderRepository
    {
        private StoreDbContext context;
        public OrderRepository(StoreDbContext context)
        {
            this.context = context;

        }
        public IQueryable<Order> Orders
        {
            get => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);
        }

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l=>l.Product));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
