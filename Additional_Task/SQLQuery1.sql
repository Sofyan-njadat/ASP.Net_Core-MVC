Create Database Mega_Store;
use Mega_Store;

CREATE TABLE Customers (
    ID INT IDENTITY(1,1) PRIMARY KEY, 
	Name NVARCHAR(50) NOT NULL, 
	Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(20) NULL,
	Password VARCHAR (30) NOT NULL
    );



ALTER TABLE Customers
DROP COLUMN Phone;