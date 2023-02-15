using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TrainerContext>(options => options.UseInMemoryDatabase("TrainersList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/GetTrainers", async (TrainerContext context) =>
        await context.Trainers.ToListAsync());

app.MapPost("/AddTrainer", async (Trainer trainer, TrainerContext context) =>
{
    context.Add(trainer);
    await context.SaveChangesAsync();
});

app.MapPut("/ModifyTrainer/{email}", (string email, Trainer trainer, TrainerContext context) =>
{
    var existingTrainer = context.Trainers.Find(email);
    if (existingTrainer is null)
        return Results.NotFound();

    existingTrainer.firstName = trainer.firstName;
    existingTrainer.lastName = trainer.lastName;
    existingTrainer.company = trainer.company;
    existingTrainer.experience = trainer.experience;
    return Results.Accepted();
});

app.MapDelete("/Remove/{email}", async (string email, TrainerContext context) =>
{
    var existingTrainer = context.Trainers.Find(email);
    if (existingTrainer is null)
        return Results.NotFound();
    context.Remove(existingTrainer);
    await context.SaveChangesAsync();
    return Results.Accepted();
});











app.Run();

public class Trainer
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int experience { get; set; }
    public string email { get; set; }
    public string company { get; set; }
}


public class TrainerContext : DbContext
{
    public TrainerContext(DbContextOptions options) : base(options) { }

    public DbSet<Trainer> Trainers { get; set; }
}
