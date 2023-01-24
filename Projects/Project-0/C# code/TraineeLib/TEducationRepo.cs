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
            string query = $"insert into [Trainee.Education] values(@uc, @up, @upy, @pc, @pp, @ppy, @id); update [Trainee.Login] set EDUstatus = 1 where Email = (select Mail from [Trainee.Trainer_details] T where T.TID =  {education.Tid});";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@uc", education.UG_college);
            sqlCommand.Parameters.AddWithValue("@up", education.UG_percentage);
            sqlCommand.Parameters.AddWithValue("@upy", education.UG_passout_year);
            sqlCommand.Parameters.AddWithValue("@pc", education.PG_college);
            sqlCommand.Parameters.AddWithValue("@pp", education.PG_percentage);
            sqlCommand.Parameters.AddWithValue("@ppy", education.PG_passout_year);
            sqlCommand.Parameters.AddWithValue("@id", education.Tid);
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("------ ** Education details added ** ------");
            return education;
            //throw new NotImplementedException();
        }


        public TEducation GetDetails(TDetails details)
        {
            TEducation education = new TEducation();
            Console.Clear();
            Console.WriteLine("\n----- => Enter Education Details <= -----");
            Console.WriteLine("\nEnter your Under Graduation details...");
            while (true)
            {
                Console.Write("College : ");
                education.UG_college = Console.ReadLine();
                if (education.UG_college.Length >= 2) break;
                else
                {
                    Console.WriteLine("Invalid input : Enter a valid UG College name");
                    Console.WriteLine();
                }
            }
            Validate valid = new Validate();
            while (true)
            {
                Console.Write("Percentage : ");
                try
                {
                    float x = (float)Convert.ToDouble(Console.ReadLine());
                    if (valid.ValidatePercentage(x))
                    {
                        education.UG_percentage = x;
                        break;
                    }
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input : Allowed percentage range is [40-100]\n");
                }
            }

            while (true)
            {
                Console.Write("Passout year : ");
                try
                {
                    int x = Convert.ToInt32(Console.ReadLine());
                    if(valid.ValidatePassoutYear(x))
                    {
                        education.UG_passout_year = x;
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input : Passout year should be in range [1999-2023]\n");
                }
            }
            Console.WriteLine("\nEnter your Post Graduation details...");
            Console.WriteLine("** Note : If you are not a Post graduate, you can fill the below stated 'Default' values **");
            Console.WriteLine("College : 'NA'\nPercentage : 0\nPassout year : 0\n");
            while (true)
            {
                Console.Write("College : ");
                education.PG_college = Console.ReadLine();
                if (education.PG_college.Length >= 2) break;
                else
                {
                    Console.WriteLine("Invalid input : Enter a valid PG College name");
                    Console.WriteLine();
                }
            }
            while (true)
            {
                Console.Write("Percentage : ");
                try
                {
                    education.PG_percentage = (float)Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input\n");
                }
            }

            while (true)
            {
                Console.Write("Passout year : ");
                try
                {
                    education.PG_passout_year = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input : Enter an integer\n");
                }
            }
            try
            {
                education.Tid = details.Id;
            }
            catch(Exception)
            {
                Console.WriteLine($"^^ ** {details.Fname} {details.Lname}, you've entered education details before ** ^^");
            }
            return AddTrainee(education);

        }

        public TEducation fetchDetails(TDetails details)
        {
            TEducation education = new TEducation();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "select UG_college, UG_percentage, UG_passout_year, PG_college, PG_percentage, PG_passout_year from [Trainee.Education] where TID = @id";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@id", details.Id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    reader.Read();
                    education.UG_college = Convert.ToString(reader["UG_college"]);
                    education.UG_percentage = (float)Convert.ToDouble(reader["UG_percentage"]);
                    education.UG_passout_year = Convert.ToInt32(reader["UG_passout_year"]);
                    education.PG_college = Convert.ToString(reader["PG_college"]);
                    education.PG_percentage = (float)Convert.ToDouble(reader["PG_percentage"]);
                    education.PG_passout_year = Convert.ToInt32(reader["PG_passout_year"]);
                }
                catch(Exception)
                {
                    //Console.Clear();
                    Console.WriteLine("--- ** INFO : No Education Details are Available ** ---");
                }
            }
            return education;
            //throw new NotImplementedException();
        }
    }
}
