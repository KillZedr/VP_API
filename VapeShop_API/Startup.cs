using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using VapeShop_API.Middleware;


namespace VapeShop_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            

            
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5170";
                    options.Audience = "VapeShopAPI";
                    options.RequireHttpsMetadata = false;
                });
            services.AddVersionedApiExplorer(options =>
                options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                    ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddApiVersioning();

          

            /*services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    /*config.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.ApiVersion.ToString());*/
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioning();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
