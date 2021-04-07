create PROCEDURE [dbo].[ResourceItems_GetByIncludeDeleted]
	(
	@IncludeDeleted bit
	)
AS
IF (@IncludeDeleted = 1)
SELECT
	*
FROM
	ResourceItems
ORDER BY
	FileName
ELSE
SELECT
	*
FROM
	ResourceItems
WHERE
	(IsDeleted = 0) OR (IsDeleted IS NULL)
ORDER BY
	FileName