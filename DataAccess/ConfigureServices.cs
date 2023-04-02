using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ConnectionString")));

            services.AddTransient<IInvoiceLineRepository, InvoiceLineRepository>();
            services.AddTransient<IInvoiceHeaderRepository, InvoiceHeaderRepository>();


            return services;

        }
    }
}
