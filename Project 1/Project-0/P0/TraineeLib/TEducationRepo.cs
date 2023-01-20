using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class TEducationRepo : IRepo<TEducation, TDetails>
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public TEducation AddTrainee(TEducation education)
        {
            string query = "insert into [Trainee.Education] values(@uc, @up, @upy, @pc, @pp, @ppy, @id)";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@uc", education.UG_college);
            sqlCommand.Parameters.AddWithValue("@up", education.UG_percentage);
            sqlCommand.Parameters.AddWithValue("@upy", education.UG_passout_year);
            sqlCommand.Parameters.AddWithValue("@uc", education.UG_college);
            sqlCommand.Parameters.AddWithValue("@up", education.UG_percentage);
            sqlCommand.Parameters.AddWithValue("@upy", education.UG_passout_year);
            sqlCommand.Parameters.AddWithValue("@id", education.Tid);
            int rows = sqlCommand.ExecuteNonQuery();
            //Console.WriteLine("------ ** New Trainee added ** ------");
            return education;
            //throw new NotImplementedException();
        }


        public TEducation GetDetails(TDetails details)
        {
            TEducation education = new TEducation();
            Console.WriteLine("Enter your Under Graduation details below...");
            Console.Write("College : ");
            education.UG_college = Console.ReadLine();
            Console.Write("Percentage : ");
            education.UG_percentage = Convert.ToInt32(Console.ReadLine());
            Console.Write("Passout year : ");
            education.UG_passout_year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Post Graduation details below...");
            Console.WriteLine("** Note : If you are not a Post graduate");
            Console.Write("College : ");
            education.UG_college = Console.ReadLine();
            Console.Write("Percentage : ");
            education.UG_percentage = Convert.ToInt32(Console.ReadLine());
            Console.Write("Passout year : ");
            education.UG_passout_year = Convert.ToInt32(Console.ReadLine());
            education.Tid = details.Id;
            return education;

        }

        public TEducation fetchDetails(TDetails details)
        {
            TEducation education;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "select UG_college, UG_percentage, UG_passout_year, PG_college, PG_percentage, PG_passout_year from [Trainee.Education] where TID = @id";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@id", details.Id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                education = new TEducation()
                    {
                        UG_college = Convert.ToString(reader["UG_college"]),
                        UG_percentage = Convert.ToInt32(reader["UG_percentage"]),
                        UG_passout_year = Convert.ToInt32(reader["PG_passout_year"]),
                        PG_college = Convert.ToString(reader["PG_college"]),
                        PG_percentage = Convert.ToInt32(reader["PG_percentage"]),
                        PG_passout_year = Convert.ToInt32(reader["PG_passout_year"]),
                        //Tid = Convert.ToInt32(reader["TID"])
                    };
            }
            return education;
            //throw new NotImplementedException();
        }
    }
}
