CREATE PROCEDURE [dbo].[GetPurchaseById]
	@id int
AS
	BEGIN
		SELECT * FROM [Purchase]
		WHERE [Id]=@id
		RETURN 0
	END
