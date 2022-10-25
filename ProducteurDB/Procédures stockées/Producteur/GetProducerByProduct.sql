CREATE PROCEDURE [dbo].[GetProducerByProduct]
	@id int
AS
	SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password] FROM [Producer] 
	WHERE [Id]=(SELECT [ProducteurID] FROM [Product] where [Id]=@id)
RETURN 0
