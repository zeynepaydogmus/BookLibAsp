using FirstProjectAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectAsp.Utility
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {} 
        public DbSet<BookGenre> BookGenres { get; set; }
    }
}
