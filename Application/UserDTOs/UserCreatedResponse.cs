using System;

namespace Application.UserDTOs
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
