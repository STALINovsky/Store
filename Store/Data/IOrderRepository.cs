using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
    public interface IOrderRepository
    {
        public IQueryable<Order> Orders { get; }
        public void SaveOrder(Order order);
    }
}
