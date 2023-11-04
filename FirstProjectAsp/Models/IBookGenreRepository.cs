namespace FirstProjectAsp.Models
{
    public interface IBookGenreRepository : IRepository<BookGenre>
    {
        void UpdateBookGenre(BookGenre bookGenre);
        void Save();
    }
}
