using LoadBalancing.Api.Bootstraper;
using LoadBalancing.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterPostgresSql();

var app = builder.Build();

app.MapUserEndpoints();

app.Run();

