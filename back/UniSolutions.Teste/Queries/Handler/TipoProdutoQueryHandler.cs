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
    public class GetTipoProdutoQueryHandler : IRequestHandler<GetTipoProdutoQuery, List<GetTipoProdutoResult>>
    {
        private readonly UniSolutionQueryDapperContext _dapper;

        public GetTipoProdutoQueryHandler(UniSolutionQueryDapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<GetTipoProdutoResult>> Handle(GetTipoProdutoQuery query, CancellationToken cancellationToken)
        {
            using (var conexao = new SqlConnection(_dapper.Connection))
            {
                var querySql = "select TOP 200 Id, Descricao from TipoProduto";
                var response = await conexao.QueryAsync<GetTipoProdutoResult>(querySql);
                return response.ToList();
            }
        }
    }

    public class GetTipoProdutoQuery : IRequest<List<GetTipoProdutoResult>>
    {

    }

    public class GetTipoProdutoResult
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
