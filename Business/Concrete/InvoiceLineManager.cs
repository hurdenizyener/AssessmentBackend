using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace Business.Concrete
{
    public class InvoiceLineManager : IInvoiceLineService
    {
        private readonly IInvoiceLineRepository _invoiceLineRepository;
        private readonly ILogger<InvoiceLineManager> _logger;

        public InvoiceLineManager(IInvoiceLineRepository invoiceLineRepository, ILogger<InvoiceLineManager> logger)
        {
            _invoiceLineRepository = invoiceLineRepository;
            _logger = logger;
        }

        public async Task<InvoiceLine> AddAsync(InvoiceLine invoiceLine)
        {
            _logger.LogInformation("Invoice Line Add");
            return await _invoiceLineRepository.AddAsync(invoiceLine);
        }

        public async Task<List<InvoiceLine>> GetAllAsync(string invoiceId)
        {
            _logger.LogInformation("Invoice Line List");
            return await _invoiceLineRepository.GetAllAsync(p => p.InvoiceId == invoiceId);
        }
    }
}
