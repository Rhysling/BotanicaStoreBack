CREATE PROCEDURE [dbo].[Keys_UpdateItem]
	(
	@KeyName varchar(50),
	@KeyValue varchar(2047)
	)
	
AS

IF (SELECT Count(*) FROM Keys WHERE (KeyName = @KeyName)) = 0
BEGIN
INSERT INTO Keys
	(
	KeyName,
	KeyValue
	) 
 
VALUES 
	(
	@KeyName,
	@KeyValue
	)
END

ELSE
BEGIN
UPDATE
	Keys
SET
	KeyValue = @KeyValue
WHERE
	(KeyName = @KeyName)

END