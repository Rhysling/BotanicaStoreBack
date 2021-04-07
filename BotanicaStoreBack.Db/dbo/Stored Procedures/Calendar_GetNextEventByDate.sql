CREATE PROCEDURE [dbo].[Calendar_GetNextEventByDate]
	(
		@CurrentDate datetime
	)
AS

SELECT TOP 1
	*
FROM
	Calendar
WHERE
	(BeginDate >= @CurrentDate) OR (EndDate >= @CurrentDate)
ORDER BY
	BeginDate

RETURN