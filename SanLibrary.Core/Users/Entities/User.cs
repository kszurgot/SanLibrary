using SanLibrary.Core.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Users.Entities
{
    public class User
    {
        public UserId Id { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public FullName FullName { get; private set; }
        public Role Role { get; private set; }
        public UserStatus Status { get; private set; }

        public User(UserId id, Email email, Password password, FullName fullName, Role role, UserStatus status)
        {
            Id = id;
            Email = email;
            Password = password;
            FullName = fullName;
            Role = role;
            Status = status;
        }
    }
}
