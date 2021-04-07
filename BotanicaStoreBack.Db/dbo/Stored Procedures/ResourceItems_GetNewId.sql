create PROCEDURE [dbo].[ResourceItems_GetNewId]
	(
	@KeyString char(8)
	)
AS
INSERT INTO ResourceItems 
	(
	KeyString,
	Description
	) 
 
VALUES 
	(
	@KeyString,
	'New'
	)
	
SELECT @@IDENTITY