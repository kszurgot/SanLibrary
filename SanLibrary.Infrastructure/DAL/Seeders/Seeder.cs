using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.Repositories;
using SanLibrary.Core.Publishers.Repositories;
using SanLibrary.Core.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Infrastructure.DAL.Seeders
{
    internal class Seeder
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IPublisherRepository _publisherRepository;

        public Seeder(IAuthorRepository authorRepository, IBookRepository bookRepository, IPublisherRepository publisherRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _publisherRepository = publisherRepository;
        }
        internal async void Seed()
        {
            var authors = await _authorRepository.GetAllAsync();
            var publishers = await _publisherRepository.GetAllAsync();

            var book = new Book(
                PrepareGuid(1),
                "Zrozumieć programowanie",
                authors.ElementAt(0),
                publishers.ElementAt(0),
                DateTimeOffset.Parse("2015-04-01"),
                "9788301190873",
                Genre.IT,
                2);
            await _bookRepository.AddAsync(book);

            book = new Book(
                PrepareGuid(2),
                "Czysty Kod",
                authors.ElementAt(1),
                publishers.ElementAt(1),
                DateTimeOffset.Parse("2015-04-01"),
                "9788328302341",
                Genre.IT,
                4);
            await _bookRepository.AddAsync(book);

            book = new Book(
                PrepareGuid(3),
                "Ogniem i mieczem",
                authors.ElementAt(2),
                publishers.ElementAt(2),
                DateTimeOffset.Parse("1884-08-29"),
                "9780020820444",
                Genre.Novel,
                10);
            await _bookRepository.AddAsync(book);

            book = new Book(
                PrepareGuid(4),
                "Potop",
                authors.ElementAt(2),
                publishers.ElementAt(2),
                DateTimeOffset.Parse("1886-02-05"),
                "9788381860185",
                Genre.Novel,
                14);
            await _bookRepository.AddAsync(book);

            book = new Book(
                PrepareGuid(5),
                "Pan Wołodyjowski",
                authors.ElementAt(2),
                publishers.ElementAt(2),
                DateTimeOffset.Parse("1888-07-04"),
                "9788377916315",
                Genre.Novel,
                7);
            await _bookRepository.AddAsync(book);

            var books = await _bookRepository.GetAllAsync();
        }

        internal static Guid PrepareGuid(int id)
        {
            return Guid.Parse($"00000000-0000-0000-0000-{id.ToString("D12")}");
        }
    }
}
