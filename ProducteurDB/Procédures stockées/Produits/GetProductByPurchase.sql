CREATE PROCEDURE [dbo].[GetProductByPurchase]
	@id int
AS
	SELECT * FROM [Product] 
	WHERE [Id]=(SELECT [ProductID] FROM [Purchase] where [Id]=@id)
RETURN 0
