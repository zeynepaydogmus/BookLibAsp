using FirstProjectAsp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//Veri Tabanında EF Tablo Oluşturması için ilgili model sınıfları eklenir.
namespace FirstProjectAsp.Utility
{
    public class ApplicationDbContext:IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {} 
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
