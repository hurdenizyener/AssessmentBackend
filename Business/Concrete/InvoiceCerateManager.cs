using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Transactions;

namespace Business.Concrete
{
    public class InvoiceCerateManager : IInvoiceCreateService
    {

        private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;
        private readonly IInvoiceLineRepository _invoiceLineRepository;
        private readonly ILogger<InvoiceCerateManager> _logger;

        public InvoiceCerateManager(IInvoiceHeaderRepository invoiceHeaderRepository, IInvoiceLineRepository invoiceLineRepository, ILogger<InvoiceCerateManager> logger)
        {
            _invoiceHeaderRepository = invoiceHeaderRepository;
            _invoiceLineRepository = invoiceLineRepository;
            _logger = logger;
        }

        public async Task InvoiceCreate(string json)
        {
            InvoiceCreateDto? invoiceCreateDto = JsonConvert.DeserializeObject<InvoiceCreateDto>(json);

            using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                await CreateInvoiceHeader(invoiceCreateDto);
                await CreateInvoiceLine(invoiceCreateDto);

                _logger.LogInformation("Invoice Create");
                transactionScope.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Hürdeniz");
                transactionScope.Dispose();
                throw;
            }
        }

        private async Task CreateInvoiceHeader(InvoiceCreateDto invoiceCreateDto)
        {
            await _invoiceHeaderRepository.AddAsync(new InvoiceHeader()
            {
                Date = invoiceCreateDto.InvoiceHeader.Date,
                InvoiceId = invoiceCreateDto.InvoiceHeader.InvoiceId,
                ReceiverTitle = invoiceCreateDto.InvoiceHeader.ReceiverTitle,
                SenderTitle = invoiceCreateDto.InvoiceHeader.SenderTitle

            });
        }

        private async Task CreateInvoiceLine(InvoiceCreateDto invoiceCreateDto)
        {
            foreach (InvoiceLine item in invoiceCreateDto.InvoiceLine)
            {
                await _invoiceLineRepository.AddAsync(new InvoiceLine()
                {
                    Id = item.Id,
                    InvoiceId = invoiceCreateDto.InvoiceHeader.InvoiceId,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    UnitCode = item.UnitCode,
                    UnitPrice = item.UnitPrice

                });
            }

        }
    }
}
