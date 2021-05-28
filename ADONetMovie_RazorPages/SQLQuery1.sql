GO

DROP TABLE [dbo].[Users]
CREATE TABLE [dbo].[Users] (
   [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR (50) NOT NULL,
    [Role] VARCHAR (50) NOT NULL,
	[Password] VARCHAR (50) NOT NULL
);

GO
DROP TABLE [dbo].[Room]
CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Capacity] INT NOT NULL, 
    [Size] VARCHAR(50) NOT NULL
)
GO
DROP TABLE [dbo].[BookingRoom]
CREATE TABLE [dbo].[BookingRoom]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [RoomId] INT NOT NULL, 
    [Time] DATETIME NOT NULL, 
    [UserId] INT NOT NULL
)
GO
INSERT INTO [dbo].[Users] ( [Name], [Role], [Password]) VALUES ( N'Edem', N'Admin', 'kek')
INSERT INTO [dbo].[Users] ([Name], [Role], [Password]) VALUES ( N'Edem', N'Admin', N'kek')
INSERT INTO [dbo].[Users] ([Name], [Role], [Password]) VALUES ( N'David', N'Teacher', N'ooo')
INSERT INTO [dbo].[Users] ([Name], [Role], [Password]) VALUES (N'Paulina', N'Student', N'wek')
