using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Entities;

namespace Business.Concrete
{
    public class InvoiceLineManager : IInvoiceLineService
    {
        private readonly IInvoiceLineRepository _invoiceLineRepository;

        public InvoiceLineManager(IInvoiceLineRepository invoiceLineRepository)
        {
            _invoiceLineRepository = invoiceLineRepository;
        }

        public async Task<InvoiceLine> AddAsync(InvoiceLine invoiceLine)
        {
            return await _invoiceLineRepository.AddAsync(invoiceLine);
        }

        public async Task<List<InvoiceLine>> GetAllAsync(string invoiceId)
        {
            return await _invoiceLineRepository.GetAllAsync(p => p.InvoiceId == invoiceId);
        }

        public async Task<InvoiceLine> GetAsyncById(int id)
        {
            return await _invoiceLineRepository.GetAsync(p => p.Id == id);
        }
    }
}
