CREATE PROCEDURE [dbo].[checkProducer]
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS	
	SELECT	[Id],
			[lastname],
			[firstname],
			[Email],
			'********' AS [Password],
			[AddressId]
	FROM [Producer]
	WHERE [Email] LIKE @email
		AND [Password] = [dbo].[Hash]([dbo].[Salt]([Presalt],@password,[Postsalt]))
GO