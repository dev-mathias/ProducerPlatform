CREATE PROCEDURE [dbo].[DeleteProduct]
	@id int
AS	
	BEGIN
		DELETE FROM [Product] where [Id]=@id
		RETURN 0
	END