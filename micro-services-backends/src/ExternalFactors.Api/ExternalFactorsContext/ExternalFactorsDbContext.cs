using Microsoft.EntityFrameworkCore;
using TrafficFine.Api.Fines;

namespace TrafficFine.Api.FineContext
{
    public class ExternalFactorsDbContext : DbContext
    {
        public ExternalFactorsDbContext(DbContextOptions<ExternalFactorsDbContext> options) : base(options)
        {
        }
        // Adding a change
        public DbSet<Fine> Fines { get; set; }
    }
}
