CREATE PROCEDURE [dbo].[Calendar_DeleteItem]
	(
		@ItemId int
	)
AS

DELETE
FROM Calendar
WHERE
	(ItemId = @ItemId)

RETURN