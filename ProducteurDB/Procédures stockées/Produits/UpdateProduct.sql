CREATE PROCEDURE [dbo].[UpdateProduct]
	@id int,
	@nom nvarchar(100),
	@quantite decimal,
	@description nvarchar(max),
	@Price decimal
AS
	BEGIN
		UPDATE [Product]
		SET [Name]=@nom,
			[Quantite]=@quantite,
			[Description]=@description,
			[Price]=@Price
		WHERE [Id]=@id
		RETURN 0
	END
