using System;

namespace Application.UserUseCases
{
    public class ListAllUsers
    {
        private readonly IUserRepository repostory;
        public ListAllUsers(IUserRepository userRepostory) => this.repostory = userRepository;

        public async Task<List<User>> ListAll() => await this.repostory.Read();
        
    }
}
