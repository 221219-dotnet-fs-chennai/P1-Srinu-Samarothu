using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace TraineeLib
{
    internal class Update 
    {
        private static string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        readonly TDetails details = new TDetails();
        

        public Update(TDetails detailsT) { details = detailsT; }


        public bool Update123(string table)
        {
            Console.Write("--> Enter how many fields you want to change : ");
            int numOfFields = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, string> fieldValues = new Dictionary<string, string>();
            Console.WriteLine("\n** Note : Enter the column names as excatly they are in the above options **");
            string? col, val;
            for (int i = 1; i <= numOfFields; i++)
            {
                Console.Write($"\nEnter the column {i} name : ");
                col = Console.ReadLine();
                Console.Write($"Enter the new value you want to update in {col} column : ");
                val = Console.ReadLine();
                fieldValues.Add(col, val);
            }
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int count = 0;
            string? sql;
            foreach (KeyValuePair<string, string> pair in fieldValues)
            {
                if (Int32.TryParse(pair.Value, out int x))
                {
                    sql = $"update [{table}] set {pair.Key} = {x} where TID = {details.Id}";
                }
                else if (Int64.TryParse(pair.Value, out long t))
                {
                    sql = $"update [{table}] set {pair.Key} = {x} where TID = {details.Id}";
                }
                else
                {
                    sql = $"update [{table}] set {pair.Key} = '{pair.Value}' where TID = {details.Id}";
                }
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
                    count += command.ExecuteNonQuery();

                }
                catch (Exception) { Console.WriteLine($"Updation of Details failed at column \"{pair.Key}\""); }
            }
            if (count == numOfFields)
            {
                Console.WriteLine($"{count} value(s) updated");
                return false;
            }
            else
            {
                Console.WriteLine($"--> Partial updation took place");
                Console.WriteLine("Try Again");
                Console.Write("Enter your choice : ");
                return true;
            }
        }


// ------------------------------------------------------------------------------------------------------------------------------
        public bool Update4(string table)
        {
            Console.Write("--> Enter how many fields you want to change : ");
            int numOfFields = Convert.ToInt32(Console.ReadLine());
            //List<string> oldValues = new List<string>();
            TExperienceRepo repo = new TExperienceRepo();
            Dictionary<string, string> fieldValues = new Dictionary<string, string>();
            Console.WriteLine("\n** Note : Enter the column names as excatly they are in the above options **");
            string? col, val, exp;
            var experiences = repo.fetchDetails(details);
            Console.WriteLine("-- Below are the Experience details you've entered earlier --");
            Console.WriteLine(":----------------------------------------------------------------------:");
            foreach (var experience in experiences )
            {
                Console.WriteLine(experience.ToString());
                Console.WriteLine(":----------------------------------------------------------------------:");
            }
            for (int i = 1; i <= numOfFields; i++)
            {
                Console.Write($"\nEnter the column {i} name : ");
                col = Console.ReadLine();
                Console.Write($"Enter the new value you want to update in {col} column : ");
                val = Console.ReadLine();
                fieldValues.Add(col, val);
            }
            Console.Write($"\nEnter the Company value on which you want to perform updations : ");
            exp = Console.ReadLine();
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int count = 0;
            string? sql;
            foreach (KeyValuePair<string, string> pair in fieldValues)
            {
                if (Int32.TryParse(pair.Value, out int x))
                {
                    sql = $"update [{table}] set {pair.Key} = {x} where TID = {details.Id} and Company = '{exp}'";
                }
                else
                {
                    if (pair.Key == "Company")
                    {
                        sql = $"update [{table}] set {pair.Key} = '{pair.Value}' where TID = {details.Id} and Company = '{exp}'";
                        exp = pair.Value;
                    }
                    else
                    {
                        sql = $"update [{table}] set {pair.Key} = '{pair.Value}' where TID = {details.Id} and Company = '{exp}'";
                    }
                }
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
                    count += command.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine($"Updation of Details failed at column {count}. \"{pair.Key}\""); }
            }
            if (count == numOfFields)
            {
                Console.WriteLine($"{count} value(s) updated");
                return false;
            }
            else
            {
                Console.WriteLine($"--> Partial updation took place");
                Console.WriteLine("Try Again");
                Console.Write("Enter your choice : ");
                return true;
            }
        }



// --------------------------------------------------------------------------------------------------------------------------------

        public bool Update5(string table)
        {
            
            Console.Write("--> Enter how many fields you want to change : ");
            int numOfFields = Convert.ToInt32(Console.ReadLine());
            //List<string> oldValues = new List<string>();
            TSkillsRepo repo = new TSkillsRepo();
            Dictionary<string, string> fieldValues = new Dictionary<string, string>();
            Console.WriteLine("\n** Note : Enter the column names as excatly they are in the above options **");
            string? col, val, sk;
            Console.WriteLine("-- Below are the Skill(S) details you've entered earlier --");
            Console.WriteLine(":----------------------------------------------------------------------:");
            var skills = repo.fetchDetails(details);
            foreach(var skill in skills ) 
            { 
                Console.WriteLine(skill.ToString());
                Console.WriteLine(":----------------------------------------------------------------------:");
            }
            for (int i = 1; i < numOfFields; i++)
            {
                Console.Write($"\nEnter the column {i} name : ");
                col = Console.ReadLine();
                Console.Write($"Enter the new value you want to update in {col} column : ");
                val = Console.ReadLine();
                fieldValues.Add(col, val);
            }
            Console.Write($"Enter the Skill on which you want to perform updates : ");
            sk = Console.ReadLine();
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int count = 0;
            string? sql;
            foreach (KeyValuePair<string, string> pair in fieldValues)
            {
                if (Int32.TryParse(pair.Value, out int x))
                {
                    sql = $"update [{table}] set {pair.Key} = {x} where TID = {details.Id} and Skill = '{sk}'";
                }
                else
                {
                    sql = $"update [{table}] set {pair.Key} = '{pair.Value}' where TID = {details.Id} and Skill = '{sk}'";
                }
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
                    count += command.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine($"Updation of Details failed at column {count}. \"{pair.Key}\""); }
            }
            if (count == numOfFields)
            {
                Console.WriteLine($"{count} value(s) updated");
                return false;
            }
            else
            {
                Console.WriteLine($"--> Partial updation took place");
                Console.WriteLine("Try Again");
                Console.Write("Enter your choice : ");
                return true;
            }
        }


    }
}
