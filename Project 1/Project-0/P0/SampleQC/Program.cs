using System;
using System.Data.Common;
using System.Data.SqlTypes;
//using System.Text.SqlClient;

namespace Sample
{
    public class Example
    {
        public static void Add(string name, int age)
        {
            string connectionString;
            string command = "insert into Table1 values(@name, @age)";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(command, con);
            sqlCommand.Parameter.AddWuthValue("@name", name);
            sqlCommand.Parameter.AddWithValue("@age", age);
            sqlCommand.ExecuteNonQuery();
        }
    }
}