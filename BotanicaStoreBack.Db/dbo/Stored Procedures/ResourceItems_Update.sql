CREATE PROCEDURE [dbo].[ResourceItems_Update]
	(
	@ItemID int,
	@Description varchar(1023),
	@FileName varchar(100),
	@FileType varchar(20),
	@FileData image,
	@FileDataByteLength int,
	@FileSize varchar(20),
	@IconGroup int,
	@LastUpdate datetime
	)
AS
UPDATE    ResourceItems
SET
	Description = @Description,
	FileName = @FileName,
	FileType = @FileType,
	FileSize = @FileSize,
	IconGroup = @IconGroup,
	LastUpdate = @LastUpdate	
WHERE
	(ItemId = @ItemID)
IF (@FileDataByteLength > 0)
BEGIN
UPDATE    ResourceItems
	SET
		FileData = @FileData,
		FileDataByteLength = @FileDataByteLength
	WHERE
		(ItemId = @ItemID)
END