using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MongoDB.Driver;
using MongoRepository.Settings;

namespace MongoRepository.RecordRepro
{
    public class RecordMongoRepository : IRecordRepository
    {
        private readonly IMongoCollection<RecordModel> collection;

        public RecordMongoRepository(IMongoRepositorySettings<RecordModel> settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            this.collection = database.GetCollection<RecordModel>(settings.CollectionName);         
        }

        public Task<List<Record>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<Record> Read(RecordId id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Record>> Read(UserId id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(Record record)
        {
            throw new NotImplementedException();
        }
    }
}
