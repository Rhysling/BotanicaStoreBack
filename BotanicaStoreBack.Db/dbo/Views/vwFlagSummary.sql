

CREATE VIEW [dbo].[vwFlagSummary]
AS

SELECT
	Flag,
	COUNT(PlantId) AS PlantCount,
	MAX(LastUpdate) AS LastUpdate

FROM
	Plants

WHERE
	(Flag is not null) AND (IsDeleted = 0)

GROUP BY
	Flag