using SanLibrary.Application.DTO;
using SanLibrary.Application.Exceptions;
using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.Repositories;
using SanLibrary.Core.Publishers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Application.Services
{
    internal class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookService(IBookRepository bookRepository, 
            IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(x => new BookDto
            {
                Id = x.Id,
                Title = x.Title,
                AuthorFirstName = x.Author.FirstName,
                AuthorLastName = x.Author.LastName,
                Publisher = x.Publisher.Name,
                ReleaseDate = x.ReleaseDate,
                ISBN = x.ISBN,
                Genre = x.Genre,
                CopiesNumber = x.CopiesNumber
            });
        }

        public async Task<BookDto> GetAsync(Guid bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);
            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorFirstName = book.Author.FirstName,
                AuthorLastName = book.Author.LastName,
                Publisher = book.Publisher.Name,
                ReleaseDate = book.ReleaseDate,
                ISBN = book.ISBN,
                Genre = book.Genre,
                CopiesNumber = book.CopiesNumber
            };
        }

        public async Task AddAsync(CreateBookDto book)
        {
            var author = await _authorRepository.GetAsync(book.AuthorId);
            if (author == null)
            {
                throw new AuthorNotFoundException(book.AuthorId);
            }

            var publisher = await _publisherRepository.GetAsync(book.PublisherId);
            if (publisher == null)
            {
                throw new PublisherNotFoundException(book.PublisherId);
            }

            await _bookRepository.AddAsync(
                new Book(book.Id, book.Title, author, publisher,
                book.ReleaseDate, book.ISBN, book.Genre, book.CopiesNumber));
        }

        public async Task DeleteAsync(Guid bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);
            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            await _bookRepository.DeleteAsync(book);
        }
    }
}
