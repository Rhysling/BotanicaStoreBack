CREATE PROCEDURE [dbo].[Plants_GetFeaturedPlant]

AS

SELECT TOP 1
	*
FROM
	Plants
WHERE
	(IsFeatured = 1)

RETURN