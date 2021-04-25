




CREATE VIEW [dbo].[vwPlantPriceSummary]
AS

SELECT
	PlantId,
	Genus,
	Species,
	dbo.fnPricesAvailable_ByPlant(PlantId, 1) AS Available,
	dbo.fnPricesAvailable_ByPlant(PlantId, 0) AS NotAvailable

FROM
	Plants