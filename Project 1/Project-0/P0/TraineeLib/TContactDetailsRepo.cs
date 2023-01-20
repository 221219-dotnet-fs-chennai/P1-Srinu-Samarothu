using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    public class TContactDetailsRepo : IRepo<TContactDetails, TDetails>
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public TContactDetails AddTrainee(TContactDetails contactDetails)
        {
            string query = "insert into [Trainee.Contact_details] values(@num, @address, @city, @state, @zipcode, @id, @mail)";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@num", contactDetails.Num);
            sqlCommand.Parameters.AddWithValue("@address", contactDetails.Address);
            sqlCommand.Parameters.AddWithValue("@city", contactDetails.City);
            sqlCommand.Parameters.AddWithValue("@state", contactDetails.State);
            sqlCommand.Parameters.AddWithValue("@zipcode", contactDetails.Zipcode);
            sqlCommand.Parameters.AddWithValue("@id", contactDetails.Tid);
            sqlCommand.Parameters.AddWithValue("@mail", contactDetails.Email);
            int rows = sqlCommand.ExecuteNonQuery();
            return contactDetails;
            //throw new NotImplementedException();

        }


        public TContactDetails GetDetails(TDetails details)
        {
            TContactDetails contactDetails = new TContactDetails();
            Console.WriteLine("Enter your Contact details below...");
            Console.Write("Mobile number : ");
            contactDetails.Num = Convert.ToInt64(Console.ReadLine());
            Console.Write("Address Lane : ");
            contactDetails.Address = Console.ReadLine();
            Console.Write("City : ");
            contactDetails.City = Console.ReadLine();
            Console.Write("State : ");
            contactDetails.State = Console.ReadLine();
            Console.Write("Zipcode : ");
            contactDetails.Zipcode = Console.ReadLine();
            contactDetails.Email = details.email;
            contactDetails.Tid = details.Id;
            return contactDetails;

        }




        public TContactDetails fetchDetails(TDetails details)
        {
            TContactDetails contactDetails = new TContactDetails();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = $"select Mobile_Number, Address_Lane, City, State, Zipcode, TID, Mail_id from [Trainee.Contact_details] where TID = @id";
                using SqlCommand sqlCommand = new SqlCommand(command, con);
                sqlCommand.Parameters.AddWithValue("@id", details.Id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                contactDetails.Num = Convert.ToInt64(reader["Mobile_Number"]);
                contactDetails.Address = Convert.ToString(reader["Address_Lane"]);
                contactDetails.City = Convert.ToString(reader["City"]);
                contactDetails.State = Convert.ToString(reader["State"]);
                contactDetails.Zipcode = Convert.ToString(reader["Zipcode"]);
                contactDetails.Tid = Convert.ToInt32(reader["TID"]);
                contactDetails.Email = Convert.ToString(reader["Mail_id"]);
            }
            return contactDetails;
            //throw new NotImplementedException();
        }
    }
}
