using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class Validate
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public TLogin SearchEmail(string mail)
        {
            TLogin login = new TLogin();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = $"select Email, Password from [Trainee.Login] where Email = @mail";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@mail", mail);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    reader.Read();
                    login.Email = reader.GetString(0);
                    login.Password = reader.GetString(1);
                    //Console.WriteLine(login.Email + "    " + login.Password);
                }
                catch (Exception)
                {
                    Console.WriteLine();
                }
            }
            return login;
        }
        // ------------------------------------------------------------------------------------------------
        public bool ValidateEmail(TLogin login, string email)
        {
            if (login.Email == email)
                return true;
            else
                return false;
        }

        // ------------------------------------------------------------------------------------------------

        public void ValidatePassword(TLogin login)
        {
            Console.Write("Enter your password : ");
            string pwd;
            while (true)
            {
                pwd = Console.ReadLine();
                if (login.Password == pwd) break;
                else
                {
                    Console.WriteLine("\n** ERR : Incorrect password ! **");
                    Console.Write("\nEnter again : ");
                }
            }
        }

        // ------------------------------------------------------------------------------------------------

        public int GetID(TLogin login)
        {
            using SqlConnection con = new SqlConnection(connectionString) ;
            con.Open();
            string command = $"select TID from [Trainee.Trainer_details] T where  T.Mail = @mail";
            using SqlCommand sqlCommand = new SqlCommand(command, con);
            sqlCommand.Parameters.AddWithValue("@mail", login.Email);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }
    }
}
