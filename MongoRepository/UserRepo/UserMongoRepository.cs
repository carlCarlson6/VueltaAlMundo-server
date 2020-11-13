using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MongoDB.Driver;
using MongoRepository.Settings;

namespace MongoRepository.UserRepo
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> collection;

        public UserMongoRepository(IMongoRepositorySettings<UserModel> settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            this.collection = database.GetCollection<UserModel>(settings.CollectionName);
        }

        public async Task<List<User>> Read()
        {
            IAsyncCursor<UserModel> userAsyncCursor = await this.collection.FindAsync(user => true);
            List<UserModel> usersModel = await userAsyncCursor.ToListAsync();
            return usersModel.Select(userModel => new User(new Guid(userModel.id), new Email(userModel.email), new Name(userModel.name), new Password(new EncryptedPassword(userModel.password)))).ToList();
        }

        public async Task<User> Read(Guid id)
        {
            IAsyncCursor<UserModel> userAsyncCursor = await this.collection.FindAsync(user => user.id == id.ToString());
            UserModel userFound = await userAsyncCursor.FirstOrDefaultAsync();
            return new User(new Guid(userFound.id), new Email(userFound.email), new Name(userFound.name), new Password(new EncryptedPassword(userFound.password)));
        }

        public async Task<User> Read(Email email)
        {
            IAsyncCursor<UserModel> userAsyncCursor = await this.collection.FindAsync(user => user.email == email.Value);
            UserModel userFound = await userAsyncCursor.FirstOrDefaultAsync();
            return new User(new Guid(userFound.id), new Email(userFound.email), new Name(userFound.name), new Password(new EncryptedPassword(userFound.password)));
        }

        public async Task<int> Save(User user)
        {
            UserModel model = new UserModel(user);
            await this.collection.InsertOneAsync(model);
            return 201;
        }

    }
}