using SanLibrary.Core.Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanLibrary.Core.Books.ValueObjects;

namespace SanLibrary.Core.Books.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetAsync(BookId id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task DeleteAsync(Book book);
    }
}
