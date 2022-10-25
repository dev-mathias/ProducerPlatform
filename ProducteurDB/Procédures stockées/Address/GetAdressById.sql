CREATE PROCEDURE [dbo].[GetAdressById]
	@id int
AS
	SELECT * FROM [Address] WHERE [Id]=@id
RETURN 0
