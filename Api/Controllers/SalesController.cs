using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public IActionResult CreateSale([FromBody] Sale sale)
        {
            try
            {
                _saleService.AddSale(sale);
                return CreatedAtAction(nameof(GetSale), new { saleNumber = sale.SaleNumber }, sale);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{saleNumber}")]
        public IActionResult GetSale(int saleNumber)
        {
            try
            {
                var sale = _saleService.GetSaleByNumber(saleNumber);
                return Ok(sale);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllSales()
        {
            var sales = _saleService.GetAllSales();
            return Ok(sales);
        }

        [HttpPut("{saleNumber}")]
        public IActionResult UpdateSale(int saleNumber, [FromBody] Sale updatedSale)
        {
            try
            {
                _saleService.UpdateSale(saleNumber, updatedSale);
                return Ok(new { Message = "Venda atualizada com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{saleNumber}")]
        public IActionResult CancelSale(int saleNumber)
        {
            try
            {
                _saleService.CancelSale(saleNumber);
                return Ok(new { Message = "Venda cancelada com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
