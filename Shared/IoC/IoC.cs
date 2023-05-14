namespace Shared.IoC
{
    using Application.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Shared.Service;
    public static class  IoC
    {
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configurations)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();

        }
    }
}
