using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace TraineeLib
{
    public class SetAllDetails
    {
        public void Display(TLogin login) 
        {
            TDetailsRepo detailsRepo = new TDetailsRepo();
            TDetails details = detailsRepo.GetDetails(login);
            detailsRepo.AddTrainee(details);
        }
    }
}
