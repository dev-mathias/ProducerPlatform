CREATE PROCEDURE [dbo].[GetProducerById]
	@id int
AS
	BEGIN
		SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password] FROM [Producer]
		WHERE [Id]=@id
		RETURN 0
	END
