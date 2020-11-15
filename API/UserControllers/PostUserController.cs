using System.Threading.Tasks;
using API.UserControllers.Messages;
using Application.UserDTOs;
using Application.UserUseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.UserControllers
{
    [ApiController]
    [Route("api/user")]
    public class PostUserController : ControllerBase
    {
        private readonly ILogger<PostUserController> logger;
        private readonly CreateUser create;
        public PostUserController(ILogger<PostUserController> logger, CreateUser createUser)
        {
            this.logger = logger;
            this.create = createUser;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserCreatedResponse> Post([FromBody] CreateUserCommand createUserRequest)
        {
            User user = await this.create.Execute(createUserRequest);
            return new UserCreatedResponse(user.Id); 
        } 
    }
}
