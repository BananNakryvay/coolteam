GO


CREATE TABLE [dbo].[Users] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR (50) NULL,
    [Role] VARCHAR (50) NULL,
);
GO
CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Capacity] INT NOT NULL, 
    [ Size] VARCHAR(50) NOT NULL, 
    [Status] BIT NOT NULL
)
GO
CREATE TABLE [dbo].[BookingRoom]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [RoomId] INT NOT NULL, 
    [Time] DATETIME NOT NULL, 
    [UserId] INT NOT NULL
)
GO
INSERT INTO [dbo].[Users] ( [Name], [Role]) VALUES ( N'Edem', N'Admin')

