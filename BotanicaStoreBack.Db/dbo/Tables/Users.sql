CREATE TABLE [dbo].[Users] (
    [UserId]        INT           IDENTITY (1, 1) NOT NULL,
    [Email]         VARCHAR (50)  NOT NULL,
    [FullName]      VARCHAR (100) NULL,
    [IsAdmin]       BIT           CONSTRAINT [DF_Users_IsAdmin] DEFAULT ((0)) NOT NULL,
    [CreatedDate]   DATETIME      NOT NULL,
    [LastLoginDate] DATETIME      NOT NULL,
    [LoginCount]    INT           CONSTRAINT [DF_Users_LoginCount] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_Email]
    ON [dbo].[Users]([Email] ASC);

