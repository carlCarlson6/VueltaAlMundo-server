using System.Threading.Tasks;
using Application.RecordDTOs;
using Domain.Entities;
using Domain.Repositories;

namespace Application.RecordUseCases
{
    public class CreateRecord
    {
        private readonly IRecordRepository repository;
        public CreateRecord(IRecordRepository recordRepository)
        {
            this.repository = recordRepository;
        }

        public async Task<Record> Execute(CreateRecordCommand command)
        {
            Record newRecord = Record.Create(command.UserId, command.Kilometers, command.CreatedAt);
            await this.repository.Save(newRecord);

            return newRecord;
        }
    }
}
