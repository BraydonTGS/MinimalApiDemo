using MinimalApi.Api.Api;
using MinimalApi.DataAccess.DbAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Default"); 
builder.Services.AddSingleton<ISqlDataAccess>(new SqlDataAccess(connectionString));
builder.Services.AddSingleton<IUserRepository, UserRepository>();   


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();
