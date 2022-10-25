CREATE PROCEDURE [dbo].[CreateProduct]
	@nom nvarchar(100),
	@quantite float,
	@ProducteurId int,
	@Description nvarchar(max),
	@Price float
AS
	BEGIN
		INSERT INTO [Product]([Name],[Quantite],[ProducteurID],[Description],[Price])
		OUTPUT [Inserted].[Id]
		Values (@nom, @quantite, @ProducteurId, @Description,@Price)
		RETURN 0
	END