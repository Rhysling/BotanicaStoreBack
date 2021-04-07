CREATE PROCEDURE [dbo].[Calendar_GetById]
	(
		@ItemId int
	)
AS

SELECT *
FROM Calendar
WHERE
	(ItemId = @ItemId)

RETURN