namespace Business.Abstract
{
    public interface IInvoiceCreateService
    {
        Task InvoiceCreate(string json);
    }
}
