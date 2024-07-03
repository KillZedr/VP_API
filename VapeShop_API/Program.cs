
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using VapeShop_BLL;
using VapeShop_BLL.Contracts.Identity;
using VapeShop_BLL.Contracts.VCProduct;
using VapeShop_BLL.Services.Identity;
using VapeShop_BLL.Services.VCProduct;

namespace VapeShop_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            TestWebApiModule.AddServices(builder);
            VapeShopBLL_ModuleHead.RegisterModule(builder.Services);







            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Forbidden";
                options.LogoutPath = "/Auth/Login";
            });

            builder.Services.AddScoped<Startup>();
         



            var app = builder.Build();

            DbInitializer.InitializeDB(app.Services);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }






            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };

            app.UseCookiePolicy(cookiePolicyOptions);



            app.MapControllers();

            app.Run();
        }
    }
}
