using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class IoC
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
           services.AddAutoMapper(Assembly.GetExecutingAssembly());
           services.AddMediatR(Assembly.GetExecutingAssembly());
           services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
