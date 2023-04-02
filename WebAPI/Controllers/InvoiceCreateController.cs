using Business.Abstract;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceCreateController : ControllerBase
    {
        private readonly IInvoiceHeaderService _invoiceHeaderService;
        private readonly IInvoiceLineService _invoiceLineService;

        public InvoiceCreateController(IInvoiceHeaderService invoiceHeaderService, IInvoiceLineService invoiceLineService)
        {
            _invoiceHeaderService = invoiceHeaderService;
            _invoiceLineService = invoiceLineService;
        }

        [HttpPost("InvoiceCreate")]
        public async Task<IActionResult> AddAsyncJson(IFormFile fileName)
        {
            if (fileName != null && fileName.Length > 0 && fileName.ContentType == "application/json")
            {
                using StreamReader reader = new(fileName.OpenReadStream());
                string json = await reader.ReadToEndAsync();


                var invoiceCreateDto = JsonConvert.DeserializeObject<InvoiceCreateDto>(json);

                InvoiceHeader invoiceHeader = new()
                {
                    Date = invoiceCreateDto.InvoiceHeader.Date,
                    InvoiceId = invoiceCreateDto.InvoiceHeader.InvoiceId,
                    ReceiverTitle = invoiceCreateDto.InvoiceHeader.ReceiverTitle,
                    SenderTitle = invoiceCreateDto.InvoiceHeader.SenderTitle

                };

                await _invoiceHeaderService.AddAsync(invoiceHeader);


                foreach (var item in invoiceCreateDto.InvoiceLine)
                {
                    InvoiceLine invoiceLine = new()
                    {
                        Id = item.Id,
                        InvoiceId = invoiceCreateDto.InvoiceHeader.InvoiceId,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        UnitCode = item.UnitCode,
                        UnitPrice = item.UnitPrice

                    };

                    await _invoiceLineService.AddAsync(invoiceLine);

                }
            }
            else
            {
                return BadRequest("Seçitiğiniz Dosya Json Formatında Değil");
            }

            return Ok("Fatura Oluşturuldu");

        }
    }
}
