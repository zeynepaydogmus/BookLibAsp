using FirstProjectAsp.Utility;
using System.Linq.Expressions;

namespace FirstProjectAsp.Models
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public BookRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _applicationDbContext.Update(book);
        }


    }
}
