using Models;
using DF = DataFluentApi.Entities;

namespace DataFluentApi
{
    public class TrainerRepo : ITrainerRepo<DF.TraineeTrainerDetail>
    {
        private readonly DF.TraineeDbContext dbContext;

        public TrainerRepo(DF.TraineeDbContext context)
        {
            dbContext = context;
        }
        public void AddDetails(DF.TraineeTrainerDetail obj)
        {
            dbContext.Add(obj);
            dbContext.SaveChanges();
        }

        public DF.TraineeTrainerDetail DeleteDetails(DF.TraineeTrainerDetail obj)
        {
            Console.WriteLine($"Deleting Trainer - {obj.FirstName} {obj.LastName}");
            dbContext.Remove(obj);
            dbContext.SaveChanges();
            return obj;
        }

        public IEnumerable<DF.TraineeTrainerDetail> GetDetails()
        {
            return dbContext.TraineeTrainerDetails.ToList();
        }

        public void UpdateDetails(DF.TraineeTrainerDetail obj)
        {
            dbContext.Update(obj);
            dbContext.SaveChanges();
        }
    }
}
