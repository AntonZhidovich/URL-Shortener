using Microsoft.EntityFrameworkCore;
using URLShortenerApp.Models;

namespace URLShortenerApp.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<URL> URLs { get; set; } = null!;

        public AppDBContext(DbContextOptions<AppDBContext> contextOptions) : base(contextOptions) {}
    }
}
