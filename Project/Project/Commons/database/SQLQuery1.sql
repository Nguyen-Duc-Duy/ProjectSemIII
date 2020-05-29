CREATE DATABASE ManagerHotel_ProjectsXixao
GO
USE ManagerHotel_ProjectsXixao
GO
select * from Employees
GO

-- table Room
CREATE TABLE Rooms
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(125) not null,
	id_type int not null,
	address_room NVARCHAR(125)NOT NULL,
	descript NVARCHAR(256) NULL,
	stt INT NOT NULL DEFAULT(1),
	date_created DATETIME DEFAULT(GETDATE()),
	date_update DATETIME DEFAULT(GETDATE())
)
GO
insert into Rooms(name,id_type,address_room,descript,stt)
values (N'001',1,N'Tầng 2','phòng có sẵn các dịch vụ cơ bẳn',1)
insert into Rooms(name,id_type,address_room,descript,stt)
values (N'002',2,N'Tầng 2','phòng có sẵn các dịch vụ cơ bẳn',1)
insert into Rooms(name,id_type,address_room,descript,stt)
values (N'003',2,N'Tầng 2','phòng có sẵn các dịch vụ cơ bẳn',1)
insert into Rooms(name,id_type,address_room,descript,stt)
values (N'004',2,N'Tầng 2','phòng có sẵn các dịch vụ cơ bẳn',0)
select * from Rooms
select * from Customers
-- table Service
CREATE TABLE Servicers
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(125) not null,
	price FLOAT NOT NULL,
	sale FLOAT NULL,
	stt INT NOT NULL DEFAULT(1),
	descript NVARCHAR(256) NULL,
	date_created DATETIME ,
	date_update DATETIME
)
GO

-- table types
CREATE TABLE Types_Room
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(125) not null,
	stt INT NOT NULL DEFAULT(1),
	moneys FLOAT NOT NULL,
	AdultStandar int NOT NULL,
	AdultMax int NULL,
	ChildrentStandar int not null,
	ChildrentMax int null,
	descript NVARCHAR(256) NULL,
	date_created DATETIME DEFAULT(GETDATE()),
	date_update DATETIME DEFAULT(GETDATE())
)
GO
select * from Types_Room
insert into Types_Room(name,moneys,member_max,member_standar,descript)
values (N'2 giường đơn',250000,N'2 người lớn - 2 trẻ em (dưới 12 tuổi),4 trẻ em dưới 12t tuổi',N'2 người lớn,2 trẻ em',N'Các bé dưới 7 tuổi nên có cha mẹ cùng phòng')
insert into Types_Room(name,moneys,member_max,member_standar,descript)
values (N'2 giường đơn, 1 giường đôi',250000,N'2 người lớn - 2 trẻ em (dưới 12 tuổi),4 trẻ em dưới 12t tuổi',N'2 người lớn,2 trẻ em',N'Các bé dưới 7 tuổi nên có cha mẹ cùng phòng')
-- table Unit
/*
CREATE TABLE Units
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(125) not null,
	stt INT NOT NULL DEFAULT(1),
	descript NVARCHAR(256) NULL,
	date_created DATETIME DEFAULT(GETDATE()),
	date_update DATETIME DEFAULT(GETDATE())
)
GO
*/
-- table Bill 
CREATE TABLE Bills
(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_em INT NOT NULL,
	id_cus INT NOT NULL,
	dateFrom varchar(50) NOT NULL,
	decript NVARCHAR(256) NULL,
	totals FLOAT NOT NULL,
	stt INT NOT NULL DEFAULT(1),
	dateTo varchar(50) not null,
	Prepay Float null,
	InputMoney Float not null,
	OutMoney Float not null,
	date_created DATETIME DEFAULT(GETDATE()),
	date_update DATETIME DEFAULT(GETDATE())
)
GO

-- table Detail_Bill
CREATE TABLE Details_Bill
(
	id_bill INT NOT NULL,
	id_ser INT NOT NULL,
	quantity TINYINT NOT NULL DEFAULT(1),
	id_room INT NOT NULL
)
GO
-- add primary key Detail_Bill
ALTER TABLE Details_Bill
ADD PRIMARY KEY (id_bill,id_ser,id_room)

-- table Employees
CREATE TABLE Employees
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(32),
	email VARCHAR(125),
	phone VARCHAR(10),
	pass VARCHAR(125),
	avt VARCHAR(256),
	stt INT NOT NULL DEFAULT(1),
	decript NVARCHAR(256) NULL,
	date_created DATETIME DEFAULT(GETDATE()),
	date_update DATETIME DEFAULT(GETDATE())
)
GO
alter table Employees
ADD CONSTRAINT DF_avt DEFAULT 'avt.png' FOR avt

INSERT INTO Employees (name,email,pass,avt,stt,decript,date_created)
VALUES
(N'Quản trị hệ thống','manager@gmail.com','1','avt-man.png',2,N'Tài khoản của quản tri viên có đầy đủ các quyền',GETDATE())
select * from Employees
-- table Customers
CREATE TABLE Customers
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(32),
	sex TINYINT NOT NULL,
	car_personal VARCHAR(1) not null,
	adults int null,
	childrens int null,
	id_nation int not null,
	phone VARCHAR(10),
	stt INT NOT NULL DEFAULT(1),
	decript NVARCHAR(256) NULL,
	date_created DATETIME DEFAULT(GETDATE()),
	date_update DATETIME DEFAULT(GETDATE())
)

	--tạo khóa ngoại cho các bảng
-- type room
ALTER TABLE Rooms
ADD CONSTRAINT FK_RoomsType FOREIGN KEY (id_type) REFERENCES Types_Room(id)
-- service unit
--ALTER TABLE Servicers
--ADD CONSTRAINT FK_SerUnit FOREIGN KEY (id_unit) REFERENCES Units(id)
-- bill em cus
ALTER TABLE Bills
ADD CONSTRAINT FK_BillEm FOREIGN KEY  (id_em) REFERENCES Employees(id)
ALTER TABLE Bills
ADD CONSTRAINT FK_BillCus FOREIGN KEY  (id_cus) REFERENCES Customers(id)
-- detail bill_ser_room
ALTER TABLE Details_Bill
ADD CONSTRAINT FK_DetailsBill FOREIGN KEY  (id_bill) REFERENCES Bills(id)
ALTER TABLE Details_Bill
ADD CONSTRAINT FK_DetailsSer FOREIGN KEY  (id_ser) REFERENCES Servicers(id)
ALTER TABLE Details_Bill
ADD CONSTRAINT FK_DetailsRoom FOREIGN KEY  (id_room) REFERENCES Rooms(id)
-- customer country
ALTER TABLE Customers
ADD CONSTRAINT FK_CusCountry FOREIGN KEY  (id_nation) REFERENCES country(id)

SELECT * FROM Servicers
GO