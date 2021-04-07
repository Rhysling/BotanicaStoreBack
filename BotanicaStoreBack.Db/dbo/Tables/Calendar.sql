CREATE TABLE [dbo].[Calendar] (
    [ItemId]      INT           IDENTITY (1, 1) NOT NULL,
    [BeginDate]   DATETIME      NULL,
    [EndDate]     DATETIME      NULL,
    [EventTime]   VARCHAR (50)  NULL,
    [Title]       VARCHAR (50)  NULL,
    [Location]    VARCHAR (100) NULL,
    [Description] VARCHAR (500) NULL,
    [IsSpecial]   BIT           NULL,
    CONSTRAINT [PK_Calendar] PRIMARY KEY CLUSTERED ([ItemId] ASC)
);

