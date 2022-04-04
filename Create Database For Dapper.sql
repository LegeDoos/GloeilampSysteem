DROP TABLE LAMP
DROP TABLE LIGHTSWITCH

create table LIGHTSWITCH(
id int primary key,
[name] varchar(50),
isOn bit)

create table LAMP(
id int primary key,
[name] varchar(50),
isOn bit,
[state] varchar(10),
frequency int,
lightswitchid int,
FOREIGN KEY (lightswitchid) REFERENCES LIGHTSWITCH (id))

insert into LIGHTSWITCH 
values (1,'Schakelaar woonkamer',0),
(2,'Schakelaar keuken',0),
(3,'Schakelaar gang',0),
(4,'Schakelaar garage',0);

insert into lamp
values (1,'philips',0,'uit',60,1),
(2,'philips',0,'uit',60,1),
(3,'philips',0,'uit',60,1),
(4,'philips',0,'uit',80,2),
(5,'philips',0,'uit',90,3),
(6,'osram',0,'uit',100,4)