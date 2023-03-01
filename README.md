- Fix migrations error:

Ao executar o comando dotnet ef migrations add nameOfMigration, o seguinte erro aparecia na linha de comando.
> `Unable to create an object of type 'ApplicationDbContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728`

Para corrigí-lo basta passar como parâmetros o projeto em que será criado as migrações através do comando *-project* e o projeto de startup da aplicação através do parâmetro *--statup-project*

```cli
dotnet ef migrations add  test --verbose --project .\PHCleanArchSample.Infra.Data\PHCleanArchSample.Infra.Data.csproj   --startup-project .\PHCleanArchSample.MVC\PHCleanArchSample.MVC.csproj
```
Referência: https://stackoverflow.com/questions/70273434/unable-to-resolve-service-for-type-%C2%A8microsoft-entityframeworkcore-dbcontextopti