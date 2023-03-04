using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace YugiohApi.Models
{
    public class YugiohContext : DbContext
    {
        public YugiohContext(DbContextOptions<YugiohContext> options)
            : base(options)
        {
        }

        public DbSet<YugiohCard> YugiohCards { get; set; } = null!;
    }
}