using SanLibrary.Application.DTO;

namespace SanLibrary.Application.Services
{
    public interface IBorrowingBookService
    {
        Task BorrowBookAsync(BorrowBookDto dto);
    }
}