using Market.Products.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.AddSwagger()
    .AddData()
    .AddTime()
    .AddApplicationService()
    .AddMappers()
    .AddMediatR()
    .AddConfiguration();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
