CREATE PROCEDURE [dbo].[CreateProducer]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384),
	@Password NVARCHAR(50),
	@AddressId INT
AS	
	
	DECLARE @Presalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @Postsalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @PwdHased as BINARY(64)
	SET @PwdHased=[dbo].[Hash]([dbo].[Salt](@Presalt,@Password,@Postsalt))
	
	INSERT INTO [Producer]([Lastname], [Firstname], [Email], [Password], [Presalt], [Postsalt], [AddressId])
	OUTPUT [Inserted].[Id]
	VALUES (@LastName,@FirstName,@Email,@PwdHased,@Presalt, @Postsalt, @AddressId)
GO
