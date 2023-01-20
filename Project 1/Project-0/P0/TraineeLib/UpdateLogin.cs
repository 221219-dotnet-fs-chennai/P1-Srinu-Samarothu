using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;

namespace Trainer
{
   public class UpdateLogin
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public string Display(TLogin login)
        {
            string? choice;
            Console.WriteLine("Update your \"LOGIN\" details below..");
            Console.WriteLine("[1] Update password");
            Console.WriteLine("[2] Go back");
            Console.Write("Your choice : ");
            choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    UpdatePassword(login);
                    return "Menu";
                case "2":
                    return "Menu";
                default:
                    Console.WriteLine("Invalid choice");
                    return "Menu";

            }
        
        }
        private void UpdatePassword(TLogin login)
        {
            //TLoginRepo repo = new TLoginRepo();
            int count = 3;
            Console.Write("Enter your old password : ");
            while(count > 0)
            {
                if(login.Password == Console.ReadLine())   break;
                else
                {
                    Console.WriteLine("** ERR : Incorrect password ** ");
                    Console.WriteLine($"** WARNING : {count} attempts left ** ");
                    Console.Write("Re-enter your password :");
                }
                count--;
            }
            if(count > 0)
            {
                Console.Write("Enter new password : ");
                string? pwd;
                while (true)
                {
                    pwd = Console.ReadLine();
                    if (pwd == login.Password) break;
                    else
                    {
                        Console.WriteLine("--- Old password can not be your new password again ---");
                        Console.Write("Enter again : ");
                    }
                }
                string query = "update [Trainee.Login] set Password = @pwd where Email = @mail";
                using SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                using SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@pwd", pwd);
                command.Parameters.AddWithValue("@mail", login.Email);
                int row = command.ExecuteNonQuery();
                Console.WriteLine($"{row} row(s) affected");
                Console.WriteLine($"--- Password for {login.Email} has changed ---");
            }
            else
            {
                Console.WriteLine("** Failed to update your password **");
            }
        }
    }
}
