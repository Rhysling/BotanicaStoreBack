CREATE TABLE [dbo].[Calendar] (
    [ItemId]      INT           IDENTITY (1, 1) NOT NULL,
    [BeginDate]   DATE          NOT NULL,
    [EndDate]     DATE          NULL,
    [EventTime]   VARCHAR (50)  NULL,
    [Title]       VARCHAR (50)  NOT NULL,
    [Location]    VARCHAR (100) NULL,
    [Description] VARCHAR (500) NULL,
    [IsSpecial]   BIT           CONSTRAINT [DF_Calendar_IsSpecial] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Calendar] PRIMARY KEY CLUSTERED ([ItemId] ASC)
);



