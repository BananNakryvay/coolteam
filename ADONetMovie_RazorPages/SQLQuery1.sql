GO

DROP TABLE [dbo].[Studio];
CREATE TABLE [dbo].[Users] (
    [Id]   INT          NOT NULL,
    [Name] VARCHAR (50) NULL,
    [Role] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
DROP TABLE [dbo].[Room]
CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Capacity] INT NOT NULL, 
    [ Size] VARCHAR(50) NOT NULL, 
    [Time] DATETIME NOT NULL, 
    [Status] BIT NOT NULL
)

INSERT INTO [dbo].[Users] ([Id], [Name], [Role]) VALUES (1, N'Edem', N'Admin')

