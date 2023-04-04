﻿using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHeaderController : ControllerBase
    {
        private readonly IInvoiceHeaderService _invoiceHeaderService;


        public InvoiceHeaderController(IInvoiceHeaderService invoiceHeaderService )
        {
            _invoiceHeaderService = invoiceHeaderService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _invoiceHeaderService.GetAllAsync();

            return Ok(result);

        }
    
    }
}
