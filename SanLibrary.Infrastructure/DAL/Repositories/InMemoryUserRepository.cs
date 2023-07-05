using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Users.Entities;
using SanLibrary.Core.Users.Repositories;
using SanLibrary.Core.Users.ValueObjects;
using SanLibrary.Infrastructure.DAL.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Infrastructure.DAL.Repositories
{
    internal class InMemoryUserRepository : IUserRepository
    {
        private static readonly HashSet<User> Users = new()
        {
            new User(Seeder.PrepareGuid(1), "user1@example.com", "secret-pass", "Jan Kowalski", Role.Employee, UserStatus.Active),
            new User(Seeder.PrepareGuid(2), "user2@example.com", "secret-pass", "Radosław Nowak", Role.RegularUser, UserStatus.Active),
            new User(Seeder.PrepareGuid(3), "user3@example.com", "secret-pass", "Michał Ryś", Role.RegularUser, UserStatus.Active),
        };

        public Task<User?> GetAsync(UserId id) => Task.FromResult(Users.SingleOrDefault(x => x.Id == id));
        public Task<IEnumerable<User>> GetAllAsync() => Task.FromResult(Users.AsEnumerable());

        public Task AddAsync(User user)
        {
            Users.Add(user);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(User user)
        {
            Users.Remove(user);
            return Task.CompletedTask;
        }
    }
}
