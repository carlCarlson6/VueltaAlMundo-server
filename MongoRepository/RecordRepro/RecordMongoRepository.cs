using System;
using System.Linq;
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

        public async Task<List<Record>> Read()
        {
            IAsyncCursor<RecordModel> asyncCursor = await this.collection.FindAsync(model => true);
            List<RecordModel> recordsModel = await asyncCursor.ToListAsync();

            if(recordsModel.Count == 0)
            {
                return new List<Record>();
            }

            // TODO
            //return recordsModel.Select(recordModel => new Record()).ToList();
            throw new NotImplementedException();
        }

        public Task<Record> Read(RecordId id)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<List<Record>> Read(UserId id)
        {
            // TODO
            throw new NotImplementedException();
        }

        public async Task<int> Save(Record record)
        {
            RecordModel model = new RecordModel(record);
            await this.collection.InsertOneAsync(model);
            return 201;
        }
    }
}
