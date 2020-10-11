using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Data
{
    public class StoreIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) :
        base(options)
        {
            Database.EnsureCreated();
        }
    }
}
