CREATE PROCEDURE [dbo].[Plants_AddUpdateItem]
	(
	@PlantId int,
	@Genus varchar(50),
	@Species varchar(50),
	@Common varchar(50),
	@Description varchar(1023),
	@WebDescription varchar(1023),
	@PlantSize varchar(50),
	@PlantType varchar(50),
	@PlantZone varchar(50),
	@LastUpdate datetime,
	@Offered varchar(50),
	@IsAvailable bit,
	@IsSoldOut bit,
	@IsFeatured bit,
	@ShowDescription bit,
	@Flag varchar(2)
	)

AS

/* Clear IsFeatured if changed */
IF @IsFeatured = 1
BEGIN
UPDATE
	Plants
SET
	IsFeatured = 0
END


IF @PlantId > 0
BEGIN
UPDATE
	Plants
SET
	Genus = @Genus,
	Species = @Species,
	Common = @Common,
	Description = @Description,
	WebDescription = @WebDescription,
	PlantSize = @PlantSize,
	PlantType = @PlantType,
	PlantZone = @PlantZone,
	LastUpdate = @LastUpdate,
	Offered = @Offered,
	IsAvailable = @IsAvailable,
	IsSoldOut = @IsSoldOut,
	IsFeatured = @IsFeatured,
	ShowDescription = @ShowDescription,
	Flag = @Flag
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

END

ELSE
BEGIN

INSERT INTO Plants 
	(
	Genus,
	Species,
	Common,
	Description,
	WebDescription,
	PlantSize,
	PlantType,
	PlantZone,
	LastUpdate,
	Offered,
	IsAvailable,
	IsSoldOut,
	IsFeatured,
	ShowDescription,
	Flag
	) 
 
VALUES 
	(
	@Genus,
	@Species,
	@Common,
	@Description,
	@WebDescription,
	@PlantSize,
	@PlantType,
	@PlantZone,
	@LastUpdate,
	@Offered,
	@IsAvailable,
	@IsSoldOut,
	@IsFeatured,
	@ShowDescription,
	@Flag
	)

SELECT @@IDENTITY

END