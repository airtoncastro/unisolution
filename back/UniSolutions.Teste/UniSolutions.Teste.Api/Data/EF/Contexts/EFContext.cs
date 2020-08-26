using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using UniSolutions.Teste.Data.EF.Extensions;

namespace UniSolutions.Teste.Data.EF.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.SetDefaultColumnsPropertiesSqlServer();
        }
    }
}
