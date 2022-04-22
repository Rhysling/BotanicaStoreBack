




CREATE VIEW [dbo].[vwPlantsAvailable]
AS

SELECT
	p.PlantId,
	p.Genus + ' ' + p.Species AS PlantName,
	ps.Id AS PotSizeId,
	ps.PotDescription,
	ps.PotShorthand,
	ps.SortOrder,
	pp.Price

FROM
	Plants p

	INNER JOIN PlantPrices pp
	ON (p.PlantId = pp.PlantId)

	INNER JOIN PotSizes ps
	ON (pp.PotSizeId = ps.Id)

WHERE
	(pp.IsAvailable = 1) AND
	(p.IsListed = 1) AND
	(p.IsDeleted = 0);