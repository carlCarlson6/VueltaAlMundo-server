using System;
using Domain.Entities;
using MongoRepository.Settings;

namespace MongoRepository.UserRepo
{
    public class UserRepositorySettings : IMongoRepositorySettings<User>
    {
        public String CollectionName { get; set; }
        public String ConnectionString { get; set; }
        public String DatabaseName { get; set; }
    }
}