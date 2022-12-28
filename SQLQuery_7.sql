-- Creating database EmployeeDB
create database EmployeeDB;

-- Creating Department table
create table Department(
 [deptId] int Primary key,
 [Name] varchar(25),
 [Location] varchar(20)     
);

-- Inserting values into Department table
 insert into Department values (101, 'Tech', 'Chennai'),
 (102, 'AI', 'Bangalore'),
 (103, 'ML', 'Chennai'),
 (104, 'Data Analyst', 'Delhi'),
 (105, 'Cyber Security', 'Mumbai');

-- Creating Employee table
create table Employee(
 [empId] int Primary key,
 [firstName] varchar(25),
 [lastName] varchar(25),
 [SSN] int,
 [DeptID] int,
 constraint [FK_DeptID] FOREIGN KEY (DeptID) references Department(deptId)
);

-- Inserting values into Employee table
insert into Employee values (01, 'Hannah', 'Baker', 801, 105),
(02, 'Clay', 'Jensen', 812, 101),
(03, 'Naruto', 'Uzumaki', 834, 103),
(04, 'Hinata', 'Hyuga', 854, 101),
(05, 'Sasuke', 'Uchiha', 859, 104);


-- Creating EmpDetails table
create table EmpDetails(
    [empdID] int primary key,
    [EmployeeID] int foreign key references Employee(empId),
    [Salary] smallmoney,
    [Address_1] varchar(20),
    [Address_2] varchar(20),
    [City] varchar(15),
    [State] varchar(15),
    [Country] varchar(15)
);


-- Inserting values into EmpDetails
insert into EmpDetails values (1001, 05, 40000, 'Hidden leaf village', null, 'Kakinada', 'Andhra pradesh', 'India'),
(1003, 03, 38000, 'street 4', 'Market road', 'Bangalore', 'Karnataka', 'India'),
(1002, 01, 45000, 'road no 3', 'Taj road', 'Agra', 'Uttar Pradesh', 'India'),
(1004, 05, 33000, 'Hidden', 'leaf village', 'Eluru', 'Andhra pradesh', 'India'); 

-- select * from EmpDetails;
-- select * from Department;
-- select * from Employee;





-- Add Tina Smith
insert into Employee values(06, 'Tina', 'Smith', 789, 107);
-- Add Marketing department
insert into Department values(107, 'Marketing', 'Hyderabad');

-- Inserting a new row into EmpDetails
insert into EmpDetails values (1005, 06, 50000, 'street 5', 'Benz circle', 'Vijayawada', 'Andhra pradesh', 'India')


-- List all employees in Marketing
select e.firstName as First_Name, e.lastName as Last_Name  
from Employee e, Department d 
where e.deptId = d.DeptID AND d.Name = 'Marketing';


-- report total salary of Marketing
select sum(ed.Salary) as Total_Salary 
from EmpDetails ed, Employee e
where e.empId = ed.EmployeeID and e.DeptID = (select deptId from Department where [Name] = 'Marketing');


-- report totalemployees by department
select count(e.empId)as total_employees, d.[Name]
from Employee e, Department d
where e.DeptID = d.deptId
group by d.[Name];


-- Increase salary of Tina Smith to $90,000
update EmpDetails 
 set EmpDetails.Salary = 90000
 from EmpDetails ed inner join Employee e
 on ed.EmployeeID = e.empID  and e.firstName = 'Tina';