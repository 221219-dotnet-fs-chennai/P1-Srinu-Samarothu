using Models;
using DF = DataFluentApi.Entities;

namespace Business_Logic
{
    public interface ILogic
    {

        //------------- Login Logic -----------------

        public TraineeLogin AddLogin(TraineeLogin details);

        public IEnumerable<TraineeLogin> GetLoginDetails();

        public void UpdateLogin(string? mail, string? pwd, TraineeLogin login);

        public TraineeLogin DeleteLogin(string? mail);


        //------------- Trainer Logic -----------------

        public TraineeTrainerDetail AddTrainer(string? Email, TraineeTrainerDetail tDetails);

        public IEnumerable<TraineeTrainerDetail> GetTrainerDetails();

        public TraineeTrainerDetail GetTrainerDetails(string? Email);

        public TraineeTrainerDetail DeleteTrainer(string? mail);

        public void UpdateTrainer(string? mail, TraineeTrainerDetail trainer);


        //------------- Trainer Contact Logic -----------------

        public TraineeContactDetail AddTrainerContact(string? mail, TraineeContactDetail contactDetails);

        public TraineeContactDetail GetTrainerContact(string? Email);

        public void UpdateTrainerContact(string? mail, TraineeContactDetail contact);

        public TraineeContactDetail DeleteTrainerContact(string? mail);

        //------------- Trainer Contact Logic -----------------

        public Education AddTrainerEducation(string? mail, Education educationDetails);

        public Education GetTrainerEducation(string? Email);

        public void UpdateTrainerEducation(string? mail, Education education);

        public Education DeleteTrainerEducation(string? mail);
    }
}
