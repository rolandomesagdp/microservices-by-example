namespace VehicleInsurancePricer.Api.ProductDiscounts
{
    public class DiscountContext
    {
        public string DriverId { get; set; }

        public int YearsOfExperience { get; set; }

        public int DriverLicencePoints { get; set; }

        public int TotalFines { get; set; }
    }
}
