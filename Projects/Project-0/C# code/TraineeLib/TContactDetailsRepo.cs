using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeLib;

namespace Trainer
{
    public class TContactDetailsRepo : IRepo<TContactDetails, TDetails>
    {
        private static readonly string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        public TContactDetails AddTrainee(TContactDetails contactDetails)
        {
            string query = $"insert into [Trainee.Contact_details] values(@num, @address, @city, @state, @zipcode, @id, @mail); update [Trainee.Login] set CDstatus = 1 where Email = (select Mail from [Trainee.Trainer_details] T where T.TID =  {contactDetails.Tid});";
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
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            Console.WriteLine("------ ** Contact details added ** ------");
            return contactDetails;
            //throw new NotImplementedException();

        }


        public TContactDetails GetDetails(TDetails details)
        {
            TContactDetails contactDetails = new TContactDetails();
            RegexValidation validate = new RegexValidation();
            Console.Clear();
            Console.WriteLine("\n----- => Enter Your Contact Details <= -----");
            while (true)
            {
                Console.Write("Mobile number : ");
                long number = Convert.ToInt64(Console.ReadLine());
                if(validate.ValidateNumber(number.ToString()))
                {
                    contactDetails.Num = number;
                    break;
                }
                else
                {
                    Console.WriteLine("*** ALERT :- Invalid 'Mobile number', check wheather you entered a 10-digit mobile number :] ***");
                }
            }
            Console.Write("Address Lane : ");
            contactDetails.Address = Console.ReadLine();
            Console.Write("City : ");
            contactDetails.City = Console.ReadLine();
            Console.Write("State : ");
            contactDetails.State = Console.ReadLine();
            while (true)
            {
                Console.Write("Zipcode : ");
                string? zipcode = Console.ReadLine();
                if(validate.ValidateZipcode(zipcode))
                {
                    contactDetails.Zipcode = zipcode;
                    break;
                }
                else
                {
                    Console.WriteLine("*** ALERT :- Invalid 'Zipcode', check wheather you entered 6-digit zipcode :] ***");
                }
            }
            try
            {
                contactDetails.Email = details.email;
                contactDetails.Tid = details.Id;
            }
            catch(Exception) 
            {
                Console.WriteLine($"^^ ** {details.Fname} {details.Lname}, you've entered contact details before ** ^^");
            }
            return AddTrainee(contactDetails);

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
                try
                {
                    reader.Read();
                    contactDetails.Num = Convert.ToInt64(reader["Mobile_Number"]);
                    contactDetails.Address = Convert.ToString(reader["Address_Lane"]);
                    contactDetails.City = Convert.ToString(reader["City"]);
                    contactDetails.State = Convert.ToString(reader["State"]);
                    contactDetails.Zipcode = Convert.ToString(reader["Zipcode"]);
                    contactDetails.Tid = Convert.ToInt32(reader["TID"]);
                    contactDetails.Email = Convert.ToString(reader["Mail_id"]);
                    if (contactDetails.Num > 99)
                        Console.WriteLine(contactDetails.ToString());
                }
                catch(Exception)
                {
                    //Console.Clear();
                    Console.WriteLine("\n--- ** INFO : No Contact Details are Available ** ---");
                }
            }
            return contactDetails;
            //throw new NotImplementedException();
        }
    }
}
