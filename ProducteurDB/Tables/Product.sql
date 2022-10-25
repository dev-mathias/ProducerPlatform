CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Quantite] FLOAT NOT NULL,
	[ProducteurID] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Price] FLOAT NOT NULL, 
    CONSTRAINT [FK_Produit_Producteur] FOREIGN KEY ([ProducteurID]) REFERENCES [Producer]([Id]),

)
