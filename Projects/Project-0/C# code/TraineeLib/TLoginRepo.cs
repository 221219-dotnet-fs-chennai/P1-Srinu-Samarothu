using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Trainer;
using TraineeLib;
using Serilog;

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

        public static TLogin FetchEmail(string mail)
        {
            TLogin login = new TLogin();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = $"select Email, Password, TDstatus, CDstatus, EDUstatus, EDstatus, SDstatus from [Trainee.Login] where Email = @mail";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@mail", mail);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    Log.Information("Got TLogin object from FetchEmail(string mail)");
                    reader.Read();
                    login.Email = reader.GetString(0);
                    login.Password = reader.GetString(1);
                    if (reader.GetInt32(2) == 1) { login.TDstatus = "  -  Filled"; }
                    else { login.TDstatus = ""; }
                    if (reader.GetInt32(3) == 1) { login.CDstatus = "  -  Filled"; }
                    else { login.CDstatus = ""; }
                    if (reader.GetInt32(4) == 1) { login.EDUstatus = "  -  Filled"; }
                    else { login.EDUstatus = ""; }
                    if (reader.GetInt32(5) == 1) { login.EDstatus = "  -  Filled"; }
                    else { login.EDstatus = ""; }
                    if (reader.GetInt32(6) == 1) { login.SDstatus = "  -  Filled"; }
                    else { login.SDstatus = ""; }
                    //Console.WriteLine(login.Email + "    " + login.Password);
                }
                catch (Exception)
                {
                    Console.WriteLine();
                }
            }
            return login;
        }

        // ---------------------------------------------------------------------------------------------------------


        public TLogin NewTrainee(string mail)
        {
            TLogin login = new TLogin();
            RegexValidation validate = new RegexValidation();
            Console.Write($"\nYour Email id : {mail}");
            login.Email = mail;
            Console.WriteLine("\n# Rules to create password :");
            Console.WriteLine("1. Must '8 characters' long");
            Console.WriteLine("2. Must include atleast an 'Uppercase' alphabet");
            Console.WriteLine("3. Must contain atleast a digit");
            string password;
            Log.Information("Asking for new password ");
            while (true)
            {
                Console.Write("\nCreate a new password : ");
                password = Console.ReadLine();
                if(validate.ValidatePassword(password))
                {
                    login.Password = password;
                    break;
                }
                else
                {
                    Console.WriteLine("*** ALERT :- Invalid 'Password', check wheather you entered a 10-digit mobile number :] ***");
                }
            }
            while (true)
            {
                Console.Write("Confirm your password : ");
                password = Console.ReadLine();
                if (login.Password == password) break;
                else Console.WriteLine("\nERR : Passwords are not matching");
            }
            Log.Information("New password is added");
            return login;
        }


        //------------------------------------------------------------------------------------------------

        public TLogin fetchDetails(string obj)
        {
            throw new NotImplementedException();
        }

        //---------------------------------------------------------------------------------------------------------------------

    }
}





