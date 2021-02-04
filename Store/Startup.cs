using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Store
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false);
            
            string productDbConnection = Configuration.GetConnectionString("StoreProducts");
            services.AddDbContext<StoreDbContext>
            (options => options.UseSqlServer(productDbConnection));

            string usersDbConnection = Configuration.GetConnectionString("StoreUsers");
            services.AddDbContext<StoreIdentityDbContext>(options =>
            options.UseSqlServer(usersDbConnection));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<StoreIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddScoped<Cart>(SessionCart.GetCart);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
        }
    }
}
