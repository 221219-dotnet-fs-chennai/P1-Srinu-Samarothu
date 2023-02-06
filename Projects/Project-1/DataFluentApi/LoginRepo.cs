using Models;
using DF = DataFluentApi.Entities;

namespace DataFluentApi;

public class LoginRepo : ITrainerRepo<DF.TraineeLogin>
{
    private readonly DF.TraineeDbContext dbContext;

    public LoginRepo(DF.TraineeDbContext context)
    {
        dbContext = context;
    }
    public IEnumerable<DF.TraineeLogin> GetDetails()
    {
        return dbContext.TraineeLogins.ToList();
    }

    public void AddDetails(DF.TraineeLogin obj)
    {
        dbContext.Add(obj);
        dbContext.SaveChanges();
    }


    public void UpdateDetails(DF.TraineeLogin obj)
    {
        dbContext.Update(obj);
        dbContext.SaveChanges();
    }

    public DF.TraineeLogin DeleteDetails(DF.TraineeLogin obj)
    {
        Console.WriteLine($"Deleting {obj.Email}");
        dbContext.Remove(obj);
        dbContext.SaveChanges();
        return obj;
    } 
}