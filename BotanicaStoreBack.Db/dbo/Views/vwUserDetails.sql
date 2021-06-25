
CREATE VIEW [dbo].[vwUserDetails]
AS
SELECT
u.UserId,
u.Email,
u.FullName,
u.IsAdmin,
u.CreatedDate,
u.LastLoginDate,
u.LoginCount,
isnull(w.CountAll, 0) AS CountAll,
isnull(w.CountPending, 0) AS CountPending,
isnull(w.CountClosed, 0) AS CountClosed

FROM
	Users u

	LEFT OUTER JOIN
	(
		SELECT
			UserId,
			sum(1) AS CountAll,
			sum(CASE WHEN EmailedDate is null THEN 1 ELSE 0 END) AS CountPending,
			sum(CASE WHEN IsClosed = 1 THEN 1 ELSE 0 END) AS CountClosed
		FROM
			[WishLists]
		GROUP BY
			UserId
	) w
	ON (u.UserId = w.UserId)