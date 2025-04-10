using Newtonsoft.Json;
using System.Text;
using VehicleInsurancePricer.Api.InsuranceOffers;

namespace VehicleInsurancePricer.Api.Offers
{
    public class InsuranceOfferServiceClient
    {
        private readonly string baseUrl;

        public InsuranceOfferServiceClient(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("The base url for the Insurance Offers API should not be empty");
            }
            this.baseUrl = baseUrl;
        }

        public async Task SaveOffer(InsuranceOffer offer)
        {
            try
            {
                HttpResponseMessage result;

                using (var client = new HttpClient())
                {
                    var url = string.Concat(baseUrl, $"/InsuranceOffers");

                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var jsonContent = JsonConvert.SerializeObject(offer);
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    result = await client.SendAsync(request);
                }

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception("The offer could not be saved");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
