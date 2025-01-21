IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Demo')
BEGIN
    CREATE DATABASE Demo;
END

GO

USE Demo;

-- Create Role table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Role')
BEGIN
CREATE TABLE Role (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name VARCHAR(30)
);
END

-- Create Account table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Account')
BEGIN
CREATE TABLE Account (
    accountId INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50),
    password VARCHAR(500),
    createdAt DATETIME,
    updatedAt DATETIME,
    deleted BIT,
    deletedAt DATETIME,
    role_id INT
);
END

-- Create User table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'User')
BEGIN
CREATE TABLE [User] (
    userId INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(30),
    email VARCHAR(40),
    createdAt DATETIME,
    updatedAt DATETIME,
    deleted BIT,
    deletedAt DATETIME,
    accountId INT
);
END

IF NOT EXISTS (SELECT * FROM [User])
BEGIN
INSERT INTO [User]
([name], [email], [createdAt], [updatedAt], [deleted], [accountId])
VALUES
    ('Jake Johnson', 'jakejohnson@gmail.com', '2025-01-10 15:23:45', '2025-01-10 15:23:45', 0, 1),
    ('Marry Joe', 'marryjoe@gmail.com', '2025-01-10 15:23:45', '2025-01-10 15:23:45', 0, 2),
    ('Bob Dan', 'bobdan@gmail.com', '2025-01-10 15:23:45', '2025-01-10 15:23:45', 0, 3);
END

IF NOT EXISTS (SELECT * FROM [Account])
BEGIN
INSERT INTO [Account]
([username], [password], [createdAt], [updatedAt], [deleted], [role_id])
VALUES
    ('jakejohn', 'jake123456', '2025-01-10 15:23:45', '2025-01-10 15:23:45', 0, 1),
    ('marrymarry', 'marry456789', '2025-01-10 15:23:45', '2025-01-10 15:23:45', 0, 2),
    ('bobdann', 'bobdan753159', '2025-01-10 15:23:45', '2025-01-10 15:23:45', 0, 2);
END

IF NOT EXISTS (SELECT * FROM [Role])
BEGIN
INSERT INTO [Role]
([role_name])
VALUES
    ('Admin'),
    ('User'),
    ('Lock');
END