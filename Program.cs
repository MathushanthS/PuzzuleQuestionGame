using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PuzzuleQuestion.DbContex;
using PuzzuleQuestion.MediatorQueries.AnswerQuery;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr),
    optionsBuilder => optionsBuilder.MigrationsAssembly("PuzzuleQuestion")));


builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddControllers();
builder.Services.AddSignalR().AddJsonProtocol();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Assembly configurationAppAssembly = typeof(Program).GetType().GetTypeInfo().Assembly;
builder.Services.AddMediatR(configurationAppAssembly);
builder.Services.AddMediatR(typeof(AddAnswerQuery).GetTypeInfo().Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
