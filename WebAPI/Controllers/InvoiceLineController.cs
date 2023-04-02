using Business.Abstract;
using Entities.Entities;
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
        public async Task<IActionResult> GetAllAsync(string invoiceId)
        {
            var result = await _invoiceLineService.GetAllAsync(invoiceId);

            return Ok(result);

        }


        //[HttpPost("Add")]
        //public async Task<IActionResult> AddAsync(InvoiceLine ınvoiceLine)
        //{
        //     await _invoiceLineService.AddAsync(ınvoiceLine);

        //    return Ok("Ürün Eklendi");

        //}
    }
}
