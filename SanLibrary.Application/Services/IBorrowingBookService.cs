using SanLibrary.Application.DTO;

namespace SanLibrary.Application.Services
{
    internal interface IBorrowingBookService
    {
        Task BorrowBookAsync(BorrowBookDto dto);
    }
}