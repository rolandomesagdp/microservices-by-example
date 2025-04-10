using VehicleInsurancePricer.Api.Drivers;
using VehicleInsurancePricer.Api.ExternalFactors.TrafficFines;
using VehicleInsurancePricer.Api.InsuranceOffers;
using VehicleInsurancePricer.Api.Insurances;

namespace VehicleInsurancePricer.Api.Offers
{
    public class InsuranceOfferGenerator
    {
        public Driver Driver { get; set; }

        public List<TrafficFine> DriverFines { get; set; }

        public int PersonalDiscount { get; set; }

        public InsuranceOfferGenerator()
        { 
        }

        public InsuranceOffer GenerateOffer(InsuranceType insuranceType, Coverages coverage)
        {
            return new InsuranceOffer
            {
                Id = Guid.NewGuid().ToString(),
                ClientId = Driver.DriverId,
                Type = insuranceType,
                Coverage = coverage,
                ExpeditionDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddMonths(1),
                Status = OfferStatus.Created,
                BasePrice = 200,
                Discount = PersonalDiscount,
                FinalPrice = ApplyDiscount(200)
            };
        }

        private int ApplyDiscount(int total)
        {
            var discountAmmount = total * PersonalDiscount / 100;
            return total - discountAmmount;
        }
    }
}
