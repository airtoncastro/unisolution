# unisolution
## Atualizar back appsettings.json com o banco que irá utilizar para teste
"ConnectionStrings": 
{
    "CommandConnectionString": "Data Source=localhost,15789;Initial Catalog=UniSolution;User ID=sa;Password=1q2w3e!Q@W#E;",
    "QueryConnectionString": "Data Source=localhost,15789;Initial Catalog=UniSolution;User ID=sa;Password=1q2w3e!Q@W#E;"
}

## Atualizar front src/proxy.conf.json com a url e porta da api 

{
    "/api/*": {
        "target": "https://localhost:5001",
        "secure": false,
        "logLevel": "debug"
    }
}
