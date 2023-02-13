using DataFluentApi;
using DF = DataFluentApi.Entities;
using Models;


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
            catch(Exception)
            {
                throw new Exception("Please Enter Trainer details first");
            }
        }

        public Dictionary<string, int> GetSkillDictionary(int? id)
        {
            try
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                var skillList = (from s in context.Skills
                        where id == s.Tid
                        select s);
                foreach (var skill in skillList)
                {
                    dict.Add(skill.Skill1, skill.Proficiency);
                }
                return dict;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
