using Business_Logic;
using Microsoft.EntityFrameworkCore;
using DF = DataFluentApi.Entities;
using Models;
using DataFluentApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var obj = builder.Configuration.GetConnectionString("TrainerDB");
builder.Services.AddDbContext<DF.TraineeDbContext>(options => options.UseSqlServer(obj));


builder.Services.AddScoped<ILogic, TrainerLogic>();
builder.Services.AddScoped<LogicActions, LogicActions>();
builder.Services.AddScoped<ITrainerRepo<DF.TraineeLogin>, LoginRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.TraineeTrainerDetail>, TrainerRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.TraineeContactDetail>, ContactRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.Education>, EducationRepo>();




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
