using Microsoft.AspNetCore.Mvc;
using VehicleInsurancePricer.Api.Drivers;
using VehicleInsurancePricer.Api.ExternalFactors.TrafficFines;
using VehicleInsurancePricer.Api.Insurances;
using VehicleInsurancePricer.Api.Offers;
using VehicleInsurancePricer.Api.ProductDiscounts;

namespace VehicleInsurancePricer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsurancePriceController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public InsurancePriceController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost(Name = "GeInsurancePrice")]
        public async Task<IActionResult> PostInsurancePrice(Driver driver)
        {
            try
            {
                var externalFactorsApiBaseUrl = configuration["Endpoints:ExternalFactorsApi"];
                var finesServiceClient = new TrafficFineServiceClient(externalFactorsApiBaseUrl);
                var driverFines = await finesServiceClient.GetDriverTrafficFines(driver.DriverId);

                var discountApiBaseUrl = configuration["Endpoints:ProductDiscountApi"];
                var discountServiceClient = new DiscountServiceClient(discountApiBaseUrl);
                var discountContext = new DiscountContext()
                {
                    DriverId = driver.DriverId,
                    YearsOfExperience = driver.YearsOfExperience,
                    DriverLicencePoints = driver.DriverLicencePoints,
                    TotalFines = driverFines.Count
                };
                var driverDiscount = await discountServiceClient.GetDiscountForDriver(discountContext);

                var offerGenerator = new InsuranceOfferGenerator()
                {
                    Driver = driver,
                    PersonalDiscount = driverDiscount,
                    DriverFines = driverFines
                };
                var offer = offerGenerator.GenerateOffer(InsuranceType.MotorBike, Coverages.CivilLiability);
                var insuranceOfferApiUrl = configuration["Endpoints:InsuranceOffersApi"];
                var offerServiceClient = new InsuranceOfferServiceClient(insuranceOfferApiUrl);
                await offerServiceClient.SaveOffer(offer);

                return Ok(offer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
