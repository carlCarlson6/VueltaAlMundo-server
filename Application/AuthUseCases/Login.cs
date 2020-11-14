using System.Threading.Tasks;
using Application.AuthDTOs;
using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.AuthUseCases
{
    public class Login 
    {
        private readonly UserFinder finder; 
        public Login(UserFinder userFinder) => this.finder = userFinder; 

        public async Task Execute(LoginCommand command)
        {
            User user = await this.finder.Find(new Email(command.Email));
            user.Password.Verify(command.Password);
            // TODO - generate and return JWT
        }
    }
}