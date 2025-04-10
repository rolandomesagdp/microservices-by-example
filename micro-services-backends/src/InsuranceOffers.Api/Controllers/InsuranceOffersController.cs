using InsuranceOffers.Api.InsuranceOffers;
using InsuranceOffers.Api.OfferContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceOffers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceOffersController : ControllerBase
    {
        private readonly OfferDbContext dbContext;

        public InsuranceOffersController(OfferDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var offers = await dbContext.Offers.ToListAsync();

            return Ok(offers);
        }

        [HttpGet("{offerId}")]
        public async Task<IActionResult> Get(string offerId)
        {
            var requestedOffer = await dbContext.Offers.FirstOrDefaultAsync(x => x.Id == offerId);
            if (requestedOffer == null) {
                return BadRequest("No such offer exists in our system");
            }

            return Ok(requestedOffer);
        }

        [HttpPost(Name = "CreateInsuranceOffer")]
        public async Task<IActionResult> Post(InsuranceOffer offer)
        {
            var createdOffer = dbContext.Offers.Add(offer);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetDriverOffers(string clientId)
        {
            var clientOffers = await dbContext.Offers.Where(x => x.ClientId == clientId).ToListAsync();
            if (clientOffers == null)
            {
                return BadRequest("No such offer exists in our system");
            }

            return Ok(clientOffers);
        }
    }
}
