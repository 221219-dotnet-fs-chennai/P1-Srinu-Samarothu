using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeLib
{
    public class UpdateExperience 
    {
        private static string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        //readonly TDetails details = new TDetails();
        static int _id;
        public UpdateExperience(int id) { _id = id; }
        //public void Display()
        //{
        //    Console.WriteLine("---------- Update your \"EXPERIENCE\" DETAILS here ----------");
        //    Console.WriteLine("Fields of Details :");
        //    Console.WriteLine("Company");
        //    Console.WriteLine("Designation");
        //    Console.WriteLine("Experience");
        //    Console.Write("--> Enter how many fields you want to change : ");
        //    int numOfFields = Convert.ToInt32(Console.ReadLine());
        //    List<string> oldValues = new List<string>();
        //    Dictionary<string, string> fieldValues = new Dictionary<string, string>();
        //    Console.WriteLine("\n** Note : Enter the column names as excatly they are in the above options **");
        //    string? col, val;
        //    for (int i = 1; i < numOfFields; i++)
        //    {
        //        Console.Write($"\nEnter the column {i} name : ");
        //        col = Console.ReadLine();
        //        Console.Write($"Enter the old value that you want to change in {col} column : ");
        //        oldValues.Add(Console.ReadLine());
        //        Console.Write($"Enter the new value you want to update in {col} column : ");
        //        val = Console.ReadLine();
        //        fieldValues.Add(col, val);
        //    }
        //    Update(fieldValues, oldValues);
        //}
        public bool Update(string table)
        {
            Console.Write("--> Enter how many fields you want to change : ");
            int numOfFields = Convert.ToInt32(Console.ReadLine());
            List<string> oldValues = new List<string>();
            Dictionary<string, string> fieldValues = new Dictionary<string, string>();
            Console.WriteLine("\n** Note : Enter the column names as excatly they are in the above options **");
            string? col, val;
            for (int i = 1; i < numOfFields; i++)
            {
                Console.Write($"\nEnter the column {i} name : ");
                col = Console.ReadLine();
                Console.Write($"Enter the old value that you want to change in {col} column : ");
                oldValues.Add(Console.ReadLine());
                Console.Write($"Enter the new value you want to update in {col} column : ");
                val = Console.ReadLine();
                fieldValues.Add(col, val);
            }
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int count = 0;
            string? sql;
            Console.WriteLine(_id);
            var inputValues = fieldValues.Zip(oldValues, (d, l) => new { dictionary = d, list = l });
            foreach (var input in inputValues)
            {
                if (Int32.TryParse(input.dictionary.Value, out int x))
                {
                    sql = $"update [{table}] set {input.dictionary.Key} = {x} where Trainer_Id = {_id} and {input.dictionary.Key} = {input.list}";
                }
                else
                {
                    sql = $"update [{table}] set {input.dictionary.Key} = '{input.dictionary.Value}' where Trainer_Id = {_id} and {input.dictionary.Key} = \'{input.list}\'";
                }
                SqlCommand command = new SqlCommand(sql, connection);
                Console.WriteLine(sql);
                try
                {
                    count += command.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine($"Updation of Details failed at column {count}. \"{input.dictionary.Key}\""); }
            }
            if (count == numOfFields)
            {
                Console.WriteLine($"{count} values are updated");
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
