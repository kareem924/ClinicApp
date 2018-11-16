USE master;  
GO
IF DB_ID (N'ClinicApp') IS NOT NULL
DROP DATABASE ClinicApp;
GO
CREATE DATABASE ClinicApp;  
GO
-- Verify the database files and sizes  
SELECT name, size, size*1.0/128 AS [Size in MBs]
FROM sys.master_files
WHERE name = N'ClinicApp';  
GO

USE ClinicApp
CREATE TABLE dbo.users
(
    Id int NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
    Name NVARCHAR(120) NULL,
    Email NVARCHAR(120) NULL,
    IsDeleted BIT,
    jig
        CreatedAt
    DATETIME2 NULL,
    UpdatedAt DATETIME2 NULL,
    CreatedBy INT NULL,
    UpdatedBy INT NULL
);

    ALTER TABLE dbo.Users 
ADD EmailConfirmationCode NVARCHAR(300) NULL,
IsActive BIT NULL , 
EmailNormalized NVARCHAR(150);

    ALTER TABLE dbo.users 
ADD UsernameNormalized NVARCHAR(150)
    /*TRUNCATE TABLE dbo.users;*/

    ALTER TABLE dbo.users
ADD UserTypeId INT NOT NULL;
    USE ClinicApp
    CREATE TABLE dbo.UserTokens
    (
        Id int NOT NULL
            PRIMARY KEY CLUSTERED IDENTITY(1,1),
        Token NVARCHAR(150) NOT NULL,
        UserId INT NOT NULL
    );
    ALTER TABLE dbo.UserTokens 
ADD CONSTRAINT FK_UserTokens_Users FOREIGN KEY (UserId)     
    REFERENCES dbo.Users (Id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
    CREATE TABLE dbo.UserClaims
    (

        Id int NOT NULL
            PRIMARY KEY CLUSTERED IDENTITY(1,1),
        ClaimName NVARCHAR(50) NOT NULL,
        ClaimValue NVARCHAR(50) NOT NULL,
        UserId INT NOT NULL
    );
    ALTER TABLE dbo.UserClaims 
ADD CONSTRAINT FK_UserClaims_Users FOREIGN KEY (UserId)     
    REFERENCES dbo.Users (Id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION

    CREATE TABLE dbo.Roles
    (

        Id int NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
        RoleName NVARCHAR(50) NOT NULL
        ,

    )




    CREATE TABLE SysPages
    (
        Id int NOT NULL PRIMARY KEY,
        PageName NVARCHAR(50),
        ParentId INT NOT NULL
    )
    ALTER TABLE dbo.SysPages 
ADD CONSTRAINT FK_SysPages_SysPagesParent FOREIGN KEY (ParentId)     
    REFERENCES dbo.SysPages (Id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION

    CREATE TABLE SysActions
    (
        Id int NOT NULL PRIMARY KEY,
        ActionName NVARCHAR(50)
    )
       CREATE TABLE SysPageActions
    (
        Id int NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
        PageId INT NOT NULL,
        ActionId INT NOT NULL,
        IsAllowed BIT NOT NULL,
        RoleId INT 
    )
     ALTER TABLE dbo.SysPageActions 
ADD CONSTRAINT FK_SysPagesActions_SysPages FOREIGN KEY (PageId)     
    REFERENCES dbo.SysPages (Id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
    CONSTRAINT FK_SysPagesActions_SysActions FOREIGN KEY (ActionId)     
    REFERENCES dbo.SysActions (Id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
 CONSTRAINT FK_SysPagesActions_Roles FOREIGN KEY (RoleId)     
    REFERENCES dbo.Roles (Id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION

    ALTER TABLE [dbo].[users] ADD [EncryptedPassword] varchar(255) NULL