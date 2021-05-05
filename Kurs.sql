drop table Service;  ----заполнено
drop table Apartment_condition; ----заполнено
drop table Employee;   ----заполнено
drop table Position;    -------------заполнено
drop table User_record;
drop table Apartment;-----заполнено
drop table Category_of_apartment; -----------заполнено
drop table Payment;   ------можно не заполнять
drop table Reservation;   ------можно не заполнять
drop table Client;   -----------можно не заполнять 



create table Position
(
Id number generated always as identity(start with 1 increment by 1) primary key,
AccessLevel number not null,
Position nvarchar2(100) not null
);


create table Employee 
(
Id number generated always as identity(start with 1 increment by 1) primary key,
Surname nvarchar2(50) not null,
Name nvarchar2(50) not null,
SecondName nvarchar2(50) not null,
Salary number (8,2) not null,
PhoneNumber nvarchar2(50) not null,
PositionId number, foreign key(PositionId) references Position(Id),
DateOfHiring Date,
DateOfBirth Date,
DateOfDismissal nvarchar2(30)
);

create table User_record
(
Id number generated always as identity(start with 1 increment by 1) primary key,
Login nvarchar2(50),
Password nvarchar2(150),
EmployeeId, foreign key(EmployeeId) references Employee(Id)
);

create table Client
(
Id number generated always as identity(start with 1 increment by 1) primary key,
Surname nvarchar2(50) not null,
Name nvarchar2(50) not null,
SecondName nvarchar2(50) not null,
PassportId nvarchar2(20) not null,
DateOfBirth Date not null,
PhoneNumber nvarchar2(50) not null
);


create table Category_of_apartment
(
Id number generated always as identity(start with 1 increment by 1) primary key,
Category nvarchar2(50),
CountsOfSeats number not null,
CostPerDay number(8,2) not null,
Description nvarchar2(250)
);


create table Apartment
(
Id number generated always as identity(start with 1 increment by 1) primary key,
NumberOfApartment number not null,
CategoryId number, foreign key(CategoryId) references Category_of_apartment(Id),
Status nvarchar2(15) check (Status= 'Свободен' or Status='Занят'),
img blob
);

create table Service
(
Id number generated always as identity(start with 1 increment by 1) primary key,
Service nvarchar2(50),
Cost number(8,2) not null,
Description nvarchar2(250)
);


create table Reservation
(
Id number generated always as identity(start with 1 increment by 1) primary key,
ClientId, foreign key(ClientId) references Client(Id),
ApartmentId, foreign key(ApartmentId) references Apartment(Id),
ArrivalDate Date,
DateOfDeparture Date,
EmployeeId, foreign key(EmployeeId) references Employee(Id),
ServiceId, foreign key(ServiceId) references Service(Id)
);


create table Payment
(
Id number generated always as identity(start with 1 increment by 1) primary key,
ReservationId, foreign key(ReservationId) references Reservation(Id),
ServiceFee number(8,2),
AccomodationFee number(8,2)
);

-----------inserts------------
--ДОЛЖНОСТЬ----
insert into Position(AccessLevel, Position) values(1,'Администратор');
insert into Position(AccessLevel, Position) values(2,'Портье');
insert into Position(AccessLevel, Position) values(3,'Швейцар');
insert into Position(AccessLevel, Position) values(3,'Беллбой');
insert into Position(AccessLevel, Position) values(3,'Менеджер');
insert into Position(AccessLevel, Position) values(3,'Горничная');
insert into Position(AccessLevel, Position) values(2,'Бухгалтер');
insert into Position(AccessLevel, Position) values(3,'Охранник');
insert into Position(AccessLevel, Position) values(3,'Повар');
insert into Position(AccessLevel, Position) values(3,'Официант');

--select * from Position;

