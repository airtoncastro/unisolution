using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniSolutions.Teste.Api.Commands;
using UniSolutions.Teste.Api.Queries.Handler;

namespace UniSolutions.Teste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TanqueController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = await _mediator.Send(new GetTanqueQuery());
            return Ok(response);
        }

        [HttpGet("ByDeposito/{deposito}")]
        public async Task<IActionResult> GetByDeposito(string deposito)
        {
            var response = await _mediator.Send(new GetTanqueByDepositoQuery(deposito));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> New([FromBody] CreateTanqueCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpDate([FromBody] UpdateTanqueCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{deposito}")]
        public async Task<IActionResult> Delete(string deposito)
        {
            var command = new DeleteTanqueCommand(deposito);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
