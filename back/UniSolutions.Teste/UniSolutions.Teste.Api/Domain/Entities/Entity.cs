using System;
using System.Collections.Generic;
using System.Text;
using UniSolutions.Teste.Api.Domain.Entities;

namespace UniSolutions.Teste.Api.Domain.Entities
{
    public class Entity : Entity<int>, IEntity
    {
    }

    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
