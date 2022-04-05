using Microsoft.EntityFrameworkCore;
using ActorsRestAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ActorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ActorContext")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<ActorContext>(opt =>
    opt.UseInMemoryDatabase("Actor"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "Actor", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();

