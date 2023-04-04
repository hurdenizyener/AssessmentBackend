using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IInvoiceLineService, InvoiceLineManager>();
            services.AddTransient<IInvoiceHeaderService, InvoiceHeaderManager>();
            services.AddTransient<IInvoiceCreateService, InvoiceCerateManager>();

            return services;
        }
    }
}
