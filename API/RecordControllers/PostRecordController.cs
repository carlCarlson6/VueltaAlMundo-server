using System.Net;
using System.Threading.Tasks;
using API.RecordControllers.Messages;
using Application.RecordDTOs;
using Application.RecordUseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.RecordControllers
{
    [ApiController]
    [Route("api/record")]
    public class PostRecordController : ControllerBase
    {
        private readonly CreateRecord create;
        public PostRecordController(CreateRecord createRecord)
        {
            this.create = createRecord;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<RecordCreatedResponse> Post([FromBody] CreateRecordCommand createRecordRequest)
        {
            Record record = await this.create.Execute(createRecordRequest);
            return new RecordCreatedResponse(record.Id);
        }

    }
}
