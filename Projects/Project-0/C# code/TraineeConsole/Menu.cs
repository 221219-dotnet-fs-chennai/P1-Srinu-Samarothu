using Serilog;
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
            RegexValidation validate = new RegexValidation();
            TLogin login = new ();
            Console.Clear();
            Log.Information("Entered 'SignUp' page");
            Console.WriteLine("\t\t---------- *** Welcome :) *** ----------");
            string mail;
            while (true)
            {
                Console.Write("\nEnter your Email id : ");
                mail = Console.ReadLine();
                if(validate.ValidateEmail(mail)) { break; }
                else
                {
                    Console.WriteLine("*** ALERT :- Invalid 'Email', check wheather you entered a proper mail id  :] ***\nExample mail : xyz@gmail.com");
                }
            }
            login = TLoginRepo.FetchEmail(mail);
            Log.Information("Checking wheather input mail exists or not");
            if (valid.ValidateEmail(login, mail))
            {
                Log.Information("Email is validated");
                valid.ValidatePassword(login);
                Log.Information("Password is validated");
                //TDetails details = drepo.fetchDetails(login);
                //Console.WriteLine($"\n*** =>  Hey {details.Fname} {details.Lname} welcome back  <= *** ");
                status = "Login";
                Log.Information("Successful login");
                return login;
            }
            else
            {
                Log.Information("New user arraived");
                Console.WriteLine("--- *** INFO : IT looks like you are new here, Get youself registered *** ---");
                TLogin elogin = new TLogin();
                while (true)
                {
                    YN:
                    Console.Write("\nWould you like to join us ('Y' or 'N') ? ");
                    char c = Convert.ToChar(Console.ReadLine());
                    switch (c) 
                    {
                        case 'Y':
                            elogin = repo.NewTrainee(mail);
                            repo.AddTrainee(elogin);
                            Log.Information($"New Trainer Added {mail}");
                            status = "Signin";
                            return elogin;
                        case 'N':
                            Environment.Exit(0);
                            goto BREAK;
                        default:
                            Console.WriteLine("\nInvalid input\n");
                            goto YN;
                   }
                BREAK:
                    break;
                }
                return elogin;
            }
        }

//---------------------------------------------------------------------------------------------------------------------
        public void Display(TLogin login)
        {
            login = TLoginRepo.FetchEmail(login.Email);
            string? keyWord;
            if (status == "Login") 
            {
                Log.Information("Entered into Login Menu");
            LOGIN:
                Console.Clear();
                Console.WriteLine("\n-- ** Please enter your choice using the Keywords on LHS ** --");
                Console.WriteLine("\n'ADD' : Add details");
                Console.WriteLine("'GET' : Get details");
                Console.WriteLine("'UPDATE' : Update details");
                Console.WriteLine("'DELETE' : Delete details");
                Console.WriteLine("'EXIT' : Exit");
                Console.Write("\nChoose and Enter a Keyword : ");
                keyWord = Console.ReadLine();
                GetAllDetails gad = new GetAllDetails(login);
                SetAllDetails set = new SetAllDetails();
                TDetailsRepo repo = new TDetailsRepo();
                switch (keyWord)
                {
                    case "ADD":
                        Log.Information("User adding some more details");
                        set.Display(login);
                        goto LOGIN;
                    case "GET":
                        Log.Information("Going into GET display menu");
                        gad.DisplayGET();
                        goto LOGIN;
                    case "UPDATE":
                        Log.Information("Going into UPDATE display menu");
                        gad.DisplayUPDATE();
                        goto LOGIN;
                    case "DELETE":
                        DeleteDetails delDetails = new DeleteDetails();
                        TDetails details = repo.fetchDetails(login);
                        delDetails.Display(details);
                        goto LOGIN;
                    case "EXIT":
                        Console.Clear();
                        Console.WriteLine("Closing your profile :)\n\n\t\t... *** Comeback Again *** ...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("ERR : Invalid Input \nClosing your profile...");
                        goto LOGIN;
                }
            }
            else if(status == "Signin")
            {
                Console.WriteLine("\n-- ** Hello Trainer, please enter your details ** --");
                SetAllDetails set = new SetAllDetails();
                set.Display(login);
            }
        }
    }
}
