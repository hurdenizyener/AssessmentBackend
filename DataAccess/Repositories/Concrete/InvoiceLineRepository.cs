using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;

namespace DataAccess.Repositories.Concrete
{
    public class InvoiceLineRepository : EfRepositoryBase<InvoiceLine, BaseDbContext>, IInvoiceLineRepository
    {
        public InvoiceLineRepository(BaseDbContext context) : base(context)
        {
        }
    }
}


