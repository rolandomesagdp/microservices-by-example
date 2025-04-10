using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrafficFine.Api.FineContext;
using TrafficFine.Api.Fines;

namespace TrafficFine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FineController : ControllerBase
    {
        private readonly ExternalFactorsDbContext fineDbContext;

        public FineController(ExternalFactorsDbContext fineDbContext)
        {
            this.fineDbContext = fineDbContext;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllFines()
        {
            var allFines = await fineDbContext.Fines.ToArrayAsync();
            return Ok(allFines);
        }

        [HttpGet("driver/{driverId}")]
        public async Task<IActionResult> GetDriverFines(string driverId)
        {
            var driverFines = await fineDbContext.Fines.Where(x => x.DriverId == driverId).ToArrayAsync();
            return Ok(driverFines);
        }

        [HttpPost()]
        public async Task<IActionResult> AddFine(Fine fine)
        {
            fineDbContext.Fines.Add(fine);
            await fineDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}