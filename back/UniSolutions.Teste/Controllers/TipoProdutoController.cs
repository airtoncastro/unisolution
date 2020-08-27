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
    public class TipoProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TipoProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = await _mediator.Send(new GetTipoProdutoQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var response = await _mediator.Send(new GetTipoProdutoByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> New([FromBody] CreateTipoProdutoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpDate([FromBody] UpdateTipoProdutoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTipoProdutoCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
