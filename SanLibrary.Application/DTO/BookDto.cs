using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Publishers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Application.DTO
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Publisher { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }
        public int CopiesNumber { get; set; }
    }
}
