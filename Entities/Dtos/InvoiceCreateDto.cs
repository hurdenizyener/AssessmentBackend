using Entities.Common;
using Entities.Entities;

namespace Entities.Dtos
{
    public class InvoiceCreateDto :IDto
    {
        public InvoiceHeader InvoiceHeader { get; set; }
        public List<InvoiceLine> InvoiceLine { get; set; }
    }
}
