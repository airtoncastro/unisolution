using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UniSolutions.Teste.Api.Domain.Entities;

namespace UniSolutions.Teste.Data.Mappings
{
    public static class TanqueMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tanque>(map =>
            {
                map.HasKey(t => t.Deposito);
            });
        }
    }
}
