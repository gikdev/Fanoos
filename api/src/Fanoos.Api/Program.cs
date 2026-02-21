using Fanoos.Api.Middleware;
using Fanoos.Common.Endpoints;
using Fanoos.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddFanoosInfrastructure(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.ApplyMigrations();
}

app.UseExceptionHandler();
RouteGroupBuilder apiGroup = app.MapGroup("/api");
app.MapEndpoints(apiGroup);
app.MapOpenApi();
app.MapOpenApi("/openapi.yaml");
app.MapScalarApiReference();

app.Run();
