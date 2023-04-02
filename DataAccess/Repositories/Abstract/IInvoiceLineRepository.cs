using DataAccess.Repositories.GenericRepositories.Abstract;
using Entities.Entities;

namespace DataAccess.Repositories.Abstract
{
    public interface IInvoiceLineRepository : IAsyncRepository<InvoiceLine>
    {
    }
}
