using System;
using Application.AuthDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.AuthControllers
{
    [ApiController]
    [Route("api/auth")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public UserLogedResponse Login()
        {
            throw new NotImplementedException();
        }
    }
}