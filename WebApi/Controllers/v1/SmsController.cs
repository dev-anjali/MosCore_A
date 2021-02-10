using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MosCore.Application.Features.Smss.Queries.GetAllCached;
using MosCore.Application.Features.Smss.Queries.GetById;
using Application.Features.Smss.Command.Create;
using MosCore.Application.Features.Smss.Commands.Update;
using MosCore.Application.Features.Smss.Commands.Delete;
using System.Collections.Generic;
using AspNetCoreHero.Results;

namespace MosCore.WebApi.Controllers.v1
{
    public class SmsController : BaseApiController<SmsController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sms = await _mediator.Send(new GetAllSmssCachedQuery());
            return Ok(sms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sms = await _mediator.Send(new GetSmsByIdQuery() { Id = id });
            return Ok(sms);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(List<CreateSmsCommand> commands)
        {
            foreach (var item in commands)
            {
                await _mediator.Send(item);
            }
            return Ok(Result.Success("success"));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSmsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteSmsCommand { Id = id }));
        }
    }
}
