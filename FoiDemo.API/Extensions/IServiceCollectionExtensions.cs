using FoiDemo.Business.Services.EntityServices;
using FoiDemo.Data;
using FoiDemo.Data.Interfaces;
using FoiDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FoiDemo.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DemoDb");

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void ConfigureDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
        }

        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ClientService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FOI API", Version = "v1" });
            });
        }
    }
}
