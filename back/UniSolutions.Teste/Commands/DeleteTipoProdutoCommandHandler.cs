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
    public class DeleteTipoProdutoCommandHandler : IRequestHandler<DeleteTipoProdutoCommand>
    {
        private readonly IMapper _mapper;
        private readonly UniSolutionCommandEFContext _context;

        public DeleteTipoProdutoCommandHandler(UniSolutionCommandEFContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTipoProdutoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _context.TiposProduto.Find(command.Id);
                _context.TiposProduto.Remove(entity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class DeleteTipoProdutoCommand : IRequest
    {
        public DeleteTipoProdutoCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
