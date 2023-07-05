using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.Repositories;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Time;
using SanLibrary.Core.Users.ValueObjects;
using SanLibrary.Infrastructure.Time;
using static System.Reflection.Metadata.BlobBuilder;

namespace SanLibrary.Infrastructure.DAL.Repositories
{

    internal class InMemoryBorrowingBooksUserRepository : IBorrowingBooksUserRepository
    {
        private readonly HashSet<BorrowingBooksUser> BorrowingBooksUser = new();
        private readonly IClock _clock = new DateTimeClock();

        public Task<BorrowingBooksUser?> GetAsync(BorrowingBooksUserId id) 
            => Task.FromResult(BorrowingBooksUser.SingleOrDefault(x => x.Id == id));

        public Task<IEnumerable<BorrowingBooksUser>> GetAllAsync() 
            => Task.FromResult(BorrowingBooksUser.AsEnumerable());

        public Task<IEnumerable<BorrowingBooksUser>> GetAllForUserAsync(UserId userId)
            => Task.FromResult(BorrowingBooksUser.Where(x => x.UserId == userId).AsEnumerable());

        public Task<BorrowingBooksUser?> GetForCurrentMonthAsync(UserId userId) 
            => Task.FromResult(BorrowingBooksUser
                .SingleOrDefault(x => x.UserId == userId && x.Month == _clock.Current().Month));

        public Task AddAsync(BorrowingBooksUser borrowingBooksUser)
        {
            BorrowingBooksUser.Add(borrowingBooksUser);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(BorrowingBooksUser borrowingBooksUser)
        {
            BorrowingBooksUser.Remove(borrowingBooksUser);
            return Task.CompletedTask;
        }
    }
}