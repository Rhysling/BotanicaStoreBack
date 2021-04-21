CREATE TABLE [dbo].[PotSizes] (
    [Id]          INT          NOT NULL,
    [Description] VARCHAR (50) NOT NULL,
    [Shorthand]   VARCHAR (50) NOT NULL,
    [SortOrder]   INT          NOT NULL,
    CONSTRAINT [PK_PotSizes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

