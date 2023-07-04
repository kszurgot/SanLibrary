using SanLibrary.Core.Books.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Entities
{
    public class Author
    {
        public AuthorId Id { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        public Author(AuthorId id, FirstName firstName, LastName lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
