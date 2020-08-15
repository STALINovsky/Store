using System.Collections.Generic;
using Store.Models;
using Store.ViewModels;

namespace Store.ViewModels {

    public class ProductsListViewModel {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
