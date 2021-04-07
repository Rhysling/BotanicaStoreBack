CREATE PROCEDURE [dbo].[Plants_GetCountOfFlags]
	
AS

SELECT
	Count(PlantId) AS PlantCount
FROM
	Plants
WHERE
	(Flag IS NOT NULL)

RETURN