using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Trainer;

namespace Trainer
{
    public class TLoginRepo : IRepo<TLogin, string>
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public TLogin AddTrainee(TLogin login)
        {
            string query = "insert into [Trainee.Login](Email, Password) values(@mail, @password)";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand sqlCommand= new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@mail", login.Email);
            sqlCommand.Parameters.AddWithValue("@password", login.Password);
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("------ ** New Trainee added ** ------");
            return login;
        }

// ----------------------------------------------------------------------------------------------------------

        public TLogin fetchDetails(string mail)
        {
            TLogin login;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "select Email, Password from [Trainee.Login]";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                login = new TLogin(reader.GetString(0), reader.GetString(1));
            }
            return login ;
        }

 // ---------------------------------------------------------------------------------------------------------

        
        public TLogin NewTrainee(string mail)
        {
            TLogin login = new TLogin();
            Console.Write($"\nYour Email id : {mail}");
            login.Email = mail;
            Console.Write("\nCreate a new password : ");
            login.Password = Console.ReadLine();
            string pwd;
            while (true)
            {
                Console.Write("Confirm your password");
                pwd = Console.ReadLine();
                if (login.Password == pwd) break;
                else Console.WriteLine("\nERR : Passwords are not matching");
            }
            return login;
        }

        //---------------------------------------------------------------------------------------------------------------------

    }
}





