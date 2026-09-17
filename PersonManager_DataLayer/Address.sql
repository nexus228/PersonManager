CREATE TABLE [dbo].[Address]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [PersonId] INT NOT NULL,
    [ZipCode] VARCHAR(50) NULL, 
    [City] VARCHAR(100) NULL, 
    [Street] VARCHAR(100) NULL, 
    [HouseNumber] VARCHAR(25) NULL,

    CONSTRAINT [FK_Address_Person]
        FOREIGN KEY ([PersonId])
        REFERENCES [dbo].[Person]([Id]) ON DELETE NO ACTION
)