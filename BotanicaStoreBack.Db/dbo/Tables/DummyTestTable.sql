CREATE TABLE [dbo].[DummyTestTable] (
    [FirstKey]     INT             NOT NULL,
    [SecondKey]    VARCHAR (50)    NOT NULL,
    [LastThing]    DATE            NOT NULL,
    [Info]         NCHAR (10)      NULL,
    [MoreStuff]    NCHAR (10)      NULL,
    [ByteThing]    VARBINARY (50)  NOT NULL,
    [BigByteThing] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_DummyTestTable] PRIMARY KEY CLUSTERED ([FirstKey] ASC, [SecondKey] ASC)
);

