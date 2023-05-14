namespace Persistence.IoC
{
    using Application.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence.EntityFrameworkCore.ApplicationContext;
    using Persistence.Repository;

    public static class IoC
    {
        public static void AddPersistenceInfraestructre(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(optitions => optitions.UseSqlServer(
                configuration.GetConnectionString("DefaulConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddTransient(typeof(IReadRepositoryAsync<>), typeof(Repository<>));
        }
    }
}
