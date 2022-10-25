CREATE PROCEDURE [dbo].[GetAddressByCustomer]
	@id int
AS
	SELECT * from [Address]
	WHERE [Id]=(SELECT AddressId FROM [Customer] where Id=@id)
RETURN 0
