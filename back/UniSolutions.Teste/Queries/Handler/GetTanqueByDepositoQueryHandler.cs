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
    public class GetTanqueByDepositoQueryHandler : IRequestHandler<GetTanqueByDepositoQuery, GetTanqueResult>
    {
        private readonly UniSolutionQueryDapperContext _dapper;

        public GetTanqueByDepositoQueryHandler(UniSolutionQueryDapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<GetTanqueResult> Handle(GetTanqueByDepositoQuery query, CancellationToken cancellationToken)
        {
            var param = new { deposito = query.Deposito };
            using (var conexao = new SqlConnection(_dapper.Connection))
            {
                var querySql = "select Deposito,Capacidade,TipoProduto,Descricao as TipoProdutoDescricao  from tanque t left join TipoProduto tp on t.TipoProduto = tp.Id where Deposito = @deposito";
                var response = await conexao.QueryAsync<GetTanqueResult>(querySql, param);
                return response.FirstOrDefault();
            }
        }
    }

    public class GetTanqueByDepositoQuery : IRequest<GetTanqueResult>
    {
        public GetTanqueByDepositoQuery(string deposito)
        {
            this.Deposito = deposito;
        }
        public string Deposito { get; set; }
    }
}
