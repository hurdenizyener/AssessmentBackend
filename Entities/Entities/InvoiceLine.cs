using Entities.Common;

namespace Entities.Entities
{
    public class InvoiceLine : IEntity
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public string Name { get; set; }
        public ushort Quantity { get; set; }
        public string UnitCode { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
