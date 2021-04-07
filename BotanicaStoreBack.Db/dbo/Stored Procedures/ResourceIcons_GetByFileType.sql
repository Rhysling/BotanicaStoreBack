create PROCEDURE [dbo].[ResourceIcons_GetByFileType]
	(
		@FileType varchar(10)
	)
AS
SELECT
	*
FROM
	ResourceIcons
WHERE
	(FileType = @FileType)
RETURN