using AuthAppDotNet.Application;
using AuthAppDotNet.Domain.Users;
using AuthAppDotNet.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
.AddApplication()
    .AddInfrastructure(configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapIdentityApi<ApplicationUser>();
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
