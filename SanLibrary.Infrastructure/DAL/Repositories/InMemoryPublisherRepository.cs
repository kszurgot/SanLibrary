using SanLibrary.Core.Publishers.Entities;
using SanLibrary.Core.Publishers.Repositories;
using SanLibrary.Core.Publishers.ValueObjects;
using SanLibrary.Core.Users.ValueObjects;
using SanLibrary.Infrastructure.DAL.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Infrastructure.DAL.Repositories
{
    internal class InMemoryPublisherRepository : IPublisherRepository
    {
        private static readonly HashSet<Publisher> Publishers = new()
        {
            new Publisher(Seeder.PrepareGuid(1), "PWN"),
            new Publisher(Seeder.PrepareGuid(2), "Helion"),
            new Publisher(Seeder.PrepareGuid(3), "Zielona Sowa"),
        };

        public Task<Publisher?> GetAsync(PublisherId id) 
            => Task.FromResult(Publishers.SingleOrDefault(x => x.Id == id));
        public Task<IEnumerable<Publisher>> GetAllAsync() => Task.FromResult(Publishers.AsEnumerable());

        public Task AddAsync(Publisher publisher)
        {
            Publishers.Add(publisher);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Publisher publisher)
        {
            Publishers.Remove(publisher);
            return Task.CompletedTask;
        }
    }
}
