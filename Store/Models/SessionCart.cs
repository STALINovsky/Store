using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        public static Cart GetCart(IServiceProvider provider)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            SessionCart cart = session.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddNewProduct(Product product, int quantity)
        {
            base.AddNewProduct(product, quantity);
            SaveChanges();
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            SaveChanges();
        }

        private void SaveChanges()
        {
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            SaveChanges();
        }
    }
}
