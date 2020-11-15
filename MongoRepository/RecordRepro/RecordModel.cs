using System;
using Domain.Repositories;

namespace MongoRepository.RecordRepro
{
    public class RecordModel : IRecordModel
    {
        public String id { get; set; }
        public String userId { get; set; }
        public Double kilometers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StoredAt { get; set; }
    }
}
