using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using VersionManager.Application.DependencyInjection;
using VersionManager.Configurations;
using VersionManager.Domain.Enums;
using VersionManager.ExceptionHandler;
using VersionManager.Infra.DependencyInjection;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.ConfigureSerilog();

    builder.Services.AddControllers().AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new AmbientVersionJsonConverter());
        opts.JsonSerializerOptions.Converters.Add(new StatusContractJsonConverter());
    });
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.Services.ConfigureInfra();

    builder.ConfigureCors();

    builder.Services.ConfigureServices();

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(opt =>
    { });

    var app = builder.Build();

    app.UseExceptionHandler(_ => { });

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(opts => opts.DocExpansion(DocExpansion.None));
    }

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "Fatal error on startup.");
}
finally
{
    await Log.CloseAndFlushAsync();
}