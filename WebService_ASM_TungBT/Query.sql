Create database BankService
Use BankService

Create table KhachHang(
maKH varchar(50) Primary key,
pin varchar(50),
soDu decimal
)

Create table DoiTac(
maDoiTac varchar(50) primary key,
matKhau varchar(50),
soDu decimal
)

Create table GiaoDich(
maGD varchar(50) primary key,
maKH varchar(50),
maDoiTac varchar(50),
soTien decimal,
tenGD varchar(50),
loai int,	
thoiGian Datetime,
phiGD decimal
Constraint fkKH FOREIGN KEY  (maKH) REFERENCES KhachHang(maKH),
Constraint fkDT FOREIGN KEY  (maDoiTac) REFERENCES DoiTac(maDoiTac)
)

Insert into KhachHang Values('KH01','1234',5000000)
Insert into KhachHang Values('KH02','1234',10000000)
Insert into KhachHang Values('KH03','1234',1000000)
Insert into KhachHang Values('KH04','1234',3000000)
Insert into KhachHang Values('KH05','1234',2000000)
Select * from KhachHang

Insert into DoiTac Values('DT01','1234',15000000)
Insert into DoiTac Values('DT02','1234',50000000)
Insert into DoiTac Values('DT03','1234',10000000)
Insert into DoiTac Values('DT04','1234',150000000)
Select * from  DoiTac

