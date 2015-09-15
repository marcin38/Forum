IF OBJECT_ID('POSTS', 'U') IS NOT NULL
	drop table POSTS;
IF OBJECT_ID('Threads', 'U') IS NOT NULL
	drop table Threads;
IF OBJECT_ID('Categories', 'U') IS NOT NULL
	drop table Categories;
IF OBJECT_ID('USERS', 'U') IS NOT NULL
	drop table USERS;
IF OBJECT_ID('Avatars','U') IS NOT NULL
	DROP TABLE AVATARS;


----------------------------------------------------

CREATE TABLE [dbo].[Avatars](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Image] [image] NOT NULL
);

CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Hash] [varbinary](50) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[RemovalDate] [datetime] NULL,
	[Location] [nvarchar](50) NULL,
	[AvatarId] [int] NULL

	CONSTRAINT [FK_Users_AvatarId] FOREIGN KEY ([AvatarId]) REFERENCES [Avatars]([Id])
);

CREATE TABLE [dbo].[Categories](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL
)


CREATE TABLE [dbo].[Threads](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Title] [nvarchar](50) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL

	CONSTRAINT [FK_Threads_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Threads_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
)

CREATE TABLE [dbo].[Posts](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[AuthorId] [int] NOT NULL,
	[PostContent] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ThreadId] [int] NOT NULL

	CONSTRAINT [FK_Posts_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Posts_ThreadId] FOREIGN KEY ([ThreadId]) REFERENCES [Threads]([Id])
)


