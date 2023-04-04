using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceCreateController : ControllerBase
    {
        private readonly IInvoiceCreateService _invoiceCreateService;

        public InvoiceCreateController(IInvoiceCreateService invoiceCreateService)
        {
            _invoiceCreateService = invoiceCreateService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsyncJson(IFormFile fileName)
        {
            if (fileName == null || fileName.Length <= 0 || fileName.ContentType != "application/json")
            {
                return BadRequest("Seçitiğiniz Dosya Json Formatında Değil");
            }
            else
            {
                using StreamReader reader = new(fileName.OpenReadStream());
                string json = await reader.ReadToEndAsync();
                await _invoiceCreateService.InvoiceCreate(json);

            }

            return Ok();

        }
    }
}
