CREATE PROCEDURE [dbo].[Calendar_GetListAfterDate]
	(
		@CurrentDate datetime
	)
AS

SELECT
	*
FROM
	Calendar
WHERE
	(BeginDate >= @CurrentDate) OR (EndDate >= @CurrentDate)
ORDER BY
	BeginDate

RETURN