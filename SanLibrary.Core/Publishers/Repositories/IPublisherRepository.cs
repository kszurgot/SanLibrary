using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Publishers.Entities;
using SanLibrary.Core.Publishers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Publishers.Repositories
{
    public interface IPublisherRepository
    {
        Task<Publisher?> GetAsync(PublisherId id);
        Task<IEnumerable<Publisher>> GetAllAsync();
        Task AddAsync(Publisher publisher);
        Task DeleteAsync(Publisher publisher);
    }
}
