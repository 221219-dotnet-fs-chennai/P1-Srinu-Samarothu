using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeLib;

namespace Trainer
{
    public class TExperienceRepo 
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        int rows = 0 ;
        public void AddTrainee(string company, string designation, int experience, TDetails details)
        {
            string query = "insert into [Trainee.Experience] values(@com, @des, @exp, @id)";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@com", company);
            sqlCommand.Parameters.AddWithValue("@des", designation);
            sqlCommand.Parameters.AddWithValue("@exp", experience);
            sqlCommand.Parameters.AddWithValue("@id", details.Id);
            rows += sqlCommand.ExecuteNonQuery();
            //return exp;
            //throw new NotImplementedException();
        }


        public void GetDetails(TDetails details)
        {
            //TExperience experience = new TExperience();
            int c = 1, experience;
            string? company, des;
            Console.Clear();
            Console.WriteLine("** You can enter atmost 3 experience-details below... ");
            while (c < 4)
            {
                Console.Write("Company (or) Institution name : ");
                company = Console.ReadLine();
                Console.Write("Designation : ");
                des = Console.ReadLine();
                Console.Write("Experience in months : ");
                experience = Convert.ToInt32(Console.ReadLine());
                AddTrainee(company, des, experience, details);
                c++;
                if (c >= 2 && c <= 3)
                {
                    Console.Write($"\nDo you want to add another Experience-{c} ? then enter Y otherwise enter N to skip : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    if (ch == 'Y' || ch == 'y') { continue; }
                    else { break; }
                }
            }
            Console.WriteLine($"{rows} row(s) got inserted");
            Update update = new Update(details);
            update.UpdateEDStatus();
            Console.WriteLine("------ ** Experience details added ** ------");
        }



        public List<TExperience> fetchDetails(TDetails details)
        {
            List<TExperience> experiences = new List<TExperience>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "select Company, Designation, Overall_Experience, TID from [Trainee.Experience] where TID = @id";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@id", details.Id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        experiences.Add(new TExperience() {
                            Company = Convert.ToString(reader["Company"]),
                            Designation = Convert.ToString(reader["Designation"]),
                            Experience = Convert.ToInt32(reader["Overall_Experience"]),
                            Tid = Convert.ToInt32(reader["TID"])
                        });
                    }
                }
                catch (Exception)
                {
                    //Console.Clear();
                    Console.WriteLine("\n--- ** INFO : No Experience Details are Available ** ---");
                }
            }
            return experiences;
        }
    }
}
