using GymManagement.Application.Common.Interfaces;
using GymManagement.Infraestructure.Common.Persistence;
using GymManagement.Infraestructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services)
    {
        services.AddDbContext<GymManagementDbContext>(options => options.UseSqlite("Data Source= GymManagement.db"));
        services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<GymManagementDbContext>());
        return services;
    }
}
