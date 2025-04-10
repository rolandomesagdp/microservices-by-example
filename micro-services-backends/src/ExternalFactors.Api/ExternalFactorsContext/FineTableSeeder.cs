using TrafficFine.Api.Fines;

namespace TrafficFine.Api.FineContext
{
    public static class FineTableSeeder
    {
        public static void Seed(this ExternalFactorsDbContext fineDbContext)
        {
            if (!fineDbContext.Fines.Any())
            {
                AddFines(fineDbContext);
                fineDbContext.SaveChanges();
            }
        }

        private static void AddFines(this ExternalFactorsDbContext fineDbContext)
        {
            List<Fine> fines = new List<Fine>();
            fines.Add(new Fine() { FineDate = DateTime.Now, AgentId = 1123, DriverId = "30381893X", Severity = ViolationSeverity.Low, Ammmount = 100, PaidFor = true });
            fines.Add(new Fine() { FineDate = DateTime.Now.AddDays(-50), AgentId = 98786, DriverId = "12481893T", Severity = ViolationSeverity.Medium, Ammmount = 500, PaidFor = false });
            fines.Add(new Fine() { FineDate = DateTime.Now.AddMonths(-30), AgentId = 8245876, DriverId = "30657843Z", Severity = ViolationSeverity.High, Ammmount = 1000, PaidFor = true });
            fines.Add(new Fine() { FineDate = DateTime.Now.AddYears(-5), AgentId = 1123, DriverId = "30381897R", Severity = ViolationSeverity.Low, Ammmount = 100, PaidFor = true });
            fines.Add(new Fine() { FineDate = DateTime.Now.AddMonths(-5), AgentId = 98765, DriverId = "30381897R", Severity = ViolationSeverity.Low, Ammmount = 100, PaidFor = true });
            fines.Add(new Fine() { FineDate = DateTime.Now.AddDays(-5), AgentId = 62935, DriverId = "30381897R", Severity = ViolationSeverity.Extreme, Ammmount = 10000, PaidFor = true });

            fineDbContext.AddRange(fines);
        }
    }
}
