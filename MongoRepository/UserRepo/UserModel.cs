
using System;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoRepository.UserRepo
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id {get; set;}
        public String email {get; set;}
        public String name {get; set;}
        public String password {get; set;}

        public UserModel(User user)
        {
            this.id = user.Id.ToString();
            this.email = user.Email.Value;
            this.name = user.Name.Value;
            this.password = user.Password.Value;
        }

    }
}
