namespace TrafficFine.Api.Fines
{
    public class Fine
    {
        public int Id { get; set; }

        public DateTime FineDate { get; set; }

        public int AgentId { get; set; }

        public string DriverId { get; set; }

        public ViolationSeverity Severity { get; set; }

        public double Ammmount { get; set; }

        public bool PaidFor { get; set; }
    }
}
