CREATE PROCEDURE [dbo].[GetProducters]
AS
	SELECT [Id],[LastName],[FirstName],[Email],'********' AS [Password],[AddressId]
	FROM [Producer]
RETURN 0
