CREATE TABLE [dbo].[Links] (
    [LinkId]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (100)  NOT NULL,
    [Description] VARCHAR (2047) NOT NULL,
    [Url]         VARCHAR (1023) NOT NULL,
    [SortOrder]   INT            CONSTRAINT [DF_Links_SortOrder] DEFAULT ((100)) NOT NULL,
    [IsDeleted]   BIT            CONSTRAINT [DF_Links_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED ([LinkId] ASC)
);



