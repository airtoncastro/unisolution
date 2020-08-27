using Microsoft.EntityFrameworkCore;

namespace UniSolutions.Teste.Data.Contexts
{
    public class UniSolutionCommandEFContext : UniSolutionEFContext
    {
        public UniSolutionCommandEFContext(DbContextOptions<UniSolutionCommandEFContext> options) 
            : base(options)
        {
        }
    }
}
