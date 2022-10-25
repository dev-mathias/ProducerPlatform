CREATE PROCEDURE [dbo].[CreateAdress]
	@Rue NVARCHAR(50),
	@Numero NVARCHAR(7),
	@Ville NVARCHAR(50),
	@Codepostal NVARCHAR(10),
	@Pays NVARCHAR(50),
	@Long float,
	@Lat float
AS
	INSERT INTO[Address]([Rue],[Numero],[Codepostal],[Ville],[Pays],[Lon],[Lat])
	OUTPUT [inserted].Id
	Values (@Rue, @Numero, @Codepostal, @Ville,  @Pays, @Long, @Lat)
RETURN 0
