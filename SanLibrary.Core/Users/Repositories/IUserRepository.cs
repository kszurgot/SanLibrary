using SanLibrary.Core.Users.ValueObjects;
using SanLibrary.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.ValueObjects;

namespace SanLibrary.Core.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetAsync(UserId id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(User user);
    }
}
