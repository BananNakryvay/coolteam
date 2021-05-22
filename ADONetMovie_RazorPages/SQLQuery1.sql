GO

DROP TABLE [dbo].[Studio];
CREATE TABLE [dbo].[Users] (
    [Id]   INT          NOT NULL,
    [Name] VARCHAR (50) NULL,
    [Role] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


INSERT INTO [dbo].[Users] ([Id], [Name], [Role]) VALUES (1, N'Edem', N'Admin')

