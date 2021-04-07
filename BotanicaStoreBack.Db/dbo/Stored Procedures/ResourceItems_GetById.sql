create PROCEDURE [dbo].[ResourceItems_GetById]
	(
	@ItemId int
	)
AS
SELECT
	*
FROM
	ResourceItems
WHERE
	(ItemId = @ItemId)