GO

DROP TABLE [dbo].[Studio];
CREATE TABLE [dbo].[Studio] (
    [Id]            INT        NOT NULL PRIMARY KEY,
    [Name]          NCHAR (50) NOT NULL,
    [HQCity]        NCHAR (30) NOT NULL,
    [NoOfEmployees] INT        NOT NULL
);

DROP TABLE [dbo].[Actor];


GO
CREATE TABLE [dbo].[Actor] (
    [Id]            INT        NOT NULL PRIMARY KEY,
    [Name]          NCHAR (50) NOT NULL,
    [Country]        NCHAR (30) NOT NULL,
    [Birth_year]        DateTime  NOT NULL,
    [Alive] bit        NOT NULL
);

DROP TABLE [dbo].[Movie];

GO
CREATE TABLE [dbo].[Movie] (
    [Id]                INT        NOT NULL PRIMARY KEY,
    [Title]             NCHAR (50) NOT NULL,
    [Year]              INT        NOT NULL,
    [RunningTimeInMins] INT        NOT NULL,
    [StudioId]          INT        NOT NULL,
    [ActorId]          INT        NOT NULL,
   CONSTRAINT [FK_Movie_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actor]([Id]),
   CONSTRAINT [FK_Movie_Studio] FOREIGN KEY ([StudioId]) REFERENCES [Studio]([Id])
);

INSERT INTO [dbo].[Actor] ([Id], [Name], [Country], [Birth_year], [Alive]) VALUES (1, N'John Wayne ','USA', '2019-02-02', 1)
INSERT INTO [dbo].[Actor] ([Id], [Name], [Country], [Birth_year],[Alive]) VALUES (2, N'John Reno'  , 'FRANCE', '1999-04-06' , 0)
INSERT INTO [dbo].[Actor] ([Id], [Name], [Country], [Birth_year], [Alive]) VALUES (3, N'Karl Stegger','DENMARK', ' 1970', 0)

INSERT INTO [dbo].[Studio] ([Id], [Name], [HQCity], [NoOfEmployees]) VALUES (1, N'New Line Cinema                                   ', N'Boston                        ', 4000)
INSERT INTO [dbo].[Studio] ([Id], [Name], [HQCity], [NoOfEmployees]) VALUES (2, N'20th Century Fox                                  ', N'New York                      ', 2500)
INSERT INTO [dbo].[Studio] ([Id], [Name], [HQCity], [NoOfEmployees]) VALUES (3, N'Paramount Pictures                                ', N'New York                      ', 8000)

INSERT INTO [dbo].[Movie] ([Id], [Title], [Year], [RunningTimeInMins], [StudioId], [ActorId]) VALUES (1, N'Se7en                                             ', 1995, 127, 1, 1)
INSERT INTO [dbo].[Movie] ([Id], [Title], [Year], [RunningTimeInMins], [StudioId], [ActorId]) VALUES (2, N'Alien                                             ', 1979, 117, 2,3)
INSERT INTO [dbo].[Movie] ([Id], [Title], [Year], [RunningTimeInMins], [StudioId], [ActorId]) VALUES (3, N'Forrest Gump                                      ', 1994, 142, 3,2)
INSERT INTO [dbo].[Movie] ([Id], [Title], [Year], [RunningTimeInMins], [StudioId], [ActorId]) VALUES (4, N'True Grit                                         ', 2010, 110, 3,1)
INSERT INTO [dbo].[Movie] ([Id], [Title], [Year], [RunningTimeInMins], [StudioId], [ActorId]) VALUES (5, N'Dark City                                         ', 1998, 111, 1,3)
INSERT INTO [dbo].[Movie] ([Id], [Title], [Year], [RunningTimeInMins], [StudioId], [ActorId]) VALUES (6, N'Terminator                                        ', 1984, 102, 3,3 )
INSERT INTO [dbo].[Movie] ([Id], [Title], [Year], [RunningTimeInMins], [StudioId], [ActorId]) VALUES (7, N'Home Alone                                        ', 1990, 105, 2, 1)

