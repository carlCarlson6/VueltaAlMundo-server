using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.UserUseCases
{
    public class SumUserRecords
    {
        private readonly SumRecords sum;
        private readonly UserFinder userFinder;
        private readonly RecordFinder recordFinder;
        public SumUserRecords(SumRecords sumRecords, UserFinder userFinder, RecordFinder recordFinder)
        {
            this.sum = sumRecords;
            this.userFinder = userFinder;
            this.recordFinder = recordFinder;
        }

        public SumRecords Sum => sum;

        public async Task<Kilometers> Execute(UserId userId)
        {
            await this.userFinder.Find(userId);
            List<Record> records = await this.recordFinder.Find(userId);
            List<Kilometers> kilometersList = records.Select(record => record.Kilometers).ToList();
            return this.Sum.Sum(kilometersList);
        }
    }
}
