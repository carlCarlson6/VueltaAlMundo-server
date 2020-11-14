using System;
using System.Threading.Tasks;
using Application.AuthDTOs;
using Application.AuthUseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.AuthControllers
{
    [ApiController]
    [Route("api/auth")]
    public class LoginController : ControllerBase
    {
        private readonly Login login;
        public LoginController(Login login) => this.login = login;

        [HttpPost]
        public async Task<UserLogedResponse> LoginUser([FromBody] LoginCommand loginCommand)
        {
            await this.login.Execute(loginCommand);
            throw new NotImplementedException();
        }
    }
}