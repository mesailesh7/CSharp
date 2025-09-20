var builder = WebApplication.CreateBuilder(args);
//services
// Controller based api
builder.Services.AddControllers();


var app = builder.Build();

//middlewares
// app.MapGet("/", () => "Hello World!");
app.MapControllers();


app.Run();