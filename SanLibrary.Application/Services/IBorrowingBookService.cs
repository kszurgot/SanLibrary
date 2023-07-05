using SanLibrary.Application.DTO;

namespace SanLibrary.Application.Services
{
    public interface IBorrowingBookService
    {
        Task BorrowBookAsync(BorrowingBookDto dto);
        Task<IEnumerable<BorrowingBooksUserDto>> GetAllAsync(Guid userId);
    }
}