using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; }
        public Email Email { get; } 
        public Name Name { get; }
        public Password Password { get; }
    
        public User(Guid id, Email email, Name name, Password password)
        {
            this.Id = id;
            this.Email = email;
            this.Name = name;
            this.Password = password;
        }

        public static User Create(String email, String name, String password)
        {
            return new User(new Guid(), new Email(email), new Name(name), new Password(password));
        }

    }
}
