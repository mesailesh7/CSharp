using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


//cors

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin",
    policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyMethod() //if not mentioned only get will be allowed
        .AllowAnyHeader(); // x-pagination
    });
});

//services
// Controller based api
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentException("Connection string is null");
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(connectionString));

// For Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => // Adding Jwt Bearer
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
//middlewares

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();