create PROCEDURE [dbo].[ResourceItems_SetDeleteStatus]
	(
	@ItemID int,
	@IsDeleted bit
	)
AS
IF (@IsDeleted = 1)
BEGIN
DELETE FROM ResourceItems
WHERE
	(ItemId = @ItemID)
END