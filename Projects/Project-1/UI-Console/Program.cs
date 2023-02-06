using DF = DataFluentApi.Entities;
using Models;
using DataFluentApi;
using Business_Logic;


namespace UI
{

    public class Program
    {

        public static void Main(string[] args)
        {
            //ILogic logic = new TrainerLogic(new DF.TraineeDbContext());

            TraineeLogin modelLogin = new TraineeLogin();

            //DF.TraineeLogin login = new DF.TraineeLogin();



            // ----------------- Add deatils login --------------------

            Console.Write("Enter your unique mail : ");
            string? mail = Console.ReadLine();

            //modelLogin.Email = Console.ReadLine();
            //Console.Write("Enter your password : ");
            //modelLogin.Password = Console.ReadLine();

            /*
            modelLogin.Tdstatus = 0;
            modelLogin.Cdstatus = 0;
            modelLogin.Edustatus = 0;
            modelLogin.Edstatus = 0;
            modelLogin.Sdstatus = 0;

            logic.AddLogin(modelLogin); 

            */
            /*
            // --------------------- Update details login ------------------

            List<string> fields = new List<string>();

            Console.WriteLine("\n[1]. Tdstatus" +
                "\n[2]. Cdstatus" +
                "\n[3]. Edustatus" +
                "\n[4]. Edstatus" +
                "\n[5]. Sdstatus");

            while (true)
            {
                Console.Write("Enter your option : ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter TD : ");
                        modelLogin.Tdstatus = Convert.ToInt32(Console.ReadLine());
                        fields.Add("Tdstatus");
                        break;
                    case "2":
                        Console.Write("Enter CD : ");
                        modelLogin.Cdstatus = Convert.ToInt32(Console.ReadLine());
                        fields.Add("Cdstatus");
                        break;
                    case "3":
                        Console.Write("Enter EDU : ");
                        modelLogin.Edustatus = Convert.ToInt32(Console.ReadLine());
                        fields.Add("Edustatus");
                        break;
                    case "4":
                        Console.Write("Enter ED : ");
                        modelLogin.Edstatus = Convert.ToInt32(Console.ReadLine());
                        fields.Add("Edstatus");
                        break;
                    case "5":
                        Console.Write("Enter SD : ");
                        modelLogin.Sdstatus = Convert.ToInt32(Console.ReadLine());
                        fields.Add("Sdstatus");
                        break;
                }
                Console.WriteLine("Want to update more ?  : ");
                string? ch = Console.ReadLine();
                if (ch == "N" || ch == "n") break;
            }*/

            //TrainerLogic logic1 = new TrainerLogic(new DF.TraineeDbContext());

            //logic1.DeleteLogin(mail);

            //logic1.UpdateLogin(modelLogin, fields);



            // --------------------- Get details login --------------------

            //var details = logic.GetLoginDetails();
           //// foreach (var detail in details)
            {
               // Console.WriteLine(detail.ToString());
            }
        }
    }
}
