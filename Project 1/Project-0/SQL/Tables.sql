-- CREATE SCHEMA Trainee;

-- create table Trainee.Login (
--     [Email] varchar(50),
--     [Password] varchar(20) not null,
--     constraint [PK_Email] primary key (Email)
-- );

-- alter table Trainee.Login drop constraint [PK_Email]
-- alter table Trainee.Login alter column [Email] varchar(25) not null 
-- alter table Trainee.Login drop column [Trainer_Id]  
-- alter table Trainee.Login add constraint [PK_Email] primary key (Email)


-- insert into Trainee.Login(Email,[Password]) values("abcd@gmail.com", "password123");

-- create table Trainee.[Trainer_details] (
--     [Trainer_Id] int,
--     [First name] varchar(15),
--     [Last name] varchar(15),
--     [Gender] varchar(6),
--     [DOB] date,
--     [mail] varchar(25) not null,
--     constraint [PK_Trainer_Id] primary key (Trainer_Id),
--     constraint [FK_mail] foreign key ([mail]) references Trainee.Login(Email) ON DELETE CASCADE ON UPDATE CASCADE
-- )

-- create table Trainee.Contact_details (
--     [Mobile number] bigint,
--     [Address lane] varchar(30),
--     [City] varchar(20),
--     [State] varchar(15),
--     [Zipcode] varchar(6),
--     [mail] varchar(25),
--     [TID] int,
--     constraint [PK_Mobile_number] primary key ([Mobile number]),
--     constraint [FK_TID] foreign key ([TID]) references Trainee.[Trainer_details](Trainer_Id) ON DELETE CASCADE ON UPDATE CASCADE
-- )

-- create table Trainee.Education (
--     [UG_college] varchar(30) not null,
--     [UG_percentage] int not null,
--     [UG_passout year] int not null,
--     [PG_college] varchar(30),
--     [PG_percentage] int,
--     [PG_passout year] int,
--     [TID] int not null,
--     constraint [FK_EduTID] foreign key ([TID]) references Trainee.[Trainer_details](Trainer_Id) ON DELETE CASCADE ON UPDATE CASCADE
-- )

-- create table Trainee.[Skill_set] (
--     [Skill] varchar(10),
--     [Proficiency] int,
--     [TID] int not null,
--     constraint [FK_SkiTID] foreign key ([TID]) references Trainee.[Trainer_details](Trainer_Id) ON DELETE CASCADE ON UPDATE CASCADE
-- )

-- create table Trainee.[Trainee_experience] (
--     [Company] varchar(15) not null,
--     [Designation] varchar(15) not null,
--     [Experience] int not null,
--     [TID] int not null,
--     constraint [FK_ExpTID] foreign key ([TID]) references Trainee.[Trainer_details](Trainer_Id) ON DELETE CASCADE ON UPDATE CASCADE
-- )