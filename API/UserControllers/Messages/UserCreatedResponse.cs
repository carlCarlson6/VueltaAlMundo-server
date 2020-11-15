using System;

namespace API.UserControllers.Messages
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
