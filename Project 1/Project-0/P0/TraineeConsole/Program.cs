using Trainer;
using TraineeUI;
using TraineeLib;

namespace UI{
    public class Program
    {
        public static void Main()
        {
            IRepo<TLogin, string> repo = new TLoginRepo();
            TLogin login = new TLogin();
            IRepo<TDetails, TLogin> detailsRepo = new TDetailsRepo();
            TDetails details = new TDetails();
            //List<TDetails> detailsList = new List<TDetails>();
            //Validate valid = new Validate();

            Menu menu = new Menu();
            login = Menu.SignUp();
            details = detailsRepo.fetchDetails(login);
            menu.Display(login);
        }
    }
}