CREATE PROCEDURE [dbo].[Plants_GetById]
	(
		@PlantId int
	)
AS

SELECT
	*
FROM
	Plants
WHERE
	(PlantId = @PlantId)

RETURN