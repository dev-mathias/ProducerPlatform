CREATE PROCEDURE [dbo].[CreatePurchase]
	@Date datetime2,
	@ProductId int,
	@CustomerId int,
	@Quantite float
As
	BEGIN
		INSERT INTO [Purchase]([Date],[CustomerID],[ProductID], [Quantity])
		OUTPUT [inserted].[Id]
		VALUES (@Date,@CustomerId,@ProductId,@Quantite)
		RETURN 0
	END