CREATE TABLE [dbo].[PhoneConnection]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[PersonId] INT NOT NULL,
    [PhoneNumber] VARCHAR(50) NULL,

	CONSTRAINT [FK_PhoneConnection_Person]
        FOREIGN KEY ([PersonId])
        REFERENCES [dbo].[Person]([Id]) ON DELETE NO ACTION
)
