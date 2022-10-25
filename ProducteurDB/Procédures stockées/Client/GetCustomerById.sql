CREATE PROCEDURE [dbo].[GetCustomerById]
	@id int
AS
	BEGIN
		SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password], [isAdmin] FROM [Customer]
		WHERE [Id]=@id
		RETURN 0
	END
