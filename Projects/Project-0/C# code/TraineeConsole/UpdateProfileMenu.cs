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
            UPDATE:
            Console.Clear();
            Console.WriteLine("------------ *** UPDATE YOUR PROFILE *** ------------");
            Console.WriteLine("\n---- ** 'TD' - FIELDS OF \"TRAINER\" DETAILS ** ----");
            Console.WriteLine("* First_name \n* Last_name\n* Gender \n* DOB");
            Console.WriteLine("\n---- ** 'CD' - FIELDS OF \"CONTACT\" DETAILS ** ----");
            Console.WriteLine("* Mobile_number \n* Zipcode\n* Address_lane \n* City \n* State");
            Console.WriteLine("\n---- ** 'EDU' - FIELDS OF \"EDUCATION\" DETAILS ** ----");
            Console.WriteLine("* UG_college \n* UG_percentage \n* UG_passout_year\n* PG_college \n* PG_percentage \n* PG_passout_year");
            Console.WriteLine("\n---- ** 'ED' - FIELDS OF \"EXPERIENCE\" DETAILS ** ----");
            Console.WriteLine("* Company \n* Designation\n* Overall_Experience");
            Console.WriteLine("\n---- ** 'SD' - FIELDS OF \"SKILL\" DETAILS ** ----");
            Console.WriteLine("* Skill \n* Proficiency");
            Console.WriteLine("\n---- ** '<-'  GO BACK ** ----");
            Console.Write("\nEnter the option Keyword you wish to update : ");
            Update update = new Update(details);
            string choice = Console.ReadLine();
            Console.Clear();
            //ch = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case "TD":
                    Console.WriteLine("\n---- ** FIELDS OF \"TRAINER\" DETAILS ** ----");
                    Console.WriteLine("* First_name\n* Last_name\n* Gender\n* DOB");
                    update.Update123("Trainee.Trainer_details");
                    Console.Write("Do you want to update more details ? Press enter ... ");
                    Console.ReadLine();
                    goto UPDATE;
                case "CD":
                    Console.WriteLine("\n---- ** FIELDS OF \"CONTACT\" DETAILS ** ----");
                    Console.WriteLine("* Mobile_number\n* Zipcode\n* Address_lane\n* City\n* State");
                    update.Update123("Trainee.Contact_details");
                    Console.Write("Do you want to update more details ? Press enter ... ");
                    Console.ReadLine();
                    goto UPDATE;
                case "EDU":
                    Console.WriteLine("\n---- ** FIELDS OF \"EDUCATION\" DETAILS ** ----");
                    Console.WriteLine("* UG_college\n* UG_percentage\n* UG_passout_year\n* PG_college\n* PG_percentage\n* PG_passout_year");
                    update.Update123("Trainee.Education");
                    Console.Write("Do you want to update more details ? Press enter ... ");
                    Console.ReadLine();
                    goto UPDATE;
                case "ED":
                    Console.WriteLine("\n---- ** FIELDS OF \"EXPERIENCE\" DETAILS ** ----");
                    Console.WriteLine("* Company\n* Designation\n* Overall_Experience");
                    update.Update4("Trainee.Experience");
                    Console.Write("Do you want to update more details ? Press enter ... ");
                    Console.ReadLine();
                    goto UPDATE;
                case "SD":
                    Console.WriteLine("\n---- ** FIELDS OF \"SKILL\" DETAILS ** ----\n* Skill\n* Proficiency");
                    update.Update5("Trainee.Skills");
                    Console.Write("Do you want to update more details ? Press enter ... ");
                    Console.ReadLine();
                    goto UPDATE;
                case "<-":
                    Console.WriteLine("Want to go back ? Then press \'Enter\'");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("-- ALERT : Invalid input --");
                    Console.Write("Press enter to return to UPDATE menu... ");
                    Console.ReadLine();
                    goto UPDATE;
            }
        }

    }
}
