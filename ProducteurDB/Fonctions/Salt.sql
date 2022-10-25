CREATE FUNCTION [dbo].[Salt]
(
	@presalt UNIQUEIDENTIFIER,
	@password NVARCHAR(200),
	@postSalt UNIQUEIDENTIFIER
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @SaltedPwd as NVARCHAR(max)
	RETURN CONCAT(@presalt, @password, @postSalt)
END
