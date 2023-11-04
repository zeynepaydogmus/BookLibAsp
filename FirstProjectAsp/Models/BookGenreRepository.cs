using FirstProjectAsp.Utility;
using System.Linq.Expressions;

namespace FirstProjectAsp.Models
{
    public class BookGenreRepository : Repository<BookGenre>, IBookGenreRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public BookGenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void UpdateBookGenre(BookGenre bookGenre)
        {
            _applicationDbContext.Update(bookGenre);
        }
    }
}
