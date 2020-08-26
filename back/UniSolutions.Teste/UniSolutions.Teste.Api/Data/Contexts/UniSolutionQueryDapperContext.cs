using System;
using System.Collections.Generic;
using System.Text;
using UniSolutions.Teste.Data.Dapper;

namespace UniSolutions.Teste.Data.Contexts
{
    public class UniSolutionQueryDapperContext : DapperContext
    {
        public UniSolutionQueryDapperContext(string connection)
            : base(connection)
        {

        }
    }
}
