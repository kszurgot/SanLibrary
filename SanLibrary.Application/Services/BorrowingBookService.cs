using SanLibrary.Application.DTO;
using SanLibrary.Application.Exceptions;
using SanLibrary.Core.Books.DomainServices;
using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.Repositories;
using SanLibrary.Core.Shared.Time;
using SanLibrary.Core.Users.Repositories;

namespace SanLibrary.Application.Services
{
    internal sealed class BorrowingBookService : IBorrowingBookService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowingBooksUserRepository _borrowingBooksUserRepository;
        private readonly IBorrowingBookDomainService _borrowingBookDomainService;
        private readonly IClock _clock;

        public BorrowingBookService(
            IUserRepository userRepository,
            IBookRepository bookRepository,
            IBorrowingBooksUserRepository borrowingBooksUserRepository,
            IBorrowingBookDomainService borrowingBookDomainService,
            IClock clock)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _borrowingBooksUserRepository = borrowingBooksUserRepository;
            _borrowingBookDomainService = borrowingBookDomainService;
            _clock = clock;
        }

        public async Task<IEnumerable<BorrowingBooksUserDto>> GetAllAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var books = await _borrowingBooksUserRepository.GetAllForUserAsync(userId);

            return books.Select(x => new BorrowingBooksUserDto
            {
                Id = x.Id,
                Month = x.Month,
                UserId = x.UserId,
                Books = x.Books.Select(b => new BorrowingBookDetailsDto
                {
                    Id = b.Id,
                    UserId = x.UserId,
                    BookId = b.Id,
                    Date = b.Date,
                    ReturnDate = b.ReturnDate,
                })
            });
        }

        public async Task BorrowBookAsync(BorrowingBookDto dto)
        {
            var userId = dto.UserId;
            var user = await _userRepository.GetAsync(userId);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var bookId = dto.BookId;
            var book = await _bookRepository.GetAsync(bookId);
            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            var currentBorrowingBooks = await _borrowingBooksUserRepository.GetForCurrentMonthAsync(userId);
            if (currentBorrowingBooks is null)
            {
                var currentMonth = _clock.Current().Month;
                currentBorrowingBooks = new BorrowingBooksUser(Guid.NewGuid(), userId, currentMonth);
                await _borrowingBooksUserRepository.AddAsync(currentBorrowingBooks);
            }

            var borrowingBook = new BorrowingBook(dto.Id, bookId, dto.Date, dto.ReturnDate);
            var allBorrowedBooks = (await _borrowingBooksUserRepository.GetAllAsync()).SelectMany(x => x.Books);

            _borrowingBookDomainService.Borrow(allBorrowedBooks, currentBorrowingBooks, borrowingBook, book.CopiesNumber);
        }
    }
}