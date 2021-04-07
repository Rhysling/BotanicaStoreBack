CREATE PROCEDURE [dbo].[Plants_GetAvailableCount]
	(
	@IsAvailable bit
	)
AS

SELECT
	Count(PlantId)
FROM
	Plants
WHERE
	(IsAvailable = @IsAvailable)

RETURN