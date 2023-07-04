using SanLibrary.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetAsync(Guid bookId);
        Task AddAsync(CreateBookDto book);
        Task DeleteAsync(Guid bookId);
    }
}
