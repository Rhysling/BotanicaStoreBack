CREATE TABLE [dbo].[PlantPrices] (
    [PlantId]     INT            NOT NULL,
    [PotSizeId]   INT            NOT NULL,
    [Price]       DECIMAL (5, 2) NOT NULL,
    [IsAvailable] BIT            CONSTRAINT [DF_PlantPrices_IsAvailable] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PlantPrices] PRIMARY KEY CLUSTERED ([PlantId] ASC, [PotSizeId] ASC),
    CONSTRAINT [FK_PlantPrices_Plants] FOREIGN KEY ([PlantId]) REFERENCES [dbo].[Plants] ([PlantId]),
    CONSTRAINT [FK_PlantPrices_PotSizes] FOREIGN KEY ([PotSizeId]) REFERENCES [dbo].[PotSizes] ([Id])
);