--КАТЕГОРИИ НОМЕРОВ----
insert into Category_of_apartment(Category, CountsOfSeats, CostPerDay, Description) values('Стандарт',1,65,'Уютный небольшой номер. В номере представлена кровать с
ортопедическим матрасом и все необходимое для комфортного проживания. Номера расположены на 2 и 3 этажах.');
insert into Category_of_apartment(Category, CountsOfSeats, CostPerDay, Description) values('Стандарт',2,86,'Большой номер 28 кв.м. Изголовье кровати оформлено
в виде лучей восходящего солнца, как и в большинстве номеров гостиницы. Номера расположены на 2 и 3 этажах.');
insert into Category_of_apartment(Category, CountsOfSeats, CostPerDay, Description) values('Стандарт',3,114,'Большой номер, в котором может комфортно разместиться
семья из трех человек. Выход окон на солнечную сторону. Номера расположены на 2 этаже.');
insert into Category_of_apartment(Category, CountsOfSeats, CostPerDay, Description) values('Стандарт',4,185,'Номера расположены на 3 этаже и состоят из трех комнат: 
стильная гостиная и две спальни. Стены душевой облицованы ониксом, игра света и теней. Площадь номера 62 кв.м.');
insert into Category_of_apartment(Category, CountsOfSeats, CostPerDay, Description) values('Люкс',2,210,'Номера расположены на 3 этаже. Стены душевой облицованы ониксом. В номере 
есть камин.');

-----------УСЛУГИ-----------------
insert into Service(Service,Cost,Description) values ('Аренда конференц-зала',250,'Площадь помещения 31 кв.м. Вместимость до 25 человек.');
insert into Service(Service,Cost,Description) values ('Аренда банкетного зала',380,'Площадь помещения 85 кв.м. Вместимость до 60 человек.');
insert into Service(Service,Cost,Description) values ('Сауна',45,'Большая сауна до 15 человек.');
insert into Service(Service,Cost,Description) values ('Стирка',8,'Различные виды стирки, отпаривание, хим. чистка.');
insert into Service(Service,Cost,Description) values ('Доставка еды в номер',18,'Круглосуточная доставка еды в номер: завтраки, обеды, ужины.');
insert into Service(Service,Cost,Description) values ('Заказ такси',15,'Быстрое и качественное обслуживание до любой точки города.');
insert into Service(Service,Cost,Description) values ('Гид-переводчик',60,'Гиды-переводчики по языкам: английский, французский, китайский, немецкий, польский, испанский, итальянский.');
insert into Service(Service,Cost,Description) values ('Минибар',50,'Любая алкогольная продукция на ваш выбор.');
insert into Service(Service,Cost,Description) values ('-',0,'');



--------НОМЕРА----------------------
--create directory BFILE_DIR as 'C:/BFILE';
--insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (202,1,'Свободен',bfilename('BFILE_DIR','odnstand.jpg'));
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (202,1,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (203,1,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (204,1,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (205,1,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (301,2,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (302,2,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (306,2,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (308,2,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (210,3,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (211,3,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (212,3,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (213,3,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (320,4,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (321,4,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (322,4,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (324,5,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (325,5,'Свободен',empty_blob());
insert into Apartment(NumberOfApartment,CategoryId,Status,img) values (326,5,'Свободен',empty_blob());


create index Status on Apartment(Status);

alter session set nls_date_format = 'dd/MON/yyyy hh24:mi'
select * from Employee;

-----СОТРУДНИКИ----------------
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Новик','Анастасия','Дмитриевна',2000,
'+375298232243',1, to_date('10-09-2020', 'DD-MM-YYYY'),to_date('02-11-2000', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Баранчук','Владислав','Олегович',890,
'+375295964736',2, to_date('15-10-2020', 'DD-MM-YYYY'),to_date('23-02-1996', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Олешкевич','Александра','Игоревна',850,
'+375449631245',2, to_date('25-02-2021', 'DD-MM-YYYY'),to_date('04-04-1998', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Воробьев','Иван','Анатольевич',620,
'+375297854136',3, to_date('10-09-2020', 'DD-MM-YYYY'),to_date('10-05-1976', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Штучкин','Василий','Федорович',580,
'+375297152436',4, to_date('23-10-2020', 'DD-MM-YYYY'),to_date('01-10-1999', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Штучкин','Геннадий','Федорович',580,
'+375291247858',4, to_date('23-10-2020', 'DD-MM-YYYY'),to_date('01-10-1999', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Панфилова','Елена','Станиславовна',880,
'+375298136204',5, to_date('06-12-2020', 'DD-MM-YYYY'),to_date('16-08-1985', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Дубровина','Мария','Александровна',420,
'+375296325410',6, to_date('06-10-2020', 'DD-MM-YYYY'),to_date('15-07-1999', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Микляева','Анна','Сергеевна',420,
'+375294561879',6, to_date('26-03-2021', 'DD-MM-YYYY'),to_date('25-04-1997', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Ширина','Евгения','Максимовна',770,
'+375443678940',7, to_date('24-09-2020', 'DD-MM-YYYY'),to_date('23-12-1979', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Антонов','Глеб','Борисович',400,
'+375299856432',8, to_date('17-10-2020', 'DD-MM-YYYY'),to_date('08-03-1965', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Баринов','Виктор','Петрович',1100,
'+375294567213',9, to_date('08-11-2020', 'DD-MM-YYYY'),to_date('12-06-1969', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Никитюк','Сергей','Петрович',900,
'+375449005678',9, to_date('09-12-2020', 'DD-MM-YYYY'),to_date('04-09-1989', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Грудинский','Павел','Владимирович',750,
'+375298127630',9, to_date('15-01-2021', 'DD-MM-YYYY'),to_date('21-02-1991', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Ильин','Владимир','Иванович',610,
'+375447893214',10, to_date('26-01-2021', 'DD-MM-YYYY'),to_date('01-01-1997', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Зубина','Ольга','Дмитриевна',550,
'+375295362782',10, to_date('06-03-2021', 'DD-MM-YYYY'),to_date('29-03-1998', 'DD-MM-YYYY'),'-');
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values ('Косаткина','Алла','Витальевна',550,
'+375297296185',10, to_date('23-02-2021', 'DD-MM-YYYY'),to_date('10-09-1996', 'DD-MM-YYYY'),'-');

--select * from Employee;

----СОСТОЯНИЕ НОМЕРОВ--------------------
insert into Apartment_condition(CleaningDate,EmployeeId,ApartmentId) values((to_date('25-04.2021 21:50', 'DD-MM-YYYY hh24:mi')),8,1);
insert into Apartment_condition(CleaningDate,EmployeeId,ApartmentId) values((to_date('25-04.2021 21:10', 'DD-MM-YYYY hh24:mi')),8,2);
insert into Apartment_condition(CleaningDate,EmployeeId,ApartmentId) values((to_date('25-04.2021 20:30', 'DD-MM-YYYY hh24:mi')),8,3);
insert into Apartment_condition(CleaningDate,EmployeeId,ApartmentId) values((to_date('25-04.2021 21:50', 'DD-MM-YYYY hh24:mi')),9,4);
insert into Apartment_condition(CleaningDate,EmployeeId,ApartmentId) values((to_date('25-04.2021 21:10', 'DD-MM-YYYY hh24:mi')),9,5);
insert into Apartment_condition(CleaningDate,EmployeeId,ApartmentId) values((to_date('25-04.2021 20:30', 'DD-MM-YYYY hh24:mi')),9,6);


--grant execute on sys.dbms_crypto to admin;

----ПРОЦЕДУРЫ И ФУНКЦИИ---------------------
grant execute on sys.dbms_crypto to admin;
create or replace procedure addUserRecord(in_login in User_record.Login%type, in_password in User_record.Password%type, in_employeeId in User_record.EmployeeId%type)
is
user_exists number;
user_id User_record.id%TYPE;
curr_user_exists exception;
encode_key nvarchar2(2000) := 'Employee12345678';
encode_mode number;
encode_pass raw(2000);
begin
    encode_mode := DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5;
    select count(*) into user_exists from User_record where User_record.Login = in_login;
    encode_pass := DBMS_CRYPTO.ENCRYPT(utl_i18n.string_to_raw (in_password, 'AL32UTF8'),
        encode_mode, utl_i18n.string_to_raw (encode_key, 'AL32UTF8'));

    if user_exists != 0 then raise curr_user_exists;
        else insert into User_record (Login,Password,EmployeeId) values (in_login,encode_pass,in_employeeId);
    end if;
    exception
    when curr_user_exists then
    raise_application_error(-20000, 'This user is exists');
end addUserRecord;

begin
ADDUSERRECORD('Администратор','Administrator123',1);
end;
select * from EMPLOYEE;

begin
ADDUSERRECORD('baranchuk','qwertyui12345678',2);
end;
begin
ADDUSERRECORD('oleshkevich','asdfghjk12345678',3);
end;
------
--------------------------АВТОРИЗАЦИЯ
create or replace function get_user_cursor(in_login in varchar2, in_password in varchar2)
return sys_refcursor
as
user_cur sys_refcursor;
    begin
    open user_cur for select * from User_record where Login = in_login and Password = in_password;
    return user_cur;
    end get_user_cursor;
    
create or replace procedure findUser (in_login in User_record.Login%type, in_password in User_record.Password%type,user_cur out sys_refcursor)
is
invalid_user exception;
check_count number;
encode_key varchar2(2000) := 'Employee12345678';
encode_mode number;
encode_pass raw(2000);
BEGIN
encode_mode := DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5;
encode_pass := DBMS_CRYPTO.ENCRYPT(utl_i18n.string_to_raw (in_password, 'AL32UTF8'), encode_mode,
    utl_i18n.string_to_raw (encode_key, 'AL32UTF8'));

select count(*) into check_count from User_record where Login = in_login and Password = encode_pass;
    if check_count != 0 then user_cur := get_user_cursor(in_login, encode_pass);
    else raise invalid_user;
    end if;
    DBMS_OUTPUT.ENABLE();
    DBMS_SQL.RETURN_RESULT(user_cur);
    exception
    when invalid_user then
    RAISE_APPLICATION_ERROR(-20005, 'Пожалуйста, проверьте корректность введенных данных');
end findUser;

var usercur refcursor;
begin
FINDUSER('Администратор','Administrator123',:usercur);
end;



CREATE or replace PROCEDURE getEmployees(employee out sys_refcursor)
IS
begin
open employee for select Surname, Name, Secondname, Salary, PhoneNumber, Position, to_char(DateOfBirth,'DD-MM-YYYY'), to_char(DateOfHiring,'DD-MM-YYYY'), DateOfDismissal
from Employee join Position on Position.Id=Employee.PositionId;
end getEmployees;

var usercur refcursor;
begin
getEmployees(:usercur);
dbms_output.enable();
dbms_sql.return_result(:usercur);
end;

CREATE or replace PROCEDURE getApartments(apartment out sys_refcursor)
IS
begin
open apartment for select NumberOfApartment, Category, CountsOfSeats, CostPerDay, Status, Description, img
from Apartment join CATEGORY_OF_APARTMENT on CATEGORY_OF_APARTMENT.Id=Apartment.CategoryId;
end getApartments;

var usercur refcursor;
begin
getApartments(:usercur);
dbms_output.enable();
dbms_sql.return_result(:usercur);
end;

commit;

CREATE or replace PROCEDURE addEmployee(Surname_in in Employee.Surname%TYPE, EmpName in Employee.Name%TYPE, SecondName_in in Employee.SecondName%TYPE,Salary_in in Employee.Salary%TYPE,
PhoneNumber_in in Employee.PhoneNumber%TYPE, PositionId_in in Employee.PositionId%TYPE, DateOfHiring_in in Employee.DateOfHiring%TYPE, DateOfBirth_in in Employee.DateOfBirth%TYPE, DateOfDismissal_in in Employee.DateOfDismissal%TYPE)
IS
employee_id int;
emp_exists number;
curr_emp_exists exception;
begin
SELECT COUNT(*) into emp_exists from Employee where Employee.Surname = Surname_in and Employee.Name=EmpName and Employee.SecondName=SecondName_in and Employee.PhoneNumber =PhoneNumber_in and DateOfDismissal='-';
if emp_exists != 0 then raise curr_emp_exists;
else 
insert into Employee(Surname, Name, SecondName, Salary, PhoneNumber, PositionId, DateOfHiring, DateofBirth, DateOfDismissal) values
(Surname_in,EmpName, SecondName_in,Salary_in,PhoneNumber_in,PositionId_in,DateOfHiring_in, DateofBirth_in, DateOfDismissal_in);
end if;
exception
when curr_emp_exists then
raise_application_error(-20002, 'Такой сотрудник уже есть');
commit;
end addEmployee;

commit;
------СОЗДАТЬ УЧЕТНУЮ ЗАПИСЬ СОТРУДНИКА+ДОБАВИТЬ СОТРУДНИКА
CREATE or replace PROCEDURE addUser_record(Login_in in User_record.Login%TYPE, Password_in in User_record.Password%TYPE,
Surname_in in Employee.Surname%TYPE, EmpName in Employee.Name%TYPE, SecondName_in in Employee.SecondName%TYPE,Salary_in in Employee.Salary%TYPE,
PhoneNumber_in in Employee.PhoneNumber%TYPE, EmpPosition in Position.Position%TYPE, DateOfHiring_in in Employee.DateOfHiring%TYPE,
DateOfBirth_in in Employee.DateOfBirth%TYPE)
is
encode_key nvarchar2(2000) := 'Employee12345678';
encode_mode number;
encode_pass raw(2000);
user_record_id int;
user_emp_id int;
user_exists number;
curr_user_exists exception;
curr_level_exists exception;
a_level int;
Posit_id int;
begin
  begin
  select Id into Posit_id from Position where Position.Position=EmpPosition;
  end;

    encode_mode := DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5;
    encode_pass := DBMS_CRYPTO.ENCRYPT(utl_i18n.string_to_raw (Password_in, 'AL32UTF8'),
        encode_mode, utl_i18n.string_to_raw (encode_key, 'AL32UTF8'));
addEmployee(Surname_in,EmpName, SecondName_in,Salary_in,PhoneNumber_in,Posit_id,DateOfHiring_in, DateofBirth_in,'-');
SELECT COUNT(*) into user_exists from User_record where User_record.Login = Login_in;
if user_exists != 0 then raise curr_user_exists;
else
select MAX(Id) into user_record_id from Employee;
select AccessLevel into a_level from Position where Id=Posit_id;
if(a_level=1 or a_level=2) then
insert into User_record(Login, Password, EmployeeId) values (Login_in,encode_pass, user_record_id);
else insert into User_record(Login, Password, EmployeeId) values (Login_in,encode_pass, user_record_id);
select MAX(Id) into user_emp_id from Employee;
delete from User_record where EmployeeId=user_emp_id;
end if;
end if;
exception
when curr_user_exists then
raise_application_error(-20002, 'Такая учетная запись уже существует');
when curr_level_exists then
raise_application_error(-20002, 'Нельзя создавать учетную запись для сотрудника с уровнем доступа 3');
commit;
end addUser_record;

commit;
select * from Employee;
select * from User_record;


---------------------УВОЛИТЬ СОТРУДНИКА
create or replace procedure DismissalEmployee(Surname_in in Employee.Surname%TYPE, Name_in in Employee.Name%TYPE, SecondName_in in Employee.SecondName%TYPE, 
PhoneNumber_in in Employee.PhoneNumber%TYPE)
is
employee_id int;
dismis nvarchar2(50);
curr_emp_exists exception;
accesslevel int;
begin
SELECT DateOfDismissal into dismis from Employee where Employee.Surname = Surname_in and Employee.Name=Name_in and Employee.SecondName=SecondName_in and Employee.PhoneNumber =PhoneNumber_in;
if(dismis!='-') then raise curr_emp_exists;
else
SELECT Id into employee_id from Employee where Employee.Surname = Surname_in and Employee.Name=Name_in and Employee.SecondName=SecondName_in and Employee.PhoneNumber =PhoneNumber_in;
update Employee set DateOfDismissal=sysdate where Id=employee_id;

select AccessLevel into accesslevel from Employee join Position on Position.Id=Employee.PositionId where Employee.Id=employee_id;
if(accesslevel!=3) then
delete from User_record where EmployeeId=employee_id;
end if;
end if;
exception
when curr_emp_exists then
raise_application_error(-20002, 'Этот сотрудник уже уволен');
commit;
end DismissalEmployee;

select * from Employee;


create or replace procedure addClient(Surname_in in Client.Surname%TYPE, Name_in in Client.Name%TYPE, SecondName_in in Client.SecondName%TYPE, PassportId_in in Client.PassportId%TYPE,
DateOfBirth_in in Client.DateOfBirth%TYPE, PhoneNumber_in in Client.PhoneNumber%TYPE)
is
cli int;
curr_cli_exists exception;
begin
SELECT count(*) into cli from Client where Client.PassportId =PassportId_in;
if(cli!=0) then raise curr_cli_exists;
else
insert into Client(Surname, Name, SecondName, PassportId, DateOfBirth,PhoneNumber) values(Surname_in,Name_in,SecondName_in,PassportId_in,DateOfBirth_in,PhoneNumber_in);
end if;
exception
when curr_cli_exists then
raise_application_error(-20002, 'Этот клиент уже существует');
commit;
end addClient;

select * from Client;

------СПИСОК ВСЕХ КЛИЕНТОВ
CREATE or replace PROCEDURE getClients(clien out sys_refcursor)
IS
begin
open clien for select Id,Surname, Name, SecondName, PassportId, DateOfBirth, PhoneNumber
from Client;
end getClients;



-----СПИСОК УСЛУГ
CREATE or replace PROCEDURE getServices(servic out sys_refcursor)
IS
begin
open servic for select Service, Cost, Description
from Service;
end getServices;


-----ПОЛУЧИТЬ ФИО СОТРУДНИКА ПО ЛОГИНУ
CREATE or replace PROCEDURE getEmployeeFIO(login_in in User_record.Login%TYPE,emp out sys_refcursor)
IS
begin
open emp for select Surname, Name, SecondName
from Employee join User_record on Employee.Id=User_record.EmployeeId where User_record.Login=login_in;
end getEmployeeFIO;


----ПОЛУЧИТЬ ID УСЛУГИ ПО ЕЕ НАЗВАНИЮ
CREATE or replace PROCEDURE getServiceId(nameofservice in Service.Service%TYPE,servic out sys_refcursor)
IS
begin
open servic for select Id
from Service where Service=nameofservice;
end getServiceId;

update Apartment set Status = 'Занят' where Id=3;
commit;
select * from Apartment;
---ПОЛУЧИТЬ СВОБОДНЫЕ НОМЕРА----------

create table T1(NumberOfApartment int, Category nvarchar2(50), CountsOfSeats int);

CREATE or replace PROCEDURE getEmptyApartmentsbeforereservation(ArrivalDate_in Reservation.DateOfDeparture%TYPE,DateOfDeparture_in Reservation.DateOfDeparture%TYPE,apart out sys_refcursor)
is
counting int;
notfree int;
begin
delete from T1;
insert into T1 select NumberOfApartment, Category, CountsOfSeats  from Apartment 
join Category_Of_Apartment on Apartment.CategoryId=Category_Of_Apartment.Id
join Reservation on Reservation.ApartmentId=Apartment.Id;

delete from T1 where NumberOfApartment in (select NumberOfApartment from Apartment 
join Reservation on Reservation.ApartmentId=Apartment.Id where ArrivalDate_in between ArrivalDate and DateOfDeparture and DateOfDeparture_in
between ArrivalDate and DateOfDeparture or (ArrivalDate_in > DateOfDeparture or ArrivalDate_in<ArrivalDate) or (DateOfDeparture_in> DateOfDeparture or DateOfDeparture_in< ArrivalDate));

select count(NumberOfApartment) into counting from Apartment
join Reservation on Reservation.ApartmentId=Apartment.Id where ArrivalDate_in between ArrivalDate and DateOfDeparture;
if(counting=0) then
insert into T1 select NumberOfApartment, Category, CountsOfSeats  from Apartment 
join Category_Of_Apartment on Apartment.CategoryId=Category_Of_Apartment.Id
join Reservation on Reservation.ApartmentId=Apartment.Id where ArrivalDate_in>DateOfDeparture and DateOfDeparture_in>DateOfDeparture;
end if;
open apart for

select distinct * from T1;
commit;
end;

var usercur refcursor;
begin
getEmptyApartmentsbeforereservation('14.05.2021','15.05.2021',:usercur);
dbms_output.enable();
dbms_sql.return_result(:usercur);
end;


CREATE or replace PROCEDURE getEmptyApartments(apart out sys_refcursor)
IS
begin
open apart for select NumberOfApartment, Category, CountsOfSeats
from Apartment join Category_Of_Apartment on Apartment.CategoryId=Category_Of_Apartment.Id where Status='Свободен';
end getEmptyApartments;
commit;
----ПОУЛЧИТЬ ID НОМЕРА ПО ЕГО НОМЕРУ
CREATE or replace PROCEDURE getApartmentId(Numberofapartment_in in Service.Service%TYPE,ap out sys_refcursor)
IS
begin
open ap for select Id
from Apartment where NumberOfApartment=Numberofapartment_in;
end getApartmentId;

------БРОНИРОВАНИЕ
create or replace procedure addPostoyalec(ClientId_in in Reservation.ClientId%TYPE, ApartmentId_in in Reservation.ApartmentId%TYPE, ArrivalDate_in in Reservation.ArrivalDate%TYPE,
DateOfDeparture_in in Reservation.DateOfDeparture%TYPE, EmployeeId_in in Reservation.EmployeeId%TYPE, ServiceId_in in Reservation.ServiceId%TYPE)
is
post int;
curr_post_exists exception;
postId int;
service_cost number;
apartment_cost number;
begin
SELECT count(*) into post from Reservation where Reservation.ClientId =ClientId_in;
if(post!=0) then raise curr_post_exists;
else
insert into Reservation(ClientId, ApartmentId, ArrivalDate, DateOfDeparture, EmployeeId,ServiceId) values(ClientId_in,ApartmentId_in,ArrivalDate_in,DateOfDeparture_in,
EmployeeId_in,ServiceId_in);
end if;
update Apartment set Status='Занят' where Id=ApartmentId_in;
    select max(Id) into postId from Reservation;
    select CostPerDay into apartment_cost from Apartment join Category_Of_Apartment on Apartment.CategoryId=Category_Of_Apartment.Id where Apartment.Id=ApartmentId_in;
    select Cost into service_cost from Service where Id = ServiceId_in;
    insert into Payment (ReservationId,ServiceFee, AccomodationFee) values (postId, service_cost,apartment_cost*(DateOfDeparture_in-ArrivalDate_in));
exception
when curr_post_exists then
raise_application_error(-20002, 'Этот клиент уже забронировал номер');
commit;
end addPostoyalec;


select * from Reservation;
select * from Apartment;
select * from Payment;
select * from CATEGORY_OF_APARTMENT;
select * from Service;

create or replace procedure getRoomers(roomer out sys_refcursor)
IS
begin
open roomer for
select Client.Surname as Client_Sur, Client.Name as Client_Name, Client.SecondName as Client_Secon,Client.PhoneNumber, Client.PassportId, Client.DateOfBirth, Apartment.NumberOfApartment, Category_of_Apartment.Category,
Category_of_Apartment.CountsOfSeats, Reservation.ArrivalDate,
Reservation.DateOfDeparture, Employee.Surname as Employee_Sur, Employee.Name as Employee_Name, Employee.SecondName as Employee_Secon, Service.Service, Payment.ServiceFee, Payment.AccomodationFee
from Apartment 
join CATEGORY_OF_APARTMENT on Apartment.CategoryId=CATEGORY_OF_APARTMENT.Id
join Reservation on Apartment.Id=Reservation.ApartmentId
join Client on Reservation.ClientId=Client.Id
join Employee on Reservation.EmployeeId=Employee.Id
join Service on Reservation.ServiceId=Service.Id
join Payment on Reservation.Id=Payment.ReservationId;
commit;
end getRoomers;

-----ПРОДЛЕНИЕ ПРОЖИВАНИЯ ПОСТОЯЛЬЦА
create or replace procedure ProlongationForRoomer(NumberOfApartment_in Apartment.NumberOfApartment%TYPE,Clientid_in Reservation.ClientId%TYPE,ArrivalDate_in Reservation.ArrivalDate%TYPE,DateOfDeparture_in Reservation.DateOfDeparture%TYPE)
is
apartment_cost int;
begin 
select CostPerDay into apartment_cost from Apartment join Category_Of_Apartment on Apartment.CategoryId=Category_Of_Apartment.Id where Apartment.NumberOfApartment=NumberOfApartment_in;
update Reservation set DateOfDeparture=DateOfDeparture_in where ClientId=ClientId_in;
update Payment set AccomodationFee=apartment_cost*(DateOfDeparture_in-ArrivalDate_in) where ReservationId=(select Reservation.Id from Reservation join Client on
                                                                                                           Reservation.ClientId=Client.Id where ClientId=Clientid_in);
commit;
end ProlongationForRoomer;
-----ПОЛУЧИТЬ Id КЛИЕНТА по его ФИО
create or replace procedure getClientId(ClientSur_in Client.Surname%TYPE,ClientNam_in Client.Name%TYPE,ClientSecon_in Client.SecondName%TYPE,clie out sys_refcursor)
is
begin 
open clie for 
select Id from Reservation where Surname=ClientSur_in and Name=ClientNam_in and SecondName=ClientSecon_in;
end getClientId;


commit;

------SHEDULER

-------ВЫСЕЛЕНИЕ ПОСТОЯЛЬЦА
create or replace procedure DepartureRoomer
is
countApart int;
apa int;
begin
delete from Payment where ReservationId in(select Reservation.Id from Reservation where DateOfDeparture=trunc(sysdate));
delete from Reservation where DateOfDeparture=trunc(sysdate);

update Apartment set Status = 'Свободен' where Id not in(select ApartmentId from Reservation);
commit;
end;

begin
DepartureRoomer;
end;

begin
dbms_scheduler.drop_schedule(
schedule_name=>'Depart_Roomers');
end;

begin
dbms_scheduler.drop_program(
program_name=>'Depart_roomers_Program');
end;

begin
dbms_scheduler.drop_job(
job_name=>'Depart_roomers_Job');
end;

begin
dbms_scheduler.create_schedule(
schedule_name=>'Depart_Roomers',
start_date=>CURRENT_TIMESTAMP,
repeat_interval =>'FREQ=MINUTELY;INTERVAL=1');
end;

begin
dbms_scheduler.create_program(
program_name=>'Depart_roomers_Program',
program_type=>'STORED_PROCEDURE',
program_action=>'DepartureRoomer',
number_of_arguments=>0,
enabled=>true);
end;

begin
dbms_scheduler.create_job(
job_name=>'Depart_roomers_Job',
program_name=>'Depart_roomers_Program',
schedule_name=>'Depart_Roomers',
enabled=>true);
end;

exec dbms_scheduler.run_job('Depart_roomers_Job');

SET SERVEROUTPUT ON;


---------------XML EXPORT/IMPORT
CREATE OR REPLACE DIRECTORY UTLDATA AS 'C:/XML';
DROP DIRECTORY UTLDATA;

CREATE OR REPLACE PACKAGE XML_PACKAGE IS
  PROCEDURE EXPORT_CLIENTS_TO_XML;
  PROCEDURE IMPORT_CLIENTS_FROM_XML;
END XML_PACKAGE;

CREATE OR REPLACE PACKAGE BODY XML_PACKAGE IS

PROCEDURE EXPORT_CLIENTS_TO_XML
IS
  DOC  DBMS_XMLDOM.DOMDocument;
  XDATA  XMLTYPE;
  CURSOR XMLCUR IS
    SELECT XMLELEMENT("CLIENT",
      XMLAttributes('http://www.w3.org/2001/XMLSchema' AS "xmlns:xsi",
      'http://www.oracle.com/Employee.xsd' AS "xsi:nonamespaceSchemaLocation"),
      XMLAGG(XMLELEMENT("CLIENT",
        XMLELEMENT("ID",CL.ID),
        XMLELEMENT("SURNAME",CL.SURNAME),
        XMLELEMENT("NAME",CL.NAME),
        XMLELEMENT("SECONDNAME",CL.SECONDNAME),
        XMLELEMENT("PASSPORTID",CL.PASSPORTID),
        XMLELEMENT("DATEOFBIRTH",CL.DATEOFBIRTH),
        XMLELEMENT("PHONENUMBER",CL.PHONENUMBER)
      ))
) FROM CLIENT CL;
BEGIN
  OPEN XMLCUR;
    LOOP
      FETCH XMLCUR INTO XDATA;
    EXIT WHEN XMLCUR%NOTFOUND;
    END LOOP;
  CLOSE XMLCUR;
  DOC := DBMS_XMLDOM.NewDOMDocument(XDATA);
  DBMS_XMLDOM.WRITETOFILE(DOC, 'UTLDATA/clients.xml');
END EXPORT_CLIENTS_TO_XML;

PROCEDURE IMPORT_CLIENTS_FROM_XML
IS
  L_CLOB CLOB;
  L_BFILE  BFILE := BFILENAME('UTLDATA', 'clients.xml');

  L_DEST_OFFSET   INTEGER := 1;
  L_SRC_OFFSET    INTEGER := 1;
  L_BFILE_CSID    NUMBER  := 0;
  L_LANG_CONTEXT  INTEGER := 0;
  L_WARNING       INTEGER := 0;

  P                DBMS_XMLPARSER.PARSER;
  V_DOC            DBMS_XMLDOM.DOMDOCUMENT;
  V_ROOT_ELEMENT   DBMS_XMLDOM.DOMELEMENT;
  V_CHILD_NODES    DBMS_XMLDOM.DOMNODELIST;
  V_CURRENT_NODE   DBMS_XMLDOM.DOMNODE;

  CL CLIENT%ROWTYPE;
BEGIN
  DBMS_LOB.CREATETEMPORARY (L_CLOB, TRUE);
  DBMS_LOB.FILEOPEN(L_BFILE, DBMS_LOB.FILE_READONLY);

  DBMS_LOB.LOADCLOBFROMFILE (DEST_LOB => L_CLOB, SRC_BFILE => L_BFILE, AMOUNT => DBMS_LOB.LOBMAXSIZE,
    DEST_OFFSET => L_DEST_OFFSET, SRC_OFFSET => L_SRC_OFFSET, BFILE_CSID => L_BFILE_CSID,
    LANG_CONTEXT => L_LANG_CONTEXT, WARNING => L_WARNING);
  DBMS_LOB.FILECLOSE(L_BFILE);
  COMMIT;

   P := DBMS_XMLPARSER.NEWPARSER;

   DBMS_XMLPARSER.PARSECLOB(P,L_CLOB);

   V_DOC := DBMS_XMLPARSER.GETDOCUMENT(P);

   V_ROOT_ELEMENT := DBMS_XMLDOM.Getdocumentelement(v_Doc);

   V_CHILD_NODES := DBMS_XMLDOM.GETCHILDRENBYTAGNAME(V_ROOT_ELEMENT,'*');

   FOR i IN 0 .. DBMS_XMLDOM.GETLENGTH(V_CHILD_NODES) - 1
   LOOP

      V_CURRENT_NODE := DBMS_XMLDOM.ITEM(V_CHILD_NODES,i);

      DBMS_XSLPROCESSOR.VALUEOF(V_CURRENT_NODE,
        'ID/text()',CL.ID);
      DBMS_XSLPROCESSOR.VALUEOF(V_CURRENT_NODE,
        'SURNAME/text()',CL.SURNAME);
      DBMS_XSLPROCESSOR.VALUEOF(V_CURRENT_NODE,
        'NAME/text()',CL.NAME);
      DBMS_XSLPROCESSOR.VALUEOF(V_CURRENT_NODE,
        'SECONDNAME/text()',CL.SECONDNAME);
      DBMS_XSLPROCESSOR.VALUEOF(V_CURRENT_NODE,
        'PASSPORTID/text()',CL.PASSPORTID);
      DBMS_XSLPROCESSOR.VALUEOF(V_CURRENT_NODE,
        'PHONENUMBER/text()',CL.PHONENUMBER);
BEGIN
DBMS_OUTPUT.PUT_LINE('ID: '||CL.ID);
DBMS_OUTPUT.PUT_LINE('SURNAME: '||CL.SURNAME);
DBMS_OUTPUT.PUT_LINE('NAME: '||CL.NAME);
DBMS_OUTPUT.PUT_LINE('SECONDNAME: '||CL.SECONDNAME);
DBMS_OUTPUT.PUT_LINE('PASSPORTID: '||CL.PASSPORTID);
DBMS_OUTPUT.PUT_LINE('PHONENUMBER: '||CL.PHONENUMBER);
DBMS_OUTPUT.PUT_LINE('');
END;

   END LOOP;

  DBMS_LOB.FREETEMPORARY(L_CLOB);
  DBMS_XMLPARSER.FREEPARSER(P);
  DBMS_XMLDOM.FREEDOCUMENT(V_DOC);
  COMMIT;
EXCEPTION
  WHEN OTHERS THEN
  DBMS_LOB.FREETEMPORARY(L_CLOB);
  DBMS_XMLPARSER.FREEPARSER(P);
  DBMS_XMLDOM.FREEDOCUMENT(V_DOC);
  RAISE_APPLICATION_ERROR(-20101, 'IMPORT XML ERROR'|| SQLERRM);
END IMPORT_CLIENTS_FROM_XML;

END XML_PACKAGE;



begin
    XML_PACKAGE.EXPORT_CLIENTS_TO_XML();
    XML_PACKAGE.IMPORT_CLIENTS_FROM_XML();
end;


-----------------ТАБЛИЦА 100000 СТРОК
drop index pr_ind;
drop table Table_1;

create table Table_1 (pr int);
create index pr_ind on Table_1(pr);


begin
for i in 0..1000000
loop
insert into Table_1 values (i);
end loop;
end;

EXPLAIN PLAN FOR
SELECT * FROM TABLE_1 where pr between 10000 and 200000;
SELECT * FROM TABLE (dbms_xplan.display);




-----USER EMPLOYEE
create user employee identified by emppass account unlock;
grant employee_role to employee;


create role employee_role;
grant create session to employee_role;
grant execute on addClient to employee_role;
grant execute on addPostoyalec to employee_role;
grant execute on DepartureRoomer to employee_role;
grant execute on getApartmentId to employee_role;
grant execute on getApartments to employee_role;
grant execute on getClientId to employee_role;
grant execute on getClients to employee_role;
grant execute on getEmployeeFIO to employee_role;
grant execute on getEmptyApartments to employee_role;
grant execute on getEmptyApartmentsBeforeReservation to employee_role;
grant execute on getRoomers to employee_role;
grant execute on getServiceId to employee_role;
grant execute on getServices to employee_role;
grant execute on ProlongationForRoomer to employee_role;
