CREATE PROCEDURE [dbo].[checkCustomer]
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS	
	SELECT	[Id],
			[lastName],
			[firstName],
			[Email],
			'********' AS [Password],
			[AddressId],
			[isAdmin]
	FROM [Customer]
	WHERE [Email] LIKE @email
		AND [Password] = [dbo].[Hash]([dbo].[Salt]([Presalt],@password,[Postsalt]))
GO