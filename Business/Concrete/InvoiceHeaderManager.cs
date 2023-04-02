using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Entities;

namespace Business.Concrete
{
    public class InvoiceHeaderManager : IInvoiceHeaderService
    {
        private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;


        public InvoiceHeaderManager(IInvoiceHeaderRepository invoiceHeaderRepository)
        {
            _invoiceHeaderRepository = invoiceHeaderRepository;
        }

        public async Task<InvoiceHeader> AddAsync(InvoiceHeader invoiceHeader)
        {
            return await _invoiceHeaderRepository.AddAsync(invoiceHeader);
        }

        public async Task<List<InvoiceHeader>> GetAllAsync()
        {
            return await _invoiceHeaderRepository.GetAllAsync();
        }

        public async Task<InvoiceHeader> GetAsyncById(string id)
        {
            return await _invoiceHeaderRepository.GetAsync(p => p.InvoiceId == id);
        }
    }
}
