
CREATE VIEW [dbo].[vwShoppingListSummary]
AS
SELECT
	w.WlId,
	w.UserId,
	w.CreatedDate,
	w.LastUpdateDate,
	w.EmailedDate,
	w.IsClosed,
	u.FullName AS UserFullName,
	u.Email,
	sum(wi.Qty) AS TotalCount,
	sum(wi.Qty * wi.Price) AS TotalPretax

FROM
	WishLists w

	INNER JOIN WishListItems wi
	ON (w.WlId = wi.WlId)

	INNER JOIN Users u
	ON (w.UserId = u.UserId)

GROUP BY
	w.WlId,
	w.UserId,
	w.CreatedDate,
	w.LastUpdateDate,
	w.EmailedDate,
	w.IsClosed,
	u.FullName,
	u.Email