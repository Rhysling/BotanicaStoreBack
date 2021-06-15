



CREATE VIEW [dbo].[vwShoppingListItems]
AS
SELECT
	wi.WlId,
	wi.PlantId,
	p.Genus + ' ' + p.Species AS PlantName,
	wi.PotSizeId,
	ps.PotDescription,
	ps.SortOrder,
	wi.Qty,
	wi.Price,
	pp.Price AS CurrentPrice,
	pp.IsAvailable AS IsCurrentlyAvailable

FROM
	WishListItems wi

	INNER JOIN PotSizes ps
	ON (wi.PotSizeId = ps.Id)

	INNER JOIN Plants p
	ON (wi.PlantId = p.PlantId)

	LEFT OUTER JOIN PlantPrices pp
	ON ((wi.PlantId = pp.PlantId) AND (wi.PotSizeId = pp.PotSizeId))