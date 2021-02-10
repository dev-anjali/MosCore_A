using MosCore.WebApi.Controllers;
using MosCore.Application.Features.Products.Queries.GetAllPaged;
using MosCore.Application.Features.Products.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MosCore.Application.Features.Devices.Queries.GetAllCached;
using MosCore.Application.Features.Devices.Queries.GetById;
using MosCore.Application.Features.Devices.Commands.Delete;
using MosCore.Application.Features.Devices.Commands.Create;
using MosCore.Application.Features.Devices.Commands.Update;

namespace MosCore.WebApi.Controllers.v1
{
    public class DeviceController : BaseApiController<DeviceController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetAllDevicesCachedQuery());
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _mediator.Send(new GetDeviceByIdQuery() { Id = id });
            return Ok(brand);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDeviceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDeviceCommand command)
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
            return Ok(await _mediator.Send(new DeleteDeviceCommand { Id = id }));
        }
    }
}
