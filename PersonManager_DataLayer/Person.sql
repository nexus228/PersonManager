CREATE TABLE [dbo].[Person]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NULL, 
    [FirstName] VARCHAR(100) NULL, 
    [DateOfBirth] DATE NULL
)
