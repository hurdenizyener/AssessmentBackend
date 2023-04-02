using Entities.Common;

namespace Entities.Entities
{
    public class InvoiceHeader : IEntity
    {
        public string InvoiceId { get; set; }
        public string SenderTitle { get; set; }
        public string ReceiverTitle { get; set; }
        public string Date { get; set; }


    }
}
