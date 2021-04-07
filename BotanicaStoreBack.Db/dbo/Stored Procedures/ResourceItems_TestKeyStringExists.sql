CREATE PROCEDURE [dbo].[ResourceItems_TestKeyStringExists]
	(
	@KeyString char(8)
	)
AS
SELECT
	Count(ItemId)
FROM
	ResourceItems
WHERE
	(KeyString = @KeyString)