using Restock.Repositories;
using Restock.Services;

namespace Restock.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<ICartRepository, CartRepository>();
        services.AddSingleton<ICartService, CartService>();
    }
}