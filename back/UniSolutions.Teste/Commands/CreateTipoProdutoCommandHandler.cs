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
    public class CreateTipoProdutoCommandHandler : IRequestHandler<CreateTipoProdutoCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly UniSolutionCommandEFContext _context;

        public CreateTipoProdutoCommandHandler(UniSolutionCommandEFContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateTipoProdutoCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoProduto>(command);
            _context.TiposProduto.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }

    public class CreateTipoProdutoCommand : IRequest<int>
    {
        public string Descricao { get; set; }
    }
}
