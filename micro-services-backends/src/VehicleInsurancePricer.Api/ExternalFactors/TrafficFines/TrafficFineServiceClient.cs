using Newtonsoft.Json;

namespace VehicleInsurancePricer.Api.ExternalFactors.TrafficFines
{
    public class TrafficFineServiceClient: ExternalFactorsApiClient
    {

        public string TrafficFinesApiUrl 
        {
            get
            {
                return $"{BaseUrl}/fine";
            }
        }

        public TrafficFineServiceClient(string baseUrl): base(baseUrl) { }

        public async Task<List<TrafficFine>> GetDriverTrafficFines(string driverId)
        {
            try
            {
                HttpResponseMessage result;

                using (var client = new HttpClient())
                {
                    var url = string.Concat(TrafficFinesApiUrl, $"/driver/{driverId}");

                    var request = new HttpRequestMessage(HttpMethod.Get, url);

                    result = await client.SendAsync(request);
                }

                if (result.IsSuccessStatusCode)
                {
                    var payload = await result.Content.ReadAsStringAsync();

                    var driversFines = JsonConvert.DeserializeObject<List<TrafficFine>>(payload);
                    return driversFines;
                }
                else
                {
                    throw new Exception($"The call Traffic Fines api returned a status code of {result.StatusCode.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
