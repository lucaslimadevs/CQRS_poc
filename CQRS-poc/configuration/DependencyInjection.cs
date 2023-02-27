using CQRS_poc.Domain.Repositories;
using CQRS_poc.Infra.Sqlite.Repositories;
using CQRS_poc.Infra.Sqlite.UoW;

namespace CQRS_poc.configuration
{
    public static class DependencyInjection
    {        
        public static void AddDIConfiguration(this IServiceCollection services)
        {                     
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
