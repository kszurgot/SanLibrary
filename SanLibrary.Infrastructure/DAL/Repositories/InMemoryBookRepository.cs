using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.Repositories;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Users.ValueObjects;

namespace SanLibrary.Infrastructure.DAL.Repositories
{

    internal class InMemoryBookRepository : IBookRepository
    {
        private readonly HashSet<Book> Books = new();

        public Task<Book?> GetAsync(BookId id) => Task.FromResult(Books.SingleOrDefault(x => x.Id == id));

        public Task<IEnumerable<Book>> GetAllAsync() => Task.FromResult(Books.AsEnumerable());

        public Task AddAsync(Book book)
        {
            Books.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Book book)
        {
            Books.Remove(book);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Book book)
        {
            return Task.CompletedTask;
        }
    }
}