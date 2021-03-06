﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
        [UIHint("Password")]
        public string Password { get; set; }
    }

}
