using Entities.Entities;

namespace Business.Abstract
{
    public interface IInvoiceLineService
    {
        Task<List<InvoiceLine>> GetAllAsync(string invoiceId);
        Task<InvoiceLine> AddAsync(InvoiceLine invoiceLine);
        Task<InvoiceLine> GetAsyncById(int id);
    }
}
