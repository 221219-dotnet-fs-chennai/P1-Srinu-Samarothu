using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeLib;
using Trainer;

namespace Trainer
{
    public class TDetailsRepo : IRepo<TDetails, TLogin>
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public TDetails AddTrainee(TDetails details)
        {
            //TDetails details = new TDetails();
            string query = @"insert into [Trainee.Trainer_details] values(@Id, @fname, @lname, @gender, @dob, @mail);  update [Trainee.Login] set TDstatus = 1 where Email = @mail";
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
            Console.WriteLine("------ ** New Trainer Details added ** ------");
            return details;
        }

        public TDetails GetDetails(TLogin login)
        {
            TDetails details = new TDetails();
            RegexValidation validate = new RegexValidation();
            Validate valid = new Validate();
            var ids = GetAllIds();
            int c = 1;
            Console.WriteLine("\n** NOTE : The IDs that are alredy in use were listed below **");
            foreach(int id in ids)
            {
                Console.Write($"--   {id}   ");
                if(c >= 5) { Console.Write("--\n"); }
            }
            Console.WriteLine("\n\n----- => Enter Trainer Details <= -----");
            while (true)
            {
                Console.Write("\nEnter Trainer ID  (Must be a 3-digit Unique integer) : ");
                string id = Console.ReadLine();
                try
                {
                    if (valid.CheckID(Convert.ToInt32(id)))
                    {
                        if (validate.ValidateID(id))
                        {
                            details.Id = Convert.ToInt32(id);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("*** ALERT :- Invalid 'Trainer ID', check wheather you entered a 3-digit ID :] ***");
                        }
                    }
                    else
                    {
                        Console.WriteLine("*** ALERT :- Duplicate 'Trainer ID', try entering an unique ID ***");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Write("Enter your First Name : ");
            details.Fname = Console.ReadLine();
            Console.Write("Enter your Last Name : ");
            details.Lname = Console.ReadLine();
            Console.Write("Enter your gender : ");
            details.Gender = Console.ReadLine();
            while (true)
            {
                Console.Write("Enter your DOB in dd:mm:yyyy format : ");
                string dob = Console.ReadLine();
                if (validate.ValidateDOB(dob))
                {
                    details.Dob = dob;
                    break;
                }
                else
                {
                    Console.WriteLine("*** ALERT :- Invalid 'DOB', check wheather you entered a year between [1700-2900] :] ***");
                }
            }
            try
            {
                details.email = login.Email;
            }
            catch(Exception)
            {
                Console.WriteLine($" ** Trainer alredy exists with \"{valid.GetID(login)}\" as his/her Trainer ID **");
            }
            return AddTrainee(details);
        }

        private List<int> GetAllIds()
        {
            List<int> ids = new List<int>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "select TID from [Trainee.Trainer_details]";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    ids.Add(Convert.ToInt32(reader[0]));
                }
            }
            return ids;
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
                    //Console.Clear();
                    Console.WriteLine("--- ** INFO : No Trainer Details are Available ** ---");
                }
            }
            return details;
        }

        
    }
}
