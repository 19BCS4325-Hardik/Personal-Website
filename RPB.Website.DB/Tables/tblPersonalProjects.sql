CREATE TABLE [dbo].[tblPersonalProjects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Languages] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(255) NOT NULL,
	[GitHubRepository] VARCHAR(255) NOT NULL,
	[Demonstration] VARCHAR(100) NOT NULL
)
