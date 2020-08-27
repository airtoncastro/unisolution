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
    public class UpdateTipoProdutoCommandHandler : IRequestHandler<UpdateTipoProdutoCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly UniSolutionCommandEFContext _context;

        public UpdateTipoProdutoCommandHandler(UniSolutionCommandEFContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(UpdateTipoProdutoCommand command, CancellationToken cancellationToken)
        {

            try
            {
                var entity = _context.TiposProduto.Find(command.Id);
                _mapper.Map(command, entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class UpdateTipoProdutoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Descricao{ get; set; }
    }
}
