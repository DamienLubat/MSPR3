--create database PIM
--drop database PIM
use PIM

create table Medias (
	IDMedia int primary key identity(1,1),
	MediaPath nvarchar(200),
)

create table Languages (
	IDLanguage int primary key identity(1,1),
	LanguageDescription nvarchar(50)
)

create table Descriptives (
	IDDescriptive int primary key identity(1,1),
	IDLanguage int references Languages(IDLanguage),
	DescriptionShort nvarchar(50),
	DescriptionLong nvarchar(500)
)

create table Suppliers (
	IDSupplier int primary key identity(1,1),
	Name nvarchar(50),
	Adress nvarchar(50),
	Phone nvarchar(10),
)

create table Prices (
	IDPrice int primary key identity(1,1),
	Currency nvarchar(50),
	PriceHT money,
	QuantityMin int
)

create table Taxs (
	IDTax int primary key identity(1,1),
	Rate float
)

create table Volumes (
	IDVolume int primary key identity(1,1),
	VolumeDescription nvarchar(50),
	VolumeWeight float,
	Dimension nvarchar(50)
)

create table Items (
	IDItem int primary key identity(1,1),
	GTIN nvarchar(50) not null,
	ItemWeigth float,
	SaleUnite int,
	IDMedia int references Medias(IDMedia),
	IDLanguage int references Languages(IDLanguage),
	IDDescriptive int references Descriptives(IDDescriptive),
	IDSupplier int references Suppliers(IDSupplier),
	IDPrice int references Prices(IDPrice),
	IDTax int references Taxs(IDTax),
	IDVolume int references Volumes(IDVolume)
)

create table Keywords (
	IDKeyword int primary key identity(1,1),
	KeywordDescription nvarchar(50),
	IDItem int references Items(IDItem),
	IDMedia int references Medias(IDMedia)
)

create table Users (
	IDUser int primary key identity(1,1),
	Username nvarchar(50),
	Password nvarchar(50)
)

----------------------------------------------------
create table UsersItems (
	IDUsersItems int primary key identity(1,1),
	IDItem int references Items(IDItem),
	IDUser int references Users(IDUser)
)
----------------------------------------------------


