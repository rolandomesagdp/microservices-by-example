namespace VehicleInsurancePricer.Api.ExternalFactors
{
    public class ExternalFactorsApiClient
    {
        public string BaseUrl { get; private set; }

        public ExternalFactorsApiClient(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("The base url for the External Factos API should not be empty");
            }
            BaseUrl = baseUrl;
        }
    }
}
