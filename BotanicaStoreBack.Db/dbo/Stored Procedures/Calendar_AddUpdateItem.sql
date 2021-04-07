CREATE PROCEDURE [dbo].[Calendar_AddUpdateItem]
	(
	@ItemId int,
	@BeginDate datetime,
	@EndDate datetime,
	@EventTime varchar(50),
	@Title varchar(50),
	@Location varchar(100),
	@Description varchar(500),
	@IsSpecial bit
	)
	
AS

IF @ItemId > 0
BEGIN
UPDATE
	Calendar
SET
	BeginDate = @BeginDate,
	EndDate = @EndDate,
	EventTime = @EventTime,
	Title = @Title,
	Location = @Location,
	Description = @Description,
	IsSpecial = @IsSpecial
WHERE
	(ItemId = @ItemId)

	IF @@ROWCOUNT > 0
	BEGIN
	SELECT @ItemId
	END
	ELSE
	BEGIN
	SELECT 0
	END

END

ELSE
BEGIN

INSERT INTO Calendar 
	(
	BeginDate,
	EndDate,
	EventTime,
	Title,
	Location,
	Description,
	IsSpecial
	) 
 
VALUES 
	(
	@BeginDate,
	@EndDate,
	@EventTime,
	@Title,
	@Location,
	@Description,
	@IsSpecial
	)

SELECT @@IDENTITY

END