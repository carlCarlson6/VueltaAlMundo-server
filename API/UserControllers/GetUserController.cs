using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.UserUseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.UserControllers.Messages;

namespace API.UserControllers
{
    [ApiController]
    [Route("api/user")]
    public class GetUserController : ControllerBase
    {
        private readonly ILogger<GetUserController> logger;
        private readonly ListAllUsers allUsers;
        private readonly GetUser getUser;
        public GetUserController(ILogger<GetUserController> logger, ListAllUsers allUsers, GetUser getUser)
        {
            this.logger = logger;
            this.allUsers = allUsers;
            this.getUser = getUser;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<GetUserResponse>> Get()
        {
            List<User> users = await allUsers.Execute(); 
            return users.Select(user => new GetUserResponse(user)).ToList();
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<GetUserResponse> Get([FromRoute] Guid id)
        {
            User user = await this.getUser.Execute(id);
            return new GetUserResponse(user);
        }

    }
}
