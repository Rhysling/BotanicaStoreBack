CREATE TABLE [dbo].[Links] (
    [LinkId]      INT            IDENTITY (1, 1) NOT NULL,
    [LinkTitle]   VARCHAR (100)  NULL,
    [Description] VARCHAR (2047) NULL,
    [URL]         VARCHAR (1023) NULL,
    [SortOrder]   INT            NULL,
    [IsDeleted]   BIT            NULL,
    CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED ([LinkId] ASC)
);

