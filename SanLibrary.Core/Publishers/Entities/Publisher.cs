using SanLibrary.Core.Publishers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Publishers.Entities
{
    public class Publisher
    {
        public PublisherId Id { get; private set; }
        public Name Name { get; private set; }

        public Publisher(PublisherId id, Name name)
        {
            Id = id;
            Name = name;
        }
    }
}
