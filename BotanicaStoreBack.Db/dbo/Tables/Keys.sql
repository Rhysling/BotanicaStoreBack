CREATE TABLE [dbo].[Keys] (
    [KeyName]  VARCHAR (50)   NOT NULL,
    [KeyValue] VARCHAR (2047) NULL,
    CONSTRAINT [PK_Keys] PRIMARY KEY CLUSTERED ([KeyName] ASC)
);

