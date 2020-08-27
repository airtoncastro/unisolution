using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniSolutions.Teste.Api.Domain.Entities
{
    public interface IEntity : IEntity<int>
    {
    }

    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
