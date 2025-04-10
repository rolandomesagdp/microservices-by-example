using VehicleInsurancePricer.Api.Insurances;
using VehicleInsurancePricer.Api.Offers;

namespace VehicleInsurancePricer.Api.InsuranceOffers
{
    public class InsuranceOffer
    {
        public string Id { get; set; }

        public string ClientId { get; set; }

        public InsuranceType Type { get; set; }

        public Coverages Coverage { get; set; }

        public DateTime ExpeditionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public OfferStatus Status { get; set; }

        public int BasePrice { get; set; }

        public int Discount { get; set; }

        public int FinalPrice { get; set; }
    }
}
