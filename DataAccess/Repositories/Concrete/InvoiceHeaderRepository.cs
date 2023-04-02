using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using System.Net.Http.Headers;

namespace DataAccess.Repositories.Concrete
{
    public class InvoiceHeaderRepository : EfRepositoryBase<InvoiceHeader, BaseDbContext>, IInvoiceHeaderRepository
    {
        public InvoiceHeaderRepository(BaseDbContext context) : base(context)
        {
        }

   
    }


}


