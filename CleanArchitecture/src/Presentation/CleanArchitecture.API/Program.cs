using CleanArchitecture.API.Extensions;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithFilterExtension()
                .AddSwaggerGenExtension()
                .AddExceptionHandlerExtension()
                .AddMemoryCacheExtension();

builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);


var app = builder.Build();

app.UseConfigurePipelineExtension();

app.MapControllers();

app.Run();
