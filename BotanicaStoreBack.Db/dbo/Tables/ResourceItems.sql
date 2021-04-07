CREATE TABLE [dbo].[ResourceItems] (
    [ItemId]             INT            IDENTITY (1, 1) NOT NULL,
    [KeyString]          CHAR (8)       NULL,
    [Description]        VARCHAR (1023) NULL,
    [FileName]           VARCHAR (100)  NULL,
    [FileType]           VARCHAR (20)   NULL,
    [FileData]           IMAGE          NULL,
    [FileDataByteLength] INT            NULL,
    [FileSize]           VARCHAR (20)   NULL,
    [IconGroup]          INT            NULL,
    [LastUpdate]         DATETIME       NULL,
    [UpdatedBy]          INT            NULL,
    [IsDeleted]          BIT            NULL,
    CONSTRAINT [PK_ResourceItems] PRIMARY KEY CLUSTERED ([ItemId] ASC)
);

