using Market.Products.API.Mappers;
using Market.Products.BLL.Interfaces;
using Market.Products.BLL.Services;
using Market.Products.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Market.Products.API.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Market User API",
                    Version = "v1"
                });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return builder;
        }
        public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MarketProductsDbContext>(options =>
            {
                var marketProductsConnectionString = "MarketProductsDbContext";
                options.UseNpgsql(builder.Configuration.GetConnectionString(marketProductsConnectionString));
            });
            return builder;
        }
        public static WebApplicationBuilder AddApplicationService(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IManufacturerService, ManufacturerService>();
            return builder;
        }
        public static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MarketProductsMapper>();
            }, typeof(MarketProductsMapper).Assembly);

            return builder;
        }
        public static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IProductService).Assembly);
            });

            return builder;
        }
        public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings-local.json", optional: true, reloadOnChange: true);
            return builder;
        }

    }
}
