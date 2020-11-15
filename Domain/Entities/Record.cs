using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Record
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Kilometers Kilometers { get; }
        public DateTime CreatedAt { get; }

        public Record(Guid id, Guid userId, Kilometers kilometers, DateTime createdAt)
        {
            this.Id = id;
            this.UserId = userId;
            this.Kilometers = kilometers;
            this.CreatedAt = createdAt;
        }

        public static Record Create(Guid userId, Double inputKilometers)
        {
            return new Record(Guid.NewGuid(), userId, new Kilometers(inputKilometers), DateTime.Today);
        }

    }
}
