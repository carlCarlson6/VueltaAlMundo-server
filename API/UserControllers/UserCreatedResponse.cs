using System;

namespace API.UserControllers
{
    public class UserCreatedResponse
    {
        public Guid Id { get; set; }

        public UserCreatedResponse(Guid id)
        {
            this.Id = id;
        }
    }
}
