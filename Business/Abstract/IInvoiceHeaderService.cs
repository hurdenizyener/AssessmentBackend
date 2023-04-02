using Entities.Entities;

namespace Business.Abstract
{
    public interface IInvoiceHeaderService
    {
        Task<List<InvoiceHeader>> GetAllAsync();
        Task<InvoiceHeader> AddAsync(InvoiceHeader invoiceHeader);
        Task<InvoiceHeader> GetAsyncById(string id);
    }
}
