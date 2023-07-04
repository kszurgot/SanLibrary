using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.Repositories;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Users.Entities;
using SanLibrary.Core.Users.ValueObjects;
using SanLibrary.Infrastructure.DAL.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Infrastructure.DAL.Repositories
{
    internal class InMemoryAuthorRepository : IAuthorRepository
    {
        private static readonly HashSet<Author> Authors = new()
        {
            new Author(Seeder.PrepareGuid(1), "Gynvael", "Coldwind"),
            new Author(Seeder.PrepareGuid(2), "Robert", "Martin"),
            new Author(Seeder.PrepareGuid(3), "Henryk", "Sienkiewicz"),
        };

        public Task<Author?> GetAsync(AuthorId id) => Task.FromResult(Authors.SingleOrDefault(x => x.Id == id));
        public Task<IEnumerable<Author>> GetAllAsync() => Task.FromResult(Authors.AsEnumerable());

        public Task AddAsync(Author author)
        {
            Authors.Add(author);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Author author)
        {
            Authors.Remove(author);
            return Task.CompletedTask;
        }
    }
}
