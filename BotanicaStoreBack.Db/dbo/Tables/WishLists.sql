CREATE TABLE [dbo].[WishLists] (
    [WlId]           INT      IDENTITY (1, 1) NOT NULL,
    [UserId]         INT      NOT NULL,
    [CreatedDate]    DATETIME CONSTRAINT [DF_WishLists_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [LastUpdateDate] DATETIME CONSTRAINT [DF_WishLists_LastUpdateDate] DEFAULT (getdate()) NOT NULL,
    [EmailedDate]    DATETIME NULL,
    [IsClosed]       BIT      CONSTRAINT [DF_WishLists_IsClosed] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_WishLists] PRIMARY KEY CLUSTERED ([WlId] ASC),
    CONSTRAINT [FK_WishLists_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);



