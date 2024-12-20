using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpacedRecall.Models;

namespace SpacedRecall.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SpacedRecall.Models.Deck> Deck { get; set; } = default!;
        public DbSet<SpacedRecall.Models.CardType> CardType { get; set; } = default!;
    }
}
