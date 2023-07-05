using SanLibrary.Core.Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Users.ValueObjects;

namespace SanLibrary.Core.Books.Repositories
{
    public interface IBorrowingBooksUserRepository
    {
        Task<BorrowingBooksUser?> GetAsync(BorrowingBooksUserId id);
        Task<IEnumerable<BorrowingBooksUser>> GetAllAsync();
        Task<IEnumerable<BorrowingBooksUser>> GetAllForUserAsync(UserId userId);
        Task<BorrowingBooksUser?> GetForCurrentMonthAsync(UserId userId);
        Task AddAsync(BorrowingBooksUser borrowingBooksUser);
        Task DeleteAsync(BorrowingBooksUser borrowingBooksUser);
    }
}
