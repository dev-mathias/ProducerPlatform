CREATE TABLE [dbo].[Producer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY ,
	[Lastname] VARCHAR(50) NOT NULL,
	[Firstname] VARCHAR(30) NULL,
	[AddressId] INT NOT NULL,
	[Email] VARCHAR(384) NOT NULL,
	[Password] BINARY(64) NOT NULL,
	[Presalt] BINARY(64) NOT NULL,
	[Postsalt] BINARY(64) NOT NULL,

	CONSTRAINT [FK_Producer_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]),
)
