using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceLineController : ControllerBase
    {
        private readonly IInvoiceLineService _invoiceLineService;

        public InvoiceLineController(IInvoiceLineService invoiceLineService)
        {
            _invoiceLineService = invoiceLineService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromQuery]string invoiceId)
        {
            var result = await _invoiceLineService.GetAllAsync(invoiceId);

            return Ok(result);

        }

    }
}
