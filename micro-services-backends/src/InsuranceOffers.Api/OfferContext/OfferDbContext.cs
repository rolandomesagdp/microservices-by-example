using InsuranceOffers.Api.InsuranceOffers;
using Microsoft.EntityFrameworkCore;

namespace InsuranceOffers.Api.OfferContext
{
    public class OfferDbContext : DbContext
    {
        public OfferDbContext(DbContextOptions<OfferDbContext> options) : base(options)
        {
        }

        public DbSet<InsuranceOffer> Offers { get; set; }
    }
}
