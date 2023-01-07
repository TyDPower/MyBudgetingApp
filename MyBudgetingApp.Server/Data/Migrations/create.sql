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
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Wallet')
BEGIN
  -- Create the Wallet table
  CREATE TABLE Wallet (
            Id int NOT NULL,
            Name varchar(255) NOT NULL,
            Balance decimal(18,2) NOT NULL,
            Description varchar(255) NOT NULL,
            IsShared bit NOT NULL,
            IsDeleted bit NOT NULL,
            CreateDate datetime NOT NULL,
            PRIMARY KEY (Id)
        );
END
