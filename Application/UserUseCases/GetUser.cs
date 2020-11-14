using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;

namespace Application.UserUseCases
{
    public class GetUser
    {
        private readonly UserFinder finder;
        public GetUser(UserFinder userFinder) => this.finder = userFinder;
        public async Task<User> Execute(Guid id) => await this.finder.Find(id);
    }
}