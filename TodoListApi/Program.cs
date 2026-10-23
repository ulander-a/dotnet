using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using ToDoListAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Auth registrations
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration);

// DB registrations
builder.Services.AddDbContext<ToDoContext>(opt => 
    opt.UseInMemoryDatabase("ToDos")
);

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

// app.MapGet("/", () => "TodoListAPI is running");

app.Run();
