namespace MobileService
{
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using AutoMapper;

    using Data;
    using Infrastructure;
    using Services;
    using Services.Contracts;
    using Services.Infrastructure;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.Cookie.Name = "ms_authentication";
                });

            // Initialize Application Data Base Context
            services.AddDbContext<MobileServiceDbContext>(
               options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            // Initialize Automapper Profiles
            services.AddAutoMapper(
                typeof(ServiceMappingProfile).Assembly, 
                typeof(ContrallerMappingProfile).Assembly);

            // Initialize Application Services
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IRepairService, RepairService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
