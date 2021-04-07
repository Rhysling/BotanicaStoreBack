CREATE TABLE [dbo].[Plants] (
    [PlantId]        INT            IDENTITY (891, 1) NOT NULL,
    [Genus]          VARCHAR (50)   NOT NULL,
    [Species]        VARCHAR (50)   NOT NULL,
    [Common]         VARCHAR (50)   NULL,
    [Description]    VARCHAR (1023) NULL,
    [WebDescription] VARCHAR (1023) NULL,
    [PlantSize]      VARCHAR (50)   NULL,
    [PlantType]      VARCHAR (50)   NULL,
    [PlantZone]      VARCHAR (50)   NULL,
    [HasSmallPic]    BIT            CONSTRAINT [DF_Plants_HasSmallPic] DEFAULT ((0)) NOT NULL,
    [BigPicIds]      VARCHAR (50)   CONSTRAINT [DF_Plants_BigPicIds] DEFAULT ('') NOT NULL,
    [IsListed]       BIT            CONSTRAINT [DF_Plants_IsAvailable] DEFAULT ((0)) NOT NULL,
    [IsFeatured]     BIT            CONSTRAINT [DF_Plants_IsFeatured] DEFAULT ((0)) NOT NULL,
    [LastUpdate]     DATETIME       CONSTRAINT [DF_Plants_LastUpdate] DEFAULT ('1/1/1900') NOT NULL,
    [Flag]           VARCHAR (2)    NULL,
    CONSTRAINT [PK_tblPlantMaster] PRIMARY KEY CLUSTERED ([PlantId] ASC)
);

