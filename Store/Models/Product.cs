using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Descriprion")]
        public string Description { get; set; }
        [Range(0.01,double.MaxValue,ErrorMessage = "Please enter positive Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter Category")]
        public string Category { get; set; }
    }
}
