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

        // --------------------- Trainer Experience Logic -----------------

        public Experience AddTrainerExperience(string? mail, Experience experienceDetails);

        public IEnumerable<Experience> GetTrainerExperience(string? Email);

        public void UpdateTrainerExperience(string? mail, string? company, Experience experience);

        public Experience DeleteTrainerExperience(string? mail, string? company);

        public IEnumerable<Experience> DeleteAllTrainerExperience(string? mail);

        // --------------------- Trainer Skill Logic -----------------

        public Skill AddTrainerSkill(string? mail, Skill skillDetails);

        public IEnumerable<Skill> GetTrainerSkill(string? Email);

        public void UpdateTrainerSkill(string? mail, string? skill, Skill trainer);

        public Skill DeleteTrainerSkill(string? mail, string? skill);

        public IEnumerable<Skill> DeleteAllTrainerSkill(string? mail);


        // ---------------------- Filtering -----------------------

        public IEnumerable<SkillFilter> GetTrainersBySkill(string? skill);

        public IEnumerable<GenderFilter> GetTrainerByGender(string? gender);

    }
}
