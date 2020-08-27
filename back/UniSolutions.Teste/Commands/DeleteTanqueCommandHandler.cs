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
    public class DeleteTanqueCommandHandler : IRequestHandler<DeleteTanqueCommand>
    {
        private readonly IMapper _mapper;
        private readonly UniSolutionCommandEFContext _context;

        public DeleteTanqueCommandHandler(UniSolutionCommandEFContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTanqueCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _context.Tanques.Find(command.Deposito);
                _context.Tanques.Remove(entity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class DeleteTanqueCommand : IRequest
    {
        public DeleteTanqueCommand(string deposito)
        {
            this.Deposito = deposito;
        }
        public string Deposito { get; set; }
    }
}
