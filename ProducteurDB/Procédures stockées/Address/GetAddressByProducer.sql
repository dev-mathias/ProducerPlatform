CREATE PROCEDURE [dbo].[GetAddressByProducer]
	@id int
AS
	SELECT * from [Address]
	WHERE [Id]=(SELECT AddressId FROM [Producer] where Id=@id)
RETURN 0
