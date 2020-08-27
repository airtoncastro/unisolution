using Microsoft.EntityFrameworkCore;

namespace UniSolutions.Teste.Data.Contexts
{
    public class UniSolutionQueryEFContext : UniSolutionEFContext
    {
        public UniSolutionQueryEFContext(DbContextOptions<UniSolutionQueryEFContext> options) 
            : base(options)
        {
        }
    }
}
