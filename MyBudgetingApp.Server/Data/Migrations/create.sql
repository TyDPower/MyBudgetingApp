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

-- Check if the Users table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
-- Create the Users table
CREATE TABLE Users (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(255) NOT NULL,
LastName NVARCHAR(255) NOT NULL,
Email NVARCHAR(255) NOT NULL,
CreateDate DATETIME DEFAULT GETDATE()
);
END

-- Check if the Permissions table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Permissions')
BEGIN
-- Create the Permissions table
CREATE TABLE Permissions (
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
END

---- Create foreign keys for the Permissions table
--ALTER TABLE Permissions
--ADD FOREIGN KEY (FK_User_ID) REFERENCES Users(Id),
--ADD FOREIGN KEY (FK_Wallet_ID) REFERENCES Wallets(Id),
--ADD FOREIGN KEY (FK_Budget_ID) REFERENCES Budgets(Id);
--GO
