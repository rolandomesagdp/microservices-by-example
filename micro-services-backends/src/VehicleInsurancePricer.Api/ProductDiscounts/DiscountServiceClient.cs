using Newtonsoft.Json;

namespace VehicleInsurancePricer.Api.ProductDiscounts
{
    public class DiscountServiceClient
    {
        private readonly string baseUrl;

        public DiscountServiceClient(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("The base url for the Products Discount API should not be empty");
            }

            this.baseUrl = baseUrl;
        }

        public async Task<int> GetDiscountForDriver(DiscountContext context)
        {
            try
            {
                HttpResponseMessage result;

                using (var client = new HttpClient())
                {
                    var url = string.Concat(baseUrl, $"/Discount?DriverId={context.DriverId}&YearsOfExperience={context.YearsOfExperience}&DriverLicencePoints={context.DriverLicencePoints}&TotalFines={context.TotalFines}");

                    var request = new HttpRequestMessage(HttpMethod.Get, url);

                    result = await client.SendAsync(request);
                }

                if (result.IsSuccessStatusCode)
                {
                    var payload = await result.Content.ReadAsStringAsync();

                    var driverDiscount = JsonConvert.DeserializeObject<int>(payload);
                    return driverDiscount;
                }
                else
                {
                    throw new Exception($"The call Discounts api returned a status code of {result.StatusCode.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
