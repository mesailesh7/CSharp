using Backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//services
// Controller based api
builder.Services.AddControllers();

//Connection string can be defined like this as well but its not a good pracitse so we define connection string in appsettings.json and pull it from there
// string connectionString = "Data Source = Person.db";
string connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentException("Connection string is null");
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(""));

var app = builder.Build();

//middlewares
// app.MapGet("/", () => "Hello World!");
app.MapControllers();


app.Run();