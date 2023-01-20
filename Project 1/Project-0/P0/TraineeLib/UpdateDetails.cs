using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TraineeLib;

namespace Trainer
{
    public  class UpdateDetails 
    {
        private string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        //readonly TDetails details = new TDetails();
        int _id;
        public UpdateDetails(int id) { _id = id; }
        public void Display()
        {
            Console.WriteLine("---------- Update your \"TRAINER DETAILS\" here ----------");
            Console.WriteLine("Fields of Details :");
            Console.WriteLine("First_name");
            Console.WriteLine("Last_name");
            Console.WriteLine("Gender");
            Console.WriteLine("DOB");
            Console.Write("--> Enter how many fields you want to change : ");
            int numOfFields = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, string> fieldValues = new Dictionary<string, string>();
            Console.WriteLine("\n** Note : Enter the column names as excatly they are in the above options **");
            string? col, val;
            for(int i=1; i <= numOfFields; i++)
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
            string table = "Trainee.Trainer_details";
             foreach(KeyValuePair<string, string> pair in fieldValues) 
            {
                sql = $"update [{table}] set {pair.Key} = '{pair.Value}' where Trainer_Id = {_id}";
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
                    count += command.ExecuteNonQuery();
                }
                catch(Exception) { Console.WriteLine($"Updation of Details failed at column \"{pair.Key}\""); }
            }
            Console.WriteLine($"{count} values are updated");
        }
    }
}
