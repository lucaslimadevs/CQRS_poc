using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_poc.Commands
{
    public static class DependencyInjection
    {
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection));
        }
    }
}