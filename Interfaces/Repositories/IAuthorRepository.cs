using library.Entity;
namespace library.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author? GetAuthor(int Id);
        Author AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int Id);
    }
}
