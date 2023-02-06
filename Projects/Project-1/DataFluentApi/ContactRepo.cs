using Models;
using DF = DataFluentApi.Entities;

namespace DataFluentApi
{
    public class ContactRepo : ITrainerRepo<DF.TraineeContactDetail>
    {
        private readonly DF.TraineeDbContext dbContext;

        public ContactRepo(DF.TraineeDbContext context)
        {
            dbContext = context;
        }
        public void AddDetails(DF.TraineeContactDetail obj)
        {
            dbContext.Add(obj);
            dbContext.SaveChanges();
        }

        public DF.TraineeContactDetail DeleteDetails(DF.TraineeContactDetail obj)
        {
            Console.WriteLine($"Deleting Trainer Contact details");
            dbContext.Remove(obj);
            dbContext.SaveChanges();
            return obj;
        }

        public IEnumerable<DF.TraineeContactDetail> GetDetails()
        {
            return dbContext.TraineeContactDetails.ToList();
        }

        public void UpdateDetails(DF.TraineeContactDetail obj)
        {
            dbContext.Update(obj);
            dbContext.SaveChanges();
        }
    }
}
