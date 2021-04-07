CREATE TABLE [dbo].[ResourceIcons] (
    [FileType]  VARCHAR (10) NOT NULL,
    [IconGroup] INT          NOT NULL,
    CONSTRAINT [PK_ResourceIcons_1] PRIMARY KEY CLUSTERED ([FileType] ASC)
);

