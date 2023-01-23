using Trainer;
using TraineeUI;
using TraineeLib;
using Serilog; 

namespace UI{
    public class Program
    {
        public static void Main()
        {
            string path = @"C:\Revature\P1-Srinu-Samarothu\Projects\Project-0\C# code\log.txt";
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            Log.Logger = new LoggerConfiguration()
                             .WriteTo.File(path, rollingInterval : RollingInterval.Day, rollOnFileSizeLimit: true)
                             .CreateLogger();
            Log.Information("Console application started...");
            IRepo<TLogin, string> repo = new TLoginRepo();
            TLogin login = new TLogin();
            IRepo<TDetails, TLogin> detailsRepo = new TDetailsRepo();
            TDetails details = new TDetails();

            Menu menu = new Menu();
            login = Menu.SignUp();
            Log.Information("Succesful signup");
            Console.WriteLine("\n\n---- ?! Have you entered your details before !? ----");
            Console.WriteLine("'YES' : Entered the details");
            Console.WriteLine("'NO' : Want to add now");
            Console.Write("\nEnter your choice here : ");
            bool check = true;
            while (check) {
                string x = Console.ReadLine();
                switch (x)
                {
                    case "YES":
                        Log.Information("User chose YES, To carry on with GET, DELETE and UPDATE operations");
                        details = detailsRepo.fetchDetails(login);
                        Console.WriteLine($"\n*** =>  Hey \"{details.Fname} {details.Lname}\" welcome back  <= *** ");
                        menu.Display(login);
                        check = false;
                        break;
                    case "NO":
                        SetAllDetails set = new SetAllDetails();
                        set.Display(login);
                        menu.Display(login);
                        check = false;
                        break;
                    default:
                        Console.WriteLine("\nERR : Invalid input");
                        Console.Write("\nEnter your choice again : ");
                        break;
                }
            }
            //details = detailsRepo.fetchDetails(login);
            //menu.Display(login);
        }
    }
}