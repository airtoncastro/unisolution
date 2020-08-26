using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniSolutions.Teste.Api.Domain.Entities;
using UniSolutions.Teste.Api.Commands;
namespace UniSolutions.Teste.Api.Commands
{
    public class CommandToDomainMapping : Profile
    {
        public CommandToDomainMapping()
        {
            CreateMap<CreateTanqueCommand,Tanque>();  
            CreateMap<UpdateTanqueCommand, Tanque>();
        }
    }
}
