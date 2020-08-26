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
    public class GetTanqueQueryHandler : IRequestHandler<GetTanqueQuery, List<GetTanqueResult>>
    {
        private readonly UniSolutionQueryDapperContext _dapper;

        public GetTanqueQueryHandler(UniSolutionQueryDapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<GetTanqueResult>> Handle(GetTanqueQuery query, CancellationToken cancellationToken)
        {
            using (var conexao = new SqlConnection(_dapper.Connection))
            {
                var querySql = "select TOP 200 * from tanque";
                var response = await conexao.QueryAsync<GetTanqueResult>(querySql);
                return response.ToList();
            }
        }
    }

    public class GetTanqueQuery : IRequest<List<GetTanqueResult>>
    {

    }

    public class GetTanqueResult
    {
        public string Deposito { get; set; }
        public int Capacidade { get; set; }
        public int TipoProduto { get; set; }
    }
}
