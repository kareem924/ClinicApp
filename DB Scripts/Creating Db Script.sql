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
CREATE TABLE dbo.Users (Id int NOT NULL  
PRIMARY KEY CLUSTERED IDENTITY(1,1),Name NVARCHAR(120) NULL,Email NVARCHAR(120) NULL,
IsDeleted BIT,
CreatedAt DATETIME2 NULL,
UpdatedAt DATETIME2 NULL,
CreatedBy INT NULL,
UpdatedBy INT NULL
);