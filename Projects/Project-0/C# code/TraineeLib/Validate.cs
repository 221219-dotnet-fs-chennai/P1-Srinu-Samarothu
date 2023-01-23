using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainer
{
    public class Validate
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
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
                    Console.Write("\n\nEnter again : ");
                }
            }
        }

        // ------------------------------------------------------------------------------------------------

        public bool ValidatePercentage(float p)
        {
            return p >= 40 && p <= 100;
        }

        public bool ValidatePassoutYear(int year)
        {
            return year >= 1999 && year <= 2023;
        }

        public int GetID(TLogin login)
        {
            using SqlConnection con = new SqlConnection(connectionString) ;
            con.Open();
            string command = $"select TID from [Trainee.Trainer_details] T where  T.Mail = @mail";
            using SqlCommand sqlCommand = new SqlCommand(command, con);
            sqlCommand.Parameters.AddWithValue("@mail", login.Email);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            try
            {
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //--------------------------------------------------------------------------------------------------

        internal bool CheckID(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string command = $"select TID from [Trainee.Trainer_details] ";
            using SqlCommand sqlCommand = new SqlCommand(command, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<int> ids = new List<int>();
            while(reader.Read())
            {
                ids.Add(reader.GetInt32(0));
            }
            if (ids.Contains(id))
                return false;
            else
                return true;
        }
    }
}
