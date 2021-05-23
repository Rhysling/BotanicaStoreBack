






CREATE VIEW [dbo].[vwWishListFlat]
AS
SELECT
	w.UserId,
	w.CreatedDate,
	w.LastUpdateDate,
	w.EmailedDate,
	w.IsClosed,
	wi.WlId,
	wi.PlantId,
	p.Genus + ' ' + p.Species AS PlantName,
	wi.PotSizeId,
	ps.PotDescription,
	wi.Price,
	wi.Qty,
	pp.Price AS CurrentPrice,
	pp.IsAvailable AS IsCurrentlyAvailable

FROM
	(
	WishLists w

	INNER JOIN WishListItems wi
	ON (w.WlId = wi.WlId)

	INNER JOIN PotSizes ps
	ON (wi.PotSizeId = ps.Id)
	)

	LEFT OUTER JOIN PlantPrices pp
	ON ((wi.PlantId = pp.PlantId) AND (wi.PotSizeId = pp.PotSizeId))

	INNER JOIN Plants p
	ON (pp.PlantId = p.PlantId)