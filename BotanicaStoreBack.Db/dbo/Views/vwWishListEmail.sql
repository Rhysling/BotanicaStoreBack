







CREATE VIEW [dbo].[vwWishListEmail]
AS
SELECT
	w.WlId,
	w.UserId,
	w.CreatedDate,
	w.LastUpdateDate,
	w.EmailedDate,
	w.IsClosed,
	u.Email,
	u.FullName

FROM
	WishLists w

	INNER JOIN Users u
	ON (w.UserId = u.UserId)