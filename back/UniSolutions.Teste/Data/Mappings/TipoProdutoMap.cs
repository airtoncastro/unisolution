using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniSolutions.Teste.Api.Domain.Entities;

namespace UniSolutions.Teste.Api.Data.Mappings
{
    public class TipoProdutoMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProduto>(map =>
            {
                map.HasKey(t => t.Id);
            });
        }
    }
}
