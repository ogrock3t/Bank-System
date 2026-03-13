using Lab5.Application;
using Lab5.Infrastructure.Persistence;
using Lab5.Presentation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddPersistence();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();