CREATE TABLE [dbo].[PlantStatusEnum] (
    [Id]          INT          NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Description] VARCHAR (50) NULL,
    CONSTRAINT [PK_PlantStatusEnum] PRIMARY KEY CLUSTERED ([Id] ASC)
);

