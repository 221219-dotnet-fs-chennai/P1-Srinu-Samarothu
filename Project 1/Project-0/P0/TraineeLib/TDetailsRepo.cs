using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace Trainer
{
    public class TDetailsRepo : IRepo<TDetails, TLogin>
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public TDetails AddTrainee(TDetails details)
        {
            //TDetails details = new TDetails();
            string query = "insert into [Trainee.Trainer_details] values(@Id, @fname, @lname, @gender, @dob, @mail)";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@Id", details.Id);
            sqlCommand.Parameters.AddWithValue("@fname", details.Fname);
            sqlCommand.Parameters.AddWithValue("@lname", details.Lname);
            sqlCommand.Parameters.AddWithValue("@gender", details.Gender);
            sqlCommand.Parameters.AddWithValue("@dob", details.Dob);
            sqlCommand.Parameters.AddWithValue("@mail", details.email);
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("------ ** New Trainee added ** ------");
            return details;
        }

        public TDetails GetDetails(TLogin login)
        {
            TDetails details = new TDetails();
            Console.Write("Enter Trainer ID  (Must be Unique) : ");
            details.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your First Name : ");
            details.Fname = Console.ReadLine();
            Console.Write("Enter your Last Name : ");
            details.Lname = Console.ReadLine();
            Console.Write("Enter your gender : ");
            details.Gender = Console.ReadLine();
            Console.Write("Enter your DOB in dd:mm:yyyy format : ");
            details.Dob = Console.ReadLine();
            details.email = login.Email;
            return details;

        }

        public TDetails fetchDetails(TLogin login)
        {
            //throw new NotImplementedException();
            TDetails details = new TDetails();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "select TID, First_name, Last_name, Gender, DOB, Mail from [Trainee.Trainer_details] where Mail = @mail";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@mail", login.Email);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    reader.Read();
                    details.Id = Convert.ToInt32(reader["TID"]);
                    details.Fname = Convert.ToString(reader["First_name"]);
                    details.Lname = Convert.ToString(reader["Last_name"]);
                    details.Gender = Convert.ToString(reader["Gender"]);
                    details.Dob = Convert.ToString(reader["DOB"]);
                    details.email = Convert.ToString(reader["Mail"]);
                }
                catch (Exception) 
                {
                    Console.WriteLine("--------- No Data is Available ---------");
                    Console.WriteLine("------- Try inserting some data  -------");
                }
            }
            return details;
        }

        
    }
}
