using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace TraineeLib
{
    internal class DeleteDetails
    {
        public void Display(TDetails details)
        {
        DELETE:
            Console.Clear();
            Console.WriteLine("--------- *** DELETE TRAINER DETAILS *** ---------");
            Console.WriteLine("'DT'  : Delete Trainer Profile (Complete profile gets deleted including login credentials)");
            Console.WriteLine("'TD'  : Delete Trainer Details (Profile gets deleted excluding login credentials");
            Console.WriteLine("'CD'  : Delete Contact Details");
            Console.WriteLine("'EDU' : Delete Education Details");
            Console.WriteLine("'ED'  : Delete Experience Details");
            Console.WriteLine("'SD'  : Delete Skills");
            Console.WriteLine("'<-'  : Go back");
            Console.Write("\nChoose and Enter a Keyword : ");
            DeleteProfile trainer = new DeleteProfile();
            switch(Console.ReadLine())
            {
                case "DT":
                    trainer.DeleteTrainer(details.email);
                    Console.Write("Press any key to return to Deletion menu..");
                    Console.ReadLine();
                    goto DELETE;
                case "TD":
                    trainer.DeleteTDetails(details);
                    Console.ReadLine();
                    goto DELETE;
                case "CD":
                    trainer.DeleteCDetails(details);
                    Console.ReadLine();
                    goto DELETE;
                case "EDU":
                    trainer.DeleteEDUdetails(details);
                    Console.ReadLine();
                    goto DELETE;
                case "ED":
                    trainer.DeleteEDetails(details);
                    Console.ReadLine();
                    goto DELETE;
                case "SD":
                    trainer.DeleteSDetails(details);
                    Console.ReadLine();
                    goto DELETE;
                case "<-":
                    break;
                default:
                    Console.WriteLine("** Invalid input **");
                    Console.ReadKey();
                    goto DELETE;
            }
        }
    }
}
