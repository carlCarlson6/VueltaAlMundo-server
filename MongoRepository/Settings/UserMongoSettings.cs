using System;
using Domain.Entities;
using MongoRepository.Settings;
using MongoRepository.UserRepo;

namespace MongoRepository.Settings
{
    public class UserMongoSettings : IMongoRepositorySettings<UserModel>
    {
        public String CollectionName { get; set; }
        public String ConnectionString { get; set; }
        public String DatabaseName { get; set; }
    }
}