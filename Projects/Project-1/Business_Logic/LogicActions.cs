using DF = DataFluentApi.Entities;


namespace Business_Logic
{
    public class LogicActions
    {
        //ILogic trainerLogic; 
        DF.TraineeDbContext context;
        public LogicActions(DF.TraineeDbContext con)
        {
            context = con;
        }

        /// <summary>
        /// Generates unique random Trainer Id
        /// </summary>
        /// <returns>int</returns>

        public int GetUniqueId()
        {
            Random random = new Random();
            int id;
            while (true)
            {
                IEnumerable<int> ids = from trainer in context.TraineeTrainerDetails
                                       select trainer.Tid;
                id = random.Next(100, 1000);

                if (!(ids.Contains(id)))   return id;
                else    continue;
            }
        }


        public int GetTrainerId(string? mail)
        {
            try { 
                return (from trainer in context.TraineeTrainerDetails
                        where trainer.Mail == mail
                        select trainer.Tid).First();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
