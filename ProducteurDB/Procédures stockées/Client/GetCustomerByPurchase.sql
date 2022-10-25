CREATE PROCEDURE [dbo].[GetCustomerByPurchase]
	@id int
AS
	SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password], [isAdmin] FROM [Customer] 
	WHERE [Id]=(SELECT [CustomerID] FROM [Purchase] where [Id]=@id)
RETURN 0
