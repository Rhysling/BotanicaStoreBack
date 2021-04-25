CREATE TABLE [dbo].[PotSizes] (
    [Id]             INT          NOT NULL,
    [PotDescription] VARCHAR (50) NOT NULL,
    [PotShorthand]   VARCHAR (50) NOT NULL,
    [SortOrder]      INT          NOT NULL,
    CONSTRAINT [PK_PotSizes] PRIMARY KEY CLUSTERED ([Id] ASC)
);



