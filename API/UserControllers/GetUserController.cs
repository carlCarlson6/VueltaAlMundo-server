using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.UserControllers
{
    [ApiController]
    [Route("api/user")]
    public class GetUserController : ControllerBase
    {
        private readonly ILogger<GetUserController> logger;
        private readonly ListAllUsers allUsers;
        public GetUserController(ILogger<GetUserController> logger, ListAllUsers allUsers)
        {
            this.logger = logger;
            this.allUsers = allUsers;
        }

        [HttpGet]
        public String Get()
        {
            List<User> users = allUsers.ListAll(); 
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public String Get([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
