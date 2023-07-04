using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.DomainServices
{
    public interface IBorrowingBookDomainService
    {
        void Borrow(
            IEnumerable<BorrowingBook> allBorrowedBooks,
            BorrowingBooksUser currentBorrowingBooksUser,
            BorrowingBook borrowingBook,
            CopiesNumber copiesNumber);
    }
}
