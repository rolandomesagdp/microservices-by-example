using Microsoft.AspNetCore.Mvc;
using ProductDiscounts.Api.Discounts;

namespace ProductDiscounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        public DiscountController()
        {
        }

        [HttpGet(Name = "GetDiscountForClient")]
        public async Task<IActionResult> Get([FromQuery]DiscountContext discountContext)
        {
            var discountCalculator = new DiscountCalculator(discountContext);
            return Ok(discountCalculator.CalculateDiscount());
        }
    }
}
