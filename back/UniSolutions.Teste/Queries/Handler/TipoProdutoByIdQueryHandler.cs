using AutoMapper.QueryableExtensions;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniSolutions.Teste.Data.Contexts;

namespace UniSolutions.Teste.Api.Queries.Handler
{
    public class TipoProdutoByIdQueryHandler : IRequestHandler<GetTipoProdutoByIdQuery, GetTipoProdutoResult>
    {
        private readonly UniSolutionQueryDapperContext _dapper;

        public TipoProdutoByIdQueryHandler(UniSolutionQueryDapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<GetTipoProdutoResult> Handle(GetTipoProdutoByIdQuery query, CancellationToken cancellationToken)
        {
            var param = new { id = query.Id };
            using (var conexao = new SqlConnection(_dapper.Connection))
            {
                var querySql = "select TOP 200 Id, Descricao from TipoProduto where Id = @id";
                var response = await conexao.QueryAsync<GetTipoProdutoResult>(querySql, param);
                return response.FirstOrDefault();
            }
        }
    }

    public class GetTipoProdutoByIdQuery : IRequest<GetTipoProdutoResult>
    {
        public GetTipoProdutoByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
