using library.Entity;
namespace library.Interfaces.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author? GetAuthor(int Id);
        Author AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int Id);
    }
}
