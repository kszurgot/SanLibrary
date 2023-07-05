using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Application.DTO
{
    public class BorrowingBooksUserDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Month { get; set; }
        public IEnumerable<BorrowingBookDto> Books { get; set; }
    }
}
