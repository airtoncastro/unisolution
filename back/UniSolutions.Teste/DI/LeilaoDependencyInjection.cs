using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniSolutions.Teste.Data.Contexts;

namespace UniSolutions.Teste.DependencyInjection
{ 
    public static class LeilaoDependencyInjection
    {
        public static void AddUniSolutionContext(this IServiceCollection services, string commandConnectionString, string queryConnectionString)
        {
            //Context 
            services.AddDbContext<UniSolutionCommandEFContext>(options => options.UseSqlServer(commandConnectionString));
            services.AddDbContext<UniSolutionQueryEFContext>(options => options.UseSqlServer(queryConnectionString));

            services.AddScoped(e => new UniSolutionQueryDapperContext(queryConnectionString));
        }
    }
}
