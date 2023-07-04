using SanLibrary.Core.Books.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Application.DTO
{
    public class BorrowBookDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset ReturnDate { get; set; }
    }
}
