using System.Threading.Tasks;
using Application.UserDTOs;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.UserUseCases
{
    public class CreateUser
    {
        private readonly IUserRepository repostory;
        private readonly UserFinder finder;
        public CreateUser(IUserRepository userRepository, UserFinder userFinder)
        {
            this.repostory = userRepository;
            this.finder = userFinder;
        }

        public async Task<User> Execute(CreateUserCommand command)
        {
            User newUser = User.Create(command.Email, command.Name, command.Password);
            await this.finder.Find(newUser.Email);

            await this.repostory.Save(newUser);

            return newUser; 
        }
    }
}
