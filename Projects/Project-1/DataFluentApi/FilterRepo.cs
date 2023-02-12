using DataFluentApi.Views;
using Models;


namespace DataFluentApi
{
    public class FilterRepo : IFilterRepo<VirtualTable>
    {
        private readonly TraineeDbContext dbContext;

        public FilterRepo(TraineeDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<VirtualTable> GetVirtualTable()
        {
            return dbContext.VirtualTables.ToList();
        }
    }
}
