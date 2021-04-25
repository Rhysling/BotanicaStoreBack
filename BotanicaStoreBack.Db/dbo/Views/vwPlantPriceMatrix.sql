


CREATE VIEW [dbo].[vwPlantPriceMatrix]
AS

SELECT
	ps.Id AS PotSizeId,
	ps.PotDescription,
	ps.PotShorthand,
	ps.SortOrder,
	pp.PlantId,
	pp.Price,
	pp.IsAvailable

FROM
	PotSizes ps

	LEFT OUTER JOIN PlantPrices pp
	ON (ps.Id = pp.PotSizeId)