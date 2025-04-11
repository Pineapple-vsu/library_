using library.Entity;
using library.Interfaces.Repositories;
using library.Interfaces.Services;

namespace library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Author> GetAllAuthors() => _repository.GetAllAuthors();

        public Author? GetAuthor(int Id) => _repository.GetAuthor(Id);

        public Author AddAuthor(Author Author) => _repository.AddAuthor(Author);

        public void UpdateAuthor(Author Author) => _repository.UpdateAuthor(Author);

        public void DeleteAuthor(int Id) => _repository.DeleteAuthor(Id);
    }
}
