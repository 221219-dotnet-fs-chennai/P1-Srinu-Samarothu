using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeLib;
using Trainer;

namespace TraineeUI
{
    public class Menu
    {
        static string status;
        public static TLogin SignUp()
        {
            TLoginRepo repo = new TLoginRepo();
            Validate valid = new Validate();
            TDetailsRepo drepo = new TDetailsRepo();
            TLogin login = new ();
            Console.WriteLine("---------- *** Welcome :) *** ----------");
            Console.Write("\nEnter your Email id : ");
            string? mail = Console.ReadLine();
            login = valid.SearchEmail(mail);
            if (valid.ValidateEmail(login, mail))
            {
                valid.ValidatePassword(login);
                TDetails details = drepo.fetchDetails(login);
                Console.WriteLine($"\n*** =>  Hey {details.Fname} {details.Lname} welcome back  <= *** ");
                status = "Login";
                return login;
            }
            else
            {
                Console.WriteLine(" INFO : IT looks like you are new here, Get youself registered --->");
                var elogin = repo.NewTrainee(mail);
                repo.AddTrainee(elogin);
                status = "Signin";
                return elogin;
            }
        }

//---------------------------------------------------------------------------------------------------------------------
        public void Display(TLogin login)
        {
            string? keyWord;
            if (status == "Login") 
            {
                Console.WriteLine("-- ** Please enter your choice using the Keywords on LHS ** --");
                Console.WriteLine("'GET' : Get details");
                Console.WriteLine("'UPDATE' : Update details");
                Console.WriteLine("'DELETE' : Delete details");
                Console.WriteLine("'Exit' : Exit");
                Console.Write("\nChoose and Enter a Keyword : ");
                keyWord = Console.ReadLine();
                GetAllDetails gad = new GetAllDetails(login);
                switch (keyWord)
                {
                    case "GET":
                        gad.DisplayGET();
                        break;
                    case "UPDATE":
                        gad.DisplayUPDATE();
                        break;
                    case "DELETE":
                        DeleteProfile profile = new DeleteProfile();
                        profile.DeleteTrainer(login);
                        break;
                    case "EXIT":
                        Console.WriteLine("Press any key to Exit...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("ERR : Invalid Input \nClosing your profile...");
                        break;
                }
            }
            else if(status == "Signin")
            {
                Console.WriteLine("-- ** Please enter your choice using the Keywords on LHS ** --");
                Console.WriteLine("-- Please enter your values...");
                Console.Write("\nChoose and Enter a Keyword : ");
                keyWord = Console.ReadLine();
            }
        }
    }
}
