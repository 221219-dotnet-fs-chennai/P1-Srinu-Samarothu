using Models;
using DF = DataFluentApi.Entities;

namespace DataFluentApi
{
    public class ExperienceRepo : ITrainerRepo<DF.Experience>
    {
        private readonly DF.TraineeDbContext dbContext;

        public ExperienceRepo(DF.TraineeDbContext context)
        {
            dbContext = context;
        }
        public void AddDetails(DF.Experience obj)
        {
            dbContext.Add(obj);
            dbContext.SaveChanges();
        }

        public DF.Experience DeleteDetails(DF.Experience obj)
        {
            dbContext.Remove(obj);
            dbContext.SaveChanges();
            return obj;
        }

        public IEnumerable<DF.Experience> GetDetails()
        {
            return dbContext.Experiences.ToList();
        }

        public void UpdateDetails(DF.Experience obj)
        {
            dbContext.Update(obj);
            dbContext.SaveChanges();
        }
    }
}
