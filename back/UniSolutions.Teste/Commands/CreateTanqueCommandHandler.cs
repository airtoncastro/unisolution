using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniSolutions.Teste.Api.Domain.Entities;
using UniSolutions.Teste.Data.Contexts;

namespace UniSolutions.Teste.Api.Commands
{
    public class CreateTanqueCommandHandler : IRequestHandler<CreateTanqueCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly UniSolutionCommandEFContext _context;

        public CreateTanqueCommandHandler(UniSolutionCommandEFContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(CreateTanqueCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Tanque>(command);
            _context.Tanques.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Deposito;
        }
    }

    public class CreateTanqueCommand : IRequest<string>
    {
        public string Deposito { get; set; }
        public int Capacidade { get; set; }
        public int TipoProduto { get; set; }
    }
}
