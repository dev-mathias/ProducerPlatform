﻿CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY ,
	[Lastname] VARCHAR(50) NOT NULL,
	[Firstname] VARCHAR(50) NOT NULL,
	[AddressId] INT NOT NULL,
	[Email] VARCHAR(384) NOT NULL,
	[Password] BINARY(64) NOT NULL,
	[Presalt] UNIQUEIDENTIFIER NOT NULL,
	[Postsalt] UNIQUEIDENTIFIER NOT NULL, 
    [isAdmin] BIT NOT NULL, 
    CONSTRAINT [FK_Customer_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]),
)
