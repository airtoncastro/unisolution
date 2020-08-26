using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UniSolutions.Teste.Api.Domain.Entities;
using UniSolutions.Teste.Api.Queries.Handler;

namespace UniSolutions.Teste.Api.Queries
{
    public class DomainToQueryResultMapping : Profile
    {
        public DomainToQueryResultMapping()
        {
            CreateMap<Tanque, GetTanqueResult>();
            DisableConstructorMapping();
        }
    }
}
