using Business_Logic;
using Microsoft.EntityFrameworkCore;
using DF = DataFluentApi.Entities;
using DV = DataFluentApi.Views;
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
builder.Services.AddDbContext<DV.TraineeDbContext>(options => options.UseSqlServer(obj));


builder.Services.AddScoped<ILogic, TrainerLogic>();
builder.Services.AddScoped<LogicActions, LogicActions>();
builder.Services.AddScoped<ITrainerRepo<DF.TraineeLogin>, LoginRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.TraineeTrainerDetail>, TrainerRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.TraineeContactDetail>, ContactRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.Education>, EducationRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.Experience>, ExperienceRepo>();
builder.Services.AddScoped<ITrainerRepo<DF.Skill>, SkillRepo>();
builder.Services.AddScoped<IFilterRepo<DV.VirtualTable>, FilterRepo>();



builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

/*app.UseStaticFiles();
app.UseDefaultFiles();*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
