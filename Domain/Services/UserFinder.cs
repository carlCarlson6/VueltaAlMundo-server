using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Domain.Services
{
    public class UserFinder
    {
        private readonly IUserRepository userRepository;
        public UserFinder(IUserRepository userRepository) => this.userRepository = userRepository;
 
        public async Task<User> Find(Guid id)
        {
            User user = await this.userRepository.Read(id);

            if(user == null)
                throw new UserNotFoundException(nameof(Guid), id.ToString());

            return user;
        }

        public async Task<User> Find(Email email)
        {
            User user = await this.userRepository.Read(email);

            if(user == null)
                throw new UserNotFoundException(nameof(Email), email.Value);

            return user;
        }

    }
}
