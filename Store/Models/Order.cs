using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Store.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter your City")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please enter your Street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter your House")]
        public string House { get; set; }
        [Required(ErrorMessage = "Please enter your Region")]
        public string Region { get; set; }

        public int Zip { get; set; }

        public string Comments { get; set; }
    }
}
