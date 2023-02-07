using Models;
using DF = DataFluentApi.Entities;

namespace DataFluentApi
{
    public class SkillRepo : ITrainerRepo<DF.Skill>
    {
        private readonly DF.TraineeDbContext dbContext;

        public SkillRepo(DF.TraineeDbContext context)
        {
            dbContext = context;
        }
        public void AddDetails(DF.Skill obj)
        {
            dbContext.Add(obj);
            dbContext.SaveChanges();
        }

        public DF.Skill DeleteDetails(DF.Skill obj)
        {
            dbContext.Remove(obj);
            dbContext.SaveChanges();
            return obj;
        }

        public IEnumerable<DF.Skill> GetDetails()
        {
            return dbContext.Skills.ToList();
        }

        public void UpdateDetails(DF.Skill obj)
        {
            dbContext.Add(obj);
            dbContext.SaveChanges();
        }
    }
}
