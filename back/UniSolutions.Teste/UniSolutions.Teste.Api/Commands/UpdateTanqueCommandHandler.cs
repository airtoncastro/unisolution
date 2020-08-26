using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniSolutions.Teste.Api.Domain.Entities;
using UniSolutions.Teste.Data.Contexts;

namespace UniSolutions.Teste.Api.Commands
{
    public class UpdateTanqueCommandHandler : IRequestHandler<UpdateTanqueCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly UniSolutionCommandEFContext _context;

        public UpdateTanqueCommandHandler(UniSolutionCommandEFContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(UpdateTanqueCommand command, CancellationToken cancellationToken)
        {

            try
            {
                var entity = _context.Tanques.Find(command.Deposito);
                _mapper.Map(command, entity);
                await _context.SaveChangesAsync();
                return entity.Deposito;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class UpdateTanqueCommand : IRequest<string>
    {
        public string Deposito { get; set; }
        public string Capacidade { get; set; }
        public int TipoProduto { get; set; }
    }
}
