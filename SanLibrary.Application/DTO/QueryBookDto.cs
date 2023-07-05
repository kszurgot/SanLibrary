using SanLibrary.Core.Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Application.DTO
{
    public class QueryBookDto
    {
        public Guid? PublisherId { get; set; }
        public Guid? AuthorId { get; set; }
        public Genre? Genre { get; set; }
    }
}
