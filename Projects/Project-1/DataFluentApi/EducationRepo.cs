using Models;
using DF = DataFluentApi.Entities;


namespace DataFluentApi
{
    public class EducationRepo : ITrainerRepo<DF.Education>
    {
        private readonly DF.TraineeDbContext dbContext;

        public EducationRepo(DF.TraineeDbContext context)
        {
            dbContext = context;
        }
        public void AddDetails(DF.Education obj)
        {
            dbContext.Add(obj);
            dbContext.SaveChanges();
        }

        public DF.Education DeleteDetails(DF.Education obj)
        {
            dbContext.Remove(obj);
            dbContext.SaveChanges();
            return obj;
        }

        public IEnumerable<DF.Education> GetDetails()
        {
            return dbContext.Educations.ToList();
        }

        public void UpdateDetails(DF.Education obj)
        {
            dbContext.Update(obj);
            dbContext.SaveChanges();
        }
    }
}