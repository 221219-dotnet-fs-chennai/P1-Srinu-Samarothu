using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace TraineeLib
{
    public class TSkillsRepo 
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        private void AddTrainee(Dictionary<string, int> skills, TDetails details)
        {
            int rows = 0;
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            foreach (KeyValuePair<string, int> skill in skills) 
            {
                string query = "insert into [Trainee.Skills] values(@skill, @pro, @id)";
                using SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.Parameters.AddWithValue("@skill", skill.Key );
                sqlCommand.Parameters.AddWithValue("@pro", skill.Value);
                sqlCommand.Parameters.AddWithValue("@id", details.Id);
                rows += sqlCommand.ExecuteNonQuery();
            }
            Update update = new Update(details);
            update.UpdateSDStatus();
            Console.WriteLine($"{rows} row(s) got inserted");
            Console.WriteLine("------ ** Skill(s) added ** ------");
        }


        public void GetDetails(TDetails details)
        {
            Console.Clear();
            Console.WriteLine(" ** You can enter atmost 3 technical skills and the corresponding proficiency levels ** ");
            int c = 1;
            Dictionary<string, int> skills = new Dictionary<string, int>();
            string? skill;
            int rate;
            while (c < 4)
            {
                //TSkills skills = new TSkills();
                Console.Write("Skill name : ");
                skill = Console.ReadLine();
                Console.Write("Proficiency (rate  yourself in [1-5]) : ");
                rate = Convert.ToInt32(Console.ReadLine());
                //skills.Tid = details.Id;
                skills.Add(skill, rate);
                c++;
                if (c >= 2 && c <= 3)
                {
                    Console.Write($"\nDo you want to add skill-{c} ? then enter Y otherwise enter N to skip : ");
                    string ch = Console.ReadLine();
                    if( ch == "Y" || ch == "Y"){ continue; }
                    else { break;  }
                }
            }
            AddTrainee(skills, details);
        }



        public List<TSkills> fetchDetails(TDetails details)
        {
            List<TSkills> skills = new List<TSkills>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "select Skill, Proficiency, TID from [Trainee.Skills] where TID = @id";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@id", details.Id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        skills.Add(new TSkills()
                        {
                            Skill = Convert.ToString(reader["Skill"]),
                            Rate = Convert.ToInt32(reader["Proficiency"]),
                            Tid = Convert.ToInt32(reader["TID"])
                        }) ;
                    }
                }
                catch(Exception)
                {
                    //Console.Clear();
                    Console.WriteLine("--- ** INFO : No Skill(s) Available ** ---");
                }
            }
            return skills;
            //throw new NotImplementedException();
        }
    }
}
