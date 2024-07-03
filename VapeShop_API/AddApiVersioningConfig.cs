/*using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace VapeShop_API
{
    public  IServiceCollection AddApiVersioningConfig(this IServiceCollection services)
    {
        services.AddApiVersioning(cfg =>
        {
            cfg.DefaultApiVersion = new ApiVersion(1, 0);
            cfg.AssumeDefaultVersionWhenUnspecified = true;             
            cfg.ReportApiVersions = true;                               


            

            cfg.ApiVersionReader = ApiVersionReader.Combine(
                new HeaderApiVersionReader("X-version"),
                new QueryStringApiVersionReader("api-version"),
                new UrlSegmentApiVersionReader(),
                new MediaTypeApiVersionReader("ver"));
        });

        return services;
    }
}
}
*/