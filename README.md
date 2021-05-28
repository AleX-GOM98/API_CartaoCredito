# API_CartaoCredito

## Criando um projeto com vscode

### CMD
* Criando o arquivo
```shell script
dotnet new webapi -o TodoApi
cd TodoApi
```
* Instalando o pacote EntityFrameworkCore
```shell script
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```
## Pastas

### Controller\v1

Adicionar os verbos http

```shell script
[ApiController]
[Route("V1/[controller]")]
public class ClienteControler : ControllerBase
{
private static readonly string[] Email = new[]
       {
          'teste@gmail.com'
       };         
       private readonly ILogger<CleinteControler> _logger;     
} 
```
 
### Domain\Models

* CartaoCredito
```shell script
 public class CartaoCredito
    {
        public int id {get; set;}
        public string sumary {get; set;}
    }
```

* Cliente
```shell script
public class Cliente
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string CartaoCredito {get; set;} 
    }
```
* ClienteContext
```shell script
public class Cliente
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string CartaoCredito {get; set;}
        
    }
```
 
 
* Domain\GeratorCC
  Nucleo de geração do cartaod e credito
```shell script
 string CCBIN = txtBIN.Text.Trim().Replace(" ", "");
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            txtCCGerado.Clear();
            string CCBin = txtBIN.Text.Trim().Replace(" ", "");
```
