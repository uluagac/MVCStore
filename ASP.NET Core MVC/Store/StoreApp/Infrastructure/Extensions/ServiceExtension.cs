using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extensions
{
  public static class ServiceExtension
  {
    /// <summary>
    /// Database için extension
    /// </summary>
    /// <param name="services">Ekleme yapılacak class</param>
    /// <param name="configuration"></param>
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<RepositoryContext>(options =>
      {
        options.UseSqlite(configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
      }
      );
    }
    /// <summary>
    /// Sessiona erişmek için extension
    /// </summary>
    /// <param name="services">Ekleme yapılacak class</param>
    public static void ConfigureSession(this IServiceCollection services)
    {
      services.AddDistributedMemoryCache();
      services.AddSession(options =>
      {
        options.Cookie.Name = "StoreApp.Session";
        options.IdleTimeout = TimeSpan.FromMinutes(10);
      });
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddScoped<Cart>(c => SessionCart.GetCart(c));
    }
    /// <summary>
    /// Repository IoC için extension
    /// </summary>
    /// <param name="services">Ekleme yapılacak class</param>
    public static void ConfigureRepositoryRegistration(this IServiceCollection services)
    {
      services.AddScoped<IRepositoryManager, RepositoryManager>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();
    }
    /// <summary>
    /// Service IoC için extension
    /// </summary>
    /// <param name="services">Ekleme yapılacak class</param>
    public static void ConfigureServiceRegistration(this IServiceCollection services)
    {
      services.AddScoped<IServiceManager, ServiceManager>();
      services.AddScoped<IProductService, ProductManager>();
      services.AddScoped<ICategoryServices, CategoryManager>();
      services.AddScoped<IOrderService, OrderManager>();
    }
    public static void ConfigureRouting(this IServiceCollection services)
    {
      services.AddRouting(options =>
      {
        options.LowercaseUrls = true;
        options.AppendTrailingSlash = false;
      });
    }
  }
}