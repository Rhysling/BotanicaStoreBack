CREATE PROCEDURE [dbo].[Keys_GetByKeyName]
	(
		@KeyName varchar(50)
	)
AS

SELECT
	KeyValue
FROM
	Keys
WHERE
	(KeyName = @KeyName)

RETURN