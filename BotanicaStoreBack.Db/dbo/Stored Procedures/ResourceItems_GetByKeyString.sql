CREATE PROCEDURE [dbo].[ResourceItems_GetByKeyString]
	(
	@KeyString char(8)
	)
AS
SELECT
	*
FROM
	ResourceItems
WHERE
	(CAST(KeyString AS binary(8)) = CAST(@KeyString AS binary(8)))