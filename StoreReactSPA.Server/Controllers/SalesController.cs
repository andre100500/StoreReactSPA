using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.Services;
using System.Security.Claims;

namespace StoreReactSPA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSale(CreateSaleDto createSaleDto)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized();
            }
            var userId = new Guid(userIdString);

            var createdSaleDto = await _saleService.CreateSaleAsync(createSaleDto, userId);

            return CreatedAtAction(nameof(GetSaleById),new {id = createdSaleDto.Id }, createdSaleDto);
        }
    }
}
