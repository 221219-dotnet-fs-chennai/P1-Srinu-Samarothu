using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Trainer;
using System.Data.SqlClient;
using Serilog;

namespace TraineeLib
{
    public class DeleteProfile
    {
        private string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public void DeleteTrainer(string mail)
        {
            Console.Clear();
            Console.WriteLine("Deleting your \"Trainer Profile\"");
            Console.WriteLine("* OK \n* NO");
            Console.Write("Enter OK to delete your profile permanently or else NO to skip the deletion : ");
            string choice = Console.ReadLine();
            TLogin login = TLoginRepo.FetchEmail(mail);
            if (choice == "OK" || choice == "ok" || choice == "Ok" || choice == "oK") 
            {
                Console.WriteLine("--- < Please confirm your password in 3 attempts before deactivating your profile > ---");
                for (int i = 3; i > 0; )
                {
                    Console.Write("Enter password here : ");
                    string pwd = Console.ReadLine();
                    if (login.Password == pwd)
                    {
                        using SqlConnection connection = new SqlConnection(connectionString);
                        connection.Open();
                        using SqlCommand sqlCommand = new SqlCommand($"delete from [Trainee.Login] where Email = '{login.Email}'", connection);
                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                            Console.WriteLine($"---------- Profile Deletion successful -----------");
                            break;
                        }
                        catch (Exception ex) { Console.WriteLine($"Interruption occured !? {ex.Message}\nReturning to Main menu..."); break; }
                    }
                    else
                    {
                        if (i - 1 >= 0)
                        {
                            Console.WriteLine($"---Invalid input : {--i} attempt(s) left ---");
                            //Console.Write("Enter the password again : ");
                        }
                        else
                        {
                            Console.WriteLine("--- Invalid Access ---");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("^^** Hurray, You are staying **^^\nReturning to Main menu...");
            }
        }


        //-----------------------------------------------------------------------------------------------------------

        public void DeleteTDetails(TDetails details) 
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"delete from [Trainee.Trainer_details] where TID = {details.Id}; update [Trainee.Login] set TDstatus = 0, CDstatus = 0, EDUstatus = 0, EDstatus = 0, SDstatus = 0 where Email = '{details.email}'";
            using SqlCommand sqlCommand = new SqlCommand(query,connection);
            try 
            { 
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"---- INFO : {details.Fname} {details.Lname}'s Complete Trainer details deleted ^_^ ----");
            }
            catch(Exception) { Console.WriteLine("--- Handled Exception : Deletion of 'Trainer details' failed ---"); }
        }

        public void DeleteCDetails(TDetails details)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"delete from [Trainee.Contact_details] where TID = {details.Id}; update [Trainee.Login] set CDstatus = 0 where Email = '{details.email}';";
            using SqlCommand sqlCommand = new SqlCommand(query, connection);
            try 
            { 
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"---- INFO : {details.Fname} {details.Lname}'s Contact details deleted ^_^ ----");
            }
            catch (Exception) { Console.WriteLine("--- Handled Exception : Deletion of 'Contact details' failed ---"); }
        }

        public void DeleteEDUdetails(TDetails details)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"delete from [Trainee.Education] where TID = {details.Id}; update [Trainee.Login] set EDUstatus = 0 where Email = '{details.email}';";
            using SqlCommand sqlCommand = new SqlCommand(query, connection);
            try 
            { 
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"---- INFO : {details.Fname} {details.Lname}'s Education details deleted ^_^ ----");
            }
            catch (Exception) { Console.WriteLine("--- Handled Exception : Deletion of 'Education details' failed ---"); }
        }

        public void DeleteEDetails(TDetails details)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"delete from [Trainee.Experience] where TID = {details.Id}; update [Trainee.Login] set EDstatus = 0 where Email = '{details.email}';";
            using SqlCommand sqlCommand = new SqlCommand(query, connection);
            try 
            { 
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"---- INFO : {details.Fname} {details.Lname}'s Experience details deleted ^_^ ----");
            }
            catch (Exception) { Console.WriteLine("--- Handled Exception : Deletion of 'Experience details' failed ---"); }
        }

        public void DeleteSDetails(TDetails details)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"delete from [Trainee.Skills] where TID = {details.Id}; update [Trainee.Login] set SDstatus = 0 where Email = '{details.email}';";
            using SqlCommand sqlCommand = new SqlCommand(query, connection);
            try 
            { 
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"---- INFO : {details.Fname} {details.Lname}'s Skill(s) deleted ^_^ ----");
            }
            catch (Exception) { Console.WriteLine("--- Handled Exception : Deletion of 'Skill(s)' failed ---"); }
        }

    }
}
