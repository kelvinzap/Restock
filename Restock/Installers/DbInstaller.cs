using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restock.Data;
using Restock.Repositories;
using Restock.Services;

namespace Restock.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        
        services.AddSingleton<IProductRepository, ProductRepository>();
        //services.AddSingleton<ICartRepository, CartRepository>();
        services.AddSingleton<ICartService, CartService>();
        services.AddSingleton<IDbConnection, DbConnection>();
        services.AddSingleton<ICartRepository, MongoCartRepository>();
    }
}