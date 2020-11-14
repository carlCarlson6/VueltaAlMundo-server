using System;
using Domain.Entities;

namespace API.UserControllers
{
    public class GetUserResponse
    {
        public String Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }

        public GetUserResponse(User user)
        {
            this.Id = user.Id.ToString();
            this.Email = user.Email.Value;
            this.Name = user.Name.Value;
        }
    }
}
