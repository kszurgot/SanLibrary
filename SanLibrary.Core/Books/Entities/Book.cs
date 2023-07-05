using SanLibrary.Core.Books.Exceptions;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Publishers.Entities;

namespace SanLibrary.Core.Books.Entities
{
    public class Book
    {
        public BookId Id { get; set; }
        public Title Title { get; private set; }
        public Author Author { get; private set; }
        public Publisher Publisher { get; private set; }
        public ReleaseDate ReleaseDate { get; private set; }
        public ISBN ISBN { get; private set; }
        public Genre Genre { get; private set; }
        
        public CopiesNumber CopiesNumber { get; private set; }

        public Book(
            BookId bookId,
            Title title,
            Author author,
            Publisher publisher,
            ReleaseDate releaseDate, 
            ISBN ISBN, 
            Genre genre,
            CopiesNumber copiesNumber)
        {
            Id = bookId;
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            this.ISBN = ISBN;
            Genre = genre;
            CopiesNumber = copiesNumber;
        }

        public void Update(
            Title title,
            Author author,
            Publisher publisher,
            ReleaseDate releaseDate,
            ISBN ISBN,
            Genre genre,
            CopiesNumber copiesNumber)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            this.ISBN = ISBN;
            Genre = genre;

            if (copiesNumber < CopiesNumber)
            {
                throw new BookCopiesNumberIsLessThanCurrently(copiesNumber, CopiesNumber);
            }

            CopiesNumber = copiesNumber;
        }
    }
}