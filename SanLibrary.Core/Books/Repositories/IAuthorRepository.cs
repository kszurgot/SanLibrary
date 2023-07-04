using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author?> GetAsync(AuthorId id);
        Task<IEnumerable<Author>> GetAllAsync();
        Task AddAsync(Author author);
        Task DeleteAsync(Author author);
    }
}
