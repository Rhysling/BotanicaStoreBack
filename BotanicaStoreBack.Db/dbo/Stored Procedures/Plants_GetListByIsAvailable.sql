CREATE PROCEDURE [dbo].[Plants_GetListByIsAvailable]
	(
	@IsAvailable bit
	)
AS

SELECT
	*
FROM
	Plants
WHERE
	(IsAvailable = @IsAvailable)
ORDER BY
	Genus, Species

RETURN