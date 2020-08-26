using Microsoft.EntityFrameworkCore;
using UniSolutions.Teste.Data.Mappings;
using UniSolutions.Teste.Api.Domain.Entities;
using UniSolutions.Teste.Data.EF.Contexts;

namespace UniSolutions.Teste.Data.Contexts
{
    public class UniSolutionEFContext : EFContext
    {
        #region Entities DbSet
        public DbSet<Tanque> Tanques { get; set; }

        #endregion

        public UniSolutionEFContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Entities Db Mapping
            TanqueMap.Map(modelBuilder);
            #endregion
        }
    }
}
