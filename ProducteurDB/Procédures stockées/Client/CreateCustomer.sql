CREATE PROCEDURE [dbo].[CreateCustomer]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384),
	@Password NVARCHAR(50),
	@isAdmin BIT,
	@AddressId INT

AS	
	DECLARE @Presalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @Postsalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @PwdHased as BINARY(64)
	SET @PwdHased=[dbo].[Hash]([dbo].[Salt](@Presalt,@Password,@Postsalt))
	
	

	INSERT INTO [Customer]([Lastname], [Firstname], [Email], [Password], [Presalt], [Postsalt], [AddressId],[isAdmin])
	OUTPUT [Inserted].[Id]
	VALUES (@LastName,@FirstName,@Email,@PwdHased,@Presalt, @Postsalt, @AddressId, @isAdmin)
GO

