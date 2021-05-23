CREATE TABLE [dbo].[WishListItems] (
    [WlId]      INT            NOT NULL,
    [PlantId]   INT            NOT NULL,
    [PotSizeId] INT            NOT NULL,
    [Price]     DECIMAL (5, 2) NOT NULL,
    [Qty]       INT            NOT NULL,
    CONSTRAINT [PK_WishListItems_1] PRIMARY KEY CLUSTERED ([WlId] ASC, [PlantId] ASC, [PotSizeId] ASC),
    CONSTRAINT [FK_WishListItems_Plants] FOREIGN KEY ([PlantId]) REFERENCES [dbo].[Plants] ([PlantId]),
    CONSTRAINT [FK_WishListItems_PotSizes] FOREIGN KEY ([PotSizeId]) REFERENCES [dbo].[PotSizes] ([Id]),
    CONSTRAINT [FK_WishListItems_WishLists] FOREIGN KEY ([WlId]) REFERENCES [dbo].[WishLists] ([WlId])
);

