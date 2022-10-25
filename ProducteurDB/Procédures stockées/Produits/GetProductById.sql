CREATE PROCEDURE [dbo].[GetProductById]
	@id int
AS
	BEGIN
		SELECT * FROM [Product]
		WHERE [Id]=@id
		RETURN 0
	END
