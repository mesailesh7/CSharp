var builder = WebApplication.CreateBuilder(args);
//services

var app = builder.Build();

//middlewares
// app.MapGet("/", () => "Hello World!");

app.Run();