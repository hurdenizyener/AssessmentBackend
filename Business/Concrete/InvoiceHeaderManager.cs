using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace Business.Concrete
{
    public class InvoiceHeaderManager : IInvoiceHeaderService
    {
        private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;
        private readonly ILogger<InvoiceHeaderManager> _logger;


        public InvoiceHeaderManager(IInvoiceHeaderRepository invoiceHeaderRepository, ILogger<InvoiceHeaderManager> logger)
        {
            _invoiceHeaderRepository = invoiceHeaderRepository;
            _logger = logger;
        }

        public async Task<InvoiceHeader> AddAsync(InvoiceHeader invoiceHeader)
        {
            _logger.LogInformation("Invoice Header Add");
            return await _invoiceHeaderRepository.AddAsync(invoiceHeader);
            
        }

        public async Task<List<InvoiceHeader>> GetAllAsync()
        {
            _logger.LogInformation("Invoice Header List");
            return await _invoiceHeaderRepository.GetAllAsync();
        }
    }
}
