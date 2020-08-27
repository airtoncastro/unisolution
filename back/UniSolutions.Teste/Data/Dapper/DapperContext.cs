using System;
using System.Collections.Generic;
using System.Text;

namespace UniSolutions.Teste.Data.Dapper
{
    public class DapperContext
    {
        public DapperContext(string connection)
        {
            Connection = connection;
        }

        public string Connection { get; set; }
    }
}
