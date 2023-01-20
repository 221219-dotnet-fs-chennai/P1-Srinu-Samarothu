-- Create database TraineeDB;

--create schema Trainee;


 create table Trainee.Login (
     [Email] varchar(50),
     [Password] varchar(20) not null,
     constraint [PK_Email] primary key (Email)
 );



 create table Trainee.Trainer_details (
     [Trainer_iD] int,
     [First_name] varchar(15),
     [Last_name] varchar(15),
     [Gender] varchar(6),
     [DOB] date,
     [Mail] varchar(50) not null,
     constraint [PK_Trainer_Id] primary key (Trainer_id),
     constraint [FK_mail] foreign key ([Mail]) references [Trainee.Login](Email) ON DELETE CASCADE ON UPDATE CASCADE
 )


 create table Trainee.Contact_details (
     [Mobile_number] bigint,
     [Address_lane] varchar(70),
     [City] varchar(20),
     [State] varchar(15),
     [Zipcode] varchar(6),
     [mail] varchar(25),
     [TID] int,
     constraint [PK_Mobile_number] primary key ([Mobile_number]),
     constraint [FK_TID] foreign key ([TID]) references [Trainee.Trainer_details](Trainer_id) ON DELETE CASCADE ON UPDATE CASCADE
 )



 create table Trainee.Education (
     [UG_college] varchar(30) not null,
     [UG_percentage] int not null,
     [UG_passout_year] int not null,
     [PG_college] varchar(30),
     [PG_percentage] int,
     [PG_passout_year] int,
     [TID] int ,
     constraint [FK_EduTID] foreign key ([TID]) references [Trainee.Trainer_details](Trainer_id) ON DELETE CASCADE ON UPDATE CASCADE
 )



 create table [Trainee.Skills] (
     [Skill] varchar(10),
     [Proficiency] int,
     [TID] int unique,
     constraint [FK_SkillsTID] foreign key ([TID]) references [Trainee.Trainer_details](Trainer_id) ON DELETE CASCADE ON UPDATE CASCADE
 )



 create table Trainee.Experience (
     [Company] varchar(15) not null,
     [Designation] varchar(15) not null,
     [Overall_Experience] int not null,
     [TID] int ,
     constraint [FK_ExpTID] foreign key ([TID]) references [Trainee.Trainer_details](Trainer_id) ON DELETE CASCADE ON UPDATE CASCADE
 )






 select * from [Trainee.Login]
 select * from [Trainee.Trainer_details]
 select * from [Trainee.Contact_details]
 select * from [Trainee.Education]
 select * from [Trainee.Experience]
 select * from [Trainee.Skills]

