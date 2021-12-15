create database todolist;
use todolist;
create table employees(
id int not null auto_increment primary key,
fullName nvarchar(20),
hours float,
title nvarchar(40)
);

create table todos(
id int not null auto_increment primary key,
tName nvarchar(25),
tdescription nvarchar(100),
assignedto int,
hoursneeded float,
iscompleted bit,
foreign key (assignedto) references employees(id)
);

insert into employees
values(0,"Emily Ployee",40,"Official Employee"),
(0,"Steve Jobguy",35,"Hiring person"),
(0,"Shirley Boss",60,"Chief Important Officeholder");



create table employeetodoitems(
id int not null auto_increment primary key,
employeeid int,
todoitemid int,
foreign key (employeeid) references employees(id),
foreign key (todoitemid) references todos(id)
);

select * from employees;
select * from todos;
select * from employeetodoitems;
