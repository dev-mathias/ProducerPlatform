CREATE TABLE [dbo].[Purchase]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME2 NOT NULL, 
    [ProductID] INT NOT NULL, 
    [CustomerID] INT NOT NULL, 
    [Quantity] FLOAT NOT NULL, 
    CONSTRAINT [FK_Purchase_ToCustomer] FOREIGN KEY ([CustomerID]) REFERENCES [Customer]([Id]), 
    CONSTRAINT [FK_Purchase_ToProduct] FOREIGN KEY ([ProductID]) REFERENCES [Product]([Id])
)
