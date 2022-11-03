using MediatR;
using Network.API.Extensions;
using Network.Application.Common.Interfaces.Repositories;
using Network.Infrastructure.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();
var app = builder.Build();

await app.SeedData();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandling();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.UseAuthorization();
app.UseDbTransction();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();