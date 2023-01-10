-- Check if the database exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MyBudgetingApp')
BEGIN
-- Create the database
CREATE DATABASE MyBudgetingApp;
END
GO

-- Use the database
USE MyBudgetingApp;
GO

---- Check if the Users table exists
--IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'User')
--BEGIN
---- Create the Users table
--CREATE TABLE User (
--ID INT PRIMARY KEY IDENTITY,
--FirstName NVARCHAR(255) NOT NULL,
--LastName NVARCHAR(255) NOT NULL,
--Email NVARCHAR(255) NOT NULL,
--CreateDate DATETIME DEFAULT GETDATE()
--);
-- Enable IDENTITY_INSERT for the Permission table
--SET IDENTITY_INSERT Permission ON
---- Disable IDENTITY_INSERT for the Permission table
--SET IDENTITY_INSERT Permission OFF
--END

-- Check if the Permissions table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Permission')
BEGIN

-- Create the Permissions table
CREATE TABLE Permission (
ID INT PRIMARY KEY IDENTITY,
FK_User_ID INT NOT NULL,
FK_Wallet_ID INT NOT NULL,
FK_Budget_ID INT NOT NULL,
Can_Delete BIT NOT NULL,
Can_Share BIT NOT NULL,
Can_Modify BIT NOT NULL,
Can_View BIT NOT NULL,
CreateDate DATETIME DEFAULT GETDATE()
);
-- Enable IDENTITY_INSERT for the Permission table
SET IDENTITY_INSERT Permission ON
END

---- Create foreign keys for the Permissions table
--ALTER TABLE Permissions
--ADD FOREIGN KEY (FK_User_ID) REFERENCES User(Id),
--ADD FOREIGN KEY (FK_Wallet_ID) REFERENCES Wallet(Id),
--ADD FOREIGN KEY (FK_Budget_ID) REFERENCES Budget(Id);
--GO
