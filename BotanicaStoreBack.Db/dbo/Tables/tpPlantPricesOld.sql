CREATE TABLE [dbo].[tpPlantPricesOld] (
    [PlantId] INT          IDENTITY (891, 1) NOT NULL,
    [Offered] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_tpPlantPricesOld] PRIMARY KEY CLUSTERED ([PlantId] ASC)
);

