using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Trainer;
using System.Data.SqlClient;

namespace TraineeLib
{
    public class DeleteProfile
    {
        private string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public void DeleteTrainer(TLogin login)
        {
            Console.WriteLine("Deleting your \"Trainer Profile\"");
            Console.WriteLine("* OK \t * NO");
            Console.Write("Enter OK to delete your profile permanently or else NO to skip the deletion : ");
            string choice = Console.ReadLine();
            if (choice == "OK") 
            { 
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                using SqlCommand sqlCommand= new SqlCommand("delete from [Trainee.Login] where Email = @mail");
                sqlCommand.Parameters.AddWithValue("@mail", login.Email);
                try
                {
                    int x = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Deletion successful : {x} row(s) affected");
                }
                catch(Exception) { Console.WriteLine("Interruption occured !?\nReturning to Main menu..."); }
            }
            else
            {
                Console.WriteLine("^^** Hurray, You are staying **^^\nReturning to Main menu...");
            }
        }
    }
}
