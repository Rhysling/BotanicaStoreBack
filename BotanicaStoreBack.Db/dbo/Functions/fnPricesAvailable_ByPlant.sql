

CREATE FUNCTION [dbo].[fnPricesAvailable_ByPlant]
	(
		@PlantId as int,
		@IsAvailable as bit
	)
	RETURNS varchar(1023)
AS
BEGIN
	DECLARE @List varchar(1023);
	SET @List = '';

	SELECT
		@List = @List + ps.PotShorthand + '-$' + CAST(pp.Price AS varchar) + ',' 

	FROM
		PlantPrices pp

		INNER JOIN PotSizes ps
		ON (pp.PotSizeId = ps.Id)

	WHERE
		(pp.PlantId = @PlantId) AND
		(pp.IsAvailable = @IsAvailable)

	ORDER BY
		SortOrder;

	--trim off extra comma at end
	IF (@List <> '')
	SET @List = LEFT(@List, LEN(@List) - 1)
	
	RETURN @List
	
END