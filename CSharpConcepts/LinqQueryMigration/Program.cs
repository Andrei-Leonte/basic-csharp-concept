using FluentMigrator.Runner;
using LinqQueries.DbContexts;
using LinqQueries.Migrations;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = CreateServices();
using (var scope = serviceProvider.CreateScope())
{
    UpdateDatabase(scope.ServiceProvider);
}

using var context = new LinqQueriesDBContext();

DataSeeder.SeedData(context);


Console.WriteLine("All done!");

static IServiceProvider CreateServices()
{
    return new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            .AddSqlServer()
            .WithGlobalConnectionString("Server=.;Database=LinqQueriesDB;Trusted_Connection=True;TrustServerCertificate=True;")
            .ScanIn(typeof(CreateInitialSchema).Assembly).For.Migrations())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);
}

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}