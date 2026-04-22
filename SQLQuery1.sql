create database InternationalShippingRateCalculator;

go 
use InternationalShippingRateCalculator;
go


create table Countrys(
Id int identity(1,1) primary key not null,
name varchar(50) not null,
priceSend decimal(5,2) not null
);


INSERT INTO Countrys (name, priceSend) 
VALUES 
    ('India', 5.00),
    ('US', 8.00),
    ('UK', 10.00);