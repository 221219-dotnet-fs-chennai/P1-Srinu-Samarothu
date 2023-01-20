using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace TraineeLib
{
    public class UpdateProfileMenu
    {
        private string connectionString = $"Server=Cnu;Database=TraineeDB;Trusted_Connection=True;";
        readonly TDetails details = new TDetails();
        int _id;
        public UpdateProfileMenu(TDetails detailsT) { details = detailsT; }
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("------------ *** UPDATE YOUR PROFILE *** ------------");
            Console.WriteLine("\n---- ** 1. FIELDS OF \"TRAINER\" DETAILS ** ----");
            Console.WriteLine("* First_name \n* Last_name\n* Gender \n* DOB");
            Console.WriteLine("\n---- ** 2. FIELDS OF \"CONTACT\" DETAILS ** ----");
            Console.WriteLine("* Mobile_number \n* Zipcode\n* Address_lane \n* City \n* State");
            Console.WriteLine("\n---- ** 3. FIELDS OF \"EDUCATION\" DETAILS ** ----");
            Console.WriteLine("* UG_college \n* UG_percentage \n* UG_passout_year\n* PG_college \n* PG_percentage \n* PG_passout_year");
            Console.WriteLine("\n---- ** 4. FIELDS OF \"EXPERIENCE\" DETAILS ** ----");
            Console.WriteLine("* Company \n* Designation\n* Overall_Experience");
            Console.WriteLine("\n---- ** 5. FIELDS OF \"SKILL\" DETAILS ** ----");
            Console.WriteLine("* Skill \n* Proficiency");
            Console.WriteLine("\n---- ** 6. EXIT ** ----");
            Console.Write("\nEnter the option number you wish to update : ");
            Update update = new Update(details);
            bool okay = true;
            while(okay)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                //ch = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n---- ** FIELDS OF \"TRAINER\" DETAILS ** ----");
                        Console.WriteLine("* First_name\n* Last_name\n* Gender\n* DOB");
                        update.Update123("Trainee.Trainer_details");
                        Console.WriteLine("Do you want to update more details ?");
                        Console.Write("\nEnter the option number you wish to update : ");
                        break;
                    case 2:
                        Console.WriteLine("\n---- ** FIELDS OF \"CONTACT\" DETAILS ** ----");
                        Console.WriteLine("* Mobile_number\n* Zipcode\n* Address_lane\n* City\n* State");
                        update.Update123("Trainee.Contact_details");
                        Console.WriteLine("Do you want to update more details ?");
                        Console.Write("\nEnter the option number you wish to update : ");
                        break;
                    case 3:
                        Console.WriteLine("\n---- ** FIELDS OF \"EDUCATION\" DETAILS ** ----");
                        Console.WriteLine("* UG_college\n* UG_percentage\n* UG_passout_year\n* PG_college\n* PG_percentage\n* PG_passout_year");
                        update.Update123("Trainee.Education");
                        Console.WriteLine("Do you want to update more details ?");
                        Console.Write("\nEnter the option number you wish to update : ");
                        break;
                    case 4:
                        Console.WriteLine("\n---- ** FIELDS OF \"EXPERIENCE\" DETAILS ** ----");
                        Console.WriteLine("* Company\n* Designation\n* Overall_Experience");
                        update.Update4("Trainee.Experience");
                        Console.WriteLine("Do you want to update more details ?");
                        Console.Write("\nEnter the option number you wish to update : ");
                        break;
                    case 5:
                        Console.WriteLine("\n---- ** FIELDS OF \"SKILL\" DETAILS ** ----");
                        Console.WriteLine("* Skill\n* Proficiency");
                        update.Update5("Trainee.Skills");
                        Console.WriteLine("Do you want to update more details ?");
                        Console.Write("\nEnter the option number you wish to update : ");
                        break;
                    case 6:
                        Console.WriteLine("Want to go back ? Then press \'Enter\'");
                        Console.ReadLine();
                        okay = false;
                        break;
                    default:
                        Console.WriteLine("-- ALERT : Invalid input --");
                        Console.Write("Enter your choice again : ");
                        break;
                }

            }
        }

        //List<string> GetAllSkills(TDetails details)
        //{
        //    string query = $"select Skill from "
        //    using SqlConnection connection = new SqlConnection();
        //    connection.Open();
        //    using SqlCommand command = new SqlCommand("")
        //}
       
    }
}
