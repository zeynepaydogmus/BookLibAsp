namespace FirstProjectAsp.Models
{
    public interface IBookRepository : IRepository<Book>
    {
        void UpdateBook(Book book);
        void Save();
    }
}
