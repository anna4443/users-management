use "master"
GO

drop database "LoginPerson"
GO

create database "LoginPerson"
GO

use "LoginPerson"
GO



create table City
(
	IDCity int primary key identity not null, 
	Name nvarchar(50) not null
)
GO

create table StatusPerson
(
	IDStatusPerson int primary key identity not null,
	Name nvarchar(50) not null
)
GO

create table Person
(
	IDPerson int primary key identity not null,
	Name nvarchar(50) not null,
	Surname nvarchar(50) not null,
	Pass nvarchar(50) not null,
	Telephone nvarchar(50),
	StatusPersonID int,
	CityID int,
	CONSTRAINT FK_PersonStatusPerson FOREIGN KEY(StatusPersonID) REFERENCES StatusPerson(IDStatusPerson),
	CONSTRAINT FK_PersonCity FOREIGN KEY(CityID) REFERENCES City(IDCity)
)
GO

create table Email
(
	IDEmail int primary key identity not null, 
	EmailAdress nvarchar(50) not null,
	PersonID int,
	CONSTRAINT FK_EmailPerson FOREIGN KEY(PersonID) REFERENCES Person(IDPerson)
)
GO

-- inserting into tables
insert into City(Name)
values ('Zagreb'),
	   ('Varaždin'),
	   ('Split'),
	   ('Rijeka'),
	   ('Pula'),
	   ('Osijek'),
	   ('Dubrovnik')
GO

insert into StatusPerson(Name)
values ('User'),
	   ('Administrator')
GO

select * from Person
GO







