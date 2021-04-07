CREATE PROCEDURE [dbo].[Plants_UpdateOffered]
	(
	@PlantId int,
	@LastUpdate datetime,
	@Offered varchar(50),
	@IsAvailable bit,
	@IsSoldOut bit,
	@ShowDescription bit
	)

AS

UPDATE
	Plants
SET
	LastUpdate = @LastUpdate,
	Offered = @Offered,
	IsAvailable = @IsAvailable,
	IsSoldOut = @IsSoldOut,
	ShowDescription = @ShowDescription
WHERE
	(PlantId = @PlantId)

IF @@ROWCOUNT > 0
BEGIN
	SELECT @PlantId
END
ELSE
BEGIN
	SELECT 0
END