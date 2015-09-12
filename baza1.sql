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

	CONSTRAINT [FK_AvatarId_Avatars] FOREIGN KEY ([AvatarId]) REFERENCES [Avatars]([Id])
);

