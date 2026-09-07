CREATE DATABASE PasswordsManagement;
GO

USE PasswordsManagement;
GO


-- =============================================
-- Account Types
-- =============================================
CREATE TABLE AccountTypes
(
    ID INT IDENTITY(1, 1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO


INSERT INTO AccountTypes (Name)
VALUES
    ('Social'),
    ('Gaming'),
    ('Education'),
    ('Work'),
    ('Personal'),
    ('Banking'),
    ('Shopping'),
    ('Custom');
GO


-- =============================================
-- Users
-- =============================================
CREATE TABLE Users
(
    ID INT IDENTITY(1, 1) PRIMARY KEY,
    EncryptedVerification NVARCHAR(70) NOT NULL,
    Salt NVARCHAR(70) NOT NULL,
    PasswordHint NVARCHAR(10) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    Username NVARCHAR(70) NOT NULL,
    IsActive BIT NOT NULL,
    EncryptedMEK NVARCHAR(100) NOT NULL
);
GO


-- =============================================
-- Accounts
-- =============================================
CREATE TABLE Accounts
(
    ID INT IDENTITY(1, 1) PRIMARY KEY,
    Service NVARCHAR(70) NOT NULL,
    AccountTypeID INT NOT NULL,
    Website NVARCHAR(100) NULL,
    EncryptedPassword NVARCHAR(70) NOT NULL,
    CreationDate DATETIME NOT NULL,
    LastModificationDate DATETIME NOT NULL,
    Notes NVARCHAR(500) NULL,
    IsFavorite BIT NOT NULL,
    IsActive BIT NOT NULL,
    IV NVARCHAR(100) NOT NULL,
    Username NVARCHAR(100) NOT NULL,
    EmailAddress NVARCHAR(100) NULL,
    PhoneNumber NVARCHAR(30) NULL,

    CONSTRAINT FK_Accounts_AccountTypes
        FOREIGN KEY (AccountTypeID)
        REFERENCES AccountTypes(ID)
);
GO


-- =============================================
-- History
-- =============================================
CREATE TABLE History
(
    ID INT IDENTITY(1, 1) PRIMARY KEY,
    Action NVARCHAR(200) NOT NULL,
    ActionDate DATETIME NOT NULL,
    Service NVARCHAR(70) NULL,
    Status BIT NOT NULL,
    Username NVARCHAR(100) NULL
);
GO