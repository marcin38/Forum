IF OBJECT_ID('RolesUsers', 'U') IS NOT NULL
	drop table RolesUsers;
IF OBJECT_ID('Roles','U') IS NOT NULL
	drop table Roles;
IF OBJECT_ID('Warnings', 'U') IS NOT NULL
	drop table Warnings;
IF OBJECT_ID('POSTS', 'U') IS NOT NULL
	drop table POSTS;
IF OBJECT_ID('Threads', 'U') IS NOT NULL
	drop table Threads;
IF OBJECT_ID('Categories', 'U') IS NOT NULL
	drop table Categories;
IF OBJECT_ID('Messages','U') IS NOT NULL
	drop table Messages;
IF OBJECT_ID('USERS', 'U') IS NOT NULL
	drop table USERS;
IF OBJECT_ID('Avatars','U') IS NOT NULL
	DROP TABLE AVATARS;


----------------------------------------------------
CREATE TABLE Avatars(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Image] [image] NOT NULL,
	[ContentType] [nvarchar](50) NOT NULL
);

CREATE TABLE Users(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Hash] [varbinary](50) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[RemovalDate] [datetime] NULL,
	[Location] [nvarchar](50) NULL,
	[BirthDate] [date] NULL,
	[AvatarId] [int] NULL,
	[NumberOfWarnings] [int] NOT NULL,
	[IsBanned] [bit] NOT NULL

	CONSTRAINT [FK_Users_AvatarId] FOREIGN KEY ([AvatarId]) REFERENCES [Avatars]([Id]),
	CONSTRAINT [UQ_Users_Name] UNIQUE ([Name])
);

CREATE TABLE Messages(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[From] [int] NOT NULL,
	[To] [int] NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[Body] [nvarchar](MAX) NOT NULL,
	[SentDate] [datetime] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[DeletedBySender] [bit] NOT NULL,
	[DeletedByRecipient] [bit] NOT NULL

	CONSTRAINT [FK_Message_From] FOREIGN KEY ([From]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Message_To] FOREIGN KEY ([To]) REFERENCES [Users]([Id])
);


CREATE TABLE Categories(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL
)


CREATE TABLE Threads(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Title] [nvarchar](100) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[LastPost] [int] NULL,
	CONSTRAINT [FK_Threads_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Threads_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]) ON DELETE CASCADE
)

CREATE TABLE Posts(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[AuthorId] [int] NOT NULL,
	[PostContent] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ThreadId] [int] NOT NULL

	CONSTRAINT [FK_Posts_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Posts_ThreadId] FOREIGN KEY ([ThreadId]) REFERENCES [Threads]([Id]) ON DELETE CASCADE
)

CREATE TABLE Warnings(
	[UserId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
	[Reason] [nvarchar](500) NOT NULL

	CONSTRAINT [PK_Warnings_UserIdPostId] PRIMARY KEY ([UserId],[PostId]),
	CONSTRAINT [FK_Warnings_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Warnings_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts]([Id])
)

CREATE TABLE Roles(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Name] [nvarchar](50) NOT NULL
)

CREATE TABLE RolesUsers(
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL

	CONSTRAINT [FK_RolesUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_RolesUsers_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([Id])
)