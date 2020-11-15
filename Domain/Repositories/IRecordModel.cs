using System;

namespace Domain.Repositories
{
    public interface IRecordModel
    {
        String id { get; set; }
        String userId { get; set; }
        Double kilometers { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime StoredAt { get; set; }
    }
}
