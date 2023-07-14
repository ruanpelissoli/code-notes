using Carter;
using CodeNotes.API.Middlewares;
using CodeNotes.Domain.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(
    builder.Configuration,
    typeof(CodeNotes.API.DependencyInstaller).Assembly,
    typeof(CodeNotes.Infrastructure.DependencyInstaller).Assembly,
    typeof(CodeNotes.Application.DependencyInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapCarter();

app.Run();