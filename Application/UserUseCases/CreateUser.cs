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
        private readonly CheckNewUser checkNewUser;
        public CreateUser(IUserRepository userRepository, CheckNewUser checkNewUser)
        {
            this.repostory = userRepository;
            this.checkNewUser = checkNewUser;
        }

        public async Task<User> Execute(CreateUserCommand command)
        {
            User newUser = User.Create(command.Email, command.Name, command.Password);
            await this.checkNewUser.Check(newUser);

            await this.repostory.Save(newUser);

            return newUser; 
        }
    }
}
