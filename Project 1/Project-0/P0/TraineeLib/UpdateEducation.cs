using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeLib
{
    public class UpdateEducation
    {
        private string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        //readonly TDetails details = new TDetails();
        int _id;
        public UpdateEducation(int id) { _id = id; }
        public void Display()
        {
            Console.WriteLine("---------- Update your \"EDUCATION DETAILS\" here ----------");
            Console.WriteLine("Fields of Details :");
            Console.WriteLine("UG_college");
            Console.WriteLine("UG_percentage");
            Console.WriteLine("UG_passout_year");
            Console.WriteLine("PG_college");
            Console.WriteLine("PG_percentage");
            Console.WriteLine("PG_passout_year");
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
            Update(fieldValues);
        }
        public void Update(Dictionary<string, string> fieldValues)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int count = 0;
            string? sql;
            Console.WriteLine(_id);
            foreach (KeyValuePair<string, string> pair in fieldValues)
            {
                if (Int32.TryParse(pair.Value, out int x))
                {
                    sql = $"update [Trainee.Education] set {pair.Key} = {x} where Trainer_Id = {_id}";
                }
                else
                {
                    sql = $"update [Trainee.Education] set {pair.Key} = '{pair.Value}' where Trainer_Id = {_id}";
                }
                SqlCommand command = new SqlCommand(sql, connection);
                Console.WriteLine(sql);
                try
                {
                    count += command.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine($"Updation of Details failed at column \"{pair.Key}\""); }
            }
            Console.WriteLine($"{count} values are updated");
        }
    }
}
