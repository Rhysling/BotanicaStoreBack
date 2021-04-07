create PROCEDURE [dbo].[ResourceItems_GetFile]
	(
	@ItemId int
	)
AS
SELECT
	FileData,
	FileDataByteLength
FROM
	ResourceItems
WHERE
	(ItemId = @ItemId)