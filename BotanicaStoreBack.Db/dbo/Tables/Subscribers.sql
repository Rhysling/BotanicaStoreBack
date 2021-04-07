CREATE TABLE [dbo].[Subscribers] (
    [ItemId]       INT           IDENTITY (287, 1) NOT NULL,
    [FirstName]    VARCHAR (50)  NULL,
    [LastName]     VARCHAR (50)  NULL,
    [ExtraName]    VARCHAR (50)  NULL,
    [Email]        VARCHAR (50)  NULL,
    [Address1]     VARCHAR (100) NULL,
    [Address2]     VARCHAR (50)  NULL,
    [City]         VARCHAR (50)  NULL,
    [State]        VARCHAR (3)   NULL,
    [ZipCode]      VARCHAR (10)  NULL,
    [SendNotices]  BIT           NOT NULL,
    [MailCalendar] BIT           NOT NULL,
    [IsDeleted]    BIT           NOT NULL,
    [Notes]        VARCHAR (255) NULL,
    [AddedDate]    DATETIME      NULL,
    [LastUpdate]   DATETIME      NULL,
    CONSTRAINT [PK_SubscribersIn] PRIMARY KEY CLUSTERED ([ItemId] ASC)
);

