using LoadBalancing.Api.Bootstraper;
using LoadBalancing.Api.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterPostgresSql();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapUserEndpoints();
app.MapScalarApiReference();


app.Run();

