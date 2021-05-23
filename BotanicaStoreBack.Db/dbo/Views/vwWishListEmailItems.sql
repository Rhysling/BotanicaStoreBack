
CREATE VIEW [dbo].[vwWishListEmailItems]
AS
SELECT
	wi.WlId,
	wi.PlantId,
	p.Genus + ' ' + p.Species AS PlantName,
	wi.PotSizeId,
	ps.PotDescription,
	wi.Price,
	wi.Qty

FROM
	WishListItems wi

	INNER JOIN PotSizes ps
	ON (wi.PotSizeId = ps.Id)

	INNER JOIN Plants p
	ON (wi.PlantId = p.PlantId)