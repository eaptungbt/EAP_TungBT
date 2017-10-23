Create database ElevationDB
use ElevationDB
Create table Customer(
	emailCustomer varchar(50) primary key,
	nameCustomer nvarchar(50),
	passwordCustomer varchar(50),
	addressCustomer nvarchar(50),
	company nvarchar(50) null 
)
Create table Employee(
	emailEmployee varchar(50) primary key,
	nameEmployee nvarchar(50),
	passwordEmployee varchar(50),
	addressEmpoyee nvarchar(50)
)
Insert into Employee values ('thanhbuikaka@gmail.com','Bùi Thanh Tùng','1234','Hà Nam')
Create table Elevator(
	idElevator varchar(50) primary key,
	systemType nvarchar(50),
	functionElevator nvarchar(54),
	number int,
	cost decimal,
	descriptionElevator nvarchar(100),
	design varchar(50)
)
Insert into Elevator values('E001',N'Thang không phòng máy',N'Tải khách',10,50000000,'','0')
Insert into Elevator values('E002',N'Thang không phòng máy',N'Tải khách',6,45000000,'','0')
Insert into Elevator values('E003',N'Thang có phòng máy',N'Tải hàng',6,5000000,'','0')
Insert into Elevator values('E004',N'Thang có phòng máy',N'Bệnh viện',15,15000000,'','0')

Create table [Order] (
	idOder varchar(50) primary key,
	emailCustomer varchar(50),
	emailEmployee varchar(50),
	OrderStatus int,
	[time] datetime
	Constraint fkCus FOREIGN KEY  (emailCustomer) REFERENCES Customer(emailCustomer),
	Constraint fkEm FOREIGN KEY  (emailEmployee) REFERENCES Employee(emailEmployee)
)

Create table OrderDetail(
	idOD int IDENTITY  primary key,
	idOder varchar(50),
	idElevator varchar(50),
	qty int,
	price decimal,
	Constraint fkEle FOREIGN KEY  (idElevator) REFERENCES Elevator(idElevator),
	Constraint fkOD FOREIGN KEY  (idOder) REFERENCES [Order](idOder)
)

Create table Feedback(
	idFb int IDENTITY  primary key,
	idElevator varchar(50),
	Satisfy nvarchar(50),
	problem nvarchar(100),
	improvement nvarchar(100),
	statusFeedback int,
	Constraint fkFB FOREIGN KEY  (idElevator) REFERENCES Elevator(idElevator)
)

Create table Maintenance(
	idMt int IDENTITY  primary key,
	idOder varchar(50),
	problem nvarchar(100),
	statusMaintenace int,
	Constraint fkmt FOREIGN KEY  (idOder) REFERENCES [Order](idOder)
)

Insert into Customer values('nguyenvana@gmail.com',N'Nguyễn Văn A','1234',N'Hà Nội','ABC')

select * from Feedback
select * from Employee
select * from Customer
select * from Elevator
select * from [Order]
delete from [Order]
delete from OrderDetail