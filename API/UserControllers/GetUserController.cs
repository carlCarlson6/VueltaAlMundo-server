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
        public GetUserController(ILogger<GetUserController> logger) => this.logger = logger;

        [HttpGet]
        public String Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public String Get([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
